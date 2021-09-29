using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESS.Amanse.DAL
{
    [Table("tblanamnesis_at_home_flow")]

    public class anamnesis_at_home_flow
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string notification_email { get; set; }
        public bool @default { get; set; }
        public string display_email { get; set; }
        public string display_phone { get; set; }
        public virtual List<HomeflowTemplates> HomeflowTemplates { get; set; }
    }
}
