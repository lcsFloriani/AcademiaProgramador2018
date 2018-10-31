using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Receivers;
using Projeto_NFe.Application.Features.Receivers.Commands;
using Projeto_NFe.Application.Features.Receivers.Queries;
using Projeto_NFe.Application.Mapping;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Receivers;

using System;
using System.Collections.Generic;
using System.Linq;


namespace Projeto_NFe.Application.Test.Features.Receivers
{
	[TestFixture]
	public class ReceiverApplicationTest
	{
		private Mock<IReceiverRepository> _mockRepository;
		private Mock<ReceiverRegisterCommand> _mockRegisterCommand;
		private Mock<ReceiverUpdateCommand> _mockUpdateCommand;
		private ReceiverDeleteCommand _removeCommand;

		private IReceiverService _service;
		private List<Receiver> _receivers;
		private Receiver _receiver;


		[SetUp]
		public void Initialize()
		{
			_mockRepository = new Mock<IReceiverRepository>();
			_mockRegisterCommand = new Mock<ReceiverRegisterCommand>();
			_mockUpdateCommand = new Mock<ReceiverUpdateCommand>();
			_removeCommand = new ReceiverDeleteCommand();

			_service = new ReceiverService( _mockRepository.Object );
			_receiver = new Receiver { Id = 1 };

			_receivers = new List<Receiver>();
			_receivers.Add( new Mock<Receiver>().Object );
			_receivers.Add( new Mock<Receiver>().Object );
			_receivers.Add( new Mock<Receiver>().Object );


		}

		[Test]
		public void Receivers_Service_Add_ShouldAddWithSuccess()
		{
			//Cenario
			_mockRepository.Setup( m => m.Save( It.IsAny<Receiver>() ) ).Returns( _receiver );

			long biggerThan = 0;
			long expectedId = 1;

			//Executa
			long receiverId = _service.Add( _mockRegisterCommand.Object );

			//Saida
			receiverId.Should().BeGreaterThan( biggerThan );
			receiverId.Should().Be( expectedId );
			_mockRepository.Verify( m => m.Save( It.IsAny<Receiver>() ) );
		}

		[Test]
		public void Receivers_Service_Update_ShouldUpdateWithSuccess()
		{
			// Cenario
			_mockRepository.Setup( m => m.Update( It.IsAny<Receiver>() ) ).Returns( true );
			_mockRepository.Setup( m => m.Get( It.IsAny<long>() ) ).Returns( _receiver );

			//Executa
			bool updated = _service.Update( _mockUpdateCommand.Object );

			//Saida
			_mockRepository.Verify( m => m.Update( It.IsAny<Receiver>() ) );
			updated.Should().BeTrue();
		}

		[Test]
		public void Receivers_Service_Update_ShouldThrowNotFoundException()
		{
			// Cenario Executa
			Action action = () => _service.Update( _mockUpdateCommand.Object );

			//Saida
			action.Should().Throw<NotFoundException>();
		}

		[Test]
		public void Receivers_Service_Get_ShouldGetWithSuccess()
		{
			// Cenario
			int searchId = 1;
			_mockRepository.Setup( m => m.Get( searchId ) ).Returns( _receiver );

			// Executa
			Receiver result = _service.Get( searchId );

			// Saída	
			result.Should().NotBeNull();
			_mockRepository.Verify( m => m.Get( searchId ) );

		}

		[Test]
		public void Receivers_Service_Get_ShouldThrowNotFoundException()
		{
			// Cenario
			int searchId = 1000;
			_mockRepository.Setup( m => m.Get( searchId ) ).Returns( It.IsAny<Receiver>() );

			// Executa
			Action action = () => _service.Get( searchId );

			// Saída	
			action.Should().Throw<NotFoundException>();
		}

		[Test]
		public void Receivers_Service_GetAll_ShouldGettAllWithSuccess()
		{
			// Cenario
			_mockRepository.Setup( x => x.GetAll() ).Returns( _receivers.AsQueryable());
			int size = 3;

			//	Executa
			IQueryable<Receiver> results = _service.GetAll();

			// Saída
			
			results.Count().Should().Equals( size );
			_mockRepository.Verify( m => m.GetAll() );
			
		}

		[Test]
		public void Receivers_Service_GetAllWithSize_ShouldGettAllWithSuccess()
		{
			// Cenario
			_mockRepository.Setup( x => x.GetAll(It.IsAny<int>()) ).Returns( _receivers.AsQueryable() );

			int size = 3;
			ReceiverQuery query = new ReceiverQuery(size);

			//	Executa
			IQueryable<Receiver> results = _service.GetAll(query);

			// Saída
			results.Count().Should().Equals( size );
			_mockRepository.Verify( m => m.GetAll( It.IsAny<int>() ) );
		}

		[Test]
		public void Receivers_Service_Delete_ShouldDeleteWithSuccess()
		{
			// Cenario
			long id = 1;
			var receiverIds = new long[] { id };
			_mockRepository.Setup( m => m.Delete( It.IsAny<long>() ) ).Returns(true);
			_removeCommand.ReceiverIds = receiverIds;

			//	Executa
			bool result = _service.Delete( _removeCommand );

			// Saída
			result.Should().BeTrue();
			_mockRepository.Verify( m => m.Delete( It.IsAny<long>() ) );
		}

	}
}
