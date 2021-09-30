
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
        private readonly ITemplates _Templates;
        public document_templates(IWebHostEnvironment hostingEnvironment, ITemplates Templates)
        {
            _hostingEnvironment = hostingEnvironment;
            _Templates = Templates;
        }

        [Route("external/[controller]/TemplatesTypes")]
        [HttpGet]
        public IActionResult GetTemplatesTypes() ///used
        {
            var types = _Templates.GetAllTemplatesTypes();
            return Ok(types);
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
        public IActionResult GetTemplatesByid(int id)
        {
            var model = _Templates.GetTemplateById(id);
            return Ok( model);
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
        public IActionResult DeleteTemplateSheet(long id)
        {
            _Templates.DeleteTemplates(id);
            var templates = _Templates.getallDocumentTemplates();
            List<Vorlagen> templateid1 = new List<Vorlagen>();
            List<Vorlagen> templateid2 = new List<Vorlagen>();
            if (templates.Count > 0)
            {
                templateid1 = templates.Where(x => x.CategoryID == 1).ToList();
                templateid2 = templates.Where(x => x.CategoryID == 2).ToList();
            }
            return Ok(new { templateid1, templateid2 });
        }
        [Route("external/[controller]/new")]
        [HttpPost]
        public string newTemplate(TemplateDuplicateViewModel model)
        {
            return _Templates.CreatenewTemplate(model);
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
            var templates = _Templates.getallDocumentTemplates();
            List<Vorlagen> templateid1 = new List<Vorlagen>();
            List<Vorlagen> templateid2 = new List<Vorlagen>();
            if (templates.Count > 0)
            {
                templateid1 = templates.Where(x => x.CategoryID == 1).ToList();
                templateid2 = templates.Where(x => x.CategoryID == 2).ToList();
            }

            return Ok(new { templateid1, templateid2 });
        }


    }
}
