using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace CS301_Spend_Transactions.Migrations
{
    public partial class RemoveRewardIdAndChangeIdTypeFromPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RewardId",
                table: "points");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "points",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "points",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "points");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "points",
                type: "int",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "RewardId",
                table: "points",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
