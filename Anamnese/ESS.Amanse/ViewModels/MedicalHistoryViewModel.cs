using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.ViewModels
{
    public class MedicalHistoryViewModel
    {
        public long medicalHistoryID { get; set; }
        public string medicalHistoryLink { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string date_of_birth { get; set; }
        public string created_at { get; set; }
        public long? pvs_patid { get; set; }
    }
}
