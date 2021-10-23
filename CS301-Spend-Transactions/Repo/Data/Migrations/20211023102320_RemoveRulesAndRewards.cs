using Microsoft.EntityFrameworkCore.Migrations;

namespace CS301_Spend_Transactions.Migrations
{
    public partial class RemoveRulesAndRewards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "reward_campaign_fkey",
                table: "rules");

            migrationBuilder.DropForeignKey(
                name: "FK_rules_rewards_RewardId",
                table: "rules");

            migrationBuilder.DropForeignKey(
                name: "campaign_card_fkey",
                table: "rules");

            migrationBuilder.DropIndex(
                name: "IX_rules_RewardId1",
                table: "rules");

            migrationBuilder.AddForeignKey(
                name: "FK_rules_cards_CardId",
                table: "rules",
                column: "CardId",
                principalTable: "cards",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_rules_rewards_RewardId",
                table: "rules",
                column: "RewardId",
                principalTable: "rewards",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rules_cards_CardId",
                table: "rules");

            migrationBuilder.DropForeignKey(
                name: "FK_rules_rewards_RewardId",
                table: "rules");

            migrationBuilder.CreateIndex(
                name: "IX_rules_RewardId1",
                table: "rules",
                column: "RewardId");

            migrationBuilder.AddForeignKey(
                name: "reward_campaign_fkey",
                table: "rules",
                column: "RewardId",
                principalTable: "rewards",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rules_rewards_RewardId",
                table: "rules",
                column: "RewardId",
                principalTable: "rewards",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "campaign_card_fkey",
                table: "rules",
                column: "CardId",
                principalTable: "cards",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
