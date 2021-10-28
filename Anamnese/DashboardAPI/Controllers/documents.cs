using ESS.Amanse.BLL.ICollection;
using Microsoft.AspNetCore.Mvc;


namespace DashboardAPI.Controllers
{
    [ApiController]
    public class documents : ControllerBase
    {
        private readonly IDocument _Document;

        public documents(IDocument Document)
        {
            _Document = Document;
        }
        [Route("api/v1/[controller]")]
        [HttpGet]
        public IActionResult Get()
        {
            var data = _Document.GetAllDocument();
            //string jsonData= System.IO.File.ReadAllText("athenabox_documents/athenabox_documents_get.json");
            return Ok(data);
        }
        [Route("external/[controller]/{id}")]
        [HttpGet]
        public IActionResult ShowDocument(long id)
        {
            return Ok();
        }

    }
}
