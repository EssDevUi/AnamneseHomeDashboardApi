using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.ViewModels.AnamneseHome;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardAPI.Controllers
{
    [ApiController]
    [Authorize]
    public class AnamneseLearning : ControllerBase
    {
        private readonly IPatient _Patient;
        private readonly ITemplates _Templates;

        public AnamneseLearning(IPatient Patient, ITemplates Templates)
        {
            _Patient = Patient;
            _Templates = Templates;

        }
        [Route("api/[controller]")]
        [HttpGet]
        public ActionResult GetPatientList()
        {
            var patients = _Patient.GetAllPatient();

            return Ok(patients);
        }

        [Route("api/[controller]/owntemplates")]
        [HttpGet]
        public IActionResult GetOwntemplate() //used
        {
            var List = _Templates.GetAllTemplatesC12().Where(x => x.@default == false).ToList();
            return Ok(List);
        }
        [Route("api/[controller]/systemtemplates")]
        [HttpGet]
        public IActionResult Getsystemtemplate() //used
        {
            var List = _Templates.GetAllTemplatesC12().Where(x => x.@default == true).ToList();
            return Ok(List);
        }

        [Route("api/v1/[controller]/{TemplateID}")]
        [HttpGet]
        public IActionResult gettemplate(long TemplateID)
        {
            PatientFormViewModel model = new PatientFormViewModel();
            model.document_templates = new List<VorlagenForAnamneseHome>();
            var templates = _Templates.GetTemplateById(TemplateID);
            PracticeHomeLink pr = new PracticeHomeLink();
            pr.name = "ESS";
            pr.address1 = "ESS";
            pr.address2 = "ESS";
            pr.zip_code = "";
            pr.city = "ESS";
            pr.email = "ESS";
            pr.phone = "ESS";
            pr.logo_url = "ESS";
            pr.website = "ESS";
            pr.dgsvo_data_protection_officer_address = "";
            pr.dgsvo_data_protection_officer_contact = "";
            pr.dgsvo_data_protection_officer_name = "";
            pr.dgsvo_factoring_provide = "";
            pr.loaded = false;

            model.practice = pr;
            VorlagenForAnamneseHome vor = new VorlagenForAnamneseHome();
            vor.id = templates.id.ToString();
            vor.languages = templates.languages;
            //vor.languages = null;
            vor.title = templates.templates;
            //vor.atn = null;
            vor.atn = templates.atn_v2;
            model.document_templates.Add(vor);
            return Ok(model);
        }
    }
}
