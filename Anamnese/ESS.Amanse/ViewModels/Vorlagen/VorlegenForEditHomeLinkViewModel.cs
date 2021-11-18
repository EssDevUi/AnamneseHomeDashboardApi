using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.ViewModels.Vorlagen
{
    public class VorlegenForEditHomeLinkViewModel
    {
        public long id { get; set; }
        public string title { get; set; }
        public bool @default { get; set; }
        public long template_category_id { get; set; }
        public string languages { get; set; }
    }
}
