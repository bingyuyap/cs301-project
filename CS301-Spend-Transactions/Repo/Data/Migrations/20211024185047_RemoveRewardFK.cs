using Microsoft.EntityFrameworkCore.Migrations;

namespace CS301_Spend_Transactions.Migrations
{
    public partial class RemoveRewardFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "reward_point_fkey",
                table: "points");

            migrationBuilder.DropIndex(
                name: "IX_points_RewardId",
                table: "points");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "cards",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "cards");

            migrationBuilder.CreateIndex(
                name: "IX_points_RewardId",
                table: "points",
                column: "RewardId");

            migrationBuilder.AddForeignKey(
                name: "reward_point_fkey",
                table: "points",
                column: "RewardId",
                principalTable: "rewards",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
