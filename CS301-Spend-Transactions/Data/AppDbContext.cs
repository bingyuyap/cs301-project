using System.Collections.Generic;
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
                    .HasForeignKey(c => c.User)
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
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.CardPan).HasColumnName("card_pan");
                entity.Property(e => e.CardType).HasColumnName("card_type");

                // This means card has many rules
                entity.HasMany(c => c.Rules)
                    // And a rule belongs to a card
                    .WithOne(r => r.Card)
                    // Define the foreign key for this relationship
                    .HasForeignKey(r => r.Card)
                    // Foreign Key Constraint name 
                    .HasConstraintName("rule_card_fkey");
                
                // This means card has many transactions
                entity.HasMany(c => c.Transactions)
                    // And a transaction belongs to a card
                    .WithOne(t => t.Card)
                    // Define the foreign key for this relationship
                    .HasForeignKey(t => t.Card)
                    // Foreign Key Constraint name 
                    .HasConstraintName("transaction_card_fkey");
            });

            modelBuilder.Entity<Exclusion>(entity =>
            {
                // Defining the primary key and primary key constraint name
                entity.HasKey(e => e.Id)
                    .HasName("exclusion_pkey");

                // Mapping the entity to table
                entity.ToTable("exclusions");

                // Stating what properties map to what column name
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CardType).HasColumnName("card_type");
                entity.Property(e => e.Card).HasColumnName("card_id");
                entity.Property(e => e.MCC).HasColumnName("mcc");

                // This means card has many rules
                entity.HasOne(e => e.Card)
                    // And a rule belongs to a card
                    // TODO: Check if this is actually possible
                    .WithMany(r => (ICollection<Exclusion>)r.Rules)
                    // Define the foreign key for this relationship
                    .HasForeignKey(r => r.Card)
                    // Foreign Key Constraint name 
                    .HasConstraintName("rule_card_fkey");
            });
            
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}