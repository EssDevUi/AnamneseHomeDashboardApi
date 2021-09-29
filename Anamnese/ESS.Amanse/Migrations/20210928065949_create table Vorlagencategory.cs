using Microsoft.EntityFrameworkCore.Migrations;

namespace ESS.Amanse.Migrations
{
    public partial class createtableVorlagencategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CategoryID",
                table: "tblVorlagen",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "VorlagenCategoryId",
                table: "tblVorlagen",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblVorlagenCategory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVorlagenCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblVorlagen_VorlagenCategoryId",
                table: "tblVorlagen",
                column: "VorlagenCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblVorlagen_tblVorlagenCategory_VorlagenCategoryId",
                table: "tblVorlagen",
                column: "VorlagenCategoryId",
                principalTable: "tblVorlagenCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblVorlagen_tblVorlagenCategory_VorlagenCategoryId",
                table: "tblVorlagen");

            migrationBuilder.DropTable(
                name: "tblVorlagenCategory");

            migrationBuilder.DropIndex(
                name: "IX_tblVorlagen_VorlagenCategoryId",
                table: "tblVorlagen");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "tblVorlagen");

            migrationBuilder.DropColumn(
                name: "VorlagenCategoryId",
                table: "tblVorlagen");
        }
    }
}
