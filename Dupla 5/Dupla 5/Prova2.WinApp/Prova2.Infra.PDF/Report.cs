using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Infra
{
    public class Report
    {
        public Report()
        {
        }

        public void GeneratePdf(string file, string list)
        {
            FileStream fs = new FileStream(file, FileMode.Create);
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            document.Open();

            document.AddAuthor("Diego e Felipe");
            document.AddTitle("Lista de Livros");

            document.Add(new Paragraph("Lista de Livros e Vendas" + "\n"));
            document.Add(new Paragraph(list));

            document.Close();
            writer.Close();
            fs.Close();
        }
    }
}
