using Floriani.Orm.Infra.Dados.Contexto;
using Floriani.Orm.Infra.Dados.Funcionalidades.Cargos;
using Floriani.ORM.Comum.Base.Funcionalidades;
using Floriani.ORM.Comum.Base.Seed;
using Floriani.ORM.Dominio.Funcionalidades.Cargos;
using FluentAssertions;
using NUnit.Framework;
using System.Data.Entity;

namespace Floriani.ORM.Infra.Dados.Testes.Funcionalidades.Cargos
{
    [TestFixture]
    public class CargoRepositorioTestes
    {
        private CargoRepositorio _repositorio;
        private FlorianiOrmContexto _contexto;
        private Cargo _cargo;

        [SetUp]
        public void Inicializador()
        {
            Database.SetInitializer(new SeedDb<FlorianiOrmContexto>());
            _contexto = new FlorianiOrmContexto();
            _repositorio = new CargoRepositorio(_contexto);

            _contexto.Database.Initialize(true);
        }
        [Test]
        public void Cargo_repositorio_deve_inserir_novo()
        {
            var idEsperado = 2;
            _cargo = ObjectMother.CargoValido();

            var cargoInserido = _repositorio.Inserir(_cargo);

            cargoInserido.Id.Should().Be(idEsperado);
        }
        [Test]
        public void Cargo_repositorio_deve_trazer_todos()
        {
            var esperado = 1;
            var cargos = _repositorio.PegarTodos();

            cargos.Count.Should().Be(esperado);
        }
        [Test]
        public void Cargo_repositorio_deve_trazer_por_id()
        {
            var id = 1;

            var cargoBuscado = _repositorio.PegarPorId(id);

            cargoBuscado.Should().NotBeNull();
            cargoBuscado.Id.Should().Be(1);
        }
        [Test]
        public void Cargo_repositorio_deve_trazer_por_cargo()
        {
            string cargo = "Estagiário";

            var cargoBuscado = _repositorio.BuscarPorDescricao(cargo);

            cargoBuscado.Should().NotBeNull();
            cargoBuscado.Count.Should().BeGreaterThan(0);
        }
        [Test]
        public void Cargo_repositorio_deve_atualizar()
        {
            _cargo = ObjectMother.CargoValido();
            var cargo = _repositorio.Inserir(_cargo);

            cargo.Descricao = "Reserva do Estagiário";

            var cargoAtualizado = _repositorio.Atualizar(cargo);

            cargoAtualizado.Descricao.Should().Be(cargo.Descricao);
        }
        [Test]
        public void Cargo_repositorio_deve_excluir()
        {
            _cargo = ObjectMother.CargoValido();
            _repositorio.Inserir(_cargo);
            var idEsperado = 2;
            var cargoBuscado = _repositorio.PegarPorId(idEsperado);

            _repositorio.Deletar(cargoBuscado);

            var cargoDeletado = _repositorio.PegarPorId(idEsperado);

            cargoDeletado.Should().BeNull();
        }
    }
}
