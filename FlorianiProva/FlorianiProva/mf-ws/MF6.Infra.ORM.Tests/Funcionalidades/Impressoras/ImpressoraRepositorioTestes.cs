using Effort;
using FluentAssertions;
using MF6.Common.Tests.Funcionalidades;
using MF6.Domain.Excecoes;
using MF6.Domain.Funcionalidades.Impressoras;
using MF6.Infra.ORM.Funcionalidades.Impressoras;
using MF6.Infra.ORM.Funcionalidades.Toners;
using MF6.Infra.ORM.Tests.Contexts;
using MF6.Infra.ORM.Tests.Initializer;
using NUnit.Framework;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace MF6.Infra.ORM.Tests.Funcionalidades.Impressoras
{
    [TestFixture]
    public class ImpressoraRepositorioTestes : EffortTestBase
    {
        FakeDbContext _contexto;
        ImpressoraRepositorio _impressoraRepositorio;
        Impressora _impressora;
        Impressora _impressoraSeed;

        [SetUp]
        public void SetUp()
        {
            var conexao = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _contexto = new FakeDbContext(conexao);
            _impressoraRepositorio = new ImpressoraRepositorio(_contexto);
            _impressora = ObjectMother.ImpressoraValida();
            _impressoraSeed = ObjectMother.ImpressoraValidaSemId();
            _contexto.Impressoras.Add(_impressoraSeed);
            _contexto.SaveChanges();
        }
        #region ADD
        [Test]
        public void Impressora_repositorio_inserir_deve_funcionar()
        {
            var impressora = ObjectMother.ImpressoraSemTonerValida();

            var inserindoImpressora = _impressoraRepositorio.Inserir(impressora);


            inserindoImpressora.Should().NotBeNull();
            inserindoImpressora.Id.Should().NotBe(0);
            var impressoraEsperada = _contexto.Impressoras.Find(inserindoImpressora.Id);
            impressoraEsperada.Should().NotBeNull();
            impressoraEsperada.Should().Be(inserindoImpressora);
        }
        #endregion

        #region GET

        [Test]
        public void Impressora_repositorio_pegar_todos_deve_funcionar()
        {
            var impressoras = _impressoraRepositorio.PegarTodos().ToList();
            impressoras.Should().NotBeNull();
            impressoras.Should().HaveCount(_contexto.Impressoras.Count());
            impressoras.First().Should().Be(_impressoraSeed);
        }

        [Test]
        public void Impressora_repositorio_pegar_por_id_deve_funcionar()
        {
            var impressora = _impressoraRepositorio.PegarPorId(_impressora.Id);
            impressora.Should().NotBeNull();
            impressora.Should().Be(_impressoraSeed);
        }

        [Test]
        public void Impressora_repositorio_pegar_por_id_invalido_deve_retornar_nulo()
        {
            var idNaoEncontrado = 10;
            var impressora = _impressoraRepositorio.PegarPorId(idNaoEncontrado);
            impressora.Should().BeNull();
        }

        #endregion
        #region DELETE
        [Test]
        public void Impressora_repositorio_deletar_deve_funcionar()
        {
            var impressoraRemovida = _impressoraRepositorio.Deletar(_impressoraSeed.Id);
            impressoraRemovida.Should().BeTrue();
            _contexto.Impressoras.Where(p => p.Id == _impressoraSeed.Id).FirstOrDefault().Should().BeNull();
        }

        [Test]
        public void Impressora_repositorio_deletar_id_invalido_deve_falhar()
        {
            var idNaoEncontrado = 10;
            Action remover = () => _impressoraRepositorio.Deletar(idNaoEncontrado);
            remover.Should().Throw<NaoEncontradoException>();
        }

        #endregion
        #region UPDATE
        [Test]
        public void Impressora_repositorio_atualizar_deve_funcionar()
        {
            var foiAtualizado = false;
            _impressoraSeed.EmUso = false;
            var actionAtualizar = new Action(() => { foiAtualizado = _impressoraRepositorio.Atualizar(_impressoraSeed); });
            var impressora = _impressoraRepositorio.PegarPorId(1);
            actionAtualizar.Should().NotThrow<Exception>();
            foiAtualizado.Should().BeTrue();
            impressora.EmUso.Should().Be(false);
        }
        #endregion
    }
}
