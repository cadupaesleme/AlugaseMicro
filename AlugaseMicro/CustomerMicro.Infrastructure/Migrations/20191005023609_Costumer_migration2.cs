using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerMicro.Infrastructure.Migrations
{
    public partial class Customer_migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bithday",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bithday",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Customers");
        }
    }
}
