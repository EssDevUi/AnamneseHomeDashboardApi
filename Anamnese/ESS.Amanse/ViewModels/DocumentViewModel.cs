using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.ViewModels
{
    public class DocumentViewModel
    {
        public long DocumentId { get; set; }
        public string Title { get; set; }
        public string DocumentType { get; set; }
        public string CreatedOn { get; set; }
        public string State { get; set; }
    }
}
