﻿
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System.Drawing;

namespace PrintFormService.Services
{
    public class PrintService : IPrintService
    {
        public async Task<string> ExportTemplate(string filepath, string outputname)
        {
            String inputfilename = filepath;
           Document document= new Document();
            document.LoadFromFile(inputfilename);
            Section section = document.Sections[0];
            Paragraph para1 = section.Paragraphs[0];
            para1.Text = "Spire.Doc for .NET Introduction";

            //Add New Text
            Paragraph para2 = section.Paragraphs[1];
            TextRange tr = para2.AppendText("Spire.Doc for .NET is stand-alone"
            + "to enables developers to operate Word witout Microsoft Word installed.");
            tr.CharacterFormat.FontName = "Cataneo BT";
            tr.CharacterFormat.FontSize = 12;
            tr.CharacterFormat.TextColor = Color.YellowGreen;

            //Save and Launch
            document.SaveToFile("Edit Word.docx", FileFormat.Docx);
            return "Edit Word.docx";
            
        }

    }
}