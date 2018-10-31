using FluentAssertions;
using MF6.Application.Funcionalidades.Impressoras;
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

namespace MF6.Application.Tests.Funcionalidades.Impressoras
{
    [TestFixture]
    public class ImpressoraServicoTestes
    {
        private IImpressoraServico _servico;
        private Mock<IImpressoraRepositorio> _repositorio;
        private Mock<ITonerRepositorio> _impressoraRepositorio;

        [SetUp]
        public void Initialize()
        {
            _repositorio = new Mock<IImpressoraRepositorio>();
            _impressoraRepositorio = new Mock<ITonerRepositorio>();
            _servico = new ImpressoraServico(_repositorio.Object, _impressoraRepositorio.Object);
        }
        #region ADD 
        [Test]
        public void Impressora_servico_inserir_deve_funcionar()
        {
            var impressora2 = ObjectMother.ImpressoraValidaSemId();
            _repositorio.Setup(t => t.Inserir(It.IsAny<Impressora>())).Returns(impressora2);

            var impressoraInserido = _servico.Inserir(impressora2);

            _repositorio.Verify(t => t.Inserir(It.IsAny<Impressora>()), Times.Once);
            impressoraInserido.Should().Be(impressora2.Id);
        }
        #endregion
        #region GET 
        [Test]
        public void Impressora_servico_pegar_todos_deve_funcionar()
        {
            var impressora = ObjectMother.ImpressoraValida();
            var retornoRepositorio = new List<Impressora>() { impressora }.AsQueryable();
            _repositorio.Setup(t => t.PegarTodos()).Returns(retornoRepositorio);

            var impressoras = _servico.PegarTodos();

            _repositorio.Verify(t => t.PegarTodos(), Times.Once);
            impressoras.Should().NotBeNull();
            impressoras.Count().Should().Be(retornoRepositorio.Count());

            impressoras.First().Should().Be(retornoRepositorio.First());
        }

        [Test]
        public void Impressora_servico_pegar_por_id_deve_funcionar()
        {
            var impressora = ObjectMother.ImpressoraValida();
            _repositorio.Setup(t => t.PegarPorId(impressora.Id)).Returns(impressora);

            var impressoraPego = _servico.PegarPorId(impressora.Id);

            _repositorio.Verify(t => t.PegarPorId(impressora.Id), Times.Once);
            impressoraPego.Should().NotBeNull();
            impressoraPego.Id.Should().Be(impressora.Id);
        }

        [Test]
        public void Impressora_servico_pegar_por_id_invalido_deve_falhar()
        {
            var impressora = ObjectMother.ImpressoraValida();
            var exception = new NaoEncontradoException();
            _repositorio.Setup(t => t.PegarPorId(impressora.Id)).Throws(exception);

            Action action = () => _servico.PegarPorId(impressora.Id);

            action.Should().Throw<NaoEncontradoException>();

            _repositorio.Verify(t => t.PegarPorId(impressora.Id), Times.Once);
        }
        #endregion

        #region DELETE
        [Test]
        public void Impressora_servico_deletar_deve_funcionar()
        {
            var impressoraC = ObjectMother.ImpressoraValida();
            var removido = true;
            _repositorio.Setup(pr => pr.Deletar(impressoraC.Id)).Returns(removido);

            _repositorio.Setup(s => s.PegarPorId(impressoraC.Id)).Returns(impressoraC);
            var impressoraRemovida = _servico.Deletar(impressoraC);

            _repositorio.Verify(pr => pr.Deletar(impressoraC.Id), Times.Once);
            impressoraRemovida.Should().BeTrue();
        }
        #endregion
    }
}
