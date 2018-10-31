using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Infra.Data.Features.Products;
using Projeto_NFe.Infra.ORM.Tests.Inicialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Tests.Features.Products
{
    [TestFixture]
    public class ProductRepositoryTest : EffortBaseTest
	{
       private IProductRepository _repository;

       [SetUp]
       public void Initialize()
        {
            _repository = new ProductRepository(this.context);
        }

        [Test]
        public void Products_InfraData_Save_ShouldSaveWithSuccess()
        {
            //Cenário
            Product product = ObjectMother.GetProduct();
            long expectedId = 3;

            //Ação
            Product result = _repository.Save(product);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(expectedId);
        }

        [Test]
        public void Products_InfraData_Get_ShouldGetWithSuccess()
        {
            //Cenário
           
            long searchId = 1;

            //Ação
            Product result = _repository.Get(searchId);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(searchId);
        }

        [Test]
        public void Products_InfraData_Update_ShouldUpdateWithSuccess()
        {
            //Cenário
            long searchId = 1;
            Product product = _repository.Get(searchId);
      
            //Ação
            bool updated = _repository.Update(product);

			//Saída
			updated.Should().BeTrue();
			Product result = _repository.Get(searchId);
			result.Should().NotBeNull();
            result.Id.Should().Be(searchId);
        }

        [Test]
        public void Products_InfraData_GetAll_ShouldGetAllWithSuccess()
        {
            //Cenario
            int amountItems = 2;

            //Execução
            var result = _repository.GetAll();

            //Saída
            result.Count().Should().Be(amountItems);
        }

		[Test]
		public void Products_InfraData_GetAllWithSize_ShouldGetAllWithSuccess()
		{
			//Cenario
			int amountItems = 0;

			//Execução
			var result = _repository.GetAll(amountItems);

			//Saída
			result.Count().Should().Be( amountItems );
		}

		[Test]
        public void Products_InfraData_Delete_ShouldDeleteWithSuccess()
        {
            //Cenario
           

            long id = 1;
            Product product = _repository.Get(id);

            //Ação
            _repository.Delete(product.Id);

            //Saída
            Product result = _repository.Get(id);
            result.Should().BeNull();
        }

     
        [Test]
        public void Products_InfraData_CheckDependency_ShouldCheckDependencyWithSuccess()
        {
            //Cenario
            long searchId = 1;
            Product product = _repository.Get(searchId);

            //Ação
            var result = _repository.CheckDependency(product.Id);

            //Saída
            result.Should().BeTrue();//tem dependencias
        }

    }
}
