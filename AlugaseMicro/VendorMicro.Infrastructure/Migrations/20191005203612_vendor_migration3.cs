using Microsoft.EntityFrameworkCore.Migrations;

namespace VendorMicro.Infrastructure.Migrations
{
    public partial class vendor_migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bithday",
                table: "Vendors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Vendors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bithday",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Vendors");
        }
    }
}
