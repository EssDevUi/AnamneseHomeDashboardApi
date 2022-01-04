using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESS.Amanse.Migrations
{
    public partial class updatepatienttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "insured_date_of_birth",
                table: "tblpatients",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "insured_date_of_birth",
                table: "tblpatients",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
