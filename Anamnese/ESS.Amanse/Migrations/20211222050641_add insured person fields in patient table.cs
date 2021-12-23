using Microsoft.EntityFrameworkCore.Migrations;

namespace ESS.Amanse.Migrations
{
    public partial class addinsuredpersonfieldsinpatienttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "insured_city",
                table: "tblpatients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "insured_zipcode",
                table: "tblpatients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "insured_city",
                table: "tblpatients");

            migrationBuilder.DropColumn(
                name: "insured_zipcode",
                table: "tblpatients");
        }
    }
}
