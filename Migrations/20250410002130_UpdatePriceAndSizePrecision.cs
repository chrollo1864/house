using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace house.Migrations
{
    public partial class UpdatePriceAndSizePrecisionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Houses",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Size",
                table: "Houses",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Houses",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Size",
                table: "Houses",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
