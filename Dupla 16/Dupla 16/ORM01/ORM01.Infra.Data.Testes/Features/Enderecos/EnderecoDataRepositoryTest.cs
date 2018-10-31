using FluentAssertions;
using NUnit.Framework;
using ORM01.Comum.Testes.Base;
using ORM01.Comum.Testes.Features;
using ORM01.Dominio.Features.Enderecos;
using ORM01.Infra.Data.Features.Enderecos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Infra.Data.Testes.Features.Enderecos
{
    [TestFixture]
    public class EnderecoDataRepositoryTest
    {
        Endereco _endereco;
        EnderecoDataRepository _enderecoEntiteRepository;
        ContextORM contextORM = new ContextORM();
        [SetUp]
        public void EntetiRepository_Turma_SetUpTest()
        {
            Database.SetInitializer(new IncializadorDB<ContextORM>());

            _endereco = ObjectMother.endereco;

            _enderecoEntiteRepository = new EnderecoDataRepository(contextORM);
        }
        [Test]
        public void Repository_Endereco_DeveAdicionarUmEnderecoOk()
        {
            _enderecoEntiteRepository.Add(_endereco);
            _endereco.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_Endereco_DeveDeletarUmEnderecoaOk()
        {
            _enderecoEntiteRepository.Add(_endereco);
            _enderecoEntiteRepository.Delete(_endereco);
        }

        [Test]
        public void Repository_Endereco_DeveListarUmEnderecoOk()
        {
            _enderecoEntiteRepository.Add(_endereco);
            var turmaResult = _enderecoEntiteRepository.GetById(_endereco.Id);
            turmaResult.Logradouro.Should().Be(_endereco.Logradouro);
        }

        [Test]
        public void Repository_Endereco_DeveListartodosOsEnderecosOk()
        {
            _enderecoEntiteRepository.Add(_endereco);
            var alunoResult = _enderecoEntiteRepository.GetAll();
            alunoResult.Count.Should().BeGreaterThan(0);

        }

        [Test]
        public void Repository_Endereco_DeveAtualizarUmEnderecoOk()
        {
            _endereco.Id = 1;
            _endereco.Logradouro = "Update";
            _enderecoEntiteRepository.Update(_endereco);

            var alunoResult = _enderecoEntiteRepository.GetById(1);
            alunoResult.Logradouro.Should().Be("Update");

        }
    }
}
