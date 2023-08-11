using Microsoft.AspNetCore.Mvc;
using PrintFormService.Services;
namespace PrintFormService.Controllers
{
    public class PrintController : ControllerBase
    {
        IPrintService _printservice;
        public PrintController(IPrintService printservice)
        {
            _printservice = _printservice;
        }
        [HttpPost]
        [Route("Print")]
        public async Task<IActionResult> Print(IFormFile htmlfile, string JsonData)
        {
            var filePath = Path.GetFullPath(htmlfile.FileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                await htmlfile.CopyToAsync(stream);
            }
            var result = await _printservice.ExportTemplate(filePath, JsonData);    
            return Ok("");
        }
    }
}
