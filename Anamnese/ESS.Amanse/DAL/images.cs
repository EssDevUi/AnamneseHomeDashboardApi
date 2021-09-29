using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESS.Amanse.DAL
{
    [Table("tblimages")]

    public class images
    {
        [Key]
        public long id { get; set; }
        public string patient_id { get; set; }
        public DateTime timestamp { get; set; }
        public string source { get; set; }
        public string description { get; set; }
        public string data { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string bvs_image_id { get; set; }
    }
}
