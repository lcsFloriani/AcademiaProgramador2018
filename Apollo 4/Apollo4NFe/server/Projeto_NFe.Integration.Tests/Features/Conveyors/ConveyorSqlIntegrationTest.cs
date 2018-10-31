//using FluentAssertions;
//using NUnit.Framework;
//using Projeto_NFe.Application.Features.Conveyors;
//using Projeto_NFe.Common.Tests.Base;
//using Projeto_NFe.Domain.Enums;
//using Projeto_NFe.Domain.Exceptions;
//using Projeto_NFe.Domain.Features.Addresses;
//using Projeto_NFe.Domain.Features.Conveyors;
//using Projeto_NFe.Infra.CNPJ;
//using Projeto_NFe.Infra.CPF;
//using Projeto_NFe.Infra.Data.Features.Conveyors;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Projeto_NFe.Integration.Tests.Features.Conveyors
//{
//    [TestFixture]
//    public class ConveyorSQLIntegrationTest
//    {
//        private IConveyorRepository _conveyorRepository;
//        private IConveyorService _service;

//        [SetUp]
//        public void Initialize()
//        {
//            _conveyorRepository = new ConveyorSQLRepository();
//            _service = new ConveyorService(_conveyorRepository);
//        }

//        [Test]
//        public void Conveyors_Integration_ConveyorPhysical_Add_ShouldAddWithSuccess()
//        {
//            //Cenario
//            BaseSqlTest.SeedDatabaseWithoutConveyor();

//            Address address = ObjectMother.GetAddress();
//            Cpf cpf = ObjectMother.GetCpf();
//            Conveyor c = ObjectMother.GetPhysicalConveyor(address,cpf);

//            int expectedId = 1;

//            //Ação
//            var result = _service.Add(c);

//            //Saída
//            result.Id.Should().Be(expectedId);
//        }

//        [Test]
//        public void Conveyors_Integration_ConveyorLegal_Add_ShouldAddWithSuccess()
//        {
//            //Cenario
//            BaseSqlTest.SeedDatabaseWithoutConveyor();

//            Address address = ObjectMother.GetAddress();
//            Cnpj cnpj = ObjectMother.GetCnpj();
//            Conveyor c = ObjectMother.GetLegalConveyorWithCnpj(address, cnpj);

//            int expectedId = 1;

//            //Ação
//            var result = _service.Add(c);

//            //Saída
//            result.Id.Should().Be(expectedId);

//        }


//        [Test]
//        public void Conveyors_Integration_Add_ShouldThrowFreightResponsibilityDefaultException()
//        {
//            //Cenario
//            Conveyor c = new Conveyor();
            
//            //Ação
//            Action action = () => _service.Add(c);

//            //Saída
//            action.Should().Throw<ConveyorFreightResponsibilityDefaultException>();
//        }

//        [Test]
//        public void Conveyors_Integration_Add_Validate_ShouldThrowAddressNullException()
//        {
//            //Cenario
//            Conveyor c = ObjectMother.GetConveyorWithoutAddress();

//            //Ação
//            Action action = () => _service.Add(c);

//            //Saída
//            action.Should().Throw<ConveyorAddressNullException>();
//        }

//        [Test]
//        public void Conveyors_Integration_Add_Validate_ShouldThrowTypeDefaultException()
//        {
//            //Cenario
//            Address address = ObjectMother.GetAddress();
//            Conveyor c = ObjectMother.GetConveyor(address);

//            //Ação
//            Action action = () => _service.Add(c);

//            //Saída
//            action.Should().Throw<ConveyorTypeDefaultException>();
//        }

//        [Test]
//        public void Conveyors_Integration_Add_Validate_ShouldThrowNameNullOrEmptyException()
//        {
//            //Cenario
//            Address address = ObjectMother.GetAddress();
//            Cpf cpf = ObjectMother.GetCpf();
//            Conveyor c = ObjectMother.GetPhysicalConveyorWithNameNullOrEmpty(address,cpf);

