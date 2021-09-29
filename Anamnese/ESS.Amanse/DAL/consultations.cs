using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESS.Amanse.DAL
{
    [Table("tblconsultations")]

    public class consultations
    {
        [Key]
        public long id{ get; set; }
        [MaxLength(255)]
        public string user_id { get; set; }
        [MaxLength(255)]
        public string patient_id { get; set; }
        public DateTime started_at { get; set; }
        public DateTime finished_at { get; set; }
        public int duration { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string remarks { get; set; }
    }
}
