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
        public void ItemInvoices_Domain_Validate_ShouldValidateWithSuccess()
        {
            //Cenário
            _mockProduct.Setup(x => x.Validate());
            _mockInvoice.Setup(x => x.Validate());
            _mockProduct.Object.Description = "Arroz";
            _mockProduct.Object.UnitaryValue = 1;

            ItemInvoice itemInvoice = ObjectMother.GetItemInvoice(_mockProduct.Object, _mockInvoice.Object);

            //Ação
            Action action = itemInvoice.Validate;

            //Saída
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void ItemInvoice_Domain_Validate_NullProduct_ShouldThrowsItemInvoiceNullProductException()
        {
            //Cenário 
            _mockProduct.Setup(x => x.Validate());
            _mockInvoice.Setup(x => x.Validate());

            ItemInvoice itemInvoice = ObjectMother.GetItemInvoiceInvalidProduct(_mockInvoice.Object);

            //Ação
            Action action = itemInvoice.Validate;

            //Saída 
            action.Should().Throw<ItemInvoiceNullProductException>();
        }

       
        [Test]
        public void ItemInvoice_Domain_Validate_Quantity_LessOrEqualThanOne_ShouldThrowItemInvoiceQuantityLessThanOneException()
        {
            //Cenário
            _mockProduct.Setup(x => x.Validate());
            _mockInvoice.Setup(x => x.Validate());
            _mockProduct.Object.Description = "Arroz";
            _mockProduct.Object.UnitaryValue = 1;

            ItemInvoice itemInvoice = ObjectMother.GetItemInvoiceInvalidQuantity(_mockProduct.Object, _mockInvoice.Object);

            //Ação
            Action action = itemInvoice.Validate;

            //Saída
            action.Should().Throw<ItemInvoiceQuantityLessThanOneException>();
        }

        [Test]
        public void ItemInvoice_Domain_SetProduct_ShouldBeOk()
        {
            //Cenário
            _mockProduct.Setup(x => x.Validate());
            _mockInvoice.Setup(x => x.Validate());
            _mockProduct.Object.Description = "Arroz";
            _mockProduct.Object.UnitaryValue = 2;

            ItemInvoice itemInvoice = ObjectMother.GetItemInvoice(_mockProduct.Object, _mockInvoice.Object);

            //Ação
            itemInvoice.SetProduct(_mockProduct.Object);

            //Saída
            itemInvoice.Product.Should().NotBeNull();
        }

        [Test]
        public void ItemInvoice_SetProduct_NullProduct_ShouldBeFail()
        {
            //Cenário
            _mockProduct.Setup(x => x.Validate());
            _mockInvoice.Setup(x => x.Validate());
            _mockProduct.Object.Description = "Arroz";
            _mockProduct.Object.UnitaryValue = 2;

            ItemInvoice itemInvoice = ObjectMother.GetItemInvoiceInvalidProduct(_mockInvoice.Object);

            //Ação
            Action action = () => itemInvoice.SetProduct(null);

            //Saída
            action.Should().Throw<ItemInvoiceNullProductException>();
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
