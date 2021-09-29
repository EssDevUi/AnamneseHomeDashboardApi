using Microsoft.EntityFrameworkCore.Migrations;

namespace ESS.Amanse.Migrations
{
    public partial class createtableHomeflowTemplatess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeflowTemplates_tblVorlagen_VorlagenID",
                table: "HomeflowTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeflowTemplates_tblanamnesis_at_home_flow_anamnesis_at_home_flowID",
                table: "HomeflowTemplates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeflowTemplates",
                table: "HomeflowTemplates");

            migrationBuilder.RenameTable(
                name: "HomeflowTemplates",
                newName: "tblHomeflowTemplates");

            migrationBuilder.RenameIndex(
                name: "IX_HomeflowTemplates_anamnesis_at_home_flowID",
                table: "tblHomeflowTemplates",
                newName: "IX_tblHomeflowTemplates_anamnesis_at_home_flowID");

            migrationBuilder.RenameIndex(
                name: "IX_HomeflowTemplates_VorlagenID",
                table: "tblHomeflowTemplates",
                newName: "IX_tblHomeflowTemplates_VorlagenID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblHomeflowTemplates",
                table: "tblHomeflowTemplates",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblHomeflowTemplates_tblVorlagen_VorlagenID",
                table: "tblHomeflowTemplates",
                column: "VorlagenID",
                principalTable: "tblVorlagen",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblHomeflowTemplates_tblanamnesis_at_home_flow_anamnesis_at_home_flowID",
                table: "tblHomeflowTemplates",
                column: "anamnesis_at_home_flowID",
                principalTable: "tblanamnesis_at_home_flow",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblHomeflowTemplates_tblVorlagen_VorlagenID",
                table: "tblHomeflowTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_tblHomeflowTemplates_tblanamnesis_at_home_flow_anamnesis_at_home_flowID",
                table: "tblHomeflowTemplates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblHomeflowTemplates",
                table: "tblHomeflowTemplates");

            migrationBuilder.RenameTable(
                name: "tblHomeflowTemplates",
                newName: "HomeflowTemplates");

            migrationBuilder.RenameIndex(
                name: "IX_tblHomeflowTemplates_anamnesis_at_home_flowID",
                table: "HomeflowTemplates",
                newName: "IX_HomeflowTemplates_anamnesis_at_home_flowID");

            migrationBuilder.RenameIndex(
                name: "IX_tblHomeflowTemplates_VorlagenID",
                table: "HomeflowTemplates",
                newName: "IX_HomeflowTemplates_VorlagenID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeflowTemplates",
                table: "HomeflowTemplates",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeflowTemplates_tblVorlagen_VorlagenID",
                table: "HomeflowTemplates",
                column: "VorlagenID",
                principalTable: "tblVorlagen",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeflowTemplates_tblanamnesis_at_home_flow_anamnesis_at_home_flowID",
                table: "HomeflowTemplates",
                column: "anamnesis_at_home_flowID",
                principalTable: "tblanamnesis_at_home_flow",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
