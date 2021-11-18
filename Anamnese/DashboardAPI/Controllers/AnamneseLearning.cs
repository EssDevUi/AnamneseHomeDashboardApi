using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.ViewModels.AnamneseHome;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private readonly IMedicalHistory _MedicalHistory;

        public AnamneseLearning(IPatient Patient, ITemplates Templates, IMedicalHistory MedicalHistory)
        {
            _Patient = Patient;
            _Templates = Templates;
            _MedicalHistory = MedicalHistory;

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
        public IActionResult GetOwntemplate() //used for Aufklarungsbogen catgory 2
        {
            var List = _Templates.GetAllTemplatesC12().Where(x => x.@default == false && x.template_category_id == 2).ToList();
            return Ok(List);
        }
        [Route("api/[controller]/systemtemplates")]
        [HttpGet]
        public IActionResult Getsystemtemplate() //used for Aufklarungsbogen catgory 2
        {
            var List = _Templates.GetAllTemplatesC12().Where(x => x.@default == true && x.template_category_id == 2).ToList();
            return Ok(List);
        }
        [Route("api/[controller]/OwnAnamnesetemplate")]
        [HttpGet]
        public IActionResult GetOwnAnamnesetemplate() //used for Anamnesesbogen catgory 1
        {
            var List = _Templates.GetAllTemplatesC12().Where(x => x.@default == false && x.template_category_id == 1).ToList();
            return Ok(List);
        }
        [Route("api/[controller]/systemAnamnesetemplate")]
        [HttpGet]
        public IActionResult GetsystemAnamnesetemplate() //used for Anamnesesbogen catgory 1
        {
            var List = _Templates.GetAllTemplatesC12().Where(x => x.@default == true && x.template_category_id == 1).ToList();
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
        [Route("api/public/v1/[controller]/submittemplate/{patientId}")]
        [HttpPost]
        public ActionResult PatientForm(long patientId)
        {
            var patient = _Patient.GetPatientById(patientId);
            var data = Request.Headers["formData"];
            JObject json = JObject.Parse(data);
            var patientID = _MedicalHistory.CreateMedicalHistroyAnamneseLearning(patient.PatientID,patient.FirstName, patient.SurName, Request.Headers["title"].ToString(), Convert.ToDateTime(patient.DateOFBirth), json["document_payloads"].ToString(), json["token"].ToString(), Convert.ToBoolean(Request.Headers["draft"]));
            return Ok();
        }
        [Route("api/public/v1/[controller]/summary/{MedicalHistoryId}")]
        [HttpPost]
        public ActionResult Patientsummary(long MedicalHistoryId)
        {
            var history = _MedicalHistory.MedicalHistoryByIdForSummary(MedicalHistoryId);
            var patient = JsonConvert.SerializeObject(_Patient.GetPatient(history.pvs_patid));
            history.patient_payload = patient;
            history.document_payloads= JsonConvert.SerializeObject(_Templates.GetTemplateById(long.Parse(history.token)));
            return Ok();
        }
        [Route("api/[controller]/documents/{patientId}")]
        [HttpGet]
        public ActionResult Patientdocuments(long patientId)
        {
            var history = _MedicalHistory.MedicalHistoryByPatientId(patientId);
            return Ok(history);
        }
    }
}
