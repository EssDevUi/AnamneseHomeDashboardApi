using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.ViewModels
{
   public class TemplateDuplicateViewModel
    {
        public string authenticity_token { get; set; }
        public string commit { get; set; }
        public document_template document_template { get; set; }

    }
    public class document_template
    {
        public string title { get; set; }
        public int template_category_id { get; set; }
    }
}
