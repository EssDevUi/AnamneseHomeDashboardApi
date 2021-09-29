using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESS.Amanse.DAL
{
    [Table("tblVorlagen")]

    public class Vorlagen
    {
        [Key]
        public long id { get; set; }
        public int SortIndex { get; set; }
        public string templates { get; set; }
        public bool @default { get; set; }
        public long CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public VorlagenCategory VorlagenCategory { get; set; }
    }
}
