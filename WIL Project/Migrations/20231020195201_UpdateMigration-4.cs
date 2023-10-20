using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WIL_Project.Migrations
{
    public partial class UpdateMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "percentoff",
                table: "DiscountVoucher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "value",
                table: "DiscountVoucher",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "percentoff",
                table: "DiscountVoucher");

            migrationBuilder.DropColumn(
                name: "value",
                table: "DiscountVoucher");
        }
    }
}
