using FluentAssertions;
using NUnit.Framework;
using ORM01.Comum.Testes.Base;
using ORM01.Comum.Testes.Features;
using ORM01.Dominio.Features.Alunos;
using ORM01.Infra.Data.Features.Alunos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Infra.Data.Testes.Features.Alunos
{
    [TestFixture]
    public class AlunoDataRepositoryTest
    {
        Aluno _aluno;
        AlunoDataRepository _alunoEntiteRepository;
        ContextORM contextORM = new ContextORM();
        [SetUp]
        public void EntetiRepository_Aluno_SetUpTest()
        {
            Database.SetInitializer(new IncializadorDB<ContextORM>());
            
            _aluno = ObjectMother.aluno;
            _alunoEntiteRepository = new AlunoDataRepository(contextORM);
        }

        [Test]
        public void Repository_Aluno_DeveAdicionarUmAlunoOk()
        {
            _alunoEntiteRepository.Add(_aluno);
            _aluno.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_Aluno_DeveExcluirUmAlunoOk()
        {
            _alunoEntiteRepository.Add(_aluno);
            _alunoEntiteRepository.Delete(_aluno);
        }

        [Test]
        public void Repository_Aluno_DeveListarPorIdUmAlunoOk()
        {
            _alunoEntiteRepository.Add(_aluno);
            var alunoResult = _alunoEntiteRepository.GetById(_aluno.Id);
            alunoResult.Nome.Should().Be(_aluno.Nome);

        }

        [Test]
        public void Repository_Aluno_DeveListartodosOsAlunosOk()
        {
            _alunoEntiteRepository.Add(_aluno);
            var alunoResult = _alunoEntiteRepository.GetAll();
            alunoResult.Count.Should().BeGreaterThan(0);

        }

        [Test]
        public void Repository_Aluno_DeveAtualizarUmAlunoOk()
        {
            _aluno.Id = 1;
            _aluno.Nome = "Update";
            _alunoEntiteRepository.Update(_aluno);
           
            var alunoResult = _alunoEntiteRepository.GetById(1);
            alunoResult.Nome.Should().Be("Update");

        }
    }
}
