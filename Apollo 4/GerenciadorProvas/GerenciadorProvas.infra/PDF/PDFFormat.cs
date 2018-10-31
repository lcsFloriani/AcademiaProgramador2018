using GerenciadorProvas.Dominio.Modal;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace GerenciadorProvas.infra.PDF
{
    public static class PDFFormat
    {

        public static void FormatPdfTeste(Document documento, Teste teste) {


            // Open the Document for writing
            documento.Open();

            //Cofiguração das bagaças
            var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
            var subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
            var boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
            var endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
            var bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);

            var orderInfoTable = new PdfPTable(2);
            orderInfoTable.HorizontalAlignment = 0;
            orderInfoTable.SpacingBefore = 10;
            orderInfoTable.SpacingAfter = 10;
            orderInfoTable.DefaultCell.Border = 0;
            orderInfoTable.SetWidths(new int[] { 1, 4 });

            orderInfoTable.AddCell(new Phrase("Escola:", boldTableFont));
            orderInfoTable.AddCell("E.E.B. Mariana Rech Sartor");
            orderInfoTable.AddCell(new Phrase("Disciplina:", boldTableFont));
            orderInfoTable.AddCell(teste.Cadeira.Cadeira.Nome);
            orderInfoTable.AddCell(new Phrase("Série:", boldTableFont));
            orderInfoTable.AddCell(teste.Cadeira.Serie.Grau.ToString() + "º");
            orderInfoTable.AddCell(new Phrase("Data:", boldTableFont));
            orderInfoTable.AddCell(DateTime.Now.ToShortDateString());
            orderInfoTable.AddCell(new Phrase("Nome:", boldTableFont));
            orderInfoTable.AddCell(new Phrase("", boldTableFont));            
            orderInfoTable.AddCell("\n");



            documento.Add(orderInfoTable);

            //Logo
            System.Drawing.Bitmap bmp = (System.Drawing.Bitmap)Properties.Resources.otima_prova;
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Png);
            byte[] bmpBytes = ms.ToArray();


            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(bmpBytes);
            logo.SetAbsolutePosition(440, 730);
            documento.Add(logo);


            // Add the Paragraph object to the document
            Paragraph title = new Paragraph(teste.Titulo, titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            documento.Add(title);

            //Espaço em Branco
            documento.Add(new Paragraph("\n", bodyFont));

            for (int x = 0; x < teste.Questoes.Count; x++)
            {
                var questao = teste.Questoes[x];
                documento.Add(new Paragraph(string.Format("Questão {0}:  ", x + 1), subTitleFont));

                //Enunciado
                Paragraph p = new Paragraph(questao.Enunciado, bodyFont);

                p.Alignment = Element.ALIGN_JUSTIFIED;
                documento.Add(p);

                //Espaço em Branco
                documento.Add(new Paragraph("\n", bodyFont));

                //Reposta
                foreach (Resposta r in questao.Respostas)
                {
                    documento.Add(new Paragraph(string.Format("({0})  {1}", r.Letra, r.Descricao), bodyFont));
                }
                //Espaço em Branco
                documento.Add(new Paragraph("\n", bodyFont));
            }

            documento.NewPage();

            Paragraph gabarito = new Paragraph(string.Format("Gabarito - {0}", teste.Titulo), subTitleFont);
            gabarito.Alignment = Element.ALIGN_CENTER;
            documento.Add(gabarito);

            documento.Add(new Paragraph("\n", bodyFont));

            for (int x = 0; x < teste.Questoes.Count; x++)
            {
                var questao = teste.Questoes[x];
                documento.Add(new Paragraph(string.Format(string.Format("Questão {0}:  ({1})  ", x + 1, questao.AltenativaCorreta().Letra)), bodyFont));
            }

            // Close the Document - this saves the document contents to the output stream
            documento.Close();
        }
    }
}
