using ESS.Amanse.BLL.ICollection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DashboardAPI.Controllers
{
    [ApiController]
    public class anamnesis_flow_submissions : ControllerBase
    {
        private readonly IPatient _Patient;
        private readonly IMedicalHistory _MedicalHistory;
        public anamnesis_flow_submissions(IPatient Patient, IMedicalHistory MedicalHistory)
        {
            _Patient = Patient;
            _MedicalHistory = MedicalHistory;
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
        [Route("api/public/v1/[controller]/imageurl")]
        [HttpGet]
        public ActionResult ConvertBase64image()
        {
            //string path = _hostingEnvironment.WebRootPath + "/images/" + fileName;
            byte[] b = System.IO.File.ReadAllBytes(Request.Headers["imgurl"].ToString());
            string imageBytes = "data:image/png;base64," + Convert.ToBase64String(b);
            // Do something with the file content

            return Ok(imageBytes);
        }
    }
}
