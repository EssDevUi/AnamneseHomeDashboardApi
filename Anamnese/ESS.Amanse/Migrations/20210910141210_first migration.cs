using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESS.Amanse.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblanamneses",
                columns: table => new
                {
                    document_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    s_win_anamnesis_template_id = table.Column<string>(nullable: true),
                    submitted_to_ds_win_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblanamneses", x => x.document_id);
                });

            migrationBuilder.CreateTable(
                name: "tblbackups",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    filename = table.Column<string>(nullable: true),
                    timestamp = table.Column<DateTime>(nullable: false),
                    sent_to_ds_win_at = table.Column<DateTime>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblbackups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblconsultation_event_types",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 255, nullable: true),
                    template = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblconsultation_event_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblconsultation_events",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    consultation_id = table.Column<long>(nullable: false),
                    consultation_event_type_id = table.Column<long>(nullable: false),
                    timestamp = table.Column<DateTime>(nullable: false),
                    fulltext = table.Column<string>(nullable: true),
                    payload = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblconsultation_events", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblconsultations",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(maxLength: 255, nullable: true),
                    patient_id = table.Column<string>(maxLength: 255, nullable: true),
                    started_at = table.Column<DateTime>(nullable: false),
                    finished_at = table.Column<DateTime>(nullable: false),
                    duration = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true),
                    remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblconsultations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbldocuments",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(maxLength: 255, nullable: true),
                    patient_id = table.Column<Guid>(nullable: false),
                    timestamp = table.Column<DateTime>(nullable: false),
                    title = table.Column<string>(maxLength: 255, nullable: true),
                    payload = table.Column<string>(nullable: true),
                    path_to_pdf = table.Column<string>(maxLength: 255, nullable: true),
                    type = table.Column<string>(maxLength: 255, nullable: true),
                    consultation_id = table.Column<long>(nullable: false),
                    anamnesis_form_id = table.Column<long>(nullable: false),
                    consent_form_id = table.Column<long>(nullable: false),
                    path_to_signed_pdf = table.Column<string>(nullable: true),
                    path_to_timestamp = table.Column<string>(nullable: true),
                    erb_template = table.Column<string>(nullable: true),
                    practice_data = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    submitted_to_ds_win_at = table.Column<DateTime>(nullable: false),
                    atn = table.Column<string>(nullable: true),
                    document_template_id = table.Column<int>(nullable: false),
                    signable_id = table.Column<long>(nullable: false),
                    anamnesis_at_home_submission_id = table.Column<long>(nullable: false),
                    draft = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbldocuments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbldrawings",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    consultation_id = table.Column<long>(nullable: false),
                    mime_type = table.Column<string>(maxLength: 255, nullable: true),
                    data = table.Column<string>(nullable: true),
                    document_id = table.Column<int>(nullable: false),
                    tag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbldrawings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblimages",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patient_id = table.Column<string>(nullable: true),
                    timestamp = table.Column<DateTime>(nullable: false),
                    source = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    data = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true),
                    bvs_image_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblimages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblpatients",
                columns: table => new
                {
                    MyProperty = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(maxLength: 255, nullable: true),
                    last_name = table.Column<string>(maxLength: 255, nullable: true),
                    date_of_birth = table.Column<DateTime>(nullable: false),
                    salutation = table.Column<string>(maxLength: 255, nullable: true),
                    title = table.Column<string>(maxLength: 255, nullable: true),
                    gender = table.Column<string>(maxLength: 255, nullable: true),
                    address1 = table.Column<string>(maxLength: 255, nullable: true),
                    address2 = table.Column<string>(maxLength: 255, nullable: true),
                    zipcode = table.Column<string>(maxLength: 255, nullable: true),
                    city = table.Column<string>(maxLength: 255, nullable: true),
                    country = table.Column<string>(maxLength: 255, nullable: true),
                    home_phone = table.Column<string>(maxLength: 255, nullable: true),
                    work_phone = table.Column<string>(maxLength: 255, nullable: true),
                    cellular_phone = table.Column<string>(maxLength: 255, nullable: true),
                    fax = table.Column<string>(maxLength: 255, nullable: true),
                    email = table.Column<string>(maxLength: 255, nullable: true),
                    kknr = table.Column<string>(maxLength: 255, nullable: true),
                    policy_number = table.Column<string>(maxLength: 255, nullable: true),
                    insurance_status = table.Column<string>(maxLength: 255, nullable: true),
                    employer = table.Column<string>(maxLength: 255, nullable: true),
                    profession = table.Column<string>(maxLength: 255, nullable: true),
                    pvs_patid = table.Column<string>(maxLength: 255, nullable: true),
                    pvs_name = table.Column<string>(maxLength: 255, nullable: true),
                    prxnr = table.Column<string>(maxLength: 255, nullable: true),
                    doctor = table.Column<string>(maxLength: 255, nullable: true),
                    last_visit = table.Column<DateTime>(nullable: false),
                    first_displayed_at = table.Column<DateTime>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true),
                    ds_patid = table.Column<string>(nullable: true),
                    ds_patnr = table.Column<string>(nullable: true),
                    last_submitted_at = table.Column<DateTime>(nullable: false),
                    position = table.Column<int>(nullable: false),
                    temporary_pat_id = table.Column<string>(nullable: true),
                    rejected_in_ds_win = table.Column<bool>(nullable: true),
                    insured_salutation = table.Column<string>(nullable: true),
                    insured_title = table.Column<string>(nullable: true),
                    insured_first_name = table.Column<string>(nullable: true),
                    insured_last_name = table.Column<string>(nullable: true),
                    insured_date_of_birth = table.Column<DateTime>(nullable: false),
                    insured_address1 = table.Column<string>(nullable: true),
                    insured_address2 = table.Column<string>(nullable: true),
                    insured_country = table.Column<string>(nullable: true),
                    insured_phone = table.Column<string>(nullable: true),
                    recall = table.Column<string>(nullable: true),
                    recall_to = table.Column<string>(nullable: true),
                    waiting_for_documents = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblpatients", x => x.MyProperty);
                });

            migrationBuilder.CreateTable(
                name: "tblsignables",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    folder_path = table.Column<string>(nullable: true),
                    pages = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true),
                    ds_patnr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblsignables", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblsignatures",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document_id = table.Column<long>(nullable: false),
                    signed_at = table.Column<DateTime>(nullable: false),
                    signee = table.Column<string>(nullable: true),
                    data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblsignatures", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblanamneses");

            migrationBuilder.DropTable(
                name: "tblbackups");

            migrationBuilder.DropTable(
                name: "tblconsultation_event_types");

            migrationBuilder.DropTable(
                name: "tblconsultation_events");

            migrationBuilder.DropTable(
                name: "tblconsultations");

            migrationBuilder.DropTable(
                name: "tbldocuments");

            migrationBuilder.DropTable(
                name: "tbldrawings");

            migrationBuilder.DropTable(
                name: "tblimages");

            migrationBuilder.DropTable(
                name: "tblpatients");

            migrationBuilder.DropTable(
                name: "tblsignables");

            migrationBuilder.DropTable(
                name: "tblsignatures");
        }
    }
}
