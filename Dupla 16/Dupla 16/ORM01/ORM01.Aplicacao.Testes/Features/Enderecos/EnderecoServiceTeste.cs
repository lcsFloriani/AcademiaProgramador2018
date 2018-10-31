using FluentAssertions;
using Moq;
using NUnit.Framework;
using ORM01.Aplicacao.Features.Enderecos;
using ORM01.Comum.Testes.Features;
using ORM01.Dominio.Features.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Aplicacao.Testes.Features.Enderecos
{
    [TestFixture]
    public class EnderecoServiceTeste
    {
        Mock<Endereco> _endereco;
        Mock<IEnderecoRepository> _repository;
        EnderecoService _enderecoService;
       
        [SetUp]
        public void SetUpEnderecoService()
        {
            _repository = new Mock<IEnderecoRepository>();
            _enderecoService = new EnderecoService(_repository.Object);
            _endereco = new Mock<Endereco>();
        }

        [Test]
        public void ApplService_Endereco_Deve_Incluir_Novo_Endereco()
        {

            _repository.Setup(x => x.Add(_endereco.Object));
            _endereco.Setup(x => x.Validar());
            _enderecoService.Add(_endereco.Object);
            
            _repository.Verify(x => x.Add(_endereco.Object));
            _endereco.Verify(x => x.Validar());
        }


        [Test]
        public void ApplService_Endereco_Deve_Deletar_Endereco()
        {

            _repository.Setup(x => x.Delete(_endereco.Object));

            _enderecoService.Delete(_endereco.Object);

            _repository.Verify(x => x.Delete(_endereco.Object));

        }

        [Test]
        public void ApplService_Endereco_DeveAtualizarUmEndereco()
        {
            _repository.Setup(x => x.Update(_endereco.Object));
            _endereco.Setup(x => x.Validar());

            _enderecoService.Update(_endereco.Object);


            _repository.Verify(x => x.Update(_endereco.Object));
            _endereco.Verify(x => x.Validar());
        }

        [Test]
        public void ApplService_Endereco_DeveListarTodosEndereco()
        {
            List<Endereco> turmaLista = ObjectMother.ListEndereco;
            _repository.Setup(x => x.GetAll()).Returns(turmaLista);

            List<Endereco> turmaList = _enderecoService.GetAll();

            _repository.Verify(x => x.GetAll());
            turmaList.Should().NotBeNull();
            turmaList.Should().HaveCount(3);
        }

        [Test]
        public void ApplService_Endereco_RetornarUmaEndereco()
        {
            Endereco endereco = ObjectMother.endereco;
            _repository.Setup(x => x.GetById(It.IsAny<long>())).Returns(endereco);

            Endereco avaliacaoResult = _enderecoService.GetById(endereco.Id);

            _repository.Verify(p => p.GetById(It.IsAny<long>()), Times.Once());
            avaliacaoResult.Should().NotBeNull();
            avaliacaoResult.Id.Should().Be(endereco.Id);
        }

    }
}
