



using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Spire.Pdf;
using Spire.Pdf.General.Find;
using Spire.Pdf.Graphics;
using System.Drawing;

namespace PrintFormService.Services
{
    public class PrintService : IPrintService
    {
        public async Task<string> ExportTemplate(string pdfFile, string outputname)
        {
            String inputfilename = pdfFile;
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(inputfilename);
            //var p = TransformText(doc.Pages[0]);
            //doc.InsertPage(doc,p);
            // doc.Close();
            PdfPageBase page = doc.Pages[0];
            PdfTextFindCollection collection = page.FindText("123", TextFindParameter.IgnoreCase);

            String newText = "HERE I WRITE NEW TEST LINE";
            //Creates a brush
            PdfBrush brush = new PdfSolidBrush(Color.Red);
            //Defines a font
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Regular));

            RectangleF rec;
            foreach (PdfTextFind find in collection.Finds)
            {
                // Gets the bound of the found text in page
                rec = find.Bounds;
                page.Canvas.DrawRectangle(PdfBrushes.Black, rec);
                page.Canvas.DrawString(newText, font, brush, rec);

            }

            //pdfsections = doc.Sections;
            doc.SaveToFile("newdoc.pdf");
            return "newdoc.pdf";
            
        }

        private static PdfPageBase TransformText(PdfPageBase page)
        {
            //save graphics state
            PdfGraphicsState state = page.Canvas.Save();

            //Draw the text - transform           
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 60f);
            PdfSolidBrush brush2 = new PdfSolidBrush(Color.Red);

            page.Canvas.TranslateTransform(20, 200);
            page.Canvas.ScaleTransform(1f, 0.6f);

            page.Canvas.SkewTransform(0, 0);
            page.Canvas.DrawString("TESTTTTTT!!!!!!!", font, brush2, 0, 0);

            //restor graphics
            page.Canvas.Restore(state);
            return page;
        }
    }
}
