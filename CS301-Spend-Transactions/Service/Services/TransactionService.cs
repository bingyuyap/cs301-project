using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using CS301_Spend_Transactions.Domain.DTO;
using CS301_Spend_Transactions.Domain.Exceptions;
using CS301_Spend_Transactions.Models;
using CS301_Spend_Transactions.Repo.Helpers;
using CS301_Spend_Transactions.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CS301_Spend_Transactions.Services
{
    /**
     * Service that handles the insertion and relevant processing of transaction records
     */
    public class TransactionService : ITransactionService
    {
        private readonly ILogger<TransactionService> _logger;
        // Manages the lifetime of the services we going to inject
        private readonly IServiceScopeFactory _scopeFactory;

        public TransactionService(IServiceScopeFactory scopeFactory,
            ILogger<TransactionService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }
        
        /**
         * Adds a transaction into the database, handling all the necessary checks and points earned
         */
        public Transaction AddTransaction(TransactionDTO transactionDto)
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var transaction = TransactionMapperHelper.ToTransaction(transactionDto);
            
            // 1-Validate transaction
            if (transaction.Amount < 0)
            {
                _logger.LogCritical("Amount is negative");
                throw new InvalidTransactionException("Transaction cannot have a negative amount");
            }
            
            var card = dbContext.Cards.Find(transaction.CardId);

            if (card is null)
            {
                _logger.LogCritical("Card not found");
                throw new InvalidTransactionException("Invalid card ID in transaction record");
            }
            
            // 2-Find any exclusions 
            var exclusions = dbContext.Exclusions.Where(exclusion 
                => exclusion.MCC == transactionDto.MCC);

            if (exclusions.Any())
            {
                dbContext.Transactions.Add(transaction);
                dbContext.SaveChanges();
                return transaction;
            }
            
            // 3-Check for all rules that apply, and create points
            var foreignSpend = (!transactionDto.Currency.Equals("SGD"));
            var rules = dbContext.Rules.Where(rule =>
                rule.CardType == transactionDto.Card_Type
                    && rule.MinSpend < transactionDto.Amount
                    && rule.MaxSpend > transactionDto.Amount
                    && rule.ForeignSpend == foreignSpend    
            );

            foreach (var rule in rules)
            {
                var points = new Points
                {
                    Amount = rule.GetReward(transaction.Amount), // TODO: Reward conversion based on currency?
                    ProcessedDate = DateTime.Now,
                    TransactionId = transaction.Id,
                    PointsTypeId = rule.PointsTypeId
                };

                dbContext.Points.Add(points);
            }
            
            // 4-Save changes to db
            dbContext.Transactions.Add(transaction);
            dbContext.SaveChanges();
            return transaction;
        }

        public Transaction GetTransactionById(string id)
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Using LINQ expressions here
            return dbContext.Transactions.First(transaction => transaction.Id == id);
        }
    }
}