using Floriani.Orm.Infra.Dados.Contexto;
using Floriani.Orm.Infra.Dados.Funcionalidades.Funcionarios;
using Floriani.ORM.Comum.Base.Funcionalidades;
using Floriani.ORM.Comum.Base.Seed;
using Floriani.ORM.Dominio.Funcionalidades.Funcionarios;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.ORM.Infra.Dados.Testes.Funcionalidades.Funcionarios
{
    [TestFixture]
    public class FuncionarioRepositorioTestes
    {
        private FuncionarioRepositorio _repositorio;
        private FlorianiOrmContexto _contexto;
        private Funcionario _funcionario;

        [SetUp]
        public void Inicializador()
        {
            Database.SetInitializer(new SeedDb<FlorianiOrmContexto>());
            _contexto = new FlorianiOrmContexto();
            _repositorio = new FuncionarioRepositorio(_contexto);

            _contexto.Database.Initialize(true);
        }
        [Test]
        public void Funcionario_repositorio_deve_inserir_novo()
        {
            var idEsperado = 2;
            _funcionario = ObjectMother.FuncionarioValido();

            var funcionarioInserido = _repositorio.Inserir(_funcionario);

            funcionarioInserido.Id.Should().Be(idEsperado);
        }
        [Test]
        public void Funcionario_repositorio_deve_trazer_todos()
        {
            var esperado = 1;
            var funcionarios = _repositorio.PegarTodos();

            funcionarios.Count.Should().Be(esperado);
        }
        [Test]
        public void Funcionario_repositorio_deve_trazer_por_id()
        {
            var id = 1;

            var funcionarioBuscado = _repositorio.PegarPorId(id);

            funcionarioBuscado.Should().NotBeNull();
            funcionarioBuscado.Id.Should().Be(1);
        }
        [Test]
        public void Funcionario_repositorio_deve_trazer_por_funcionario()
        {
            string funcionario = "Lucas";

            var funcionarioBuscado = _repositorio.BuscarPorNome(funcionario);

            funcionarioBuscado.Should().NotBeNull();
            funcionarioBuscado.Count.Should().BeGreaterThan(0);
        }
        [Test]
        public void Funcionario_repositorio_deve_atualizar()
        {
            _funcionario = ObjectMother.FuncionarioValido();
            var funcionario = _repositorio.Inserir(_funcionario);

            funcionario.Nome = "João";

            var funcionarioAtualizado = _repositorio.Atualizar(funcionario);

            funcionarioAtualizado.Nome.Should().Be(funcionario.Nome);
        }
        [Test]
        public void Funcionario_repositorio_deve_excluir()
        {
            _funcionario = _repositorio.PegarPorId(1);

            _repositorio.Deletar(_funcionario);

            var funcionarioDeletado = _repositorio.PegarPorId(1);

            funcionarioDeletado.Should().BeNull();
        }
    }
}
