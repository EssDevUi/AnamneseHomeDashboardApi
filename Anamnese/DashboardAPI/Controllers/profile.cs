using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.DAL;
using ESS.Amanse.ViewModels.MainProfile;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json;


namespace DashboardAPI.Controllers
{
    [ApiController]
    //[EnableCors("MyAllowSpecificOrigins")]
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
            var profile = _Profile.getProfileByID(id);
            return JsonSerializer.Serialize(profile);
        }

        [Route("external/[controller]")]
        [HttpPost]
        public void Post(MainProfileViewModel model)
        {
            MainProfile profile = new MainProfile();
            profile.ID = model.ID != null ? model.ID.Value : 0;
            profile.FirstName = model.FirstName;
            profile.LastName = model.LastName;
            profile.Password = model.Password;
            profile.Salutation = model.Salutation;
            profile.Email = model.Email;
            _Profile.AddorUpdate(profile);
        }

    }
}
