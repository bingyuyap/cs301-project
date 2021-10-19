using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace CS301_Spend_Transactions.Migrations
{
    public partial class IntitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "merchants",
                columns: table => new
                {
                    name = table.Column<string>(nullable: false),
                    mcc = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("merchants_pkey", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "rewards",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(nullable: true),
                    unit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("rewards_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    phone_no = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cards",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    card_pan = table.Column<string>(nullable: true),
                    card_type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cards_pkey", x => x.id);
                    table.ForeignKey(
                        name: "card_user_fkey",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rules",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    card_type = table.Column<string>(nullable: true),
                    CardId = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    RewardId = table.Column<int>(nullable: true),
                    MerchantName = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    start_date = table.Column<DateTime>(nullable: true),
                    end_date = table.Column<DateTime>(nullable: true),
                    min_spend = table.Column<decimal>(nullable: true),
                    max_spend = table.Column<decimal>(nullable: true),
                    foreign_spend = table.Column<bool>(nullable: true),
                    mcc = table.Column<int>(nullable: true),
                    multiplier = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("rules_pkey", x => x.id);
                    table.ForeignKey(
                        name: "campaign_merchant_fkey",
                        column: x => x.MerchantName,
                        principalTable: "merchants",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "reward_campaign_fkey",
                        column: x => x.RewardId,
                        principalTable: "rewards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rules_rewards_RewardId",
                        column: x => x.RewardId,
                        principalTable: "rewards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "campaign_card_fkey",
                        column: x => x.CardId,
                        principalTable: "cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    CardId = table.Column<string>(nullable: true),
                    MerchantName = table.Column<string>(nullable: true),
                    transaction_date = table.Column<DateTime>(nullable: false),
                    currency = table.Column<string>(nullable: true),
                    amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("transactions_pkey", x => x.id);
                    table.ForeignKey(
                        name: "transaction_card_fkey",
                        column: x => x.CardId,
                        principalTable: "cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "transaction_merchant_fkey",
                        column: x => x.MerchantName,
                        principalTable: "merchants",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "points",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RewardId = table.Column<int>(nullable: false),
                    TransactionId = table.Column<string>(nullable: true),
                    amount = table.Column<decimal>(nullable: false),
                    processed_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("points_pkey", x => x.id);
                    table.ForeignKey(
                        name: "reward_point_fkey",
                        column: x => x.RewardId,
                        principalTable: "rewards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "point_transaction_fkey",
                        column: x => x.TransactionId,
                        principalTable: "transactions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cards_UserId",
                table: "cards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_points_RewardId",
                table: "points",
                column: "RewardId");

            migrationBuilder.CreateIndex(
                name: "IX_points_TransactionId",
                table: "points",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_rules_MerchantName",
                table: "rules",
                column: "MerchantName");

            migrationBuilder.CreateIndex(
                name: "IX_rules_RewardId",
                table: "rules",
                column: "RewardId");

            migrationBuilder.CreateIndex(
                name: "IX_rules_RewardId1",
                table: "rules",
                column: "RewardId");

            migrationBuilder.CreateIndex(
                name: "IX_rules_CardId",
                table: "rules",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_CardId",
                table: "transactions",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_MerchantName",
                table: "transactions",
                column: "MerchantName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "points");

            migrationBuilder.DropTable(
                name: "rules");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "rewards");

            migrationBuilder.DropTable(
                name: "cards");

            migrationBuilder.DropTable(
                name: "merchants");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
