using FluentAssertions;
using NUnit.Framework;
using ORM01.Aplicacao.Features.Enderecos;
using ORM01.Comum.Testes.Base;
using ORM01.Comum.Testes.Features;
using ORM01.Dominio.Features.Enderecos;
using ORM01.Infra;
using ORM01.Infra.Data.Features.Enderecos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Integration.Testes.Features.Enderecos
{
    [TestFixture]
    class EnderecoServiceRepositoryTest
    {
        Endereco _endereco;
        EnderecoDataRepository _repository;
        EnderecoService _service;
        ContextORM contextORM = new ContextORM();
        [SetUp]
        public void AlunoServiceRepositoryTest_Set()
        {
            Database.SetInitializer(new IncializadorDB<ContextORM>());

            _endereco = ObjectMother.endereco;
            _repository = new EnderecoDataRepository(contextORM);
            
            _service = new EnderecoService(_repository);
        }

        [Test]
        public void Sistema_Endereco_DeveriaincluirUmNovoEnderecoOk()
        {
            _service.Add(_endereco);

            _endereco.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Sistema_Endereco_DeveriaExcluirUmNovoEnderecoOk()
        {
            _service.Add(_endereco);

            long id = _endereco.Id;

            _service.Delete(_endereco);

            var AlunoDeletado = _service.GetById(_endereco.Id);
            AlunoDeletado.Should().BeNull();

        }

        [Test]
        public void Sistema_Endereco_DeveriaAtualizarUmNovoEnderecoOk()
        {
            _endereco.Id = 1;
            _endereco.Logradouro = "Update";
            _service.Update(_endereco);

            _endereco.Logradouro.Should().Be("Update");

        }

        [Test]
        public void Sistema_Endereco_DeveriaBuscarTodosOEnderecosOk()
        {
            _service.Add(_endereco);

            List<Endereco> retornoGetAll = _service.GetAll();

            retornoGetAll.Should().NotBeNull();
            retornoGetAll.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Sistema_Endereco_DeveriaBuscarUmEnderecoOk()
        {
            _service.Add(_endereco);
            var retornoGet = _service.GetById(_endereco.Id);

            retornoGet.Should().NotBeNull();
            retornoGet.Id.Should().Be(_endereco.Id);
        }
    }
}
