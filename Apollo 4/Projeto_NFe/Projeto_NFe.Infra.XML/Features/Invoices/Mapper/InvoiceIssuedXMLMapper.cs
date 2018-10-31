using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Infra.XML.Features.Invoices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.XML.Features.Invoices.Mapper
{
    public class InvoiceIssuedXMLMapper : IMapper<InvoiceIssuedXMLModel, InvoiceIssued>
    {
        private InvoiceIssuedXMLModel _invoiceIssuedXMLModel;

        public InvoiceIssuedXMLModel Map(InvoiceIssued entity)
        {
            _invoiceIssuedXMLModel = new InvoiceIssuedXMLModel
            {
                NatureOperation = entity.NatureOperation,
                IssuanceDate = entity.IssuanceDate
            };

            return _invoiceIssuedXMLModel;
        }
    }
}
