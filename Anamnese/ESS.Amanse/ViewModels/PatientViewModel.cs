﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.ViewModels
{
    public class PatientViewModel
    {
        public long PatientID { get; set; }
        public string MedicalHistoryLink { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string DateOFBirth { get; set; }
        public string ReceivedOn { get; set; }
        public long? PatientNumber { get; set; }
    }
}
