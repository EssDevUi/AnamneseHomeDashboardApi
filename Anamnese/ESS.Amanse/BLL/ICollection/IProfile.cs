using ESS.Amanse.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.BLL.ICollection
{
    public interface IProfile
    {

        MainProfile getProfileByID(long Id);
        string AddorUpdate(MainProfile Model);
    }
}
