using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Addresses;
using Projeto_NFe.Application.Features.Emitters;
using Projeto_NFe.Application.Features.Emitters.Commands;
using Projeto_NFe.Application.Features.Emitters.Queries;
using Projeto_NFe.Application.Features.Emitters.ViewModels;
using Projeto_NFe.Application.Mapping;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Infra.Data.Features.Emitters;
using Projeto_NFe.Infra.ORM.Context;
using Projeto_NFe.WebApi.Controllers.Emitters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Integration.Tests.Features.Emitters
{
    [TestFixture]
    public class EmitterIntegrationTest
    {
        private IEmitterRepository _repository;
        private IEmitterService _service;
        private EmittersController _controller;
        private static ProjetoNFeContextTest _context;

        private EmitterDeleteCommand _emitterDelete;
        private EmitterRegisterCommand _emitterRegister;
        private EmitterUpdateCommand _emitterUpdate;
        private EmitterViewModel _emitterViewModel;
        private EmitterQuery _emitterQuery;
        private Emitter _emitter;
        private AddressCommand _addressCommand;


        [SetUp]
        public void Initialize()
        {
            Database.SetInitializer(new DbInitializer());
            _context = new ProjetoNFeContextTest();

            _repository = new EmitterRepository(_context);
            _service = new EmitterService(_repository);
            _controller = new EmittersController(_service);

            _emitterDelete = new EmitterDeleteCommand();
            _emitterRegister = new EmitterRegisterCommand();
            _emitterUpdate = new EmitterUpdateCommand();
            _emitterViewModel = new EmitterViewModel();

            _emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress());
            _emitter.Id = 1;

            _addressCommand = new AddressCommand();

            AutoMapperInitializer.Reset();
            AutoMapperInitializer.Initialize();
        }

        [Test]
        [Order(1)]
        public void Emitters_Integration_Add_ShouldAddWithSuccess()
        {
            //Cenário
            int expectedId = 1;
            Emitter recurrence = ObjectMother.GetEmitter(ObjectMother.GetAddress());
            recurrence.Id = expectedId;

            //Endereço
            _addressCommand.City = recurrence.Address.City;
            _addressCommand.Neighbourhood = recurrence.Address.Neighbourhood;
            _addressCommand.Number = recurrence.Address.Number;
            _addressCommand.State = recurrence.Address.State;
            _addressCommand.Street = recurrence.Address.Street;
            _emitterRegister.Address = _addressCommand;
            //Demais propiedades

            _emitterRegister.Cnpj = recurrence.Cnpj;
            _emitterRegister.CompanyName = recurrence.CompanyName;
            _emitterRegister.FantasyName = recurrence.FantasyName;
            _emitterRegister.StateRegistration = recurrence.StateRegistration;
            _emitterRegister.MunicipalRegistration = recurrence.MunicipalRegistration;

            //Ação
            var result = _controller.Add(_emitterRegister);
            _emitter = _service.Get(expectedId);
            //Saída
            result.Should().NotBeNull();
            _emitter.Should().NotBeNull();
            _emitter.Id.Should().Be(expectedId);
        }

        [Test]
        [Order(2)]
        public void Emitters_Integration_Update_ShouldUpdateWithSuccess()
        {
            //Cenario

            long expectedId = 1;
            string expectedNameCompany = "Teste Receiver";
            string expectedAdressCity = "City of Hell";

            string oldNameCompany = _emitter.CompanyName;
            string oldAdressCity = _emitter.Address.City;
            _emitter.CompanyName = expectedNameCompany;
            _emitter.Address.City = expectedAdressCity;
            //Ação
            //Endereço
            _addressCommand.City = _emitter.Address.City;
            _addressCommand.Neighbourhood = _emitter.Address.Neighbourhood;
            _addressCommand.Number = _emitter.Address.Number;
            _addressCommand.State = _emitter.Address.State;
            _addressCommand.Street = _emitter.Address.Street;
            _emitterUpdate.Address = _addressCommand;
            //Demais Propiedades
            _emitterRegister.Cnpj = _emitter.Cnpj;
            _emitterRegister.CompanyName = _emitter.CompanyName;
            _emitterRegister.FantasyName = _emitter.MunicipalRegistration;
            _emitterRegister.StateRegistration = _emitter.StateRegistration;
            _emitterRegister.MunicipalRegistration = _emitter.MunicipalRegistration;
            _controller.Update(_emitterUpdate);

            //Saída
            var result = _service.Get(_emitter.Id);
            result.Should().NotBeNull();
        }

        [Test]
        [Order(3)]
        public void Emitters_Integration_Get_ShouldGetWithSuccess()
        {
            //Cenário
            int searchId = 1;

            Emitter recurrence = ObjectMother.GetEmitter(ObjectMother.GetAddress());
            recurrence.Id = searchId;

            //Ação
            var result = _controller.GetById(searchId);

            //Saída
            result.Should().NotBeNull();
        }



        [Test]
        [Order(4)]
        public void Emitters_Integration_GetAll_ShouldGetAllWithSuccess()
        {
            // Cenário

            int size = 1;
            long firstEmitterId = 1;
            int biggerThan = 0;

            var odata = OdataQueryOptions.GetOdataQueryOptions<Emitter>(_controller);

            // Executa
            var emitter = _controller.Get(odata);

            // Saída
            emitter.Should().NotBeNull();
        }

        [Test]
        [Order(5)]
        public void Emitters_Integration_Delete_ShouldDeleteWithSuccess()
        {
            //Cenário
            long id = 1;
            var EmitterIds = new long[] { id };
            _emitterDelete.EmitterIds = EmitterIds;

            //Ação
            _controller.Delete(_emitterDelete);

            //Saída
            Emitter result = _repository.Get(id);
            result.Should().BeNull();
            _context.Database.Delete();
        }
    }
}
