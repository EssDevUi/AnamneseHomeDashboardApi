using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.ViewModels.atn_AditorViewModel
{
    public class Edit_atn_AditorViewModel
    {
        public DocumentTemplate document_template { get; set; }
    }
    public class DocumentTemplate
    {
        public string title { get; set; }
        public string atn_v2 { get; set; }
        public string languages { get; set; }
        public long template_category_id { get; set; }
    }
}
