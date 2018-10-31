using FlorianiProva.Comum.Base;
using FlorianiProva.Comum.ObjetosMae.Alunos;
using FlorianiProva.Dominio.Exceções;
using FlorianiProva.Dominio.Features.Alunos;
using FlorianiProva.Infra.Data.Features.Alunos;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Infra.Data.Testes.Features.Alunos
{
    [TestFixture]
    public class AlunoRepositoryTestes
    {
        private IAlunoRepository _alunoRepository;
        private Aluno _aluno;

        [SetUp]
        public void SetUp()
        {
            _alunoRepository = new AlunoRepository();
            _aluno = new Aluno();
        }
        [Test]
        public void Aluno_InfraData_Inserir_EsperadoOK()
        {
            BaseSqlTeste.SemearBanco();

            _aluno = AlunoObjetoMae.AlunoValido();

            var alunoInserido = _alunoRepository.Inserir(_aluno);

            alunoInserido.Should().NotBeNull();
        }
        [Test]
        public void Aluno_InfraData_Atualizar_EsperandoOk()
        {
            BaseSqlTeste.SemearBanco();

            _aluno = AlunoObjetoMae.AlunoValido();
            _aluno.Nome = "Zé";
            var alunoAtualizado = _alunoRepository.Atualizar(_aluno);

            alunoAtualizado.Should().NotBeNull();
            alunoAtualizado.Nome.Should().Be(_aluno.Nome);
        }
        [Test]
        public void Aluno_InfraData_Deletar_EsperadoOK()
        {

            BaseSqlTeste.SemearBanco();

            _aluno.Id = 1;

            bool deletado = _alunoRepository.Deletar(_aluno.Id);
            
            deletado.Should().BeTrue();
        }

        [Test]
        public void Aluno_InfraData_PegarPorID_EsperadoOK()
        {
            BaseSqlTeste.SemearBanco();
            _aluno.Id = 1;
            
            var aluno = _alunoRepository.ObterPorId(_aluno.Id);
            
            aluno.Should().NotBeNull();
            aluno.Id.Should().Be(_aluno.Id);
        }

        [Test]
        public void Aluno_InfraData_PegarTodos_EsperadoOK()
        {
            BaseSqlTeste.SemearBanco();
            
            var listaEnderecos = _alunoRepository.ObterTodos();
            
            listaEnderecos.Should().NotBeNull();
            listaEnderecos.Count.Should().BeGreaterThan(0);
        }
        [Test]
        public void Aluno_InfraData_Deletar_IdNegativo_EsperandoFalha()
        {
            var aluno = AlunoObjetoMae.AlunoValido();
            aluno.Id = -1;
            Action action = () => _alunoRepository.Deletar(aluno.Id);
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }
        [Test]
        public void Aluno_InfraData_Deletar_IdInexistente_EsperandoFalha()
        {
            var aluno = AlunoObjetoMae.AlunoValido();
            aluno.Id = 9998;
            var deletado = _alunoRepository.Deletar(aluno.Id);
            deletado.Should().BeFalse();
        }
    }
}
