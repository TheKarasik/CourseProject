using CourseProject.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xceed.Words.NET;
using GemBox.Document;

namespace CourseProject
{
    public class WordReader
    {
        public static void ReadDoc(docFileModel docx)
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            string encryptedText;
            //Чтение
            using (FileStream fs = new FileStream(Path.Combine(docx.Path, $"{docx.File.FileName}"), FileMode.Create))
            {
                docx.File.CopyTo(fs);
                var document1 = DocumentModel.Load(fs);
                string text = document1.Content.ToString();
                encryptedText = DeNcoder.Encrypt(text, docx.Key);

            }
            //Запись
            DocumentModel document = new DocumentModel();

            document.Content.Delete();
            document.Content.LoadText(encryptedText);
            document.Save(Path.Combine(docx.Path, $"{docx.File.FileName}"));
        }
    }
}
