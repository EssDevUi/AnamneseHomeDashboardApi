using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.ViewModels.anamnesis_at_home_flows
{
    public class home_flowsCreateNewViewModel
    {
        public string name { get; set; }
        public string link { get; set; }
        public string notification_email { get; set; }
        public bool @default { get; set; }
        public string display_email { get; set; }
        public string display_phone { get; set; }
    }
}
