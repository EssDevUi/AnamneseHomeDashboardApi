using ESS.Amanse.DAL;
using Newtonsoft.Json.Linq;
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
        public patients patient_payload { get; set; }
        public string payloadJson { get; set; }
        public List<document_payloads> document_payloads { get; set; }
        public List<document_templates> document_templates { get; set; }
    }

    public class document_payloads
    {
        public string document_template_id { get; set; }
        public JObject payload { get; set; }

    }
    public class document_templates
    {
        public long id { get; set; }
        public string title { get; set; }
        public string languages { get; set; }
        public string atn { get; set; }
        public string erb { get; set; }

    }
}
