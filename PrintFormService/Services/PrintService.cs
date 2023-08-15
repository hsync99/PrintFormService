
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System.Drawing;
using Newtonsoft.Json;
namespace PrintFormService.Services
{
    public class PrintService : IPrintService
    {
        public async Task<string> ExportTemplate(string filepath, string json)
        {
            String inputfilename = filepath;
           Document document= new Document();
            document.LoadFromFile(inputfilename);
      
            Section section = document.Sections[0];
            var jdata = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
           var header= section.HeadersFooters[0];
            var header2 = section.HeadersFooters.Header.LastParagraph.Text;
            section.HeadersFooters.Header.LastParagraph.Text = "Колонтитул";
            //header.Paragraphs[0].Text = "КОЛОНТИТУЛ";
            int j = 0;
            var c = section.Paragraphs.Count;
            for (int i = 0; i < c;i++)
            {
                foreach (var item in jdata)
                {


                    Paragraph para1 = section.Paragraphs[i];
                    

                    if (para1.Text.Contains(item.Key))
                    {
                        string text = para1.Text;
                        text = text.Replace(item.Key, item.Value);
                        para1.Text = "";
                        TextRange tr = para1.AppendText(text); 
                       
                        tr.CharacterFormat.FontName = "TimesNewRoman";
                        tr.CharacterFormat.FontSize = 12;
                        tr.CharacterFormat.TextColor = Color.Red;
                      
                    }
                   

                }
            }
           
           
            

            //Add New Text
            //Paragraph para2 = section.Paragraphs[1];
            //TextRange tr = para2.AppendText("Spire.Doc for .NET is stand-alone"
            //+ "to enables developers to operate Word witout Microsoft Word installed.");
            //tr.CharacterFormat.FontName = "TimesNewRoman";
            //tr.CharacterFormat.FontSize = 12;
            //tr.CharacterFormat.TextColor = Color.Black;

            
            //Save and Launch
            document.SaveToFile("Edit Word.docx", FileFormat.Docx);
            return "Edit Word.docx";
            
        }

    }
}
