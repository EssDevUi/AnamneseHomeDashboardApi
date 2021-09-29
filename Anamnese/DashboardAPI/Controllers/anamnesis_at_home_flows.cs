using AutoMapper;
using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.DAL;
using ESS.Amanse.ViewModels;
using ESS.Amanse.ViewModels.anamnesis_at_home_flows;
using ESS.Amanse.ViewModels.Vorlagen;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace DashboardAPI.Controllers
{
    [ApiController]
    // [Authorize]
    public class anamnesis_at_home_flows : ControllerBase
    {

        private readonly ITemplates _Templates;
        private readonly IAnamnesisAtHomeFlows _AnamnesisAtHomeFlows;
        private readonly IMapper _Mapper;
        public anamnesis_at_home_flows(ITemplates Templates, IAnamnesisAtHomeFlows AnamnesisAtHomeFlows, IMapper Mapper)
        {
            _Mapper = Mapper;
            _Templates = Templates;
            _AnamnesisAtHomeFlows = AnamnesisAtHomeFlows;
        }
        [Route("external/[controller]")]
        [HttpGet]
        public IActionResult Get() //used
        {
            var List = _AnamnesisAtHomeFlows.GetAll().ToList();
            List<anamnesis_at_home_flowsViewModel> model = new List<anamnesis_at_home_flowsViewModel>();
            foreach (var item in List)
            {
                List<VorlagenViewModel> templateList = new List<VorlagenViewModel>();
                foreach (var temp in item.HomeflowTemplates)
                {
                    VorlagenViewModel tempobj = new VorlagenViewModel();
                    tempobj.id = temp.Vorlagen.id;
                    tempobj.SortIndex = temp.Vorlagen.SortIndex;
                    tempobj.templates = temp.Vorlagen.templates;
                    templateList.Add(tempobj);
                }
                anamnesis_at_home_flowsViewModel obj = new anamnesis_at_home_flowsViewModel
                {
                    @default = item.@default,
                    display_email = item.display_email,
                    display_phone = item.display_phone,
                    id = item.id,
                    link = item.link,
                    name = item.name,
                    notification_email = item.notification_email,
                    Vorlagen = templateList.OrderBy(x => x.SortIndex).ToList()
                };
                model.Add(obj);
            }

            return Ok(model);
        }
        [Route("external/[controller]")]
        [HttpPost]
        public string CreateNewHomeLink(home_flowsCreateNewViewModel model) //used
        {
            return _AnamnesisAtHomeFlows.AddAFlow(model);
        }

        [Route("external/[controller]/{templateId}/{HomeLinkID}")]
        [HttpPost]
        public string AddtemplateInHomeLink(long templateId, long HomeLinkID)//used
        {
            return _Templates.AddtemplateInHomeLink(templateId, HomeLinkID);
        }
        [Route("external/[controller]/{id}")]
        [HttpGet]
        public string GetTemplatebuid(int id)
        {
            return "Form against id " + id + " is found...";
        }
        [Route("external/[controller]/{id}/edit")]
        [HttpPost]
        public string PostTemplates(int id)
        {
            return "Form against id " + id + " is updated...";
            //IEnumerable<TblTemplate> List = _Templates.GetAllTemplates().OrderBy(x => x.SortIndex);
            //string jsonData = JsonSerializer.Serialize(List);

            //return jsonData;
        }
        // remove
        [Route("external/[controller]/1001/document_templates/{id}/remove")]
        [HttpPost]
        public string remove(long id)//used
        {
            return _Templates.DeleteTemplateFromHomeLink(id);
        }
        [Route("external/[controller]/1001/document_templates/{id}/remove")]
        [HttpDelete]
        public string removeHomeLink(long id)//used
        {
            return _Templates.DeleteHomeLink(id);
        }

        [Route("external/[controller]/{id}/edit")]
        [HttpGet]
        public IActionResult getAllhomeLinks(long id)//used
        {
            var obj = _AnamnesisAtHomeFlows.GetByID(id);
            var selectedTemplatesId = obj.HomeflowTemplates.Select(x => x.VorlagenID).ToList();
            List<VorlagenViewModel> templateList = new List<VorlagenViewModel>();
            foreach (var temp in obj.HomeflowTemplates)
            {
                VorlagenViewModel tempobj = new VorlagenViewModel();
                tempobj.id = temp.Vorlagen.id;
                tempobj.SortIndex = temp.Vorlagen.SortIndex;
                tempobj.templates = temp.Vorlagen.templates;
                tempobj.HomeflowTemplatesID = temp.id;
                templateList.Add(tempobj);
            }
            anamnesis_at_home_flowsViewModel record = new anamnesis_at_home_flowsViewModel
            {
                @default = obj.@default,
                display_email = obj.display_email,
                display_phone = obj.display_phone,
                id = obj.id,
                link = obj.link,
                name = obj.name,
                notification_email = obj.notification_email,
                Vorlagen = templateList.OrderBy(x => x.SortIndex).ToList()
            };

            var templateid = _Templates.GetAllTemplatesC12().Where(x => !selectedTemplatesId.Contains(x.id));

            return Ok(new { record, templateid });

        }
        // move_up
        [Route("external/[controller]/1001/document_templates/{id}/move_up")]
        [HttpGet]
        public string move_up(long id)//used
        {
            _Templates.MoveUp(id);

            return "Template against id " + id + " is Move up..";
        }
        // move_down
        [Route("external/[controller]/1001/document_templates/{id}/move_down")]
        [HttpGet]
        public string move_down(long id)//used
        {
            _Templates.MoveDown(id);
            return "Template against id " + id + " is Move down..";
        }
        // move
        [Route("external/[controller]/1001/document_templates/{id}/move")]
        [HttpGet]
        public string move(int id)
        {
            var head = HttpContext.Request.Headers;
            return _Templates.Move(id, int.Parse(head["position"]));

        }
        [Route("api/v1/[controller]/{token}")]
        [HttpGet]
        public string anamnesis_at_home_flowsByPublicToken(string token)
        {
            if (token == "2b08c0ba902045f28a75143661782ed4")
            {
                return "Template against token " + token + " is found..";

            }
            else
            {
                return "Template not found..";

            }

        }
        [Route("external/[controller]/1060")]
        [HttpGet]
        public string anamnesis_at_home_flowsByID()
        {

            string jsondata = "{\"parentId\":1060,\"position\":0,\"name\":\"AnamneseErwachsene\",\"id\":13228}";
            return jsondata;

        }
    }
}
