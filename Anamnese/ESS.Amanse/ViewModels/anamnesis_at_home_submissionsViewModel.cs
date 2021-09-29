// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class PatientPayload
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [JsonProperty("last_name")]
    public string LastName { get; set; }

    [JsonProperty("date_of_birth")]
    public string DateOfBirth { get; set; }

    [JsonProperty("salutation")]
    public object Salutation { get; set; }

    [JsonProperty("title")]
    public object Title { get; set; }

    [JsonProperty("gender")]
    public object Gender { get; set; }

    [JsonProperty("address1")]
    public object Address1 { get; set; }

    [JsonProperty("address2")]
    public object Address2 { get; set; }

    [JsonProperty("zipcode")]
    public object Zipcode { get; set; }

    [JsonProperty("city")]
    public object City { get; set; }

    [JsonProperty("country")]
    public object Country { get; set; }

    [JsonProperty("home_phone")]
    public object HomePhone { get; set; }

    [JsonProperty("work_phone")]
    public object WorkPhone { get; set; }

    [JsonProperty("cellular_phone")]
    public object CellularPhone { get; set; }

    [JsonProperty("fax")]
    public object Fax { get; set; }

    [JsonProperty("email")]
    public object Email { get; set; }

    [JsonProperty("employer")]
    public object Employer { get; set; }

    [JsonProperty("profession")]
    public object Profession { get; set; }

    [JsonProperty("insured_salutation")]
    public object InsuredSalutation { get; set; }

    [JsonProperty("insured_title")]
    public object InsuredTitle { get; set; }

    [JsonProperty("insured_first_name")]
    public object InsuredFirstName { get; set; }

    [JsonProperty("insured_last_name")]
    public object InsuredLastName { get; set; }

    [JsonProperty("insured_date_of_birth")]
    public object InsuredDateOfBirth { get; set; }

    [JsonProperty("insured_address1")]
    public object InsuredAddress1 { get; set; }

    [JsonProperty("insured_address2")]
    public object InsuredAddress2 { get; set; }

    [JsonProperty("insured_country")]
    public object InsuredCountry { get; set; }

    [JsonProperty("insured_phone")]
    public object InsuredPhone { get; set; }

    [JsonProperty("anamnesis_flow_submission_id")]
    public int AnamnesisFlowSubmissionId { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }
}

public class DocumentPayload
{
    [JsonProperty("document_template_id")]
    public int DocumentTemplateId { get; set; }

    [JsonProperty("payload")]
    public string Payload { get; set; }
}

public class Style
{
    [JsonProperty("line")]
    public string Line { get; set; }

    [JsonProperty("size")]
    public string Size { get; set; }

    [JsonProperty("headingSize")]
    public int? HeadingSize { get; set; }

    [JsonProperty("align")]
    public string Align { get; set; }

    [JsonProperty("order")]
    public string Order { get; set; }

    [JsonProperty("position")]
    public string Position { get; set; }

    [JsonProperty("optionsArrangement")]
    public string OptionsArrangement { get; set; }
}

public class Content
{
    [JsonProperty("de")]
    public string De { get; set; }
}

public class Item
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("content")]
    public Content Content { get; set; }
}

public class Sizes
{
}

public class Label
{
    [JsonProperty("de")]
    public string De { get; set; }
}

public class Placeholder
{
    [JsonProperty("de")]
    public string De { get; set; }
}

public class ErrorMessage
{
    [JsonProperty("de")]
    public string De { get; set; }
}

public class Option2
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("static")]
    public bool Static { get; set; }

    [JsonProperty("label")]
    public Label Label { get; set; }

    [JsonProperty("dsWinFieldValue")]
    public string DsWinFieldValue { get; set; }

    [JsonProperty("children")]
    public List<object> Children { get; set; }

    [JsonProperty("dsWinFieldName")]
    public string DsWinFieldName { get; set; }
}

public class Child
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("content")]
    public Content Content { get; set; }

    [JsonProperty("required")]
    public bool? Required { get; set; }

    [JsonProperty("static")]
    public bool? Static { get; set; }

    [JsonProperty("label")]
    public Label Label { get; set; }

    [JsonProperty("errorMessage")]
    public ErrorMessage ErrorMessage { get; set; }

    [JsonProperty("style")]
    public Style Style { get; set; }

    [JsonProperty("dsWinFieldName")]
    public string DsWinFieldName { get; set; }

    [JsonProperty("options")]
    public List<Option2> Options { get; set; }
}

public class InfoLabel
{
    [JsonProperty("de")]
    public string De { get; set; }

    [JsonProperty("en")]
    public string En { get; set; }

    [JsonProperty("fr")]
    public string Fr { get; set; }

    [JsonProperty("es")]
    public string Es { get; set; }

    [JsonProperty("tr")]
    public string Tr { get; set; }

    [JsonProperty("pl")]
    public string Pl { get; set; }

    [JsonProperty("ru")]
    public string Ru { get; set; }

    [JsonProperty("ch")]
    public string Ch { get; set; }

    [JsonProperty("ja")]
    public string Ja { get; set; }

    [JsonProperty("ar")]
    public string Ar { get; set; }
}

public class Caption
{
    [JsonProperty("de")]
    public string De { get; set; }
}

public class Atn
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("children")]
    public List<object> Children { get; set; }

    [JsonProperty("style")]
    public Style Style { get; set; }

    [JsonProperty("content")]
    public Content Content { get; set; }

    [JsonProperty("items")]
    public List<Item> Items { get; set; }

    [JsonProperty("source")]
    public string Source { get; set; }

    [JsonProperty("sizes")]
    public Sizes Sizes { get; set; }

    [JsonProperty("placeholderSource")]
    public string PlaceholderSource { get; set; }

    [JsonProperty("required")]
    public bool? Required { get; set; }

    [JsonProperty("label")]
    public Label Label { get; set; }

    [JsonProperty("placeholder")]
    public Placeholder Placeholder { get; set; }

    [JsonProperty("errorMessage")]
    public ErrorMessage ErrorMessage { get; set; }

    [JsonProperty("options")]
    public List<Option2> Options { get; set; }

    [JsonProperty("static")]
    public bool? Static { get; set; }

    [JsonProperty("infoLabel")]
    public InfoLabel InfoLabel { get; set; }

    [JsonProperty("caption")]
    public Caption Caption { get; set; }
}

public class DocumentTemplate
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("languages")]
    public List<object> Languages { get; set; }

    [JsonProperty("atn")]
    public List<Atn> Atn { get; set; }

    [JsonProperty("erb")]
    public string Erb { get; set; }
}

public class anamnesis_at_home_submissionsViewModel
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("token")]
    public string Token { get; set; }

    [JsonProperty("practice_id")]
    public int PracticeId { get; set; }

    [JsonProperty("pvs_patid")]
    public object PvsPatid { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("submitted_at")]
    public DateTime SubmittedAt { get; set; }

    [JsonProperty("patient_payload")]
    public PatientPayload PatientPayload { get; set; }

    [JsonProperty("document_payloads")]
    public List<DocumentPayload> DocumentPayloads { get; set; }

    [JsonProperty("document_templates")]
    public List<DocumentTemplate> DocumentTemplates { get; set; }
}

