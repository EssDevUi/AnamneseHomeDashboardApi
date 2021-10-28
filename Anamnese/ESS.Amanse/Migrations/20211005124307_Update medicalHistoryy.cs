using Microsoft.EntityFrameworkCore.Migrations;

namespace ESS.Amanse.Migrations
{
    public partial class UpdatemedicalHistoryy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblMedicalHistory_tblpatients_pvs_patid",
                table: "tblMedicalHistory");

            migrationBuilder.AlterColumn<long>(
                name: "pvs_patid",
                table: "tblMedicalHistory",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_tblMedicalHistory_tblpatients_pvs_patid",
                table: "tblMedicalHistory",
                column: "pvs_patid",
                principalTable: "tblpatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblMedicalHistory_tblpatients_pvs_patid",
                table: "tblMedicalHistory");

            migrationBuilder.AlterColumn<long>(
                name: "pvs_patid",
                table: "tblMedicalHistory",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tblMedicalHistory_tblpatients_pvs_patid",
                table: "tblMedicalHistory",
                column: "pvs_patid",
                principalTable: "tblpatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
