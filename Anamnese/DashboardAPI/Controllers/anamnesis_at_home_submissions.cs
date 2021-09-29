using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;

namespace DashboardAPI.Controllers
{
    [ApiController]
    //[Authorize]

    public class anamnesis_at_home_submissions : ControllerBase
    {
        private readonly IPatient _Patient;
        public anamnesis_at_home_submissions(IPatient Patient)
        {
            _Patient = Patient;
        }
        [Route("external/[controller]")]
        [HttpGet]
        public IActionResult Get()
        {
            string json = "";

            foreach (string fileName in Directory.GetFiles("api_-_dashboard_-_v1_-_anamnesis_flow_submissions", "api_-_dashboard_-_v1_-_anamnesis_flow_submissions_-_20975_GET.json"))
            {
                using (StreamReader r = new StreamReader(fileName))
                {
                    string jsonfile = r.ReadToEnd();
                    var jsonObject = JsonConvert.DeserializeObject(jsonfile);
                    json=JsonConvert.SerializeObject(jsonObject);
                }
                // Do something with the file content
            }
            return Ok(json);
        }
        [Route("api/v1/[controller]/fetch")]
        [HttpPost]
        public IActionResult fetch()
        {
            string json = "{\"job_id\":\"9950ee580a67463cc4425afc\",\"status\":\"ok\"}";
           
            return Ok(json);
        }
        
    }
}
