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
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}