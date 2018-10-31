using Effort;
using FluentAssertions;
using MF6.Common.Tests.Funcionalidades;
using MF6.Domain.Excecoes;
using MF6.Domain.Funcionalidades.Toners;
using MF6.Infra.ORM.Funcionalidades.Toners;
using MF6.Infra.ORM.Tests.Contexts;
using MF6.Infra.ORM.Tests.Initializer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF6.Infra.ORM.Tests.Funcionalidades.Toners
{
    [TestFixture]
    public class TonerRepositorioTestes : EffortTestBase
    {
        FakeDbContext _contexto;
        TonerRepositorio _tonerRepositorio;
        Toner _toner;
        Toner _tonerSeed;

        [SetUp]
        public void SetUp()
        {
            var conexao = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _contexto = new FakeDbContext(conexao);
            _tonerRepositorio = new TonerRepositorio(_contexto);
            _toner = ObjectMother.TonerColoridoValido();
            //Seed
            _tonerSeed = ObjectMother.TonerColoridoValidoSemId();
            _contexto.Toners.Add(_tonerSeed);
            _contexto.SaveChanges();
        }

        #region ADD
        [Test]
        public void Toner_repositorio_inserir_deve_funcionar()
        {
            var toner = ObjectMother.TonerPretoBrancoValido();
            var tonerInserido = _tonerRepositorio.Inserir(toner);
            
            tonerInserido.Should().NotBeNull();
            tonerInserido.Should().Be(toner);
        }
        #endregion
        #region GET
        [Test]
        public void Toner_repositorio_pegar_todos_deve_funcionar()
        {
            var toners = _tonerRepositorio.PegarTodos().ToList();

            toners.Should().NotBeNull();
            toners.Should().HaveCount(_contexto.Toners.Count());
            toners.First().Should().Be(_tonerSeed);
        }

        [Test]
        public void Toner_repositorio_pegar_por_id_deve_funcionar()
        {
            var productResult = _tonerRepositorio.PegarPorId(_tonerSeed.Id);
            
            productResult.Should().NotBeNull();
            productResult.Should().Be(_tonerSeed);
        }

        [Test]
        public void Toner_repositorio_pegar_por_id_invalido_deve_falhar()
        {
            var idInvalido = 10;

            var productResult = _tonerRepositorio.PegarPorId(idInvalido);

            productResult.Should().BeNull();
        }
        #endregion
        #region DELETE
        [Test]
        public void Toner_repositorio_deletar_deve_funcionar()
        {

            var deletado = _tonerRepositorio.Deletar(_tonerSeed.Id);

            deletado.Should().BeTrue();
            _contexto.Toners.Where(p => p.Id == _tonerSeed.Id).ToList().Should().BeEmpty();
        }

        [Test]
        public void Toner_repositorio_deletar_id_invalido_deve_falhar()
        {
            var idInvalido = 10;

            Action action = () => _tonerRepositorio.Deletar(idInvalido);

            action.Should().Throw<NaoEncontradoException>();
        }
        #endregion
        #region UPDATE

        [Test]
        public void Toner_repositorio_atualizar_deve_funcionar()
        {
            var foiAtualizado = false;
            var novoNivel = 200;
            _tonerSeed.Nivel = novoNivel;
            var action = new Action(() => { foiAtualizado = _tonerRepositorio.Atualizar(_tonerSeed); });

            action.Should().NotThrow<Exception>();
            foiAtualizado.Should().BeTrue();
        }

        [Test]
        public void Toner_repositorio_atualizar_id_invalido_deve_falhar()
        {
            _toner.Id = 20;
            var action = new Action(() => _tonerRepositorio.Atualizar(_toner));

            action.Should().Throw<DbUpdateConcurrencyException>();
        }
        #endregion
    }
}
