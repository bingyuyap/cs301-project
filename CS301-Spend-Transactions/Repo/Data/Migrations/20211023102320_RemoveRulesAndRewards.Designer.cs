﻿// <auto-generated />
using System;
using CS301_Spend_Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CS301_Spend_Transactions.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211023102320_RemoveRulesAndRewards")]
    partial class RemoveRulesAndRewards
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CS301_Spend_Transactions.Models.Card", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("CardPan")
                        .HasColumnName("card_pan")
                        .HasColumnType("text");

                    b.Property<string>("CardType")
                        .HasColumnName("card_type")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(767)");

                    b.HasKey("Id")
                        .HasName("cards_pkey");

                    b.HasIndex("UserId");

                    b.ToTable("cards");
                });

            modelBuilder.Entity("CS301_Spend_Transactions.Models.Groups", b =>
                {
                    b.Property<int>("MinMCC")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("min_mcc")
                        .HasColumnType("int");

                    b.Property<int>("MaxMCC")
                        .HasColumnName("max_mcc")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.HasKey("MinMCC")
                        .HasName("groups_pkey");

                    b.ToTable("groups");
                });

            modelBuilder.Entity("CS301_Spend_Transactions.Models.Merchant", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("MCC")
                        .HasColumnName("mcc")
                        .HasColumnType("int");

                    b.HasKey("Name")
                        .HasName("merchants_pkey");

                    b.ToTable("merchants");
                });

            modelBuilder.Entity("CS301_Spend_Transactions.Models.Points", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnName("amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("ProcessedDate")
                        .HasColumnName("processed_date")
                        .HasColumnType("datetime");

                    b.Property<int>("RewardId")
                        .HasColumnType("int");

                    b.Property<string>("TransactionId")
                        .HasColumnType("varchar(767)");

                    b.HasKey("Id")
                        .HasName("points_pkey");

                    b.HasIndex("RewardId");

                    b.HasIndex("TransactionId");

                    b.ToTable("points");
                });

            modelBuilder.Entity("CS301_Spend_Transactions.Models.Reward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<string>("Unit")
                        .HasColumnName("unit")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("rewards_pkey");

                    b.ToTable("rewards");
                });

            modelBuilder.Entity("CS301_Spend_Transactions.Models.Rule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("CardId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("CardType")
                        .HasColumnName("card_type")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("RewardId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("rules_pkey");

                    b.HasIndex("CardId");

                    b.HasIndex("RewardId");

                    b.ToTable("rules");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Rule");
                });

            modelBuilder.Entity("CS301_Spend_Transactions.Models.Transaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("varchar(767)");

                    b.Property<decimal>("Amount")
                        .HasColumnName("amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("CardId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Currency")
                        .HasColumnName("currency")
                        .HasColumnType("text");

                    b.Property<string>("MerchantName")
                        .HasColumnType("varchar(767)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnName("transaction_date")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("transactions_pkey");

                    b.HasIndex("CardId");

                    b.HasIndex("MerchantName");

                    b.ToTable("transactions");
                });

            modelBuilder.Entity("CS301_Spend_Transactions.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("varchar(767)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNo")
                        .HasColumnName("phone_no")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("users_pkey");

                    b.ToTable("users");
                });

            modelBuilder.Entity("CS301_Spend_Transactions.Models.Campaign", b =>
                {
                    b.HasBaseType("CS301_Spend_Transactions.Models.Rule");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnName("end_date")
                        .HasColumnType("datetime");

                    b.Property<bool>("ForeignSpend")
                        .HasColumnName("foreign_spend")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("MaxSpend")
                        .HasColumnName("max_spend")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("MerchantName")
                        .HasColumnType("varchar(767)");

                    b.Property<decimal>("MinSpend")
                        .HasColumnName("min_spend")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnName("start_date")
                        .HasColumnType("datetime");

                    b.HasIndex("MerchantName");

                    b.HasDiscriminator().HasValue("Campaign");
                });

            modelBuilder.Entity("CS301_Spend_Transactions.Models.Exclusion", b =>
                {
                    b.HasBaseType("CS301_Spend_Transactions.Models.Rule");

                    b.Property<int>("MCC")
                        .HasColumnName("mcc")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Exclusion");
                });

            modelBuilder.Entity("CS301_Spend_Transactions.Models.Program", b =>
                {
                    b.HasBaseType("CS301_Spend_Transactions.Models.Rule");

                    b.Property<bool>("ForeignSpend")
                        .HasColumnName("foreign_spend")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("MaxSpend")
                        .HasColumnName("max_spend")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("MinSpend")
                        .HasColumnName("min_spend")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<float>("Multiplier")
                        .HasColumnName("multiplier")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("Program");
                });

            modelBuilder.Entity("CS301_Spend_Transactions.Models.Card", b =>
                {
                    b.HasOne("CS301_Spend_Transactions.Models.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId")
                        .HasConstraintName("card_user_fkey");
                });

            modelBuilder.Entity("CS301_Spend_Transactions.Models.Points", b =>
                {
                    b.HasOne("CS301_Spend_Transactions.Models.Reward", "Reward")
                        .WithMany("CreditedPoints")
                        .HasForeignKey("RewardId")
                        .HasConstraintName("reward_point_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CS301_Spend_Transactions.Models.Transaction", "Transaction")
                        .WithMany("AccumulatedPoints")
                        .HasForeignKey("TransactionId")
                        .HasConstraintName("point_transaction_fkey");
                });

            modelBuilder.Entity("CS301_Spend_Transactions.Models.Rule", b =>
                {
                    b.HasOne("CS301_Spend_Transactions.Models.Card", null)
                        .WithMany("Rules")
                        .HasForeignKey("CardId");

                    b.HasOne("CS301_Spend_Transactions.Models.Reward", null)
                        .WithMany("Rules")
                        .HasForeignKey("RewardId");
                });

            modelBuilder.Entity("CS301_Spend_Transactions.Models.Transaction", b =>
                {
                    b.HasOne("CS301_Spend_Transactions.Models.Card", "Card")
                        .WithMany("Transactions")
                        .HasForeignKey("CardId")
                        .HasConstraintName("transaction_card_fkey");

                    b.HasOne("CS301_Spend_Transactions.Models.Merchant", "Merchant")
                        .WithMany("Transactions")
                        .HasForeignKey("MerchantName")
                        .HasConstraintName("transaction_merchant_fkey");
                });

            modelBuilder.Entity("CS301_Spend_Transactions.Models.Campaign", b =>
                {
                    b.HasOne("CS301_Spend_Transactions.Models.Merchant", "Merchant")
                        .WithMany("Campaigns")
                        .HasForeignKey("MerchantName")
                        .HasConstraintName("campaign_merchant_fkey");
                });
#pragma warning restore 612, 618
        }
    }
}
