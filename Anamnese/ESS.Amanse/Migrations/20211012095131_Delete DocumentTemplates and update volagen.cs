using Microsoft.EntityFrameworkCore.Migrations;

namespace ESS.Amanse.Migrations
{
    public partial class DeleteDocumentTemplatesandupdatevolagen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblDocumentTemplates");

            migrationBuilder.AddColumn<string>(
                name: "atn_v2",
                table: "tblVorlagen",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "languages",
                table: "tblVorlagen",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "atn_v2",
                table: "tblVorlagen");

            migrationBuilder.DropColumn(
                name: "languages",
                table: "tblVorlagen");

            migrationBuilder.CreateTable(
                name: "tblDocumentTemplates",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    atn_v2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    languages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDocumentTemplates", x => x.ID);
                });
        }
    }
}
