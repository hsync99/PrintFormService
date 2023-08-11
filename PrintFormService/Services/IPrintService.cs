namespace PrintFormService.Services
{
    public interface IPrintService
    {
        Task<string> ExportTemplate(string htmlTemplate, string JsonData);
    }
}
