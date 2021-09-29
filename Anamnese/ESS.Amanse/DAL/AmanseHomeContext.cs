using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ESS.Amanse.DAL
{
    public partial class AmanseHomeContext : DbContext
    {
        public AmanseHomeContext(DbContextOptions<AmanseHomeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<anamneses> tblanamneses { get; set; }
        public virtual DbSet<backups> tblbackups { get; set; }
        public virtual DbSet<consultation_event_types> tblconsultation_event_types { get; set; }
        public virtual DbSet<consultation_events> tblconsultation_events { get; set; }
        public virtual DbSet<consultations> tblconsultations { get; set; }
        public virtual DbSet<documents> tbldocuments { get; set; }
        public virtual DbSet<drawings> tbldrawings { get; set; }
        public virtual DbSet<images> tblimages { get; set; }
        public virtual DbSet<patients> tblpatients { get; set; }
        public virtual DbSet<signables> tblsignables { get; set; }
        public virtual DbSet<signatures> tblsignatures { get; set; }
        public virtual DbSet<practice> tblpractice { get; set; }
        public virtual DbSet<Vorlagen> tblVorlagen { get; set; }
        public virtual DbSet<anamnesis_at_home_flow> tblanamnesis_at_home_flow { get; set; }
        public virtual DbSet<HomeflowTemplates> tblHomeflowTemplates { get; set; }
        public virtual DbSet<VorlagenCategory> tblVorlagenCategory { get; set; }
        public virtual DbSet<MainProfile> tblMainProfile { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
