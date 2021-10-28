using Microsoft.EntityFrameworkCore.Migrations;

namespace ESS.Amanse.Migrations
{
    public partial class UpdatemedicalHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblMedicalHistory_tblpatients_practice_id",
                table: "tblMedicalHistory");

            migrationBuilder.DropIndex(
                name: "IX_tblMedicalHistory_practice_id",
                table: "tblMedicalHistory");

            migrationBuilder.CreateIndex(
                name: "IX_tblMedicalHistory_pvs_patid",
                table: "tblMedicalHistory",
                column: "pvs_patid");

            migrationBuilder.AddForeignKey(
                name: "FK_tblMedicalHistory_tblpatients_pvs_patid",
                table: "tblMedicalHistory",
                column: "pvs_patid",
                principalTable: "tblpatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblMedicalHistory_tblpatients_pvs_patid",
                table: "tblMedicalHistory");

            migrationBuilder.DropIndex(
                name: "IX_tblMedicalHistory_pvs_patid",
                table: "tblMedicalHistory");

            migrationBuilder.CreateIndex(
                name: "IX_tblMedicalHistory_practice_id",
                table: "tblMedicalHistory",
                column: "practice_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblMedicalHistory_tblpatients_practice_id",
                table: "tblMedicalHistory",
                column: "practice_id",
                principalTable: "tblpatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
