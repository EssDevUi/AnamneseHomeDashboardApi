using Microsoft.EntityFrameworkCore.Migrations;

namespace ESS.Amanse.Migrations
{
    public partial class createtableHomeflowTemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblVorlagen_tblanamnesis_at_home_flow_anamnesis_at_home_flowid",
                table: "tblVorlagen");

            migrationBuilder.DropIndex(
                name: "IX_tblVorlagen_anamnesis_at_home_flowid",
                table: "tblVorlagen");

            migrationBuilder.DropColumn(
                name: "anamnesis_at_home_flowid",
                table: "tblVorlagen");

            migrationBuilder.AlterColumn<string>(
                name: "templates",
                table: "tblVorlagen",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "HomeflowTemplatesid",
                table: "tblVorlagen",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HomeflowTemplates",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VorlagenID = table.Column<long>(nullable: false),
                    anamnesis_at_home_flowID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeflowTemplates", x => x.id);
                    table.ForeignKey(
                        name: "FK_HomeflowTemplates_tblanamnesis_at_home_flow_anamnesis_at_home_flowID",
                        column: x => x.anamnesis_at_home_flowID,
                        principalTable: "tblanamnesis_at_home_flow",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblVorlagen_HomeflowTemplatesid",
                table: "tblVorlagen",
                column: "HomeflowTemplatesid");

            migrationBuilder.CreateIndex(
                name: "IX_HomeflowTemplates_anamnesis_at_home_flowID",
                table: "HomeflowTemplates",
                column: "anamnesis_at_home_flowID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblVorlagen_HomeflowTemplates_HomeflowTemplatesid",
                table: "tblVorlagen",
                column: "HomeflowTemplatesid",
                principalTable: "HomeflowTemplates",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblVorlagen_HomeflowTemplates_HomeflowTemplatesid",
                table: "tblVorlagen");

            migrationBuilder.DropTable(
                name: "HomeflowTemplates");

            migrationBuilder.DropIndex(
                name: "IX_tblVorlagen_HomeflowTemplatesid",
                table: "tblVorlagen");

            migrationBuilder.DropColumn(
                name: "HomeflowTemplatesid",
                table: "tblVorlagen");

            migrationBuilder.AlterColumn<int>(
                name: "templates",
                table: "tblVorlagen",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "anamnesis_at_home_flowid",
                table: "tblVorlagen",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblVorlagen_anamnesis_at_home_flowid",
                table: "tblVorlagen",
                column: "anamnesis_at_home_flowid");

            migrationBuilder.AddForeignKey(
                name: "FK_tblVorlagen_tblanamnesis_at_home_flow_anamnesis_at_home_flowid",
                table: "tblVorlagen",
                column: "anamnesis_at_home_flowid",
                principalTable: "tblanamnesis_at_home_flow",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
