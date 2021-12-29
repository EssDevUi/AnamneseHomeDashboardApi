using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.ViewModels;
using ESS.Amanse.ViewModels.Patient;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DashboardAPI.Controllers
{
    [ApiController]
    public class anamnesis_flow_submissions : ControllerBase
    {
        private readonly IPatient _Patient;
        private readonly IMedicalHistory _MedicalHistory;
        private readonly ICommons _Commons;
        private readonly IPractice _Practice;

        public anamnesis_flow_submissions(IPatient Patient, IMedicalHistory MedicalHistory, ICommons Commons, IPractice Practice)
        {
            _Patient = Patient;
            _MedicalHistory = MedicalHistory;
            _Commons = Commons;
            _Practice = Practice;

        }
        [Route("api/dashboard/v1/[controller]/{id}")]
        [HttpGet]
        public ActionResult GetPatientList(long id)
        {
            var patients = _Patient.GetAllPatient();
            var HISTORY = _MedicalHistory.MedicalHistoryById(id);
            anamnesis_at_home_submissionsViewModel Record = new anamnesis_at_home_submissionsViewModel
            {
                patient_payload = patients.ToList(),
                MedicalHistory = HISTORY
            };
            //anamnesis_at_home_submissionsViewModel Record = JsonConvert.DeserializeObject<anamnesis_at_home_submissionsViewModel>(System.IO.File.ReadAllText("anamnesis_flow_submissions/anamnese_flow_submition_detail.json"));
            //string data = JsonConvert.SerializeObject(Record);

            return Ok(Record);
        }
        [Route("api/dashboard/v1/[controller]/{historyid}")]
        [HttpPatch]
        public ActionResult AssignPatientToMedicalHistroy(long historyid)
        {
            long PatientID = long.Parse(HttpContext.Request.Headers["RequestPayload"]);
            _MedicalHistory.AssignPatientToMedicalHistroy(historyid, PatientID);

            var patients = _Patient.GetAllPatient();
            var HISTORY = _MedicalHistory.MedicalHistoryById(historyid);
            anamnesis_at_home_submissionsViewModel Record = new anamnesis_at_home_submissionsViewModel
            {
                patient_payload = patients.ToList(),
                MedicalHistory = HISTORY
            };

            return Ok(Record);
        }

        [Route("api/public/v1/[controller]")]
        [HttpPost]
        public ActionResult PatientForm()
        {
            var data = Request.Headers["formData"];
            JObject json = JObject.Parse(data);
            var patientID = _MedicalHistory.CreateMedicalHistroy(json["patient"]["first_name"].ToString(), json["patient"]["last_name"].ToString(), Convert.ToDateTime(json["patient"]["date_of_birth"]), json["document_payloads"].ToString(), json["token"].ToString());
            return Ok();
        }
        [Route("api/public/v1/[controller]/PatientDetail")]
        [HttpPost]
        public ActionResult PatientDetailForm()
        {
            var data = Request.Headers["formData"];
            var obj = JsonConvert.DeserializeObject<Root>(data);
            JObject json = JObject.Parse(data);
            long patientid = _MedicalHistory.CreatePatientMedicalHistroy(obj, json["document_payloads"].ToString(), json["token"].ToString());
            if (patientid > 0)
            {
                return Ok(new { navigateto = _Practice.getPractice(1).NavigateTo, ptid = patientid });
            }
            else
            {
                return Ok(patientid);
            }
        }
        [Route("api/public/v1/[controller]/imageonServer")]
        [HttpGet]
        public ActionResult ConvertBase64image()
        {
            //string path = _hostingEnvironment.WebRootPath + "/images/" + fileName;
            byte[] b = System.IO.File.ReadAllBytes(Request.Headers["imageonServer"].ToString());
            string imageBytes = "data:image/png;base64," + Convert.ToBase64String(b);
            // Do something with the file content

            return Ok(imageBytes);
        }
        [Route("api/public/v1/[controller]/imageurl")]
        [HttpGet]
        public async Task<ActionResult> downloadAndConvertBase64image()
        {
            string imageBytes = "";
            //string path = _hostingEnvironment.WebRootPath + "/images/" + fileName;
            using (var client = new HttpClient())
            {
                var bytes = await client.GetByteArrayAsync(Request.Headers["imgurl"].ToString()); // there are other methods if you want to get involved with stream processing etc
                imageBytes = "data:image/png;base64," + Convert.ToBase64String(bytes);
                //return base64String;
            }
            //byte[] b = System.IO.File.ReadAllBytes(Request.Headers["imgurl"].ToString());
            //string imageBytes = "data:image/png;base64," + Convert.ToBase64String(b);
            // Do something with the file content

            return Ok(imageBytes);
        }
        [Route("api/public/v1/[controller]/saveimage")]
        [HttpPost]
        public IActionResult SaveImage(practice_logoViewModel model)// use moel only to get image
        {
            Guid imageName = Guid.NewGuid();
            model.Logo = _Commons.SaveImage(model.Logo.Replace("data:image/png;base64,", ""), imageName.ToString());
            return Ok(model.Logo);
        }
       
    }
}
