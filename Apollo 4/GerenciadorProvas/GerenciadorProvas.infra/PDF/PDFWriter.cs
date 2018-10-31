using GerenciadorProvas.Dominio;
using GerenciadorProvas.Dominio.Modal;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.infra.PDF
{
   public class PDFWriter<T> where T : Entidade
    {
       
        public void Write(Action<Document, T> formatadorDePdf, T entidade, string path)
        {
            try
            {
                Document document = CreateDocument();
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

                formatadorDePdf(document, entidade);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        private Document CreateDocument()
        {
            Document document = new Document(PageSize.A4);
            document.SetMargins(40, 40, 40, 80);
            document.AddCreationDate();

            return document;
        }

        private void AddParagraph(Document document, Paragraph paragraph)
        {
            document.Add(paragraph);
        }

        private Paragraph GetItemParagraph(string text)
        {
            Paragraph paragraph = new Paragraph("", new Font(Font.NORMAL, 14));
            paragraph.Alignment = Element.ALIGN_JUSTIFIED;
            paragraph.Font = new Font(Font.NORMAL, 12, (int)System.Drawing.FontStyle.Regular);

            paragraph.Add(text);

            return paragraph;
        }

        private Paragraph GetTitleParagraph(string text)
        {
            Paragraph paragraph = new Paragraph("", new Font(Font.NORMAL, 14));
            paragraph.Alignment = Element.ALIGN_CENTER;
            paragraph.Font = new Font(Font.NORMAL, 12, (int)System.Drawing.FontStyle.Regular);

            paragraph.Add(text);

            return paragraph;
        }
    }
}
