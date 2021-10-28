using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.BLL.Repo;
using ESS.Amanse.DAL;
using ESS.Amanse.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace ESS.Amanse.BLL.Collection
{
    public class Document : Repository<documents>, IDocument
    {
        public Document(AmanseHomeContext context) : base(context)
        {
        }
        public IEnumerable<DocumentViewModel> GetAllDocument()
        {

            var List = dbContext.tbldocuments.Include(x => x.patient).Include(x => x.tblAbnormalities).Select(x => new DocumentViewModel
            {
                id = x.id,
                title = x.title,
                type = x.type,
                timestamp = x.created_at,
                anamnesis_report = x.tblAbnormalities.ToList(),
                DT_RowId = x.id,
                path_to_pdf = x.path_to_pdf,
                patient_name = x.patient.first_name + x.patient.last_name
            }).ToList();
            return List;
        }
    }
}
