using NUnit.Framework;
using Projeto_loterica.Common.Tests.Features.ObjectMothers;
using Projeto_loterica.CSV.Features.CSVGeral;
using Projeto_loterica.Domain.Features.Apostas;
using Projeto_loterica.Domain.Features.Boloes;
using Projeto_loterica.Domain.Features.Concursos;
using System;
using FluentAssertions;
using System.IO;
using Projeto_loterica.Domain.Tests.Features.Concursos;
using System.Collections.Generic;

namespace Projeto_loterica.CSV.Test
{
    [TestFixture]
    public class ConcursoCSVTest
    {
        Aposta _aposta;
        Concurso _concurso;
        Bolao _bolao;
        GerarCSV _gerarCSV;
        List<Concurso> listConcursos;
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        [SetUp]
        public void ApostaRepositorySet()
        {
            listConcursos = new List<Concurso>();
            _aposta = new Aposta();
            _concurso = new Concurso(new Estatisticas(new Vencedor(), new Vencedor(), new Vencedor()));
            _bolao = new Bolao();
            _gerarCSV = new GerarCSV();
            _aposta = ObjectMother.apostaValida;
            _bolao = ObjectMother.BolãoValido;
            _concurso = ObjectMother.ConcursoValido;

            _concurso.Apostas.Add(_aposta);
            _bolao.Apostas.Add(_aposta);
            _concurso.Boloes.Add(_bolao);
            _concurso.Apostas.Add(ObjectMother.apostaValidaMega);
            _concurso.Apostas.Add(ObjectMother.apostaValidaMega);
            for (int i = 0; i < 5; i++)
                _concurso.Apostas.Add(ObjectMother.apostaValidaQuina);

            for (int i = 0; i < 40; i++)
                _concurso.Apostas.Add(_aposta);

            for (int i = 0; i < 20; i++)
                _concurso.Apostas.Add(ObjectMother.apostaValidaQuadra);


            _concurso.GerarResultado(new FakeRandom());

            for (int i = 0; i < 20; i++)
                listConcursos.Add(_concurso);
        }

        [Test]
        public void Test_Generate_CSV_Relatorio_Should_BeOk()
        {
            string filePath = desktop + @"\TesteCSVVV.csv";
            _gerarCSV.GerarRelatorio(_concurso, filePath);
            File.Exists(filePath).Should().BeTrue();
        }
        [Test]
        public void Test_Generate_CSV_Relatorio_Concurso_Vazio_Should_BeOk()
        {
            var concursoVazio = new Concurso(new Estatisticas(new Vencedor(), new Vencedor(), new Vencedor()));
            concursoVazio.GerarResultado(new Random());
            string filePath = desktop + @"\TesteCSVVVazio.csv";
            _gerarCSV.GerarRelatorio(concursoVazio, filePath);
            File.Exists(filePath).Should().BeTrue();
        }

        [Test]
        public void Test_Generate_CSV_Espelho_Should_BeOk()
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = desktop + @"\TesteCSVVVEspelho.csv";
            _gerarCSV.GerarEspelhoDoBanco(listConcursos, filePath);
            File.Exists(filePath).Should().BeTrue();
        }
    }
}
