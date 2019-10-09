using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentMicro.Infrastructure.Migrations
{
    public partial class rent_migration1234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Rents",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "VendorID",
                table: "RentItem",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "VendorID",
                table: "RentItem");
        }
    }
}
