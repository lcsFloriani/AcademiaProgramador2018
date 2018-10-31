using FluentAssertions;
using NUnit.Framework;
using ORM01.Aplicacao.Features.Turmas;
using ORM01.Comum.Testes.Base;
using ORM01.Comum.Testes.Features;
using ORM01.Dominio.Features.Turmas;
using ORM01.Infra;
using ORM01.Infra.Data.Features.Turmas;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Integration.Testes.Features.Turmas
{
    [TestFixture]
    public class TurmaServiceRepositoryTest
    {
        Turma _turma;
        TurmaDataRepository _repository;
        TurmaService _service;
        ContextORM contextORM = new ContextORM();
        [SetUp]
        public void AlunoServiceRepositoryTest_Set()
        {
            Database.SetInitializer(new IncializadorDB<ContextORM>());
            
            _turma = ObjectMother.Turma;
            _repository = new TurmaDataRepository(contextORM);
            _service = new TurmaService(_repository);
        }

        [Test]
        public void Sistema_Turma_DeveriaincluirUmaNovaTurmaOk()
        {
            _service.Add(_turma);

            _turma.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Sistema_Turma_DeveriaExcluirUmaNovaTurmaOk()
        {
            _service.Add(_turma);

            long id = _turma.Id;

            _service.Delete(_turma);

            var AlunoDeletado = _service.GetById(_turma.Id);

            AlunoDeletado.Should().BeNull();
        }

        [Test]
        public void Sistema_Turma_DeveriaAtualizarUmaNovaTurmaOk()
        {
            _turma.Id = 1;
            _turma.Descricao = "Update";
            _service.Update(_turma);

            _turma.Descricao.Should().Be("Update");
        }

        [Test]
        public void Sistema_Turma_DeveriaBuscarTodasAsTurmasOk()
        {
            _service.Add(_turma);

            List<Turma> retornoGetAll = _service.GetAll();

            retornoGetAll.Should().NotBeNull();
            retornoGetAll.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Sistema_Turma_DeveriaBuscarUmaTurmaOk()
        {
            _service.Add(_turma);
            var retornoGet = _service.GetById(_turma.Id);

            retornoGet.Should().NotBeNull();
            retornoGet.Id.Should().Be(_turma.Id);
        }
    }
}