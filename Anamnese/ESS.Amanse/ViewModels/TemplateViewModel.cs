using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.ViewModels
{
   public class TemplateViewModel
    {
        public long TemplateId { get; set; }
        public string Name{ get; set; }
        public string Link{ get; set; }
        public string templates { get; set; }
        public bool? DSWin { get; set; }
        public string NotificationEmail { get; set; }
        public string EmailToShowInEmail { get; set; }
        public string PhoneToShowinEmail { get; set; }
    }
}
