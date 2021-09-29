using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.DAL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json;


namespace DashboardAPI.Controllers
{
    [ApiController]
    public class profile : ControllerBase
    {
        private readonly IProfile _Profile;
        public profile(IProfile Profile)
        {
            _Profile = Profile;
        }

        [Route("external/[controller]/{id}")]
        [HttpGet]
        public string Get(long id)
        {
            //var profile = _Profile.getProfileByID(id);
            return JsonSerializer.Serialize("s"/*profile*/);
        }

        [Route("external/[controller]")]
        [HttpPost]
        public void Post(string Salutation, string firstName , string LastName, string Email , string Password )
        {
            //dynamic JsonFormData = JObject.Parse(HttpContext.Request.Headers["data"]);
            //TblProfile Profile = new TblProfile();
            //Profile.ProfileId = JsonFormData.ProfileID;
            //Profile.Salutation = JsonFormData.Salutation;
            //Profile.FirstName = JsonFormData.Fname;
            //Profile.LastName = JsonFormData.LastName;
            //Profile.Email= JsonFormData.Email;
            //Profile.Password= JsonFormData.Password;
            //_Profile.AddorUpdate(Profile);
        }

    }
}
