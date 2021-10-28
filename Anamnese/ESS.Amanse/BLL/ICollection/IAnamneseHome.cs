using ESS.Amanse.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.BLL.ICollection
{
    public interface IAnamneseHome
    {
        List<Vorlagen> GetAllTemplateByHomeFloeID(long TemplateID);
    }
}
