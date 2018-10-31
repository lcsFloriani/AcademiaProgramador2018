using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Addresses;
using Projeto_NFe.Application.Features.Conveyors;
using Projeto_NFe.Application.Features.Conveyors.Commands;
using Projeto_NFe.Application.Features.Conveyors.Queries;
using Projeto_NFe.Application.Features.Conveyors.ViewModels;
using Projeto_NFe.Application.Mapping;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Infra.CNPJ;
using Projeto_NFe.Infra.CPF;
using Projeto_NFe.Infra.Data.Features.Conveyors;
using Projeto_NFe.Infra.ORM.Context;
using Projeto_NFe.WebApi.Controllers.Conveyors;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Projeto_NFe.Integration.Tests.Features.Conveyors
{
    [TestFixture]
    public class ConveyorIntegrationTest
    {
        private IConveyorRepository _repository;
        private IConveyorService _service;
        private ConveyorsController _controller;
        private static ProjetoNFeContextTest _context;

        private ConveyorDeleteCommand _conveyorDelete;
        private ConveyorRegisterCommand _conveyorRegister;
        private ConveyorUpdateCommand _conveyorUpdate;
        private ConveyorViewModel _conveyorViewModel;
        private ConveyorQuery _conveyorQuery;
        private Conveyor _conveyor;
        private Address _address;


        [SetUp]
        public void Initialize()
        {
            Database.SetInitializer(new DbInitializer());
            _context = new ProjetoNFeContextTest();

            _repository = new ConveyorsRepository(_context);
            _service = new ConveyorService(_repository);
            _controller = new ConveyorsController(_service);

            _conveyorDelete = new ConveyorDeleteCommand();
            _conveyorRegister = new ConveyorRegisterCommand();
            _conveyorUpdate = new ConveyorUpdateCommand();
            _conveyorViewModel = new ConveyorViewModel();

            _conveyor = ObjectMother.GetLegalConveyor(ObjectMother.GetAddress());
            _conveyor.Id = 1;

            _address = new Address();

            AutoMapperInitializer.Reset();
            AutoMapperInitializer.Initialize();
        }

        [Test]
        [Order(1)]
        public void Conveyors_Integration_Add_ShouldAddWithSuccess()
        {
            //Cenário
            int expectedId = 1;
            Conveyor recurrence = ObjectMother.GetPhysicalConveyor(ObjectMother.GetAddress());
            recurrence.Id = expectedId;

            //Endereço
            _address.City = recurrence.Address.City;
            _address.Neighbourhood = recurrence.Address.Neighbourhood;
            _address.Number = recurrence.Address.Number;
            _address.State = recurrence.Address.State;
            _address.Street = recurrence.Address.Street;
            _conveyorRegister.Address = _address;
           //Demais propiedades

            _conveyorRegister.CpfCnpj = recurrence.CpfCnpj;
            _conveyorRegister.FreightResponsibility = recurrence.FreightResponsibility;
            _conveyorRegister.NameCompanyName = recurrence.NameCompanyName;
            _conveyorRegister.PersonType = recurrence.PersonType;

            //Ação
            var result = _controller.Add(_conveyorRegister);
            _conveyor = _service.Get(expectedId);
            //Saída
            result.Should().NotBeNull();
            _conveyor.Should().NotBeNull();
            _conveyor.Id.Should().Be(expectedId);
        }

        [Test]
        [Order(2)]
        public void Conveyors_Integration_Update_ShouldUpdateWithSuccess()
        {
            //Cenario

            long expectedId = 1;
            string expectedNameCompany = "Teste Receiver";
            string expectedAdressCity = "City of Hell";

            string oldNameCompany = _conveyor.NameCompanyName;
            string oldAdressCity = _conveyor.Address.City;
            _conveyor.NameCompanyName = expectedNameCompany;
            _conveyor.Address.City = expectedAdressCity;
            //Ação
            //Endereço
            _address.City = _conveyor.Address.City;
            _address.Neighbourhood = _conveyor.Address.Neighbourhood;
            _address.Number = _conveyor.Address.Number;
            _address.State = _conveyor.Address.State;
            _address.Street = _conveyor.Address.Street;
            _conveyorUpdate.Address = _address;
            //Demais Propiedades
            _conveyorUpdate.CpfCnpj = _conveyor.CpfCnpj;
            _conveyorUpdate.FreightResponsibility = _conveyor.FreightResponsibility;
            _conveyorUpdate.NameCompanyName = _conveyor.NameCompanyName;
            _conveyorUpdate.PersonType = _conveyor.PersonType;
            _controller.Update(_conveyorUpdate);

            //Saída
            var result = _service.Get(_conveyor.Id);
            result.Should().NotBeNull();
        }

        [Test]
        [Order(3)]
        public void Conveyors_Integration_Get_ShouldGetWithSuccess()
        {
            //Cenário
            int searchId = 1;

            Conveyor recurrence = ObjectMother.GetPhysicalConveyor(ObjectMother.GetAddress());
            recurrence.Id = searchId;

            //Ação
            var result = _controller.GetById(searchId);

            //Saída
            result.Should().NotBeNull();
        }



        [Test]
        [Order(4)]
        public void Conveyors_Integration_GetAll_ShouldGetAllWithSuccess()
        {
            // Cenário

            int size = 1;
            long firstConveyorId = 1;
            int biggerThan = 0;

            var odata = OdataQueryOptions.GetOdataQueryOptions<Conveyor>(_controller);

            // Executa
            var conveyor = _controller.Get(odata);

            // Saída
            conveyor.Should().NotBeNull();
        }

        [Test]
        [Order(5)]
        public void Conveyors_Integration_Delete_ShouldDeleteWithSuccess()
        {
            //Cenário
            long id = 1;
            var ConveyorIds = new long[] { id };
            _conveyorDelete.ConveyorsIds = ConveyorIds;

            //Ação
            _controller.Delete(_conveyorDelete);

            //Saída
            Conveyor result = _repository.Get(id);
            result.Should().BeNull();
            _context.Database.Delete();
        }
    }
}
