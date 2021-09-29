﻿// <auto-generated />
using System;
using ESS.Amanse.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ESS.Amanse.Migrations
{
    [DbContext(typeof(AmanseHomeContext))]
    [Migration("20210918055828_add tblpractice")]
    partial class addtblpractice
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ESS.Amanse.DAL.anamneses", b =>
                {
                    b.Property<long>("document_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("s_win_anamnesis_template_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("submitted_to_ds_win_at")
                        .HasColumnType("datetime2");

                    b.HasKey("document_id");

                    b.ToTable("tblanamneses");
                });

            modelBuilder.Entity("ESS.Amanse.DAL.backups", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("filename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("sent_to_ds_win_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("tblbackups");
                });

            modelBuilder.Entity("ESS.Amanse.DAL.consultation_event_types", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("template")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("id");

                    b.ToTable("tblconsultation_event_types");
                });

            modelBuilder.Entity("ESS.Amanse.DAL.consultation_events", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("consultation_event_type_id")
                        .HasColumnType("bigint");

                    b.Property<long>("consultation_id")
                        .HasColumnType("bigint");

                    b.Property<string>("fulltext")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("payload")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("tblconsultation_events");
                });

            modelBuilder.Entity("ESS.Amanse.DAL.consultations", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("finished_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("patient_id")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("started_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("user_id")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("id");

                    b.ToTable("tblconsultations");
                });

            modelBuilder.Entity("ESS.Amanse.DAL.documents", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("anamnesis_at_home_submission_id")
                        .HasColumnType("bigint");

                    b.Property<long>("anamnesis_form_id")
                        .HasColumnType("bigint");

                    b.Property<string>("atn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("consent_form_id")
                        .HasColumnType("bigint");

                    b.Property<long>("consultation_id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("document_template_id")
                        .HasColumnType("int");

                    b.Property<bool?>("draft")
                        .HasColumnType("bit");

                    b.Property<string>("erb_template")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("path_to_pdf")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("path_to_signed_pdf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("path_to_timestamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("patient_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("payload")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("practice_data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("signable_id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("submitted_to_ds_win_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("user_id")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("id");

                    b.ToTable("tbldocuments");
                });

            modelBuilder.Entity("ESS.Amanse.DAL.drawings", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("consultation_id")
                        .HasColumnType("bigint");

                    b.Property<string>("data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("document_id")
                        .HasColumnType("int");

                    b.Property<string>("mime_type")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("tag")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tbldrawings");
                });

            modelBuilder.Entity("ESS.Amanse.DAL.images", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("bvs_image_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("patient_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("tblimages");
                });

            modelBuilder.Entity("ESS.Amanse.DAL.patients", b =>
                {
                    b.Property<int>("MyProperty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address1")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("address2")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("cellular_phone")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("date_of_birth")
                        .HasColumnType("datetime2");

                    b.Property<string>("doctor")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("ds_patid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ds_patnr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("employer")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("fax")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("first_displayed_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("first_name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("home_phone")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("insurance_status")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("insured_address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("insured_address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("insured_country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("insured_date_of_birth")
                        .HasColumnType("datetime2");

                    b.Property<string>("insured_first_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("insured_last_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("insured_phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("insured_salutation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("insured_title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("kknr")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("last_name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("last_submitted_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("last_visit")
                        .HasColumnType("datetime2");

                    b.Property<string>("policy_number")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("position")
                        .HasColumnType("int");

                    b.Property<string>("profession")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("prxnr")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("pvs_name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("pvs_patid")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("recall")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("recall_to")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("rejected_in_ds_win")
                        .HasColumnType("bit");

                    b.Property<string>("salutation")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("temporary_pat_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("waiting_for_documents")
                        .HasColumnType("bit");

                    b.Property<string>("work_phone")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("zipcode")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("MyProperty");

                    b.ToTable("tblpatients");
                });

            modelBuilder.Entity("ESS.Amanse.DAL.practice", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adress2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AllowPriviousEntry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlockingPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DangerZonePassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogBugReportso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("NavigateTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sendanalyticsdata")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tblpractice");
                });

            modelBuilder.Entity("ESS.Amanse.DAL.signables", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("ds_patnr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("folder_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pages")
                        .HasColumnType("int");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("tblsignables");
                });

            modelBuilder.Entity("ESS.Amanse.DAL.signatures", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("document_id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("signed_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("signee")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tblsignatures");
                });
#pragma warning restore 612, 618
        }
    }
}
