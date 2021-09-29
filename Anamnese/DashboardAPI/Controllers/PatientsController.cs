using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
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
    public class PatientsController : ControllerBase
    {
        //[EnableCors("MyPolicy")]
        [Route("api/v1/[controller]/limit={limit}")]
        [HttpOptions]
        public ActionResult Get(int limit)
        {
            //string record=System.IO.File.ReadAllText("Patients/Patient24090.json");
            //List<string> PatientsList = new List<string>();
            //dynamic stuff = JObject.Parse(RawPatientsData);
            //foreach (var item in stuff.data)
            //{
            //    dynamic Patient = new System.Dynamic.ExpandoObject();
            //    Patient.id = item.id;
            //    Patient.patient_name = item.patient_name;
            //    PatientsList.Add(JsonConvert.SerializeObject(Patient));
            //}

            var RawPatientsData = System.IO.File.ReadAllText("PatientsRecord/PatientsList.json");
            return Ok(RawPatientsData);
        }
    }
}
