using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WIL_Project.Migrations
{
    public partial class UpdateMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpeakerImage",
                table: "SpeakerInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpeakerImage",
                table: "SpeakerInformation");
        }
    }
}
