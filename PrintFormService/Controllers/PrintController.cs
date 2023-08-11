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
        [Route("Print")]
        public async Task<IActionResult> Print(IFormFile pdfFile, string JsonData)
        {
            var filePath = Path.GetFullPath(pdfFile.FileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                await pdfFile.CopyToAsync(stream);
            }
            var result = await _printservice.ExportTemplate(filePath, JsonData);
            string outfile = Path.GetFullPath(result);
            byte[] filecontent = System.IO.File.ReadAllBytes(outfile);

            return File(filecontent, "application/pdf", result);
        }
    }
}
