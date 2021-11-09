using ESS.Amanse.BLL.ICollection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardAPI.Controllers
{
    [ApiController]
    public class AnamneseLearning : ControllerBase
    {
        private readonly IPatient _Patient;

        public AnamneseLearning(IPatient Patient)
        {
            _Patient = Patient;

        }
        [Route("api/[controller]")]
        [HttpGet]
        public ActionResult GetPatientList()
        {
            var patients = _Patient.GetAllPatient();

            return Ok(patients);
        }
    }
}
