using FluentAssertions;
using Moq;
using NUnit.Framework;
using ORM01.Comum.Testes.Base;
using ORM01.Comum.Testes.Features;
using ORM01.Dominio.Features.Turmas;
using ORM01.Infra.Data.Features.Turmas;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ActivationContext;

namespace ORM01.Infra.Data.Testes.Features.Turmas
{
    [TestFixture]
    public class TurmaDataRepositoryTest
    {
        Turma _turma;
        TurmaDataRepository _turmaRepository;
        ContextORM contextORM = new ContextORM();
        [SetUp]
        public void EntetiRepository_Turma_SetUpTest()
        {
            Database.SetInitializer(new IncializadorDB<ContextORM>());
            _turma = ObjectMother.Turma;
            _turmaRepository = new TurmaDataRepository(contextORM);
        }
        [Test]
        public void Repository_Turma_DeveAdicionarUmaTurmaOk()
        {
            _turmaRepository.Add(_turma);
            _turma.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_Turma_DeveDeletarUmaTurmaOk()
        {
            _turmaRepository.Add(_turma);
            _turmaRepository.Delete(_turma);
        }

        [Test]
        public void Repository_Turma_DeveAdicinarUmAlunoOk()
        {
            _turmaRepository.Add(_turma);
            var turmaResult = _turmaRepository.GetById(_turma.Id);
            turmaResult.Descricao.Should().Be(_turma.Descricao);
        }

        [Test]
        public void Repository_Turma_DeveListartodosAsTurmasOk()
        {
            _turmaRepository.Add(_turma);
            var alunoResult = _turmaRepository.GetAll();
            alunoResult.Count.Should().BeGreaterThan(0);

        }

        [Test]
        public void Repository_Turma_DeveAtualizarUmaTurmaOk()
        {
            _turma.Id = 1;
            _turma.Descricao = "Update";
            _turmaRepository.Update(_turma);

            var alunoResult = _turmaRepository.GetById(1);
            alunoResult.Descricao.Should().Be("Update");

        }

    }
}
