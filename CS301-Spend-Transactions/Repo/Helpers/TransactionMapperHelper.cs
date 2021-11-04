using System;
using System.Diagnostics;
using CS301_Spend_Transactions.Domain.DTO;
using CS301_Spend_Transactions.Models;
using CS301_Spend_Transactions.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CS301_Spend_Transactions.Repo.Helpers
{
    public static class TransactionMapperHelper
    {
        public static TransactionDTO ToTransactionDTO(String body)
        {
            return JsonConvert.DeserializeObject<TransactionDTO>(body);
        }

        public static Transaction ToTransaction(String body)
        {
            var transactionDTO = ToTransactionDTO(body);

            return ToTransaction(transactionDTO);
        }

        public static Transaction ToTransaction(TransactionDTO transactionDTO)
        {
            return new Transaction()
            {
                Id = transactionDTO.Id,
                TransactionDate = transactionDTO.TransactionDate,
                Currency = transactionDTO.Currency,
                Amount = transactionDTO.Amount,
                CardId = transactionDTO.CardId,
                MerchantName = transactionDTO.Merchant
            };
        }
    }
}