using Floriani.Orm.Infra.Dados.Contexto;
using Floriani.Orm.Infra.Dados.Funcionalidades.Projetos;
using Floriani.ORM.Comum.Base.Funcionalidades;
using Floriani.ORM.Comum.Base.Seed;
using Floriani.ORM.Dominio.Funcionalidades.Projetos;
using FluentAssertions;
using NUnit.Framework;
using System.Data.Entity;

namespace Floriani.ORM.Infra.Dados.Testes.Funcionalidades.Projetos
{
    public class ProjetoRepositorioTestes
    {
        private ProjetoRepositorio _repositorio;
        private FlorianiOrmContexto _contexto;
        private Projeto _projeto;

        [SetUp]
        public void Inicializador()
        {
            Database.SetInitializer(new SeedDb<FlorianiOrmContexto>());
            _contexto = new FlorianiOrmContexto();
            _repositorio = new ProjetoRepositorio(_contexto);

            _contexto.Database.Initialize(true);
        }
        [Test]
        public void Projeto_repositorio_deve_inserir_novo()
        {
            var idEsperado = 2;
            _projeto = ObjectMother.ProjetoValido();

            var projetoInserido = _repositorio.Inserir(_projeto);

            projetoInserido.Id.Should().Be(idEsperado);
        }
        [Test]
        public void Projeto_repositorio_deve_trazer_todos()
        {
            var esperado = 1;
            var projetos = _repositorio.PegarTodos();

            projetos.Count.Should().Be(esperado);
        }
        [Test]
        public void Projeto_repositorio_deve_trazer_por_id()
        {
            var id = 1;

            var projetoBuscado = _repositorio.PegarPorId(id);

            projetoBuscado.Should().NotBeNull();
            projetoBuscado.Id.Should().Be(1);
        }
        [Test]
        public void Projeto_repositorio_deve_trazer_por_projeto()
        {
            string projeto = "Academia";

            var projetoBuscado = _repositorio.BuscarPorNome(projeto);

            projetoBuscado.Should().NotBeNull();
            projetoBuscado.Count.Should().BeGreaterThan(0);
        }
        [Test]
        public void Projeto_repositorio_deve_atualizar()
        {
            _projeto = ObjectMother.ProjetoValido();
            var projeto = _repositorio.Inserir(_projeto);

            projeto.Nome = "b0t";

            var projetoAtualizado = _repositorio.Atualizar(projeto);

            projetoAtualizado.Nome.Should().Be(projeto.Nome);
        }
        [Test]
        public void Projeto_repositorio_deve_excluir()
        {
            _projeto = _repositorio.PegarPorId(1);

            _repositorio.Deletar(_projeto);

            var projetoDeletado = _repositorio.PegarPorId(1);

            projetoDeletado.Should().BeNull();
        }
    }
}
