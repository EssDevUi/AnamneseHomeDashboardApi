using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.BLL.Repo;
using ESS.Amanse.DAL;
using ESS.Amanse.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.BLL.Collection
{
    public class Practice : Repository<practice>, IPractice
    {
        public Practice(AmanseHomeContext context) : base(context)
        {
        }
        public practice getPractice(long Id)
        {
            try
            {
                return dbContext.tblpractice.Find(Id);

            }
            catch (Exception r)
            {

                throw;
            }
    
        }
        public string AddorUpdate(practice Model)
        {
            try
            {
                string msg = string.Empty;
                if (Model.id > 0)
                {
                    var oldProfile = Find(x => x.id == Model.id);
                    oldProfile.Adress1 = Model.Adress1;
                    oldProfile.Adress2 = Model.Adress2;
                    oldProfile.AllowPriviousEntry = Model.AllowPriviousEntry;
                    oldProfile.BlockingPassword = Model.BlockingPassword;
                    oldProfile.BugReports = Model.BugReports;
                    oldProfile.BugReportTime = Model.BugReportTime;
                    oldProfile.City = Model.City;
                    oldProfile.DangerZonePassword = Model.DangerZonePassword;
                    oldProfile.Email = Model.Email;
                    oldProfile.Logo = Model.Logo;
                    oldProfile.Name = Model.Name;
                    oldProfile.NavigateTo = Model.NavigateTo;
                    oldProfile.Phone = Model.Phone;
                    oldProfile.PostCode = Model.PostCode;
                    oldProfile.sendanalyticsdata = Model.sendanalyticsdata;
                    oldProfile.Website = Model.Website;
                    Update(oldProfile);
                    msg = "Update";
                }
                else
                {
                    dbContext.tblpractice.Add(Model);
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

        public string AddorUpdatepracticedata(practice_dataViewModel Model)
        {
            try
            {
                string msg = string.Empty;
                if (Model.Id > 0)
                {
                    var oldProfile = Find(x => x.id == Model.Id);
                    oldProfile.Adress1 = Model.Adress1;
                    oldProfile.Adress2 = Model.Adress2;
                    oldProfile.City = Model.City;
                    oldProfile.Email = Model.Email;
                    oldProfile.Name = Model.Name;
                    oldProfile.Phone = Model.Phone;
                    oldProfile.PostCode = Model.PostCode;
                    oldProfile.Website = Model.Website;
                    Update(oldProfile);
                    msg = "Update";
                }
                else
                {
                    practice p = new practice();
                    p.Adress1 = Model.Adress1;
                    p.Adress2 = Model.Adress2;
                    p.City = Model.City;
                    p.Email = Model.Email;
                    p.Name = Model.Name;
                    p.Phone = Model.Phone;
                    p.PostCode = Model.PostCode;
                    p.Website = Model.Website;

                    dbContext.tblpractice.Add(p);
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
        public string AddorUpdatepractice_logo(practice_logoViewModel Model)
        {
            try
            {
                string msg = string.Empty;
                if (Model.Id > 0)
                {
                    var oldProfile = Find(x => x.id == Model.Id);
                    oldProfile.Logo = Model.Logo;
                    Update(oldProfile);
                    msg = "Logo Update Successfully";
                }
                else
                {
                    practice p = new practice();
                    p.Logo = Model.Logo;
                    dbContext.tblpractice.Add(p);
                    msg = "Logo Add Successfully";
                }
                Save();
                return msg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string AddorUpdateapp_options(app_optionsViewModel Model)
        {
            try
            {
                string msg = string.Empty;
                if (Model.Id > 0)
                {
                    var oldProfile = Find(x => x.id == Model.Id);
                    oldProfile.AllowPriviousEntry = Model.AllowPriviousEntry;
                    oldProfile.BlockingPassword = Model.BlockingPassword;
                    oldProfile.BugReports = Model.BugReports;
                    oldProfile.NavigateTo = Model.NavigateTo;
                    Update(oldProfile);
                    msg = "App_options Update Successfully";
                }
                else
                {
                    practice p = new practice();
                    p.AllowPriviousEntry = Model.AllowPriviousEntry;
                    p.BlockingPassword = Model.BlockingPassword;
                    p.BugReports = Model.BugReports;
                    p.NavigateTo = Model.NavigateTo;

                    dbContext.tblpractice.Add(p);
                    msg = "App_options Add Successfully";
                }
                Save();
                return msg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string AddorUpdateanamnesis_pin(anamnesis_pinViewModel Model)
        {
            try
            {
                string msg = string.Empty;
                if (Model.Id > 0)
                {
                    var oldProfile = Find(x => x.id == Model.Id);
                    oldProfile.DangerZonePassword = Model.DangerZonePassword;
                    Update(oldProfile);
                    msg = "Dangerzone Password Update Successfully";
                }
                else
                {
                    practice p = new practice();
                    p.DangerZonePassword = Model.DangerZonePassword;

                    dbContext.tblpractice.Add(p);
                    msg = "Dangerzone Password Add Successfully";
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
