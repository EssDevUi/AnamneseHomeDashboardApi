using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESS.Amanse.DAL
{
    [Table("tblanamneses")]
    public class anamneses
    {
        [Key]
        public long document_id { get; set; }
        public string s_win_anamnesis_template_id { get; set; }
        public DateTime submitted_to_ds_win_at { get; set; }
    }
}
