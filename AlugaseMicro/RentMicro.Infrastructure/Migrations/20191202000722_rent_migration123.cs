using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentMicro.Infrastructure.Migrations
{
    public partial class rent_migration123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    Date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    VendorID = table.Column<Guid>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    InitialDate = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true),
                    RentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentItem_Rents_RentId",
                        column: x => x.RentId,
                        principalTable: "Rents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentItem_RentId",
                table: "RentItem",
                column: "RentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentItem");

            migrationBuilder.DropTable(
                name: "Rents");
        }
    }
}
