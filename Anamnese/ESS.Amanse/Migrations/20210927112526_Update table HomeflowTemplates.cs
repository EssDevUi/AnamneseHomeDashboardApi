using Microsoft.EntityFrameworkCore.Migrations;

namespace ESS.Amanse.Migrations
{
    public partial class UpdatetableHomeflowTemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblVorlagen_HomeflowTemplates_HomeflowTemplatesid",
                table: "tblVorlagen");

            migrationBuilder.DropIndex(
                name: "IX_tblVorlagen_HomeflowTemplatesid",
                table: "tblVorlagen");

            migrationBuilder.DropColumn(
                name: "HomeflowTemplatesid",
                table: "tblVorlagen");

            migrationBuilder.CreateIndex(
                name: "IX_HomeflowTemplates_VorlagenID",
                table: "HomeflowTemplates",
                column: "VorlagenID");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeflowTemplates_tblVorlagen_VorlagenID",
                table: "HomeflowTemplates",
                column: "VorlagenID",
                principalTable: "tblVorlagen",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeflowTemplates_tblVorlagen_VorlagenID",
                table: "HomeflowTemplates");

            migrationBuilder.DropIndex(
                name: "IX_HomeflowTemplates_VorlagenID",
                table: "HomeflowTemplates");

            migrationBuilder.AddColumn<long>(
                name: "HomeflowTemplatesid",
                table: "tblVorlagen",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblVorlagen_HomeflowTemplatesid",
                table: "tblVorlagen",
                column: "HomeflowTemplatesid");

            migrationBuilder.AddForeignKey(
                name: "FK_tblVorlagen_HomeflowTemplates_HomeflowTemplatesid",
                table: "tblVorlagen",
                column: "HomeflowTemplatesid",
                principalTable: "HomeflowTemplates",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
