using Microsoft.EntityFrameworkCore.Migrations;

namespace ESS.Amanse.Migrations
{
    public partial class UpdatetableVorlagencategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblVorlagen_tblVorlagenCategory_VorlagenCategoryId",
                table: "tblVorlagen");

            migrationBuilder.DropIndex(
                name: "IX_tblVorlagen_VorlagenCategoryId",
                table: "tblVorlagen");

            migrationBuilder.DropColumn(
                name: "VorlagenCategoryId",
                table: "tblVorlagen");

            migrationBuilder.CreateIndex(
                name: "IX_tblVorlagen_CategoryID",
                table: "tblVorlagen",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblVorlagen_tblVorlagenCategory_CategoryID",
                table: "tblVorlagen",
                column: "CategoryID",
                principalTable: "tblVorlagenCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblVorlagen_tblVorlagenCategory_CategoryID",
                table: "tblVorlagen");

            migrationBuilder.DropIndex(
                name: "IX_tblVorlagen_CategoryID",
                table: "tblVorlagen");

            migrationBuilder.AddColumn<long>(
                name: "VorlagenCategoryId",
                table: "tblVorlagen",
                type: "bigint",
                nullable: true);

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
    }
}
