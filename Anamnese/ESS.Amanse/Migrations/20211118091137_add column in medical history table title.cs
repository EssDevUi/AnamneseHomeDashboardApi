using Microsoft.EntityFrameworkCore.Migrations;

namespace ESS.Amanse.Migrations
{
    public partial class addcolumninmedicalhistorytabletitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "tblMedicalHistory",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "title",
                table: "tblMedicalHistory");
        }
    }
}
