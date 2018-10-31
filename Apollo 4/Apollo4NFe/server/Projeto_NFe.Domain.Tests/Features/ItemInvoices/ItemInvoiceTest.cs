using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Features.ItemInvoices
{
    [TestFixture]
    public class ItemInvoiceTest
    {
        private Mock<Product> _mockProduct;
        private Mock<InvoiceInProcess> _mockInvoice;

        [SetUp]
        public void Initialize()
        {
            _mockProduct = new Mock<Product>();
            _mockInvoice = new Mock<InvoiceInProcess>();
        }

 
        [Test]
        public void ItemInvoice_TotalValue_ShouldBeOK()
        {
            //Cenário
            _mockProduct.Object.UnitaryValue = 2;
            ItemInvoice itemInvoice = ObjectMother.GetItemInvoice(_mockProduct.Object, _mockInvoice.Object);
            double ExpectedValue = _mockProduct.Object.UnitaryValue * itemInvoice.Quantity;
            
            //Ação e Saída
            itemInvoice.TotalValue.Should().Be(ExpectedValue);

        }

        [Test]
        public void ItemInvoices_Domain_ICMSValue_ShouldICMSValueWithSuccess()
        {
            //Cenário
            _mockProduct.Object.UnitaryValue = 2;

            double ExpectedValue = 0.16;

            ItemInvoice itemInvoice = ObjectMother.GetItemInvoice(_mockProduct.Object, _mockInvoice.Object);
            
            //Ação e Saída
            itemInvoice.ICMSValue.Should().Be(ExpectedValue);

        }

        [Test]
        public void ItemInvoices_Domain_IPIValue_ShouldIPIValueWithSuccess()
        {
            //Cenário
            _mockProduct.Object.UnitaryValue = 2;

            double ExpectedValue = 0.4;

            ItemInvoice itemInvoice = ObjectMother.GetItemInvoice(_mockProduct.Object, _mockInvoice.Object);

            //Ação e Saída
            itemInvoice.IPIValue.Should().Be(ExpectedValue);

        }
    }
}
