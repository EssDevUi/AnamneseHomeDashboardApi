using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.BLL.Repo;
using ESS.Amanse.DAL;
using ESS.Amanse.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESS.Amanse.BLL.Collection
{
    public class Document : Repository<documents>, IDocument
    {
        public Document(AmanseHomeContext context) : base(context)
        {
        }
        //public IEnumerable<DocumentViewModel> GetAllDocument()
        //{

        //    var List = Include(x => x.DocumentType).Include(x => x.State).Select(x => new DocumentViewModel
        //    {
        //        DocumentId = x.DocumentId,
        //        Title = x.Title,
        //        DocumentType = x.DocumentType.DocumentType,
        //        CreatedOn = x.CreatedOn,
        //        State = x.State.State

        //    }).ToList();
        //    return List;
        //}
    }
}
