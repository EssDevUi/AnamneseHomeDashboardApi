using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.ViewModels.AnamneseLearningViewModels
{
    public class DataForSummeryViewModel
    {
        public long id{ get; set; }
        public string token { get; set; }
        public long practice_id { get; set; }
        public long pvs_patid { get; set; }
        public DateTime created_at { get; set; }
        public DateTime submitted_at { get; set; }
        public string patient_payload { get; set; }
        public string document_payloads { get; set; }
        public string document_templates { get; set; }
    }
}
