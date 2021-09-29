using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESS.Amanse.DAL
{
    [Table("tblVorlagenCategory")]
    public class VorlagenCategory
    {
        [Key]
        public long Id { get; set; }
        public string CategoryName{ get; set; }
        public virtual ICollection<Vorlagen> Vorlagen { get; set; }
    }
}
