namespace PrintFormService.Services
{
    public interface IPrintService
    {
        Task<string> ExportTemplate(string pdfFile, string JsonData);
    }
}
