using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESS.Amanse.DAL
{
    [Table("tbldocuments")]

    public class documents
    {
        public documents()
        {
            draft = false;
        }
        [Key]
        public long id { get; set; }
        [MaxLength(255)]
        public string user_id { get; set; }
        public Guid patient_id { get; set; }
        public DateTime timestamp { get; set; }
        [MaxLength(255)]
        public string title { get; set; }
        public string payload { get; set; }
        [MaxLength(255)]
        public string path_to_pdf { get; set; }
        [MaxLength(255)]
        public string type { get; set; }
        public long consultation_id { get; set; }
        public long anamnesis_form_id { get; set; }
        public long consent_form_id { get; set; }
        public string path_to_signed_pdf { get; set; }
        public string path_to_timestamp { get; set; }
        public string erb_template { get; set; }
        public string practice_data { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime submitted_to_ds_win_at { get; set; }
        public string atn { get; set; }
        public int document_template_id { get; set; }
        public long signable_id { get; set; }
        public long anamnesis_at_home_submission_id { get; set; }
        public bool? draft { get; set; }
    }
}
