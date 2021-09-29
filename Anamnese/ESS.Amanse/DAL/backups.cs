using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESS.Amanse.DAL
{
    [Table("tblbackups")]

    public class backups
    {
        [Key]
        public long id { get; set; }
        public string filename { get; set; }
        public DateTime timestamp { get; set; }
        public DateTime sent_to_ds_win_at { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
