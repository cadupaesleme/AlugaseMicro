using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentMicro.Infrastructure.Migrations
{
    public partial class rent_migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Rents");

            migrationBuilder.RenameColumn(
                name: "InitialDate",
                table: "Rents",
                newName: "Date");

            migrationBuilder.CreateTable(
                name: "RentItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Rents",
                newName: "InitialDate");

            migrationBuilder.AddColumn<string>(
                name: "EndDate",
                table: "Rents",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Rents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "Rents",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
