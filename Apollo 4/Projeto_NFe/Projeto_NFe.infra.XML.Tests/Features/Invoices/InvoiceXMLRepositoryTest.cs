using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Domain.Features.Taxes;
using Projeto_NFe.Infra.AccessKeys;
using Projeto_NFe.Infra.CNPJ;
using Projeto_NFe.Infra.CPF;
using Projeto_NFe.Infra.XML.Features.Invoices;

namespace Projeto_NFe.infra.XML.Tests.Features.Invoices
{
    [TestFixture]
    public class InvoiceXMLRepositoryTest
    {
        private IInvoiceIssuedXMLRepository _xmlRepository;

        private InvoiceIssued _invoiceIssued;
        private Conveyor _conveyor;
        private Emitter _emitter;
        private Receiver _receiver;
        private List<ItemInvoice> _itens;
        private AccessKey _key;
        private Tax _tax;

        [SetUp]
        public void Initialize()
        {
            _xmlRepository = new InvoiceIssuedXMLRepository();

            Address address = ObjectMother.GetAddress();
            Cnpj cnpj = ObjectMother.GetCnpj();
            Cpf cpf = ObjectMother.GetCpf();

            _conveyor = ObjectMother.GetPhysicalConveyor(address, cpf);
            _conveyor.Id = 1;
            _emitter = ObjectMother.GetEmitter(address, cnpj);
            _emitter.Id = 1;
            _receiver = ObjectMother.GetReceiverPhysicalWithCpf(address, cpf);
            _receiver.Id = 1;
            _itens = new List<ItemInvoice>();
            _itens.Add(new ItemInvoice { Product = ObjectMother.GetProduct(), Quantity = 2});
            _itens.Add(new ItemInvoice { Product = ObjectMother.GetProduct(), Quantity = 3});
            _key = ObjectMother.GetAccessKey();
            _tax = ObjectMother.GetTaxWithOutInvoice();

            _invoiceIssued = ObjectMother.GetInvoiceIssued(_conveyor, _emitter, _receiver, _itens, _tax, _key);
            _invoiceIssued.Tax.invoice = _invoiceIssued;
        }

        [Test]
        public void Invoices_Infraxml_Export_WithReceiverPhysical_ShouldExportWithSuccess()
        {

            //Cenario
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = Path.Combine(desktop, "TesteDeNotaFiscal(destinatario Fisico).xml");

            //Ação
            _xmlRepository.Export(_invoiceIssued, path);

            //Saída
            bool exist = File.Exists(path);

            exist.Should().BeTrue();
        }

        [Test]
        public void Invoices_Infraxml_Export_WithReceiverLegal_ShouldExportWithSuccess()
        {

            //Cenario
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = Path.Combine(desktop, "TesteDeNotaFiscal(destinatario Juridico).xml");

            _receiver = ObjectMother.GetReceiverLegalWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            _receiver.Id = 1;

            _invoiceIssued = ObjectMother.GetInvoiceIssued(_conveyor, _emitter, _receiver, _itens, _tax, _key);
            _invoiceIssued.Tax.invoice = _invoiceIssued;

            //Ação
            _xmlRepository.Export(_invoiceIssued, path);

            //Saída
            bool exist = File.Exists(path);

            exist.Should().BeTrue();
        }
    }
}
