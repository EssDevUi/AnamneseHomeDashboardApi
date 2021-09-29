using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.BLL.Repo;
using ESS.Amanse.DAL;
using ESS.Amanse.ViewModels.anamnesis_at_home_flows;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESS.Amanse.BLL.Collection
{
    public class AnamnesisAtHomeFlows : Repository<anamnesis_at_home_flow>, IAnamnesisAtHomeFlows
    {
        public AnamnesisAtHomeFlows(AmanseHomeContext context) : base(context)
        {
        }
        public IEnumerable<anamnesis_at_home_flow> GetAll()
        {
            return dbContext.tblanamnesis_at_home_flow.Include(x => x.HomeflowTemplates).ThenInclude(x => x.Vorlagen).ToList();
        }
        public anamnesis_at_home_flow GetByID(long Id)
        {
            return dbContext.tblanamnesis_at_home_flow.Include(x=>x.HomeflowTemplates).ThenInclude(x=>x.Vorlagen).Where(x => x.id == Id).FirstOrDefault();
        }
        public string AddAFlow(home_flowsCreateNewViewModel model)
        {
            try
            {
                anamnesis_at_home_flow obj = new anamnesis_at_home_flow();
                obj.@default = model.@default;
                obj.display_email = model.display_email;
                obj.display_phone = model.display_phone;
                obj.link = model.link;
                obj.name = model.name;
                obj.notification_email = model.notification_email;
                dbContext.tblanamnesis_at_home_flow.Add(obj);
                dbContext.SaveChanges();
                return "Home Link Add Successfully...";
            }
            catch (Exception)
            {
                return "Something went wrong...";
            }

        }
        public bool UpdateAFlow(anamnesis_at_home_flow model)
        {
            //var olrRecord = dbContext.tblanamnesis_at_home_flow.Find(model.id);
            //olrRecord.@default = model.@default;
            //olrRecord.display_email = model.display_email;
            //olrRecord.display_phone= model.display_phone;
            //olrRecord.link= model.link;
            //olrRecord.name= model.name;
            //olrRecord.notification_email= model.notification_email;
            try
            {
                dbContext.tblanamnesis_at_home_flow.Update(model);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
