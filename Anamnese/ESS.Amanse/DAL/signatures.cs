using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESS.Amanse.DAL
{
    [Table("tblsignatures")]

    public class signatures
    {
        [Key]
        public long id { get; set; }
        public long document_id { get; set; }
        public DateTime signed_at { get; set; }
        public string signee { get; set; }
        public string data { get; set; }
    }
}
