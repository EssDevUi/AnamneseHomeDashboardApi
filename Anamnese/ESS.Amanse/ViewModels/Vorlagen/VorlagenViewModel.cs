using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.ViewModels.Vorlagen
{
    public class VorlagenViewModel
    {
        public long id { get; set; }
        public int SortIndex { get; set; }
        public string templates { get; set; }
        public long? HomeflowTemplatesID { get; set; }
    }

}
