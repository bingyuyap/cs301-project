using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;
using CS301_Spend_Transactions.Models;


namespace CS301_Spend_Transactions
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Points> Points { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<Group> Group { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                // Defining the primary key and primary key constraint name
                entity.HasKey(e => e.Id)
                    .HasName("users_pkey");

                // Mapping the entity to table
                entity.ToTable("users");

                // Stating what properties map to what column name
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.FirstName).HasColumnName("first_name");
                entity.Property(e => e.LastName).HasColumnName("last_name");
                entity.Property(e => e.PhoneNo).HasColumnName("phone_no");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                
                // This means user has many cards
                entity.HasMany(u => u.Cards)
                    // And a card belongs to one user
                    .WithOne(c => c.User)
                    // Define the foreign key for this relationship
                    .HasForeignKey(c => c.UserId)
                    // Foreign Key Constraint name 
                    .HasConstraintName("card_user_fkey");
            });
            
            modelBuilder.Entity<Card>(entity =>
            {
                // Defining the primary key and primary key constraint name
                entity.HasKey(c => c.Id)
                    .HasName("cards_pkey");

                // Mapping the entity to table
                entity.ToTable("cards");

                // Stating what properties map to what column name
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CardPan).HasColumnName("card_pan");
                entity.Property(e => e.CardType).HasColumnName("card_type");

                // This means card belongs to a user
                entity.HasOne(c => c.User)
                    // And a rule belongs to a car
                    .WithMany(u => u.Cards)
                    // Define the foreign key for this relationship
                    .HasForeignKey(c => c.UserId)
                    // Foreign Key Constraint name 
                    .HasConstraintName("card_user_fkey");
                
                // This means card has many rules
                entity.HasMany(c => (ICollection<Exclusion>) c.Rules)
                    // And a rule belongs to a card
                    .WithOne(r => r.Card)
                    // Define the foreign key for this relationship
                    .HasForeignKey(r => r.CardId)
                    // Foreign Key Constraint name 
                    .HasConstraintName("rule_card_fkey");
                
                // This means card has many rules
                entity.HasMany(c => (ICollection<Campaign>) c.Rules)
                    // And a rule belongs to a card
                    .WithOne(r => r.Card)
                    // Define the foreign key for this relationship
                    .HasForeignKey(r => r.CardId)
                    // Foreign Key Constraint name 
                    .HasConstraintName("rule_card_fkey");
                
                // // This means card has many rules
                entity.HasMany(c => (ICollection<Models.Program>) c.Rules)
                    // And a rule belongs to a card
                    .WithOne(r => r.Card)
                    // Define the foreign key for this relationship
                    .HasForeignKey(r => r.CardId)
                    // Foreign Key Constraint name 
                    .HasConstraintName("rule_card_fkey");
                
                // This means card has many transactions
                entity.HasMany(c => c.Transactions)
                    // And a transaction belongs to a card
                    .WithOne(t => t.Card)
                    // Define the foreign key for this relationship
                    .HasForeignKey(t => t.CardId)
                    // Foreign Key Constraint name 
                    .HasConstraintName("transaction_card_fkey");
            });

            modelBuilder.Entity<Rule>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("rules_pkey");
                
                entity.ToTable("rules");
                
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CardType).HasColumnName("card_type");
                
                // This means card has many rules
                entity.HasOne(r => r.Card)
                    // And a rule belongs to a card
                    .WithMany(c => c.Rules)
                    // Define the foreign key for this relationship
                    .HasForeignKey(r => r.CardId)
                    // Foreign Key Constraint name 
                    .HasConstraintName("rule_card_fkey");
            });

            modelBuilder.Entity<Exclusion>(entity =>
            {
                entity.Property(e => e.MCC).HasColumnName("mcc");
            
                // This means card has many rules
                entity.HasOne(e => e.Card)
                    // And a rule belongs to a card
                    // TODO: Check if this is actually possible
                    .WithMany(r => (ICollection<Exclusion>) r.Rules)
                    // Define the foreign key for this relationship
                    .HasForeignKey(r => r.CardId)
                    // Foreign Key Constraint name 
                    .HasConstraintName("exclusion_card_fkey");
            });
            
            // Program itself is a reserve key so we need to explicitly define the namespace for this entity
            modelBuilder.Entity<Models.Program>(entity =>
            {
                entity.Property(e => e.Multiplier).HasColumnName("multiplier");
                entity.Property(e => e.MinSpend).HasColumnName("min_spend");
                entity.Property(e => e.MaxSpend).HasColumnName("max_spend");
                entity.Property(e => e.ForeignSpend).HasColumnName("foreign_spend");
                
                // TODO: Ask Rewards relationship
                
                // This means card has many rules
                entity.HasOne(e => e.Card)
                    // And a rule belongs to a card
                    // TODO: Check if this is actually possible
                    .WithMany(r => (ICollection<Models.Program>) r.Rules)
                    // Define the foreign key for this relationship
                    .HasForeignKey(r => r.CardId)
                    // Foreign Key Constraint name 
                    .HasConstraintName("program_card_fkey");
                //
                entity.HasOne(e => e.Reward)
                    // And a rule belongs to a card
                    // TODO: Check if this is actually possible
                    .WithMany(r => (ICollection<Models.Program>) r.Rules)
                    // Define the foreign key for this relationship
                    .HasForeignKey(e => e.RewardId)
                    // Foreign Key Constraint name 
                    .HasConstraintName("program_reward_fkey");
            });
            //
            modelBuilder.Entity<Campaign>(entity =>
            {
                // Stating what properties map to what column name
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.StartDate).HasColumnName("start_date");
                entity.Property(e => e.EndDate).HasColumnName("end_date");
                entity.Property(e => e.MinSpend).HasColumnName("min_spend");
                entity.Property(e => e.MaxSpend).HasColumnName("max_spend");
                entity.Property(e => e.ForeignSpend).HasColumnName("foreign_spend");
                
                // TODO: Ask Rewards relationship
                
                // This means card has many rules
                entity.HasOne(e => e.Card)
                    // And a rule belongs to a card
                    // TODO: Check if this is actually possible
                    .WithMany(r => (ICollection<Campaign>) r.Rules)
                    // Define the foreign key for this relationship
                    .HasForeignKey(r => r.CardId)
                    // Foreign Key Constraint name 
                    .HasConstraintName("campaign_card_fkey");
                
                // This means campaign belongs to one merchant
                entity.HasOne(c => c.Merchant)
                    // And a merchant has many campaigns
                    // TODO: Check if this is actually possible
                    .WithMany(r => r.Campaigns)
                    // Define the foreign key for this relationship
                    .HasForeignKey(r => r.MerchantName)
                    // Foreign Key Constraint name 
                .HasConstraintName("campaign_merchant_fkey");
                //
                entity.HasOne(e => e.Reward)
                    // And a rule belongs to a card
                    // TODO: Check if this is actually possible
                    .WithMany(r => (ICollection<Campaign>) r.Rules)
                    // Define the foreign key for this relationship
                    .HasForeignKey(e => e.RewardId)
                    // Foreign Key Constraint name 
                    .HasConstraintName("campaign_reward_fkey");
            });
            
            modelBuilder.Entity<Models.Program>()
                .Property(b => b.RewardId)
                .HasColumnName("RewardId");

            modelBuilder.Entity<Campaign>()
                .Property(b => b.RewardId)
                .HasColumnName("RewardId");
            
            //
            modelBuilder.Entity<Merchant>(entity =>
            {
                // Defining the primary key and primary key constraint name
                entity.HasKey(e => e.Name)
                    .HasName("merchants_pkey");

                // Mapping the entity to table
                entity.ToTable("merchants");

                // Stating what properties map to what column name
                entity.Property(e => e.MCC).HasColumnName("mcc");
                entity.Property(e => e.Name).HasColumnName("name");

                // And a merchant has many campaigns
                entity.HasMany(e => e.Campaigns)
                    // This means campaign belongs to one merchant
                    .WithOne(c => c.Merchant)
                    // Define the foreign key for this relationship
                    .HasForeignKey(c => c.MerchantName)
                    // Foreign Key Constraint name 
                    .HasConstraintName("campaign_merchant_fkey");
            });
            
            modelBuilder.Entity<Points>(entity =>
            {
                // Defining the primary key and primary key constraint name
                entity.HasKey(e => e.Id)
                    .HasName("points_pkey");

                // Mapping the entity to table
                entity.ToTable("points");

                // Stating what properties map to what column name
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.ProcessedDate).HasColumnName("processed_date");

                // A point belongs to a transaction
                entity.HasOne(p => p.Transaction)
                    // This means campaign belongs to one merchant
                    .WithMany(t => t.AccumulatedPoints)
                    // Define the foreign key for this relationship
                    .HasForeignKey(p => p.TransactionId)
                    // Foreign Key Constraint name 
                    .HasConstraintName("point_transaction_fkey");
                
                // A point belongs to a particular reward
                entity.HasOne(p => p.Reward)
                    // Reward could have many points
                    .WithMany(r => r.CreditedPoints)
                    // Define the foreign key for this relationship
                    .HasForeignKey(p => p.RewardId)
                    // Foreign Key Constraint name 
                    .HasConstraintName("point_reward_fkey");
            });
            
            modelBuilder.Entity<Reward>(entity =>
            {
                // Defining the primary key and primary key constraint name
                entity.HasKey(c => c.Id)
                    .HasName("rewards_pkey");

                // Mapping the entity to table
                entity.ToTable("rewards");

                // Stating what properties map to what column name
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Unit).HasColumnName("unit");

                // This means reward has many points
                entity.HasMany(r => r.CreditedPoints)
                    // And a point belongs to a reward
                    .WithOne(p => p.Reward)
                    // Define the foreign key for this relationship
                    .HasForeignKey(p => p.RewardId)
                    // Foreign Key Constraint name 
                    .HasConstraintName("reward_point_fkey");
                
                entity.HasMany(r => (ICollection<Models.Program>) r.Rules)
                    // And a point belongs to a reward
                    .WithOne(p => p.Reward)
                    .HasForeignKey(p => p.RewardId)
                    .HasConstraintName("reward_program_fkey");


                    entity.HasMany(r => (ICollection<Campaign>) r.Rules)
                    // And a point belongs to a reward
                    .WithOne(p => p.Reward)
                    // Define the foreign key for this relationship
                    .HasForeignKey(p => p.RewardId)
                    // Foreign Key Constraint name 
                    .HasConstraintName("reward_campaign_fkey");
            });
            
            modelBuilder.Entity<Transaction>(entity =>
            {
                // Defining the primary key and primary key constraint name
                entity.HasKey(c => c.Id)
                    .HasName("transactions_pkey");

                // Mapping the entity to table
                entity.ToTable("transactions");

                // Stating what properties map to what column name
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.TransactionDate).HasColumnName("transaction_date");
                entity.Property(e => e.Currency).HasColumnName("currency");
                entity.Property(e => e.Amount).HasColumnName("amount");
                
                
                // This means transaction belongs to one card
                entity.HasOne(t => t.Card)
                    // And a card has many transactions
                    .WithMany(c => c.Transactions)
                    // Define the foreign key for this relationship
                    .HasForeignKey(t => t.CardId)
                    // Foreign Key Constraint name 
                    .HasConstraintName("transaction_card_fkey");
                
                // TODO: verify this relationship
                // This means transaction belongs to one card
                entity.HasOne(t => t.Merchant)
                    // And a card has many transactions
                    .WithMany(m => m.Transactions)
                    // Define the foreign key for this relationship
                    .HasForeignKey(t => t.MerchantName)
                    // Foreign Key Constraint name 
                    .HasConstraintName("transaction_merchant_fkey");
            });

            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}