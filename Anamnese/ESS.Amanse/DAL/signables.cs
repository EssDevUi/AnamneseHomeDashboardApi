using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESS.Amanse.DAL
{
    [Table("tblsignables")]

    public class signables
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        public string folder_path { get; set; }
        public int pages { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string ds_patnr { get; set; }
    }
}
