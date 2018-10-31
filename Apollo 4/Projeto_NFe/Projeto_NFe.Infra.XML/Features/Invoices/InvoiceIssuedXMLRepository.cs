using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Domain.Features.Taxes;
using Projeto_NFe.Infra.XML.Features.Invoices.Mapper;
using Projeto_NFe.Infra.XML.Features.Invoices.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML.Features.Invoices
{
    public class InvoiceIssuedXMLRepository : IInvoiceIssuedXMLRepository
    {

        private StreamWriter _write;

        public void Export(InvoiceIssued invoiceIssued, string path)
        {
            using (_write = new StreamWriter(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(NFeXMLModel));
                TextWriter write = _write;
                serializer.Serialize(write, Take(invoiceIssued));
                write.Close();
            }
        }


        private NFeXMLModel Take(InvoiceIssued invoiceIssued)
        {
            NFeXMLMapper mapper = new NFeXMLMapper();

            return mapper.Map(invoiceIssued);
        }
    }
}
