
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.DAL;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using System.Dynamic;
using Newtonsoft.Json.Linq;
using ESS.Amanse.ViewModels;

namespace DashboardAPI.Controllers
{

    [ApiController]
    // [Authorize]

    public class document_templates : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public document_templates( IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("external/[controller]/Sheets")]
        [HttpGet]
        public IActionResult GetTemplatesSheets()
        {
            //var List = _Templates.GetTemplateSheets();

            //var SysInformationSheet = List.Where(x => x.SheetTypeId == 1 && x.TemplateTypeId == 1);
            //var OwnInformationSheet = List.Where(x => x.SheetTypeId == 1 && x.TemplateTypeId == 2);
            //var SysMedicalhistorysheets = List.Where(x => x.SheetTypeId == 2 && x.TemplateTypeId == 1);
            //var OwnMedicalhistorysheets = List.Where(x => x.SheetTypeId == 2 && x.TemplateTypeId == 2);
            dynamic MyDynamic = new System.Dynamic.ExpandoObject();
            //MyDynamic.SysInformationSheet = SysInformationSheet;
            //MyDynamic.OwnInformationSheet = OwnInformationSheet;
            //MyDynamic.SysMedicalhistorysheets = SysMedicalhistorysheets;
            //MyDynamic.OwnMedicalhistorysheets = OwnMedicalhistorysheets;
            return Ok(MyDynamic);
        }
        [Route("external/[controller]/{id}")]
        [HttpGet]
        public string GetTemplatesByid(int id)
        {
            return "Form against id " + id + " is found..";
        }
        // here with practice-data
        [Route("atn_editor_api/v1/[controller]/{id}")]
        [HttpGet]
        public string TemplateByid_withpracticedata(int id)
        {
            return "Form against id " + id + " with practice data..";
        }
        [Route("external/[controller]/{id}")]
        [HttpDelete]
        public string DeleteTemplateSheet(long id)
        {
            return "Form against id " + id + " is deleted..";

            //_Templates.DeleteTemplateSheet(id);

            //var List = _Templates.GetTemplateSheets();

            //var SysInformationSheet = List.Where(x => x.SheetTypeId == 1 && x.TemplateTypeId == 1);
            //var OwnInformationSheet = List.Where(x => x.SheetTypeId == 1 && x.TemplateTypeId == 2);
            //var SysMedicalhistorysheets = List.Where(x => x.SheetTypeId == 2 && x.TemplateTypeId == 1);
            //var OwnMedicalhistorysheets = List.Where(x => x.SheetTypeId == 2 && x.TemplateTypeId == 2);
            //dynamic MyDynamic = new System.Dynamic.ExpandoObject();
            //MyDynamic.SysInformationSheet = SysInformationSheet;
            //MyDynamic.OwnInformationSheet = OwnInformationSheet;
            //MyDynamic.SysMedicalhistorysheets = SysMedicalhistorysheets;
            //MyDynamic.OwnMedicalhistorysheets = OwnMedicalhistorysheets;
            //return Ok(MyDynamic);

        }
        [Route("external/[controller]/new")]
        [HttpPost]
        public string newTemplate(TemplateDuplicateViewModel model)
        {
            return "Form Created Successfully...";
        }
        [Route("external/[controller]/new_from/{from_id}")]
        [HttpPost]
        public string Duplicate(int from_id, TemplateDuplicateViewModel model)
         {
            return "Yor form against id " + from_id + " is duplicated..";
        }
        [Route("external/[controller]")]
        [HttpGet]
        public IActionResult getall_document_templates()
        {
            List<string> templateid1 = new List<string>();
            List<string> templateid2 = new List<string>();
            foreach (string fileName in Directory.GetFiles("Athena Aufklärungsbögen", "*.json"))
            {
                using (StreamReader r = new StreamReader(fileName))
                {
                    string json = r.ReadToEnd();
                    dynamic stuff = JObject.Parse(json);
                    dynamic jsonObject = new ExpandoObject();
                    jsonObject.id = stuff.document_template.id;
                    jsonObject.title = stuff.document_template.title;
                    jsonObject.template_category_id = stuff.document_template.template_category_id;
                    jsonObject.@default= stuff.document_template.@default;


                    templateid1.Add(JsonConvert.SerializeObject(jsonObject));
                }
                // Do something with the file content
            }
            foreach (string fileName in Directory.GetFiles("Athena Beratungsprotokolle", "*.json"))
            {
                using (StreamReader r = new StreamReader(fileName))
                {
                    string json = r.ReadToEnd();
                    dynamic stuff = JObject.Parse(json);
                    dynamic jsonObject = new ExpandoObject();
                    jsonObject.id = stuff.document_template.id;
                    jsonObject.title = stuff.document_template.title;
                    jsonObject.template_category_id = stuff.document_template.template_category_id;
                    jsonObject.@default = stuff.document_template.@default;
                    templateid2.Add(JsonConvert.SerializeObject(jsonObject));
                }
                // Do something with the file content
            }

            return Ok(new{templateid1,templateid2});
        }
    }
}
