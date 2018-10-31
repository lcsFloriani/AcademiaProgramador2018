using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Addresses;
using Projeto_NFe.Application.Features.Receivers;
using Projeto_NFe.Application.Features.Receivers.Commands;
using Projeto_NFe.Application.Features.Receivers.Queries;
using Projeto_NFe.Application.Features.Receivers.ViewModels;
using Projeto_NFe.Application.Mapping;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Infra.CNPJ;
using Projeto_NFe.Infra.CPF;
using Projeto_NFe.Infra.Data.Features.Receivers;
using Projeto_NFe.Infra.ORM.Context;
using Projeto_NFe.WebApi.Controllers.Receivers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Integration.Tests.Features.Receivers
{
    [TestFixture]
    public class ReceiverIntegrationTest
    {
        private IReceiverRepository _repository;
        private IReceiverService _service;
        private ReceiversController _controller;
        private static ProjetoNFeContextTest _context;

        private ReceiverDeleteCommand _receiverDelete;
        private ReceiverRegisterCommand _receiverRegister;
        private AddressCommand _addressRegister;
        private ReceiverUpdateCommand _receiverUpdate;
        private ReceiverViewModel _receiverViewModel;
        private ReceiverQuery _receiverQuery;
        private Receiver _receiver;


        [SetUp]
        public void Initialize()
        {
            Database.SetInitializer(new DbInitializer());

            _context = new ProjetoNFeContextTest();

            _repository = new ReceiverRepository(_context);
            _service = new ReceiverService(_repository);
            _controller = new ReceiversController(_service);

            _receiverDelete = new ReceiverDeleteCommand();
            _receiverRegister = new ReceiverRegisterCommand();
            _receiverUpdate = new ReceiverUpdateCommand();
            _receiverViewModel = new ReceiverViewModel();
            _addressRegister = new AddressCommand();

            _receiver = ObjectMother.GetReceiverLegal(ObjectMother.GetAddress());
            _receiver.Id = 1;


            AutoMapperInitializer.Reset();
            AutoMapperInitializer.Initialize();
        }

        [Test]
        [Order(1)]
        public void Receivers_Integration_Add_ShouldAddWithSuccess()
        {
            //Cenário
            int expectedId = 1;
            Receiver recurrence = ObjectMother.GetReceiverLegal(ObjectMother.GetAddress());
            recurrence.Id = expectedId;

            _addressRegister.City = recurrence.Address.City;
            _addressRegister.Neighbourhood = recurrence.Address.Neighbourhood;
            _addressRegister.Number = recurrence.Address.Number;
            _addressRegister.State = recurrence.Address.State;
            _addressRegister.Street = recurrence.Address.Street;
            _receiverRegister.Address = _addressRegister;
            _receiverRegister.CpfCnpj = recurrence.CpfCnpj;
            _receiverRegister.NameCompanyName = recurrence.NameCompanyName;
            _receiverRegister.StateRegistration = recurrence.StateRegistration;
            _receiverRegister.Type = 1;

            //Ação
            var result = _controller.Add(_receiverRegister);
            _receiver = _service.Get(expectedId);
            //Saída
            result.Should().NotBeNull();
            _receiver.Should().NotBeNull();
            _receiver.Id.Should().Be(expectedId);
        }

        [Test]
        [Order(2)]
        public void Receivers_Integration_Update_ShouldUpdateWithSuccess()
        {
            //Cenario

            long expectedId = 1;
            string expectedNameCompany = "Teste Receiver";
            string expectedAdressCity = "City of Hell";

            string oldNameCompany = _receiver.NameCompanyName;
            string oldAdressCity = _receiver.Address.City;
            _receiver.NameCompanyName = expectedNameCompany;
            _receiver.Address.City = expectedAdressCity;

            //Ação
            _addressRegister.City = _receiver.Address.City;
            _addressRegister.Neighbourhood = _receiver.Address.Neighbourhood;
            _addressRegister.Number = _receiver.Address.Number;
            _addressRegister.State = _receiver.Address.State;
            _addressRegister.Street = _receiver.Address.Street;
            _receiverRegister.Address = _addressRegister;
            _receiverRegister.CpfCnpj = _receiver.CpfCnpj;
            _receiverRegister.NameCompanyName = _receiver.NameCompanyName;
            _receiverRegister.StateRegistration = _receiver.StateRegistration;
            _receiverRegister.Type = 1;
            //Saída
            var result = _service.Get(_receiver.Id);
            result.Should().NotBeNull();
        }

        [Test]
        [Order(3)]
        public void Receivers_Integration_Get_ShouldGetWithSuccess()
        {
            //Cenário
            int searchId = 1;

            Receiver recurrence = ObjectMother.GetReceiverLegal(ObjectMother.GetAddress());
            recurrence.Id = searchId;

            //Ação
            var result = _controller.GetById(searchId);

            //Saída
            result.Should().NotBeNull();
        }



        [Test]
        [Order(4)]
        public void Receivers_Integration_GetAll_ShouldGetAllWithSuccess()
        {
            // Cenário

            int size = 1;
            long firstReceiverId = 1;
            int biggerThan = 0;

            var odata = OdataQueryOptions.GetOdataQueryOptions<Receiver>(_controller);

            // Executa
            var receiver = _controller.GetAll(odata);

            // Saída
            receiver.Should().NotBeNull();
        }

        [Test]
        [Order(5)]
        public void Receivers_Integration_Delete_ShouldDeleteWithSuccess()
        {
            //Cenário
            long id = 1;
            var ReceiverIds = new long[] { id };
            _receiverDelete.ReceiverIds = ReceiverIds;

            //Ação
            _controller.Delete(_receiverDelete);

            //Saída
            Receiver result = _repository.Get(id);
            result.Should().BeNull();
            _context.Database.Delete();
        }
    }
}
