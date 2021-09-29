using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESS.Amanse.DAL
{
    [Table("tblconsultation_events")]
    public class consultation_events
    {
        [Key]
        public long id { get; set; }
        public long consultation_id { get; set; }
        public long consultation_event_type_id { get; set; }
        public DateTime timestamp { get; set; }
        public string fulltext { get; set; }
        public string payload { get; set; }
    }
}
