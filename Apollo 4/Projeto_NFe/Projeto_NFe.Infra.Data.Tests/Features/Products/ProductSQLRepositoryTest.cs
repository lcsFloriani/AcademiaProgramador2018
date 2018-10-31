using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Infra.Data.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Data.Tests.Features.Products
{
    [TestFixture]
    public class ProductSQLRepositoryTest
    {
       private IProductRepository _repository;

       [SetUp]
       public void Initialize()
        {
            _repository = new ProductSQLRepository();
        }

        [Test]
        public void Products_InfraData_Save_ShouldSaveWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithoutProduct();

            Product product = ObjectMother.GetProduct();
            long expectedId = 1;

            //Ação
            Product result = _repository.Save(product);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(expectedId);
        }

        [Test]
        public void Products_InfraData_Save_ShouldThrowDescriptionNullOrEmptyException()
        {
            //Cenário
            Product product = ObjectMother.GetProductWithDescriptionNullOrEmpty();

            //Ação
            Action action = () => _repository.Save(product);

            //Saída
            action.Should().Throw<ProductDescriptionNullOrEmptyException>();
        }

        [Test]
        public void Products_InfraData_Get_ShouldGetWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithProduct();
            long searchId = 1;

            //Ação
            Product result = _repository.Get(searchId);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(searchId);
        }

        [Test]
        public void Products_InfraData_Get_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            long id = 0;

            //Execução
            Action action = () => _repository.Get(id);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Products_InfraData_Update_ShouldUpdateWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithProduct();

            long searchId = 1;
            Product product = _repository.Get(searchId);
      
            //Ação
            Product result = _repository.Update(product);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(searchId);
        }

        [Test]
        public void Products_InfraData_Update_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            Product product = ObjectMother.GetProduct();

            //Execução
            Action action = () => _repository.Update(product);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Products_InfraData_GetAll_ShouldGetAllWithSuccess()
        {
            //Cenario
            int amountItems = 1;

            //Execução
            var result = _repository.GetAll();

            //Saída
            result.Count().Should().Be(amountItems);
        }

        [Test]
        public void Products_InfraData_Delete_ShouldDeleteWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithProduct();

            int id = 1;
            Product product = _repository.Get(id);

            //Ação
            _repository.Delete(product);

            //Saída
            Product result = _repository.Get(id);
            result.Should().BeNull();
        }

        [Test]
        public void Products_InfraData_Delete_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            int id = 0;
            Product product = ObjectMother.GetProduct();
            product.Id = id;

            //Ação
            Action action = () => _repository.Delete(product);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Products_InfraData_CheckDependency_ShouldCheckDependencyWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithProductWithDependency();

            long searchId = 1;
            Product product = _repository.Get(searchId);

            //Ação
            var result = _repository.CheckDependency(product);

            //Saída
            result.Should().BeTrue();//tem dependencias
        }

    }
}
