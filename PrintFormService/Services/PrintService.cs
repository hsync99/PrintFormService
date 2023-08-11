

using HtmlAgilityPack;

namespace PrintFormService.Services
{
    public class PrintService : IPrintService
    {
        public async Task<string> ExportTemplate(string htmlTemplate, string JsonData)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlTemplate);
            return "";
            
        }
    }
}
