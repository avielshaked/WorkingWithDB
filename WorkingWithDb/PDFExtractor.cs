using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithDb
{
    class PDFExtractor
    {
        public static string ExtractTextFromPDF(string pdfFileName)
        {
            StringBuilder result = new StringBuilder();
            // Create a reader for the given PDF file
            using (PdfReader reader = new PdfReader(pdfFileName))
            {
                // Read pages
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    SimpleTextExtractionStrategy strategy =
                        new SimpleTextExtractionStrategy();
                    string pageText =
                        PdfTextExtractor.GetTextFromPage(reader, page, strategy);
                    result.Append(pageText);
                }
            }
            return result.ToString();
        }

        public static string ReverseText(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
