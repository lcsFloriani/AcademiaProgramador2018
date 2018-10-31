using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using FlorianiProva.Comum.ObjetosMae.Alunos;
using FluentAssertions;
using FlorianiProva.Dominio.Features.Alunos.Excecoes;
using FlorianiProva.Dominio.Exceções;

namespace FlorianiProva.Dominio.Testes.Features.Alunos
{
    [TestFixture]
    public class AlunoTestes
    {
        [Test]
        public void Aluno_Dominio_Validar_NomeEmBranco_DeveFalhar()
        {
            var aluno = AlunoObjetoMae.AlunoComNomeEmBranco();
            Action action = () => aluno.Validar();
            action.Should().Throw<NomeEmBrancoException>();
        }
        [Test]
        public void Aluno_Dominio_Validar_IdadeNegativa_DeveFalhar()
        {
            var aluno = AlunoObjetoMae.AlunoComIdadeNegativa();
            Action action = () => aluno.Validar();
            action.Should().Throw<IdadeNegativaException>();
        }
        [Test]
        public void Aluno_Dominio_Validar_NomeMaiorQue150Caracteres_DeveFalhar()
        {
            var aluno = AlunoObjetoMae.AlunoComNomeMuitoGrande();
            Action action = () => aluno.Validar();
            action.Should().Throw<NomeMuitoGrandeException>();
        }
        [Test]
        public void Aluno_Dominio_Validar_DevePassar()
        {
            var aluno = AlunoObjetoMae.AlunoValido();
            Action action = () => aluno.Validar();
            action.Should().NotThrow<ExcecaoDeNegocio>();
        }
    }
}
