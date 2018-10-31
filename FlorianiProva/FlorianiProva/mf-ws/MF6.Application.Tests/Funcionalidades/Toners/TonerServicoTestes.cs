using FluentAssertions;
using MF6.Application.Funcionalidades.Toners;
using MF6.Common.Tests.Funcionalidades;
using MF6.Domain.Excecoes;
using MF6.Domain.Funcionalidades.Impressoras;
using MF6.Domain.Funcionalidades.Toners;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF6.Application.Tests.Funcionalidades.Toners
{
    [TestFixture]
    public class TonerServicoTestes
    {
        private ITonerServico _servico;
        private Mock<ITonerRepositorio> _repositorio;

        [SetUp]
        public void Initialize()
        {
            _repositorio = new Mock<ITonerRepositorio>();
            _servico = new TonerServico(_repositorio.Object);
        }
        #region ADD 
        [Test]
        public void Toner_servico_inserir_deve_funcionar()
        {

            var toner = ObjectMother.TonerColoridoValido();
            var toner2 = ObjectMother.TonerColoridoValidoSemId();
            _repositorio.Setup(t => t.Inserir(It.IsAny<Toner>())).Returns(toner);

            var tonerInserido = _servico.Inserir(toner2);

            _repositorio.Verify(t => t.Inserir(It.IsAny<Toner>()), Times.Once);
            tonerInserido.Should().Be(toner.Id);
        }
        #endregion
        #region GET 
        [Test]
        public void Toner_servico_pegar_todos_deve_funcionar()
        {
            var toner = ObjectMother.TonerColoridoValido();
            var retornoRepositorio = new List<Toner>() { toner }.AsQueryable();
            _repositorio.Setup(t => t.PegarTodos()).Returns(retornoRepositorio);

            var toductCB = _servico.PegarTodos();

            _repositorio.Verify(t => t.PegarTodos(), Times.Once);
            toductCB.Should().NotBeNull();
            toductCB.Count().Should().Be(retornoRepositorio.Count());

            toductCB.First().Should().Be(retornoRepositorio.First());
        }

        [Test]
        public void Toner_servico_pegar_por_id_deve_funcionar()
        {
            var toner = ObjectMother.TonerColoridoValido();
            _repositorio.Setup(t => t.PegarPorId(toner.Id)).Returns(toner);

            var tonerPego = _servico.PegarPorId(toner.Id);

            _repositorio.Verify(t => t.PegarPorId(toner.Id), Times.Once);
            tonerPego.Should().NotBeNull();
            tonerPego.Id.Should().Be(toner.Id);
        }

        [Test]
        public void Toner_servico_pegar_por_id_invalido_deve_falhar()
        {
            var toner = ObjectMother.TonerColoridoValido();
            var exception = new NaoEncontradoException();
            _repositorio.Setup(t => t.PegarPorId(toner.Id)).Throws(exception);

            Action toductAction = () => _servico.PegarPorId(toner.Id);

            toductAction.Should().Throw<NaoEncontradoException>();

            _repositorio.Verify(t => t.PegarPorId(toner.Id), Times.Once);
        }
        #endregion

        #region DELETE
        [Test]
        public void Toner_servico_deletar_deve_funcionar()
        {
            var tonerC = ObjectMother.TonerColoridoValido();
            var removido = true;
            _repositorio.Setup(pr => pr.Deletar(tonerC.Id)).Returns(removido);

            var isProductRemoved = _servico.Deletar(tonerC);

            _repositorio.Verify(pr => pr.Deletar(tonerC.Id), Times.Once);
            isProductRemoved.Should().BeTrue();
        }

        [Test]
        public void Toner_servico_deletar_id_invalido_deve_falhar()
        {
            var productCmd = ObjectMother.TonerColoridoValido();
            _repositorio.Setup(pr => pr.Deletar(productCmd.Id)).Throws<NaoEncontradoException>();

            Action action = () => _servico.Deletar(productCmd);

            action.Should().Throw<NaoEncontradoException>();

            _repositorio.Verify(pr => pr.Deletar(productCmd.Id), Times.Once);
        }
        
        #endregion
    }
}
