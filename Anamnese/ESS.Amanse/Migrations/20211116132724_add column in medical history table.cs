using Microsoft.EntityFrameworkCore.Migrations;

namespace ESS.Amanse.Migrations
{
    public partial class addcolumninmedicalhistorytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInDraft",
                table: "tblMedicalHistory",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInDraft",
                table: "tblMedicalHistory");
        }
    }
}
