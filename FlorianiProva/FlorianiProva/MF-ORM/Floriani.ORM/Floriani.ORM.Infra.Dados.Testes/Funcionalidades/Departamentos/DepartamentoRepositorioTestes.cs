using Floriani.Orm.Infra.Dados.Contexto;
using Floriani.Orm.Infra.Dados.Funcionalidades.Departamentos;
using Floriani.ORM.Comum.Base.Funcionalidades;
using Floriani.ORM.Comum.Base.Seed;
using Floriani.ORM.Dominio.Funcionalidades.Departamentos;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.ORM.Infra.Dados.Testes.Funcionalidades.Departamentos
{
    [TestFixture]
    public class DepartamentoRepositorioTestes
    {
        private DepartamentoRepositorio _repositorio;
        private FlorianiOrmContexto _contexto;
        private Departamento _departamento;

        [SetUp]
        public void Inicializador()
        {
            Database.SetInitializer(new SeedDb<FlorianiOrmContexto>());
            _contexto = new FlorianiOrmContexto();
            _repositorio = new DepartamentoRepositorio(_contexto);

            _contexto.Database.Initialize(true);
        }
        [Test]
        public void Departamento_repositorio_deve_inserir_novo()
        {
            var idEsperado = 2;
            _departamento = ObjectMother.DepartamentoValido();

            var departamentoInserido = _repositorio.Inserir(_departamento);

            departamentoInserido.Id.Should().Be(idEsperado);
        }
        [Test]
        public void Departamento_repositorio_deve_trazer_todos()
        {
            var esperado = 1;
            var departamentos = _repositorio.PegarTodos();

            departamentos.Count.Should().Be(esperado);
        }
        [Test]
        public void Departamento_repositorio_deve_trazer_por_id()
        {
            var id = 1;

            var departamentoBuscado = _repositorio.PegarPorId(id);

            departamentoBuscado.Should().NotBeNull();
            departamentoBuscado.Id.Should().Be(1);
        }
        [Test]
        public void Departamento_repositorio_deve_trazer_por_departamento()
        {
            string departamento = "Administração";

            var departamentoBuscado = _repositorio.BuscarPorDescricao(departamento);

            departamentoBuscado.Should().NotBeNull();
            departamentoBuscado.Count.Should().BeGreaterThan(0);
        }
        [Test]
        public void Departamento_repositorio_deve_atualizar()
        {
            _departamento = ObjectMother.DepartamentoValido();
            var departamento = _repositorio.Inserir(_departamento);

            departamento.Descricao = "TI";

            var departamentoAtualizado = _repositorio.Atualizar(departamento);

            departamentoAtualizado.Descricao.Should().Be(departamento.Descricao);
        }
        [Test]
        public void Departamento_repositorio_deve_excluir()
        {
            var idEsperado = 2;
            _departamento = ObjectMother.DepartamentoValido();
            _repositorio.Inserir(_departamento);

            var departamentoBuscado = _repositorio.PegarPorId(idEsperado);
            _repositorio.Deletar(departamentoBuscado);

            var departamentoDeletado = _repositorio.PegarPorId(2);

            departamentoDeletado.Should().BeNull();
        }
    }
}
