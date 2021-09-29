using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESS.Amanse.DAL
{
    [Table("tblHomeflowTemplates")]

    public class HomeflowTemplates
    {
        [Key]
        public long id { get; set; }
        public long VorlagenID { get; set; }
        public long anamnesis_at_home_flowID { get; set; }
     
        [ForeignKey("VorlagenID")]
        public virtual Vorlagen Vorlagen { get; set; }

    }
}
