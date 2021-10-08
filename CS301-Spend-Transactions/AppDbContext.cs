using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;
using CS301_Spend_Transactions.Models;


namespace CS301_Spend_Transactions
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Points> Points { get; set; }
        public DbSet<Reward> Rewards { get; set; }
    }
}