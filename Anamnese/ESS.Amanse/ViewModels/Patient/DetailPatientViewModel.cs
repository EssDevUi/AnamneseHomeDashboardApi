using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ESS.Amanse.ViewModels.Patient
{
    public class Patient
    {
        [MaxLength(255)]
        public string first_name { get; set; }
        [MaxLength(255)]
        public string last_name { get; set; }
        public DateTime date_of_birth { get; set; }
        [MaxLength(255)]
        public string salutation { get; set; }
        [MaxLength(255)]
        public string title { get; set; }
        [MaxLength(255)]
        public string gender { get; set; }
        [MaxLength(255)]
        public string address1 { get; set; }
        [MaxLength(255)]
        public string address2 { get; set; }
        [MaxLength(255)]
        public string zipcode { get; set; }
        [MaxLength(255)]
        public string city { get; set; }
        [MaxLength(255)]
        public string country { get; set; }
        [MaxLength(255)]
        public string home_phone { get; set; }
        [MaxLength(255)]
        public string work_phone { get; set; }
        [MaxLength(255)]
        public string cellular_phone { get; set; }
        [MaxLength(255)]
        public string fax { get; set; }
        [MaxLength(255)]
        public string email { get; set; }
        [MaxLength(255)]
        public string insurance_status { get; set; }
        public string insured_salutation { get; set; }
        public string insured_title { get; set; }
        public string insured_first_name { get; set; }
        public string insured_last_name { get; set; }
        public DateTime insured_date_of_birth { get; set; }
        public string insured_address1 { get; set; }
        public string insured_address2 { get; set; }
        public string insured_zipcode { get; set; }
        public string insured_city { get; set; }
        public string insured_country { get; set; }
        public string insured_phone { get; set; }
       
    }
    public class Root
    {
        public Patient patient { get; set; }
       
    }
}
