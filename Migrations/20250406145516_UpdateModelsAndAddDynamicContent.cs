using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BCrypt.Net;

#nullable disable

namespace house.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelsAndAddDynamicContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Users CHANGE COLUMN Password ProfileImage varchar(255)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDate",
                table: "Users",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisteredDate",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ApplicationDate",
                table: "Loans",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Loans",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Houses",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Houses",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Houses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PropertyTypeId",
                table: "Houses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Size",
                table: "Houses",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SiteSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastUpdated = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_LocationId",
                table: "Houses",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_PropertyTypeId",
                table: "Houses",
                column: "PropertyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Locations_LocationId",
                table: "Houses",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_PropertyTypes_PropertyTypeId",
                table: "Houses",
                column: "PropertyTypeId",
                principalTable: "PropertyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            // Create default admin user with hashed password
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword("Admin123!");
            migrationBuilder.Sql($@"
                INSERT INTO Users (Name, Email, PasswordHash, Role, PhoneNumber, Address, RegisteredDate, ProfileImage)
                VALUES ('Admin', 'admin@house.com', '{hashedPassword}', 'Admin', '1234567890', 'Admin Address', UTC_TIMESTAMP(), '/uploads/profiles/default-profile.png')
            ");

            // Create default property types
            migrationBuilder.Sql(@"
                INSERT INTO PropertyTypes (Name, Description) VALUES
                ('Single Family Home', 'Traditional detached house for one family'),
                ('Apartment', 'Unit in a multi-unit building'),
                ('Townhouse', 'Multi-floor home sharing walls with adjacent units'),
                ('Condo', 'Individually owned unit in a larger building or community'),
                ('Villa', 'Luxury detached house with garden'),
                ('Penthouse', 'Luxury apartment on the top floor')
            ");

            // Create default locations
            migrationBuilder.Sql(@"
                INSERT INTO Locations (Name, State, Country) VALUES
                ('Downtown', 'California', 'USA'),
                ('Beverly Hills', 'California', 'USA'),
                ('Manhattan', 'New York', 'USA'),
                ('Brooklyn', 'New York', 'USA'),
                ('Miami Beach', 'Florida', 'USA'),
                ('Las Vegas', 'Nevada', 'USA')
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Locations_LocationId",
                table: "Houses");

            migrationBuilder.DropForeignKey(
                name: "FK_Houses_PropertyTypes_PropertyTypeId",
                table: "Houses");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "PropertyTypes");

            migrationBuilder.DropTable(
                name: "SiteSettings");

            migrationBuilder.DropIndex(
                name: "IX_Houses_LocationId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_PropertyTypeId",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastLoginDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RegisteredDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ApplicationDate",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "PropertyTypeId",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Houses");

            migrationBuilder.Sql("ALTER TABLE Users CHANGE COLUMN ProfileImage Password varchar(255)");
        }
    }
}
