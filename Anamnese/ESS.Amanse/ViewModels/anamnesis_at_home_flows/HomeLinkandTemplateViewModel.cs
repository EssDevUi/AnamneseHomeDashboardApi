using ESS.Amanse.ViewModels.Vorlagen;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.ViewModels.anamnesis_at_home_flows
{
    public class HomeLinkandTemplateViewModel
    {
        public anamnesis_at_home_flowsViewModel anamnesis_at_home_flows { get; set; }
        public IEnumerable<VorlegenForEditHomeLinkViewModel> VorlegenForEditHomeLink { get; set; }
    }
}
