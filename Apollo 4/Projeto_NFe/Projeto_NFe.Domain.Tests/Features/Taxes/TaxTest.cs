using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Domain.Features.Taxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Features.Taxes
{
    [TestFixture]
    public class TaxTest
    {
        Mock<InvoiceIssued> _mockInvoicedIssued;
        Mock<ItemInvoice> _mockItemInvoice;

        [SetUp]
        public void Initialize()
        {
            _mockInvoicedIssued = new Mock<InvoiceIssued>();
            _mockItemInvoice = new Mock<ItemInvoice>();
            
            Product product = ObjectMother.GetProduct();
            product.UnitaryValue = 2;
            _mockItemInvoice.Object.Product = product;
            _mockItemInvoice.Object.Quantity = 1;

            _mockInvoicedIssued.Object.Items = new List<ItemInvoice> { _mockItemInvoice.Object };
        }

     
        [Test]
        public void Tax_Domain_TotalICMS_ShouldTotalICMSWithSuccess()
        {
            //Cenário
            double ExpectedValue =  0.08;
            Tax tax = ObjectMother.GetTax(_mockInvoicedIssued.Object);


            //Ação e Saída
            tax.TotalIcmsValue.Should().Be(ExpectedValue);      
        }

        [Test]
        public void Tax_Domain_TotalIPI_ShouldTotalIPIWithSuccess()
        {
            //Cenário
            double ExpectedValue =  0.2;
            Tax tax = ObjectMother.GetTax(_mockInvoicedIssued.Object);


            //Ação e Saída
            tax.TotalIpiValue.Should().Be(ExpectedValue);      
        }

        [Test]
        public void Tax_Domain_TotalProductValue_ShouldTotalProductValueWithSuccess()
        {
            //Cenário
            double ExpectedValue = 2;
            Tax tax = ObjectMother.GetTax(_mockInvoicedIssued.Object);


            //Ação e Saída
            tax.TotalProductValue.Should().Be(ExpectedValue);
        }

        [Test]
        public void Tax_Domain_TotalInvoice_ShouldTotalInvoiceWithSuccess()
        {
            //Cenário
            double ExpectedValue = 4.28;
            Tax tax = ObjectMother.GetTax(_mockInvoicedIssued.Object);


            //Ação e Saída
            tax.TotalInvoice.Should().Be(ExpectedValue);
        }
    }
}
