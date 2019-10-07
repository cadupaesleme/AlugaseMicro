using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentMicro.Infrastructure.Migrations
{
    public partial class rent_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    InitialDate = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rents");
        }
    }
}
