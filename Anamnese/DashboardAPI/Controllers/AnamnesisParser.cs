using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.Helper;
using ESS.Amanse.ViewModels.AnamneseLearningViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace DashboardAPI.Controllers
{

    [ApiController]
    [Authorize]
    public class AnamnesisParser : ControllerBase
    {
        private readonly ITemplates _Templates;
        private readonly IMedicalHistory _MedicalHistory;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        readonly IGeneratePdf _generatePdf;

        public AnamnesisParser(ITemplates Templates, IMedicalHistory MedicalHistory, IGeneratePdf generatePdf, IWebHostEnvironment WebHostEnvironment)
        {
            _Templates = Templates;
            _MedicalHistory = MedicalHistory;
            _WebHostEnvironment = WebHostEnvironment;
            _generatePdf = generatePdf;
        }

        [Route("api/[controller]/{MedicalHistoryId}")]
        [HttpGet]
        public async Task<ActionResult> GetPatientList(long MedicalHistoryId)
        {
            var history = _MedicalHistory.MedicalHistoryByIdForSummary(MedicalHistoryId);
            var payloadJsonObjectList = Newtonsoft.Json.Linq.JObject.Parse(history.payloadJson);

            history.document_payloads = new List<document_payloads>();
            List<long> templateIds = new List<long>();

            foreach (var temp in payloadJsonObjectList)
            {
                if (temp.Value.Count() > 0)
                {
                    templateIds.Add(long.Parse(temp.Key));
                    document_payloads payloadObject = new document_payloads();
                    payloadObject.document_template_id = temp.Key;
                    payloadObject.payload = (Newtonsoft.Json.Linq.JObject)temp.Value;
                    history.document_payloads.Add(payloadObject);
                }
            }
            history.document_templates = _Templates.GetTemplateByIdForLearning(templateIds);
            if (history.document_templates.Count == 0)
            {
                return Ok("Empty");
            }
            string BaseUrl = Request.Scheme + "://" + Request.Host.Value + "/";
            List<string> Htmlfiles = parse_Anamnese_Flows(history, BaseUrl);
            //Convert html to pdf
            var Options = new ConvertOptions()
            {
                PageMargins = new Wkhtmltopdf.NetCore.Options.Margins()
                {
                    Top = 20,
                    Bottom = 20,
                    Left = 20,
                    Right = 20
                },
                //FooterHtml = _WebHostEnvironment.ContentRootPath + "\\HtmlToPdf\\header.html",
                FooterSpacing = 2,
                PageSize = Wkhtmltopdf.NetCore.Options.Size.A4,

            };
            _generatePdf.SetConvertOptions(Options);
            List<string> filename = new List<string>();
            foreach (var file in Htmlfiles)
            {
                byte[] FileBytes = await _generatePdf.GetByteArray("/html/" + file);
                filename.Add(System.IO.Path.Combine("PatientsPdfForms", Common.UploadPdf(FileBytes, file)));
            }
           
            return Ok(JsonConvert.SerializeObject(filename));
            //System.IO.Path.Combine("PatientsPdfForms", filename);
        }
        public class document
        {
            public Newtonsoft.Json.Linq.JObject payload { get; set; }
            public Newtonsoft.Json.Linq.JObject template { get; set; }
        }

        public static List<string> parse_Anamnese_Flows(DataForSummeryViewModel model, string BaseUrl)
        {

            Newtonsoft.Json.Linq.JArray document_payloads = Newtonsoft.Json.Linq.JArray.Parse(JsonConvert.SerializeObject(model.document_payloads));

            Newtonsoft.Json.Linq.JArray document_templates = Newtonsoft.Json.Linq.JArray.Parse(JsonConvert.SerializeObject(model.document_templates));

            List<document> documents = new List<document>();

            foreach (Newtonsoft.Json.Linq.JObject document_template in document_templates)
            {
                document anamnese_home_flow = new document();
                anamnese_home_flow.template = document_template;


                string id = (string)document_template["id"];
                string title = (string)document_template["title"];


                Newtonsoft.Json.Linq.JObject payload_json = null;
                foreach (Newtonsoft.Json.Linq.JObject current in document_payloads)
                {
                    if ((string)current["document_template_id"] == id)
                    {
                        string payload = current["payload"].ToString();
                        payload_json = Newtonsoft.Json.Linq.JObject.Parse(payload);

                        anamnese_home_flow.payload = payload_json;
                    }
                }
                Newtonsoft.Json.Linq.JArray atn = Newtonsoft.Json.Linq.JArray.Parse(document_template["atn"].ToString());

                if (payload_json != null)
                {
                    documents.Add(anamnese_home_flow);
                }
            }
            List<string> files = new List<string>();
            foreach (document doc in documents)
            {
                files.Add(parse_Anamnese_Flow(doc, BaseUrl));
            }
            return files;
        }

        private static string parse_Anamnese_Flow(document doc, string BaseUrl)
        {
            string id = (string)doc.template["id"];
            string title = (string)doc.template["title"];

            Newtonsoft.Json.Linq.JArray atn = Newtonsoft.Json.Linq.JArray.Parse(doc.template["atn"].ToString());

            System.Text.StringBuilder stringbuilder = new System.Text.StringBuilder();

            string begin_html = System.IO.File.ReadAllText(System.IO.Path.Combine("atn", "anamnesis-begin.html"));
            string html = parseATNArray(atn, doc.payload, BaseUrl);

            stringbuilder.Append(begin_html);
            stringbuilder.Append(html);
            stringbuilder.Append("<div style='clear: both;'></div></body></html>");

            System.IO.File.WriteAllText(System.IO.Path.Combine("html", title + ".html"), stringbuilder.ToString());
            return title + ".html";

        }

        private static string parseATNArray(Newtonsoft.Json.Linq.JArray atn, Newtonsoft.Json.Linq.JObject payload, string BaseUrl)
        {
            string result = "";
            foreach (Newtonsoft.Json.Linq.JObject element in atn)
            {
                result += parseATNElement(element, payload, BaseUrl);
            }
            return result;
        }

        private static string parseATNElement(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload, string BaseUrl)
        {
            string id = (string)element["id"];
            string type = (string)element["type"];


            switch (type)
            {
                case "group":
                    return parse_Group(element, payload, BaseUrl);
                case "separator":
                    return parse_Separator(element, payload);
                case "spacer":
                    return parse_Spacer(element, payload);

                case "heading":
                    return parse_Heading(element, payload);

                case "list":
                    return parse_List(element, payload);

                case "text":
                    return parse_Text(element, payload);
                case "paragraph":
                    return parse_Paragraph(element, payload);

                case "image":
                    return parse_Image(element, payload, BaseUrl);
                case "video":
                    return parse_Video(element, payload, BaseUrl);

                case "textInput":
                    return parse_TextInput(element, payload);
                case "textAreaInput":
                    return parse_TextInputArea(element, payload);


                case "yesNo":
                    return parse_SelectOne(element, payload, BaseUrl);
                case "selectOne":
                    return parse_SelectOne(element, payload, BaseUrl);
                case "selectMultiple":
                    return parse_SelectMultiple(element, payload, BaseUrl);



                case "cameraInput":
                    return parse_CameraInput(element, payload, BaseUrl);

                case "signature":
                    return parse_Signature(element, payload, BaseUrl);
                default:
                    return "";
            }
        }

        private static string parse_Group(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload, string BaseUrl)
        {
            string id = (string)element["id"];
            Newtonsoft.Json.Linq.JArray children = (Newtonsoft.Json.Linq.JArray)element["children"];

            string result = "<div class=\"flex-container\">";
            foreach (Newtonsoft.Json.Linq.JObject child in children)
            {
                string _children = parseATNElement(child, payload, BaseUrl);
                result += "<div class='group-child'>" + _children + "</div>";
            }
            result += "</div>";
            return result;

        }

        private static string parse_Separator(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload)
        {
            return "<hr>";
        }

        private static string parse_Spacer(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload)
        {
            return "<div class=\"mt\"></div>";
        }

        private static string parse_Heading(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload)
        {
            string content = (string)element["content"]["de"];

            string align = (string)element["style"]["align"];
            string size = (string)element["style"]["size"];
            return "<h" + size + " style=\"text-align: " + align + "\">" + content + "</h" + size + ">";
        }

        private static string parse_Text(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload)
        {
            string content = (string)element["content"]["de"];

            return "<div>" + content + "</div>";
        }
        private static string parse_Paragraph(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload)
        {
            string content = (string)element["content"]["de"];

            string align = (string)element["style"]["align"];
            return
                "<div style='text-align: " + align + "'>" +
                    content +
                "</div>";
        }

        private static string parse_List(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload)
        {
            Newtonsoft.Json.Linq.JArray items = (Newtonsoft.Json.Linq.JArray)element["items"];

            string order = (string)element["style"]["order"];

            string result = (order == "unordered" ? "<ul>" : "<ol>");
            foreach (Newtonsoft.Json.Linq.JObject item in items)
            {
                result += "<li>";

                string item_id = (string)item["id"];

                string item_label = (string)item["content"]["de"];
                result += item_label;

                result += "</li>";
            }
            result += (order == "unordered" ? "</ul>" : "</ol>");
            return result;
        }

        private static string parse_Image(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload, string BaseUrl)
        {
            //string source = (string)element["source"];
            string source = (string)payload[(String)element["id"]];
            bool isonserver = source.Contains(BaseUrl.Split("//")[1]);
            if (source == null)
            {
                source = (string)element["source"];
                if (source == null)
                {
                    return "";
                }
                return
               "<img src=" + '"' +
                 source + '"' +
               " style='max-width: 700px; margin-right: auto; margin-left: auto; '>";
            }
            if (isonserver)
            {
                return
                "<img src=" + '"' +
                 BaseUrl + source + '"' +
                " style='max-width: 700px; margin-right: auto; margin-left: auto; '>";
            }
            else
            {
                return
                "<img src=" + '"' +
                 source + '"' +
                " style='max-width: 700px; margin-right: auto; margin-left: auto; '>";
            }
            
        }

        private static string parse_Video(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload, string BaseUrl)
        {
            
            return
               "<img src='" +
                BaseUrl + "assets/img/Video_player_image.png'" +
               " style='max-width: 700px; margin-right: auto; margin-left: auto; '>";

            //string source = (string)element["source"];
            //string placeholderSource = (string)element["placeholderSource"];

            //return "<video controls='' " +
            //    "poster='" + placeholderSource +
            //    "' src='" + source +
            //    "' style='max-width: 700px; margin-right: auto; margin-left: auto; '></video>";
        }

        private static string parse_TextInput(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload)
        {
            string id = (string)element["id"];
            Newtonsoft.Json.Linq.JValue value = (Newtonsoft.Json.Linq.JValue)payload[id];

            string label = (string)element["label"]["de"];
            return
                "<div class='input-container'>" +
                    "<h5>" + label + "</h5>" +
                    "<div class=\"mt\"></div>" +
                        "<div>" +
                            "<div class=\"text-input\">" + value + "</div>" +
                        "</div>" +
                "</div>";
        }

        private static string parse_TextInputArea(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload)
        {
            string id = (string)element["id"];
            Newtonsoft.Json.Linq.JValue value = (Newtonsoft.Json.Linq.JValue)payload[id];

            string label = (string)element["label"]["de"];
            return
                "<div class='input-container'>" +
                    "<h5>" + label + "</h5>" +
                    "<div class=\"mt\"></div>" +
                        "<div>" +
                            "<div class=\"text-input\">" + value + "</div>" +
                        "</div>" +
                "</div>";
        }



        private static string parse_SelectOne(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload, string BaseUrl)
        {
            string id = (string)element["id"];
            Newtonsoft.Json.Linq.JArray selectOne_value = (Newtonsoft.Json.Linq.JArray)element["options"];
            Newtonsoft.Json.Linq.JObject selectOne_label = (Newtonsoft.Json.Linq.JObject)element["label"];
            string selectOne_label_text = (string)selectOne_label["de"];

            string yesNo_value = (string)payload[id];

            string result = "<div class='input-container'><h5>" + selectOne_label_text + "</h5>";
            foreach (Newtonsoft.Json.Linq.JObject option in selectOne_value)
            {
                string option_id = (string)option["id"];

                string option_label = (string)option["label"]["de"];
                if (yesNo_value == option_id)
                {
                    result += "<div class='option" + /*" input-highlighted" +*/ "'><span class='text-muted'>&#10004;</span>";
                    result += option_label;
                    result += "</div>";
                    Newtonsoft.Json.Linq.JArray children = (Newtonsoft.Json.Linq.JArray)option["children"];
                    string _children = parseATNArray(children, payload, BaseUrl);
                    //return Environment.NewLine + "{ " + type + ", children: " + _children + " }";
                    result += "<div class='input-container-child'>" + _children + "</div>";
                }
                else
                {
                    result += "<div class='option" + /*" input-highlighted" +*/ "'><span class='text-muted'>&#9634;</span>";
                    result += option_label;
                    result += "</div>";
                }
            }
            result += "</div>";
            return result;
        }


        private static string parse_SelectMultiple(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload, string BaseUrl)
        {
            string id = (string)element["id"];
            Newtonsoft.Json.Linq.JArray selectMultiple_options = (Newtonsoft.Json.Linq.JArray)element["options"];
            Newtonsoft.Json.Linq.JArray selectMultiple_values = (Newtonsoft.Json.Linq.JArray)payload[id];


            string selectOne_label_text = (string)element["label"]["de"];

            string result = "<div class='input-container'><h5>" + selectOne_label_text + "</h5>";
            foreach (Newtonsoft.Json.Linq.JObject option in selectMultiple_options)
            {
                string option_id = (string)option["id"];
                string option_value = (string)payload[option_id];

                string option_label = (string)option["label"]["de"];
                if (option_value?.ToLower() == "true")
                {

                    result += "<div class='option" + /*" input-highlighted" +*/ "'><span class='text-muted'>&#10004;</span>";
                    result += option_label;
                    result += "</div>";
                    Newtonsoft.Json.Linq.JArray children = (Newtonsoft.Json.Linq.JArray)option["children"];
                    string _children = parseATNArray(children, payload, BaseUrl);
                    //selectMultiple_children += ";" + _children;
                    result += "<div class='input-container-child'>" + _children + "</div>";
                }
                else
                {
                    result += "<div class='option" + /*" input-highlighted" +*/ "'><span class='text-muted'>&#9634;</span>";
                    result += option_label;
                    result += "</div>";
                }
            }
            result += "</div>";
            return result;
        }



        private static string parse_CameraInput(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload, string BaseUrl)
        {
            string source = (string)payload[(String)element["id"]];
            if (source == null)
            {
                return "";
            }
            return
                "<img src=" + '"' +
                 BaseUrl + source + '"' +
                " style='max-width: 700px; margin-right: auto; margin-left: auto; '>";


            //string id = (string)element["id"];

            //string drawing_data = "data:image/png;base64,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";
            //return
            //    "<div class='input-container'><h5></h5>" +
            //        "<br>" +
            //        "<img class='camera-input' src='" + drawing_data + "'>" +
            //    "</div>";

            //return Environment.NewLine + "{ " + "camera" + " }";
        }


        private static string parse_Signature(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload, string BaseUrl)
        {
            string source = (string)payload[(String)element["id"]];
            //string id = (string)element["id"];
            if (source == null)
            {
                return "";
            }
            string signee = (string)element["caption"]["de"];
            //string signature_data = "data:image/png;base64,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";


            string signature =
                "<div class='signature-box-outer'>" +
                    "<div class='signature-box-inner'>" +
                        //"<div>" + practice_city + ", den " + started_at.ToShortDateString() +/*<%= @consultation.started_at.strftime('%d.%m.%Y') %>*/"</div>" +

                        "<img src = " + BaseUrl + source + " class='signature'>" +

                        "<div>" + signee + "</div>" +
                    "</div>" +
                "</div>";
            return signature;
            //return
            //   "<div class='signature-wrapper2'>" +

            //        "<img src='" + signature_data + "' class='signature2'>" +
            //        "<div>" + signee + "</div>" +

            //    //"<div class='text-muted small'>Nicht unterschrieben</div>"+

            //    "</div>";
            ////"<div class='text-muted small'>Nicht unterschrieben</div>"
            //return Environment.NewLine + "{ " + "signature" + " }";
        }

    }
}
