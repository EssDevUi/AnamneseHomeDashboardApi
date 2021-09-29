using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESS.Amanse.DAL
{
    [Table("tbldrawings")]

    public class drawings
    {
        [Key]
        public long id{ get; set; }
        public long consultation_id { get; set; }
        [MaxLength(255)]
        public string mime_type { get; set; }
        public string data { get; set; }
        public int document_id { get; set; }
        public string tag { get; set; }
    }
}
