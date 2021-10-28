
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
using ESS.Amanse.ViewModels.atn_AditorViewModel;
using Microsoft.AspNetCore.Cors;
using System;

namespace DashboardAPI.Controllers
{

    [ApiController]
    //[EnableCors("MyAllowSpecificOrigins")]

    // [Authorize]

    public class document_templates : ControllerBase
    {
        private readonly ITemplates _Templates;
        private readonly ICommons _Commons;

        public document_templates(ITemplates Templates, ICommons Commons)
        {
            _Templates = Templates;
            _Commons = Commons;
        }

        [Route("atn_editor_api/v1/[controller]/{DOCUMENT_TEMPLATE_ID}/Get")]
        [HttpGet]

        public IActionResult GetTemplatesFromAditor(long DOCUMENT_TEMPLATE_ID) ///used
        {

            var template = _Templates.GetTemplateById(DOCUMENT_TEMPLATE_ID);
            Edit_atn_AditorViewModel model = new Edit_atn_AditorViewModel();

            if (template != null)
            {
                model.document_template = new ESS.Amanse.ViewModels.atn_AditorViewModel.DocumentTemplate();
                model.document_template.atn_v2 = template.atn_v2?.ToString();
                model.document_template.title = template.templates;
            }

             return Ok(model);
        }
        [Route("atn_editor_api/v1/[controller]/{DOCUMENT_TEMPLATE_ID}")]
        [HttpPost]
        public IActionResult CreateTemplatesFromAditor(long DOCUMENT_TEMPLATE_ID, IFormCollection formDatad) ///used
        {
            _Templates.EditTemplateTitleFromeditor(formDatad["document_template[title]"], DOCUMENT_TEMPLATE_ID);
            Vorlagen template = new Vorlagen();
            template.atn_v2 = formDatad["document_template[atn_v2]"];
            template.id = DOCUMENT_TEMPLATE_ID;
            template.languages = formDatad["document_template[languages]"];
            template.templates = formDatad["document_template[title]"];
            _Templates.AddorUpdate(template);
            return Ok();
        }
        [Route("atn_editor_api/v1/[controller]/{DOCUMENT_TEMPLATE_ID}/medias")]
        [HttpPost]
        public IActionResult EditorUploadImage(long DOCUMENT_TEMPLATE_ID, practice_logoViewModel model)
        {
            Guid imageName = Guid.NewGuid();
            model.Logo = _Commons.SaveImage(model.Logo.Replace("data:image/png;base64,", ""), imageName.ToString());
            return Ok(model.Logo);
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
            return Ok(model);
        }
        // here with practice-data
        [Route("atn_editor_api/v1/[controller]/{id}")]
        [HttpGet]
        public string TemplateByid_withpracticedata(int id)
        {
            return "Form against id " + id + " with practice data..";
        }
        [Route("external/[controller]/{Templateid}/Delete")]
        [HttpGet]
        public IActionResult DelTemplateSheet(long Templateid)
        {
            _Templates.DeleteTemplates(Templateid);
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
        public IActionResult Duplicate(TemplateDuplicateViewModel model)
        {
            _Templates.Duplicate(model);
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
