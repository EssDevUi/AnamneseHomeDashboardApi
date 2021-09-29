using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESS.Amanse.DAL
{
    [Table("tblpractice")]

    public class practice
    {
        [Key]
        public long id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Adress1 { get; set; }
        [MaxLength(500)]
        public string Adress2 { get; set; }
        [MaxLength(50)]
        public string PostCode { get; set; }
        [MaxLength(150)]
        public string City { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(150)]
        public string Website { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(500)]
        public string Logo { get; set; }
        public bool BlockingPassword { get; set; }
        public bool BugReports { get; set; }
        public DateTime BugReportTime { get; set; }
        public bool sendanalyticsdata { get; set; }
        public bool AllowPriviousEntry { get; set; }
        public string NavigateTo { get; set; }
        public string DangerZonePassword { get; set; }

    }
}