//            //Ação
//            Action action = () => _service.Add(c);

//            //Saída
//            action.Should().Throw<ConveyorNameNullOrEmptyException>();
//        }

//        [Test]
//        public void Conveyors_Integration_Add_Validate_ShouldThrowCpfNullException()
//        {
//            //Cenario
//            Address address = ObjectMother.GetAddress();
//            Conveyor c = ObjectMother.GetPhysicalConveyorWithoutCpf(address);

//            //Ação
//            Action action = () => _service.Add(c);

//            //Saída
//            action.Should().Throw<ConveyorCpfNullException>();
//        }

//        [Test]
//        public void Conveyors_Integration_Add_Validate_ShouldThrowCompanyNameNullOrEmptyException()
//        {
//            //Cenario
//            Address address = ObjectMother.GetAddress();
//            Cnpj cnpj = ObjectMother.GetCnpj();
//            Conveyor c = ObjectMother.GetLegalConveyorWithCompanyNameNullOrEmpty(address, cnpj);

//            //Ação
//            Action action = () => _service.Add(c);

//            //Saída
//            action.Should().Throw<ConveyorCompanyNameNullOrEmptyException>();
//        }

//        [Test]
//        public void Conveyors_Integration_Add_Validate_ShouldThrowCnpjNullException()
//        {
//            //Cenario
//            Address address = ObjectMother.GetAddress();
//            Conveyor c = ObjectMother.GetLegalConveyorWithoutCnpj(address);

//            //Ação
//            Action action = () => _service.Add(c);

//            //Saída
//            action.Should().Throw<ConveyorCnpjNullException>();
//        }


//        [Test]
//        public void Conveyors_Integration_Update_ShouldUpdateWithSuccess()
//        {
//            //Cenario
//            BaseSqlTest.SeedDatabaseWithConveyor();

//            long searchId = 1;
//            string newName = "Teste TT";
//            string newStreet = "Av. kkkk";

//            Conveyor c = _service.Get(searchId);
//            c.NameCompanyName = newName;
//            c.Address.Street = newStreet;

//            //Ação
//            _service.Update(c);

//            //Saída
//            var result = _service.Get(searchId);
//            c.NameCompanyName.Should().Be(newName);
//            c.Address.Street.Should().Be(newStreet);
//        }

//        [Test]
//        public void Conveyors_Integration_Update_Invalid_d_ShouldThrowIdentifierUndefinedException()
//        {
//            //Cenario
//            long id = 0;
        
//            Conveyor c = new Conveyor { Id = id};
        
//            //Ação
//            Action action = () => _service.Update(c);

//            //Saída
//            action.Should().Throw<IdentifierUndefinedException>();
//        }

//        [Test]
//        public void Conveyors_Integration_Update_Validate_ShouldThrowFreightResponsibilityDefaultException()
//        {
//            //Cenario
//            long searchId = 1;
//            Conveyor c = _service.Get(searchId);
//            c.FreightResponsibility = FreightResponsibility.DEFAULT;

//            //Ação
//            Action action = () => _service.Update(c);

//            //Saída
//            action.Should().Throw<ConveyorFreightResponsibilityDefaultException>();
//        }

//        [Test]
//        public void Conveyors_Integration_Update_Validate_ShouldThrowAddressNullException()
//        {
//            //Cenario
//            long searchId = 1;
//            Conveyor c = _service.Get(searchId);
//            c.Address = null;

//            //Ação
//            Action action = () => _service.Update(c);

//            //Saída
//            action.Should().Throw<ConveyorAddressNullException>();
//        }

//        [Test]
//        public void Conveyors_Integration_Update_Validate_ShouldThrowTypeDefaultException()
//        {
//            //Cenario
//            long searchId = 1;
//            Conveyor c = _service.Get(searchId);
//            c.Type = PersonType.DEFAULT;

//            //Ação
//            Action action = () => _service.Update(c);

//            //Saída
//            action.Should().Throw<ConveyorTypeDefaultException>();
//        }

