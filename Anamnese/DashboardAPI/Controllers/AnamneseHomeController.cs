using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.DAL;
using ESS.Amanse.ViewModels.AnamneseHome;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardAPI.Controllers
{
    [ApiController]
    public class AnamneseHomeController : ControllerBase
    {
        private readonly IAnamneseHome _AnamneseHome;
        private readonly IPractice _Practice;
        public AnamneseHomeController(IAnamneseHome AnamneseHome, IPractice Practice)
        {
            _AnamneseHome = AnamneseHome;
            _Practice = Practice;
        }

        [Route("api/v1/AnamneseHome/{TemplateID}")]
        [HttpGet]
        public IActionResult Index(long TemplateID)
        {
            PatientFormViewModel model = new PatientFormViewModel();
            model.document_templates = new List<VorlagenForAnamneseHome>();
            var templates = _AnamneseHome.GetAllTemplateByHomeFloeID(TemplateID);
            var practice = _Practice.getPractice(1);
            PracticeHomeLink pr = new PracticeHomeLink();
            pr.name = practice.Name;
            pr.address1 = practice.Adress1;
            pr.address2 = practice.Adress2;
            pr.zip_code = "";
            pr.city = practice.City;
            pr.email = practice.Email;
            pr.phone = practice.Phone;
            pr.logo_url =  practice.Logo;
            pr.website = practice.Website;
            pr.dgsvo_data_protection_officer_address = "";
            pr.dgsvo_data_protection_officer_contact = "";
            pr.dgsvo_data_protection_officer_name = "";
            pr.dgsvo_factoring_provide = "";
            pr.loaded = false;

            model.practice = pr;

            foreach (var item in templates)
            {
                VorlagenForAnamneseHome vor = new VorlagenForAnamneseHome();
                vor.id = item.id.ToString();
                vor.languages = item.languages;
                //vor.languages = null;
                vor.title = item.templates;
                //vor.atn = null;
                vor.atn = item.atn_v2;
                model.document_templates.Add(vor);
            }
            return Ok(model);
        }



    }
}
