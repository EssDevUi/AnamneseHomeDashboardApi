using ESS.Amanse.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.ViewModels.AnamneseHome
{
    public class PatientFormViewModel
    {
        public List<VorlagenForAnamneseHome> document_templates { get; set; }
        public PracticeHomeLink practice { get; set; }
    }
    public class VorlagenForAnamneseHome
    {
        public string id { get; set; }
        public string title { get; set; }
        public string languages { get; set; }
        //public List<string> languages { get; set; }
        public string atn { get; set; }
        public string direction { get; set; }
    }
    public class PracticeHomeLink
    {
        public string name { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string zip_code { get; set; }
        public string city { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string logo_url { get; set; }
        public string website { get; set; }
        public string dgsvo_data_protection_officer_address { get; set; }
        public string dgsvo_data_protection_officer_contact { get; set; }
        public string dgsvo_data_protection_officer_name { get; set; }
        public string dgsvo_factoring_provide { get; set; }
        public bool loaded { get; set; }
    }
}
