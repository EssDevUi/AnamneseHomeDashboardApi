using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.BLL.Repo;
using ESS.Amanse.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESS.Amanse.BLL.Collection
{
    public class AnamneseHomeCollection : Repository<HomeflowTemplates>, IAnamneseHome
    {
        public AnamneseHomeCollection(AmanseHomeContext context) : base(context)
        {
        }
        public List<Vorlagen> GetAllTemplateByHomeFloeID(long TemplateID)
        {
            var data = (from HomeflowTemplates in dbContext.tblHomeflowTemplates.ToList()
                        join Templates in dbContext.tblVorlagen.ToList() on HomeflowTemplates.VorlagenID equals Templates.id
                        //join HomeFlow in dbContext.tblanamnesis_at_home_flow.ToList() on HomeflowTemplates.anamnesis_at_home_flowID equals HomeFlow.id
                        where HomeflowTemplates.anamnesis_at_home_flowID == TemplateID
                        select Templates).ToList();
            return data;
        }
        public List<Vorlagen> GetAllTemplateByIDs(List<long> TemplateIds)
        {
            var data = (from Templates in dbContext.tblVorlagen.ToList()
                        where TemplateIds.Contains(Templates.id)
                        select Templates).ToList();
            return data;
        }
    }
}
