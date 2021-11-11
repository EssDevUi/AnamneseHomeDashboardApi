using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.BLL.Repo;
using ESS.Amanse.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESS.Amanse.BLL.Collection
{
    public class Profile : Repository<MainProfile>, IProfile
    {
        public Profile(AmanseHomeContext context) : base(context)
        {
        }
        public MainProfile getProfileByID(long Id)
        {
            return Find(x => x.ID == Id);
        }
        public bool loginUser(string username, string password)
        {
            var data=dbContext.tblMainProfile.Where(x => x.Email == username && x.Password == password).FirstOrDefault();
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string AddorUpdate(MainProfile Model)
        {
            try
            {
                string msg = string.Empty;
                if (Model.ID > 0)
                {
                    var oldProfile = Find(x => x.ID == Model.ID);
                    oldProfile.FirstName = Model.FirstName;
                    oldProfile.LastName = Model.LastName;
                    oldProfile.Password = Model.Password;
                    oldProfile.Salutation = Model.Salutation;
                    oldProfile.Email = Model.Email;
                    Update(oldProfile);
                    msg = "Update";
                }
                else
                {
                    dbContext.tblMainProfile.Add(Model);
                    msg = "Add";
                }
                Save();
                return msg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
