namespace PrintFormService.Services
{
    public interface IPrintService
    {
        Task<string> ExportTemplate(string filepath, string json);
    }
}
