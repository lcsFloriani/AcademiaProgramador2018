using GerenciadorProvas.Dominio.Modal;
using GerenciadorProvas.infra.PDF;
using GerenciadorProvas.Infra.Dados.IoC;
using System;

namespace GerenciadorProvas.Aplicacao.Features.TesteServico
{
    public class TesteServico : Servico<Teste>
    {

        private readonly PDFWriter<Teste> _pdfGenerador = new PDFWriter<Teste>();

        public TesteServico() : base(IoCRepository.RepositorioTeste)
        {
        }

        public void VisualizarPDF(Teste entidade, string caminho)
        {
            try
            {
                _pdfGenerador.Write(PDFFormat.FormatPdfTeste, entidade, caminho);                   
            }
            catch (Exception x)
            {
                throw x;
            }
        }

    }

  
}
