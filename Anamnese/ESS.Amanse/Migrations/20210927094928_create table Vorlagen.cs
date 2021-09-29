using Microsoft.EntityFrameworkCore.Migrations;

namespace ESS.Amanse.Migrations
{
    public partial class createtableVorlagen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblanamnesis_at_home_flow",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    link = table.Column<string>(nullable: true),
                    notification_email = table.Column<string>(nullable: true),
                    @default = table.Column<bool>(name: "default", nullable: false),
                    display_email = table.Column<string>(nullable: true),
                    display_phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblanamnesis_at_home_flow", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblVorlagen",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SortIndex = table.Column<int>(nullable: false),
                    templates = table.Column<int>(nullable: false),
                    anamnesis_at_home_flowid = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVorlagen", x => x.id);
                    table.ForeignKey(
                        name: "FK_tblVorlagen_tblanamnesis_at_home_flow_anamnesis_at_home_flowid",
                        column: x => x.anamnesis_at_home_flowid,
                        principalTable: "tblanamnesis_at_home_flow",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblVorlagen_anamnesis_at_home_flowid",
                table: "tblVorlagen",
                column: "anamnesis_at_home_flowid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblVorlagen");

            migrationBuilder.DropTable(
                name: "tblanamnesis_at_home_flow");
        }
    }
}
