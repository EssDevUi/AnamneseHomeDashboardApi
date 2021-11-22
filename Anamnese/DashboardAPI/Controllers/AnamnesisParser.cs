using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.ViewModels.AnamneseLearningViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardAPI.Controllers
{

    [ApiController]
    [Authorize]
    public class AnamnesisParser : ControllerBase
    {
        private readonly ITemplates _Templates;
        private readonly IMedicalHistory _MedicalHistory;
        public AnamnesisParser(ITemplates Templates, IMedicalHistory MedicalHistory)
        {
            _Templates = Templates;
            _MedicalHistory = MedicalHistory;
        }
      
        [Route("api/[controller]/{MedicalHistoryId}")]
        [HttpGet]
        public ActionResult GetPatientList(long MedicalHistoryId)
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

            string file = parse_Anamnese_Flows(history);
            return Ok(file);
        }
        public class document
        {
            public Newtonsoft.Json.Linq.JObject payload { get; set; }
            public Newtonsoft.Json.Linq.JObject template { get; set; }
        }

        public static string parse_Anamnese_Flows(DataForSummeryViewModel model)
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
            string file = "";
            foreach (document doc in documents)
            {
                file = parse_Anamnese_Flow(doc);
            }
            return file;
        }

        private static string parse_Anamnese_Flow(document doc)
        {
            string id = (string)doc.template["id"];
            string title = (string)doc.template["title"];

            Newtonsoft.Json.Linq.JArray atn = Newtonsoft.Json.Linq.JArray.Parse(doc.template["atn"].ToString());

            System.Text.StringBuilder stringbuilder = new System.Text.StringBuilder();

            string begin_html = System.IO.File.ReadAllText(System.IO.Path.Combine("atn", "anamnesis-begin.html"));
            string html = parseATNArray(atn, doc.payload);

            stringbuilder.Append(begin_html);
            stringbuilder.Append(html);
            stringbuilder.Append("<div style='clear: both;'></div></body></html>");

            System.IO.File.WriteAllText(System.IO.Path.Combine("html", title + ".html"), stringbuilder.ToString());
            return System.IO.Path.Combine("html", title + ".html");

        }

        private static string parseATNArray(Newtonsoft.Json.Linq.JArray atn, Newtonsoft.Json.Linq.JObject payload)
        {
            string result = "";
            foreach (Newtonsoft.Json.Linq.JObject element in atn)
            {
                result += parseATNElement(element, payload);
            }
            return result;
        }

        private static string parseATNElement(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload)
        {
            string id = (string)element["id"];
            string type = (string)element["type"];


            switch (type)
            {
                case "group":
                    return parse_Group(element, payload);
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
                    return parse_Image(element, payload);
                case "video":
                    return parse_Video(element, payload);

                case "textInput":
                    return parse_TextInput(element, payload);
                case "textAreaInput":
                    return parse_TextInputArea(element, payload);


                case "yesNo":
                    return parse_SelectOne(element, payload);
                case "selectOne":
                    return parse_SelectOne(element, payload);
                case "selectMultiple":
                    return parse_SelectMultiple(element, payload);



                case "cameraInput":
                    return parse_CameraInput(element, payload);

                case "signature":
                    return parse_Signature(element, payload);
                default:
                    return "";
            }
        }

        private static string parse_Group(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload)
        {
            string id = (string)element["id"];
            Newtonsoft.Json.Linq.JArray children = (Newtonsoft.Json.Linq.JArray)element["children"];

            string result = "<div class=\"flex-container\">";
            foreach (Newtonsoft.Json.Linq.JObject child in children)
            {
                string _children = parseATNElement(child, payload);
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

        private static string parse_Image(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload)
        {
            //string source = (string)element["source"];
            string source = (string)payload[(String)element["id"]];
            return
                "<img src=" + "" +
                    source + //"'data:image/jpeg;base64,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'" + 
                " style='max-width: 700px; margin-right: auto; margin-left: auto; '>";
        }

        private static string parse_Video(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload)
        {
            string source = (string)element["source"];
            string placeholderSource = (string)element["placeholderSource"];

            return "<video controls='' " +
                "poster=" + placeholderSource + //"'' " + 
                "src=" + source + //"'https://www.youtube.com/watch?v=uRCJeK9MZ6c'" + 
                " style='max-width: 700px; margin-right: auto; margin-left: auto; '></video>";
            return "<img style='max-width: 700px; margin-right: auto; margin-left: auto; ' src='https://www.youtube.com/watch?v=uRCJeK9MZ6c'>";
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



        private static string parse_SelectOne(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload)
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
                    string _children = parseATNArray(children, payload);
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


        private static string parse_SelectMultiple(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload)
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
                if (option_value.ToLower() == "true")
                {

                    result += "<div class='option" + /*" input-highlighted" +*/ "'><span class='text-muted'>&#10004;</span>";
                    result += option_label;
                    result += "</div>";
                    Newtonsoft.Json.Linq.JArray children = (Newtonsoft.Json.Linq.JArray)option["children"];
                    string _children = parseATNArray(children, payload);
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



        private static string parse_CameraInput(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload)
        {
            string id = (string)element["id"];

            string drawing_data = "data:image/png;base64,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";
            return
                "<div class='input-container'><h5></h5>" +
                    "<br>" +
                    "<img class='camera-input' src='" + drawing_data + "'>" +
                "</div>";

            return Environment.NewLine + "{ " + "camera" + " }";
        }


        private static string parse_Signature(Newtonsoft.Json.Linq.JObject element, Newtonsoft.Json.Linq.JObject payload)
        {
            string id = (string)element["id"];

            string signee = (string)element["caption"]["de"];
            string signature_data = "data:image/png;base64,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";


            string signature =
                "<div class='signature-box-outer'>" +
                    "<div class='signature-box-inner'>" +
                        //"<div>" + practice_city + ", den " + started_at.ToShortDateString() +/*<%= @consultation.started_at.strftime('%d.%m.%Y') %>*/"</div>" +

                        "<img src = " + signature_data + " class='signature'>" +

                        "<div>" + signee + "</div>" +
                    "</div>" +
                "</div>";
            return signature;
            return
               "<div class='signature-wrapper2'>" +

                    "<img src='" + signature_data + "' class='signature2'>" +
                    "<div>" + signee + "</div>" +

                //"<div class='text-muted small'>Nicht unterschrieben</div>"+

                "</div>";
            //"<div class='text-muted small'>Nicht unterschrieben</div>"
            return Environment.NewLine + "{ " + "signature" + " }";
        }

    }
}
