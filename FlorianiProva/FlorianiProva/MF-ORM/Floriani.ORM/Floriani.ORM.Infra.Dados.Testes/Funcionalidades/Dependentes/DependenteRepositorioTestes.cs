using Floriani.Orm.Infra.Dados.Contexto;
using Floriani.Orm.Infra.Dados.Funcionalidades.Dependentes;
using Floriani.ORM.Comum.Base.Funcionalidades;
using Floriani.ORM.Comum.Base.Seed;
using Floriani.ORM.Dominio.Funcionalidades.Dependentes;
using FluentAssertions;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;

namespace Floriani.ORM.Infra.Dados.Testes.Funcionalidades.Dependentes
{
    [TestFixture]
    public class DependenteRepositorioTestes
    {
        private DependenteRepositorio _repositorio;
        private FlorianiOrmContexto _contexto;
        private Dependente _dependente;

        [SetUp]
        public void Inicializador()
        {
            Database.SetInitializer(new SeedDb<FlorianiOrmContexto>());
            _contexto = new FlorianiOrmContexto();
            _repositorio = new DependenteRepositorio(_contexto);

            _contexto.Database.Initialize(true);
        }
        [Test]
        public void Dependente_repositorio_deve_inserir_novo()
        {
            var idEsperado = 2;
            _dependente = ObjectMother.DependenteValido();

            var dependenteInserido = _repositorio.Inserir(_dependente);

            dependenteInserido.Id.Should().Be(idEsperado);
        }
        [Test]
        public void Dependente_repositorio_deve_trazer_todos()
        {
            var esperado = 1;
            var dependentes = _repositorio.PegarTodos();

            dependentes.Count.Should().Be(esperado);
        }
        [Test]
        public void Dependente_repositorio_deve_trazer_por_id()
        {
            var id = 1;

            var dependenteBuscado = _repositorio.PegarPorId(id);

            dependenteBuscado.Should().NotBeNull();
            dependenteBuscado.Id.Should().Be(1);
        }
        [Test]
        public void Dependente_repositorio_deve_trazer_por_dependente()
        {
            string dependente = "Zé";

            var dependenteBuscado = _repositorio.BuscarPorNome(dependente);

            dependenteBuscado.Should().NotBeNull();
            dependenteBuscado.Count.Should().BeGreaterThan(0);
        }
        [Test]
        public void Dependente_repositorio_deve_atualizar()
        {
            _dependente = ObjectMother.DependenteValido();
            var dependente = _repositorio.Inserir(_dependente);

            dependente.Nome = "João";

            var dependenteAtualizado = _repositorio.Atualizar(dependente);

            dependenteAtualizado.Nome.Should().Be(dependente.Nome);
        }
        [Test]
        public void Dependente_repositorio_deve_excluir()
        {
            _dependente = _repositorio.PegarPorId(1);

            _repositorio.Deletar(_dependente);

            var dependenteDeletado = _repositorio.PegarPorId(1);

            dependenteDeletado.Should().BeNull();
        }
    }
}
