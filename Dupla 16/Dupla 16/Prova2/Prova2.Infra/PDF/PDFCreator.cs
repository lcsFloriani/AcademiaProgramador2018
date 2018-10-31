using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Prova2.Infra.PDF
{
    public class PDFCreator
    {
        private Document _document;
        private PdfWriter _pdfWriter;

        public PDFCreator(string file)
        {
            _document = new Document(PageSize.A4);
            _document.SetMargins(40, 40, 40, 80);
            _document.AddCreationDate();

            _pdfWriter = PdfWriter.GetInstance(_document, new FileStream(file, FileMode.Create));
        }

        public void OpenDocument()
        {
            _document.Open();
        }

        public void CloseDocument()
        {
            _document.Close();
        }

        public void Write(string text)
        {
            Paragraph paragraph = new Paragraph(String.Empty, new Font(Font.NORMAL, 14));

            paragraph.Alignment = Element.ALIGN_JUSTIFIED;

            paragraph.Add(text);

            _document.Add(paragraph);
        }
    }
}
