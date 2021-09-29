using ESS.Amanse.DAL;
using ESS.Amanse.ViewModels.anamnesis_at_home_flows;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.BLL.ICollection
{
    public interface IAnamnesisAtHomeFlows
    {
        IEnumerable<anamnesis_at_home_flow> GetAll();
        anamnesis_at_home_flow GetByID(long Id);
        bool UpdateAFlow(anamnesis_at_home_flow model);
        string AddAFlow(home_flowsCreateNewViewModel model);
    }
}
