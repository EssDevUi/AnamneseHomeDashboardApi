using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.BLL.Repo;
using ESS.Amanse.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESS.Amanse.BLL.Collection
{
    public class Profile: Repository<Profile>, IProfile
    {
        public Profile(AmanseHomeContext context) : base(context)
        {
        }
        //public Profile getProfileByID(long Id)
        //{
        //   return Find(x=>x.ProfileId==Id);
        //}
        //public string AddorUpdate(TblProfile Model)
        //{
        //    try
        //    {
        //        string msg = string.Empty;
        //        if (Model.ProfileId > 0)
        //        {
        //            var oldProfile  =Find(x=>x.ProfileId==Model.ProfileId);
        //            oldProfile.FirstName = Model.FirstName;
        //            oldProfile.LastName = Model.LastName;
        //            oldProfile.Password = Model.Password;
        //            oldProfile.Salutation = Model.Salutation;
        //            oldProfile.Email = Model.Email;
        //            Update(oldProfile);
        //            msg = "Update";
        //        }
        //        else
        //        {
        //            dbContext.TblProfile.Add(Model);
        //            msg = "Add";
        //        }
        //        Save();
        //        return msg;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }

        //}
    }
}
