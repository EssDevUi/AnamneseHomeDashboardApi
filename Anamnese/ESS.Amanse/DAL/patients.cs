using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESS.Amanse.DAL
{
    [Table("tblpatients")]

    public class patients
    {
        public patients()
        {
            rejected_in_ds_win = false;
            waiting_for_documents = false;
        }
        [Key]
        public long Id { get; set; }
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
        public string kknr { get; set; }
        [MaxLength(255)]
        public string policy_number { get; set; }
        [MaxLength(255)]
        public string insurance_status { get; set; }
        [MaxLength(255)]
        public string employer { get; set; }
        [MaxLength(255)]
        public string profession { get; set; }
        [MaxLength(255)]
        public string pvs_patid { get; set; }
        [MaxLength(255)]
        public string pvs_name { get; set; }
        [MaxLength(255)]
        public string prxnr { get; set; }
        [MaxLength(255)]
        public string doctor { get; set; }
        public DateTime last_visit { get; set; }
        public DateTime first_displayed_at { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string ds_patid { get; set; }
        public string ds_patnr { get; set; }
        public DateTime last_submitted_at { get; set; }
        public int position { get; set; }
        public string temporary_pat_id { get; set; }
        public bool? rejected_in_ds_win { get; set; }
        public string insured_salutation { get; set; }
        public string insured_title { get; set; }
        public string insured_first_name { get; set; }
        public string insured_last_name { get; set; }
        public DateTime? insured_date_of_birth { get; set; }
        public string insured_address1 { get; set; }
        public string insured_address2 { get; set; }
        public string insured_zipcode { get; set; }
        public string insured_city { get; set; }
        public string insured_country { get; set; }
        public string insured_phone { get; set; }
        public string recall { get; set; }
        public string recall_to { get; set; }
        public bool? waiting_for_documents { get; set; }
    }
}
