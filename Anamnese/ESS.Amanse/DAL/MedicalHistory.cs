using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESS.Amanse.DAL
{
    [Table("tblMedicalHistory")]
    public class MedicalHistory
    {
        [Key]
        public long id { get; set; }
        public string token { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime date_of_birth { get; set; }
        public long practice_id { get; set; }
        public long? pvs_patid { get; set; }
        public DateTime created_at { get; set; }
        public DateTime submitted_at { get; set; }
        public string patient_payload { get; set; }
        [ForeignKey("pvs_patid")]
        public patients patient { get; set; }
    }
}
