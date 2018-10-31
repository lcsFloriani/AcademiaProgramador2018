using FluentAssertions;
using NUnit.Framework;
using ORM01.Aplicacao.Features.Alunos;
using ORM01.Comum.Testes.Base;
using ORM01.Comum.Testes.Features;
using ORM01.Dominio.Features.Alunos;
using ORM01.Infra;
using ORM01.Infra.Data.Features.Alunos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Integration.Testes.Features.Alunos
{
    [TestFixture]
    public class AlunoServiceRepositoryTest
    {
        Aluno _aluno;
        AlunoDataRepository _repository;
        AlunoService _service;
        ContextORM contextORM = new ContextORM();
        [SetUp]
        public void AlunoServiceRepositoryTest_Set()
        {
            Database.SetInitializer(new IncializadorDB<ContextORM>());
            _aluno = ObjectMother.aluno;
            _repository = new AlunoDataRepository(contextORM);
            _service = new AlunoService(_repository);
        }

        [Test]
        public void Sistema_Aluno_DeveriaincluirUmNovoAlinoOk()
        {
            _service.Add(_aluno);

            _aluno.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Sistema_Aluno_DeveriaExcluirUmNovoAlunoOk()
        {
            _service.Add(_aluno);

            long id = _aluno.Id;

            _service.Delete(_aluno);

            var AlunoDeletado = _service.GetById(_aluno.Id);
            AlunoDeletado.Should().BeNull();
        }

        [Test]
        public void Sistema_Aluno_DeveriaAtualizarUmNovoAlunoOk()
        {
            _aluno.Id = 1;
            _aluno.Nome = "Update";
            _service.Update(_aluno);

            _aluno.Nome.Should().Be("Update");

        }

        [Test]
        public void Sistema_Aluno_DeveriaBuscarTodosOsAlunosOk()
        {
            _service.Add(_aluno);

            List<Aluno> retornoGetAll = _service.GetAll();

            retornoGetAll.Should().NotBeNull();
            retornoGetAll.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Sistema_Aluno_DeveriaBuscarUmAlunoOk()
        {
            _service.Add(_aluno);
            var retornoGet = _service.GetById(_aluno.Id);

            retornoGet.Should().NotBeNull();
            retornoGet.Id.Should().Be(_aluno.Id);
        }
    }

}
