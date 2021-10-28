using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESS.Amanse.Migrations
{
    public partial class Firstmigration : Migration
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
                name: "tblMainProfile",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salutation = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMainProfile", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblpatients",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
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
                    table.PrimaryKey("PK_tblpatients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblpractice",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    Adress1 = table.Column<string>(maxLength: 500, nullable: true),
                    Adress2 = table.Column<string>(maxLength: 500, nullable: true),
                    PostCode = table.Column<string>(maxLength: 50, nullable: true),
                    City = table.Column<string>(maxLength: 150, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Website = table.Column<string>(maxLength: 150, nullable: true),
                    Email = table.Column<string>(maxLength: 150, nullable: true),
                    Logo = table.Column<string>(maxLength: 500, nullable: true),
                    BlockingPassword = table.Column<bool>(nullable: false),
                    BugReports = table.Column<bool>(nullable: false),
                    BugReportTime = table.Column<DateTime>(nullable: false),
                    sendanalyticsdata = table.Column<bool>(nullable: false),
                    AllowPriviousEntry = table.Column<bool>(nullable: false),
                    NavigateTo = table.Column<string>(nullable: true),
                    DangerZonePassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblpractice", x => x.id);
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

            migrationBuilder.CreateTable(
                name: "tbldocuments",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(maxLength: 255, nullable: true),
                    patient_id = table.Column<long>(nullable: false),
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
                    draft = table.Column<bool>(nullable: true),
                    anamnesis_report = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbldocuments", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbldocuments_tblpatients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "tblpatients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblMedicalHistory",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    token = table.Column<string>(nullable: true),
                    practice_id = table.Column<long>(nullable: false),
                    pvs_patid = table.Column<long>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    submitted_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMedicalHistory", x => x.id);
                    table.ForeignKey(
                        name: "FK_tblMedicalHistory_tblpatients_practice_id",
                        column: x => x.practice_id,
                        principalTable: "tblpatients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblVorlagen",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SortIndex = table.Column<int>(nullable: false),
                    templates = table.Column<string>(nullable: true),
                    @default = table.Column<bool>(name: "default", nullable: false),
                    CategoryID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVorlagen", x => x.id);
                    table.ForeignKey(
                        name: "FK_tblVorlagen_tblVorlagenCategory_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "tblVorlagenCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblAbnormalities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abnormality = table.Column<string>(nullable: true),
                    DocumentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAbnormalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblAbnormalities_tbldocuments_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "tbldocuments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblHomeflowTemplates",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VorlagenID = table.Column<long>(nullable: false),
                    anamnesis_at_home_flowID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblHomeflowTemplates", x => x.id);
                    table.ForeignKey(
                        name: "FK_tblHomeflowTemplates_tblVorlagen_VorlagenID",
                        column: x => x.VorlagenID,
                        principalTable: "tblVorlagen",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblHomeflowTemplates_tblanamnesis_at_home_flow_anamnesis_at_home_flowID",
                        column: x => x.anamnesis_at_home_flowID,
                        principalTable: "tblanamnesis_at_home_flow",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAbnormalities_DocumentId",
                table: "tblAbnormalities",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbldocuments_patient_id",
                table: "tbldocuments",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblHomeflowTemplates_VorlagenID",
                table: "tblHomeflowTemplates",
                column: "VorlagenID");

            migrationBuilder.CreateIndex(
                name: "IX_tblHomeflowTemplates_anamnesis_at_home_flowID",
                table: "tblHomeflowTemplates",
                column: "anamnesis_at_home_flowID");

            migrationBuilder.CreateIndex(
                name: "IX_tblMedicalHistory_practice_id",
                table: "tblMedicalHistory",
                column: "practice_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblVorlagen_CategoryID",
                table: "tblVorlagen",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAbnormalities");

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
                name: "tbldrawings");

            migrationBuilder.DropTable(
                name: "tblHomeflowTemplates");

            migrationBuilder.DropTable(
                name: "tblimages");

            migrationBuilder.DropTable(
                name: "tblMainProfile");

            migrationBuilder.DropTable(
                name: "tblMedicalHistory");

            migrationBuilder.DropTable(
                name: "tblpractice");

            migrationBuilder.DropTable(
                name: "tblsignables");

            migrationBuilder.DropTable(
                name: "tblsignatures");

            migrationBuilder.DropTable(
                name: "tbldocuments");

            migrationBuilder.DropTable(
                name: "tblVorlagen");

            migrationBuilder.DropTable(
                name: "tblanamnesis_at_home_flow");

            migrationBuilder.DropTable(
                name: "tblpatients");

            migrationBuilder.DropTable(
                name: "tblVorlagenCategory");
        }
    }
}
