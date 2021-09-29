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
    public class anamnesis_flow_submissions : ControllerBase
    {
        [Route("api/dashboard/v1/[controller]/{id}")]
        [HttpGet]
        public ActionResult GetPatientList(string id)
        {

            anamnesis_at_home_submissionsViewModel Record = JsonConvert.DeserializeObject<anamnesis_at_home_submissionsViewModel>(System.IO.File.ReadAllText("anamnesis_flow_submissions/anamnese_flow_submition_detail.json"));
            string data = JsonConvert.SerializeObject(Record);
          
            return Ok(data);
        }
        [Route("api/dashboard/v1/[controller]/{id}")]
        [HttpPatch]
        public ActionResult PatchPatient(string id)
        {
            var a=HttpContext.Request.Headers["RequestPayload"];

            anamnesis_at_home_submissionsViewModel Record = JsonConvert.DeserializeObject<anamnesis_at_home_submissionsViewModel>(System.IO.File.ReadAllText("anamnesis_flow_submissions/anamnese_flow_submition_detail.json"));
            Record.PvsPatid = a[0];
            string data = JsonConvert.SerializeObject(Record);
          
            return Ok(data);
        }

    }
}
