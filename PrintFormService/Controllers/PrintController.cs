using Microsoft.AspNetCore.Mvc;
using PrintFormService.Services;
namespace PrintFormService.Controllers
{
    public class PrintController : ControllerBase
    {
        IPrintService _printservice;
        public PrintController(IPrintService printservice)
        {
            _printservice = printservice;
        }
        [HttpPost]
        [Route("print")]
        public async Task<IActionResult> Print(IFormFile filepath, string JsonData)
        {
            var filePath = Path.GetFullPath(filepath.FileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                await filepath.CopyToAsync(stream);
            }
            var result = await _printservice.ExportTemplate(filePath, JsonData);
            string outfile = Path.GetFullPath(result);
            byte[] filecontent = System.IO.File.ReadAllBytes(outfile);

            return File(filecontent, "application/msword", result);
        }
    }
}