//        [Test]
//        public void Conveyors_Integration_Update_Validate_ShouldThrowNameNullOrEmptyException()
//        {
//            //Cenario
//            BaseSqlTest.SeedDatabaseWithConveyor();

//            long searchId = 1;
//            Conveyor c = _service.Get(searchId);
//            c.NameCompanyName = null;

//            //Ação
//            Action action = () => _service.Update(c);

//            //Saída
//            action.Should().Throw<ConveyorNameNullOrEmptyException>();
//        }

//        [Test]
//        public void Conveyors_Integration_Update_Validate_ShouldThrowCpfNullException()
//        {
//            //Cenario
//            long searchId = 1;
//            Conveyor c = _service.Get(searchId);
//            c.Cpf = null;

//            //Ação
//            Action action = () => _service.Update(c);

//            //Saída
//            action.Should().Throw<ConveyorCpfNullException>();
//        }

//        [Test]
//        public void Conveyors_Integration_Legal_Update_Validate_ShouldThrowCompanyNameNullOrEmptyException()
//        {
//            //Cenario
//            long searchId = 2;
//            Conveyor c = _service.Get(searchId);
//            c.NameCompanyName = null;

//            //Ação
//            Action action = () => _service.Add(c);

//            //Saída
//            action.Should().Throw<ConveyorCompanyNameNullOrEmptyException>();
//        }

//        [Test]
//        public void Conveyors_Integration_Legal_Update_ShouldThrowCnpjNullException()
//        {
//            //Cenario
//            long searchId = 2;
//            Conveyor c = _service.Get(searchId);
//            c.Cnpj = null;

//            //Ação
//            Action action = () => _service.Add(c);

//            //Saída
//            action.Should().Throw<ConveyorCnpjNullException>();
//        }

//        [Test]
//        public void Conveyors_Integration_Get_ShouldGetWithSuccess()
//        {
//            //Cenario
//            BaseSqlTest.SeedDatabaseWithConveyor();

//            long searchId = 1;

//            //Ação
//            Conveyor c = _service.Get(searchId);

//            //Saída
//            c.Should().NotBeNull();
//            c.Address.Should().NotBeNull();
//        }

//        [Test]
//        public void Conveyors_Integration_Get_Validate_ShouldThrowIdentifierUndefinedException()
//        {
//            //Cenario
//            long searchId = 0;

//            //Ação
//            Action action = () => _service.Get(searchId);

//            //Saída
//            action.Should().Throw<IdentifierUndefinedException>();
//        }


//        [Test]
//        public void Conveyors_Integration_GetAll_ShouldGetAllWithSuccess()
//        {
//            //Cenario
//            BaseSqlTest.SeedDatabaseWithConveyor();

//            int biggerThan = 0;
//            int size = 2;
//            long id = 1;

//            //Ação
//            List<Conveyor> list = _service.GetAll() as List<Conveyor>;

//            //Saída
//            list.Should().NotBeNull();
//            list.Count.Should().BeGreaterThan(biggerThan);
//            list.Count.Should().Be(size);
//            list.First().Id.Should().Be(id);
//        }

//        [Test]
//        public void Conveyors_Integration_Delete_ShouldDeleteWithSuccess()
//        {
//            //Cenario
//            BaseSqlTest.SeedDatabaseWithConveyor();

//            long searchId = 1;
//            Conveyor c = _service.Get(searchId);

//            //Ação
//            _service.Delete(c);

//            //Saída
//            var result = _service.Get(searchId);
//            result.Should().BeNull();
//        }

//        [Test]
//        public void Conveyors_Integration_Delete_Validate_ShouldThrowIdentifierUndefinedException()
//        {
//            //Cenario
//            long searchId = 0;
//            Conveyor c = new Conveyor { Id = searchId };

//            //Ação
//            Action action = () => _service.Delete(c);

//            //Saída
//            action.Should().Throw<IdentifierUndefinedException>();
//        }
//    }
//}
