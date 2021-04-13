using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_sinacor.Services
{
    public static class PdfService
    {
        public static string ExtractTextFromPdf(string file)
        {
            var reader = new PdfReader(file);
            var document = new PdfDocument(reader);
            var page = document.GetPage(1);
            var text = PdfTextExtractor.GetTextFromPage(page);

            text = text.ToLower()
                .Replace("\r\n"," ")
                .Replace("\n", " ")
                .Replace("\r", " ");

            return text;
        }
    }
}
