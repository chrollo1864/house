using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace house.Migrations
{
    /// <inheritdoc />
    public partial class AddLoanExtendedFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Barangay",
                table: "Loans",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Loans",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CivilStatus",
                table: "Loans",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ContactNo",
                table: "Loans",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Loans",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Loans",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HouseNo",
                table: "Loans",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Loans",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Loans",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Municipality",
                table: "Loans",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "Loans",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PreferredPaymentFrequency",
                table: "Loans",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Loans",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "Loans",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "StreetNo",
                table: "Loans",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Suffix",
                table: "Loans",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "Barangay",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "CivilStatus",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "ContactNo",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "HouseNo",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "Municipality",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "PreferredPaymentFrequency",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "StreetNo",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "Suffix",
                table: "Loans");
        }
    }
}
