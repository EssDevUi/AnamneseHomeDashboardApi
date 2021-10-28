using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESS.Amanse.DAL
{
    [Table("tblAbnormalities")]

    public class Abnormalities
    {
        [Key]
        public long Id{ get; set; }
        public string Abnormality { get; set; }
        public long DocumentId { get; set; }
        [ForeignKey("DocumentId")]
        public virtual documents tbldocuments { get; set; }

    }
}
