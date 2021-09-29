using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.ViewModels
{
    public class app_optionsViewModel
    {
        public long Id { get; set; }
        public bool AllowPriviousEntry { get; set; }
        public bool BlockingPassword { get; set; }
        public bool BugReports { get; set; }
        public string BugReportTime { get; set; }
        public string NavigateTo { get; set; }
        public string authenticity_token { get; set; }
        public bool Sendanalyticsdata { get; set; }

    }
}
