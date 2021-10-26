using Microsoft.EntityFrameworkCore.Migrations;

namespace CS301_Spend_Transactions.Migrations
{
    public partial class UpdateMultiplierDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "multiplier",
                table: "rules",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "multiplier",
                table: "rules",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
