using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.DAL;
using ESS.Amanse.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace DashboardAPI.Controllers
{
    [ApiController]
    public class anamnisis_home_practice : ControllerBase
    {
        private readonly ICommons _Commons;
        private readonly IPractice _Practice;
        public anamnisis_home_practice(ICommons Commons, IPractice Practice)
        {
            _Practice = Practice;
            _Commons = Commons;
        }
        [Route("external/practice")]
        [HttpGet]
        public string GetAllpracticedata()
        {

            return "Profile data received from API...";
        }
        [Route("external/practice")]
        [HttpPost]
        public string Post()
        {
            dynamic JsonFormData = JObject.Parse(HttpContext.Request.Headers["data"]);
            practice Practice = new practice();
            Practice.Adress1 = JsonFormData.Adress1;
            Practice.Adress2 = JsonFormData.Adress2;
            Practice.AllowPriviousEntry = JsonFormData.AllowPriviousEntry;
            Practice.BlockingPassword = JsonFormData.BlockingPassword;

            Practice.BugReports = JsonFormData.BugReports;
            Practice.BugReportTime = JsonFormData.BugReportTime;
            Practice.City = JsonFormData.City;
            Practice.DangerZonePassword = JsonFormData.DangerZonePassword;
            Practice.Email = JsonFormData.Email;

            Guid imageName = Guid.NewGuid();
            Practice.Logo = _Commons.SaveImage(JsonFormData.Logo.Value, imageName.ToString());
            Practice.Name = JsonFormData.Name;
            Practice.NavigateTo = JsonFormData.NavigateTo;
            Practice.Phone = JsonFormData.Phone;
            Practice.PostCode = JsonFormData.PostCode;
            Practice.sendanalyticsdata = JsonFormData.Sendanalyticsdata;
            Practice.Website = JsonFormData.Website;
            string message = _Practice.AddorUpdate(Practice);
            return "Data Post Successfully...";

        }
        [Route("external/welcome_wizard/practice_data")]
        [HttpGet]
        public practice Getpracticedata(long Id)
        {
            return _Practice.getPractice(Id);
        }
        [Route("external/welcome_wizard/practice_data")]
        [HttpPost]
        public string Postpracticedata(practice_dataViewModel model)
        {
            _Practice.AddorUpdatepracticedata(model);

            return "practice data save...";
        }
        [Route("external/welcome_wizard/practice_logo")]
        [HttpGet]
        public string Getpractice_logo(long Id)
        {
            var data = _Practice.getPractice(Id);
         
            byte[] imageArray = System.IO.File.ReadAllBytes(data.Logo);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);


            return base64ImageRepresentation;
        }
        [Route("external/welcome_wizard/practice_logo")]
        [HttpPost]
        public string practice_logo(practice_logoViewModel model)
        {
            //dynamic JsonFormData = JObject.Parse(HttpContext.Request.Headers["data"]);
            Guid imageName = Guid.NewGuid();
            model.Logo = _Commons.SaveImage(model.Logo.Replace("data:image/png;base64,", ""), imageName.ToString());

            _Practice.AddorUpdatepractice_logo(model);
            return "practice Logo save...";
        }
        [Route("external/welcome_wizard/anamnesis_pin")]
        [HttpGet]
        public string Getanamnesis_pin()
        {

            return "practice Danger zone password received from API...";
        }
        [Route("external/welcome_wizard/anamnesis_pin")]
        [HttpPost]
        public string anamnesis_pin(anamnesis_pinViewModel model)
        {
            //dynamic JsonFormData = JObject.Parse(HttpContext.Request.Headers["data"]);
            return "practice Danger zone password save...";
        }
        [Route("external/welcome_wizard/app_options")]
        [HttpGet]
        public string getapp_options(long Id)
        {

            return "App options received from API...";
        }
        [Route("external/welcome_wizard/app_options")]
        [HttpPost]
        public string app_options(app_optionsViewModel model)
        {
            //dynamic JsonFormData = JObject.Parse(HttpContext.Request.Headers["data"]);
            _Practice.AddorUpdateapp_options(model);
            return "App options save...";
        }
    }
}
