using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.ViewModels.MainProfile
{
    public class MainProfileViewModel
    {
        public long? ID { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
