using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESS.Amanse.Migrations
{
    public partial class UpdatemedicalHstory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "date_of_birth",
                table: "tblMedicalHistory",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "tblMedicalHistory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "last_name",
                table: "tblMedicalHistory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date_of_birth",
                table: "tblMedicalHistory");

            migrationBuilder.DropColumn(
                name: "first_name",
                table: "tblMedicalHistory");

            migrationBuilder.DropColumn(
                name: "last_name",
                table: "tblMedicalHistory");
        }
    }
}
