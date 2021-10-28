using ESS.Amanse.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.ViewModels
{
    public class DocumentViewModel
    {
        public long id { get; set; }
        public string patient_name { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public DateTime timestamp { get; set; }
        public string path_to_pdf { get; set; }
        public long DT_RowId { get; set; }
        public List<Abnormalities> anamnesis_report { get; set; }
    }
}
