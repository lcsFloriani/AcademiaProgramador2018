using FluentAssertions;
using Moq;
using NUnit.Framework;
using Orm.Aplicacao.Features.Enderecos;
using Orm.Comum.Testes.Features;
using Orm.Dominio.Exceptions;
using Orm.Dominio.Features.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Orm.Aplicacao.Testes.Features.Enderecos
{
    [TestFixture]
    public class EnderecoAplicacaoTestes
    {
        private Mock<IEnderecoRepositorio> _enderecoRepositorio;
        private Endereco _endereco;
        private EnderecoServico _enderecoService;

        [SetUp]
        public void SetUo()
        {
            _enderecoRepositorio = new Mock<IEnderecoRepositorio>();
            _endereco = new Endereco();
            _enderecoService = new EnderecoServico(_enderecoRepositorio.Object);
        }

        [Test]
        public void Endereco_Aplicacao_Salvar_DevePassar()
        {
            var idEsperado = 1;
            _endereco = ObjectMother.EnderecoValido();
            _enderecoRepositorio.Setup(er => er.Salvar(_endereco)).
                Returns(new Endereco { Id = 1});

            var enderecoSalvo = _enderecoService.Salvar(_endereco);

            _enderecoRepositorio.Verify(er => er.Salvar(_endereco));
            enderecoSalvo.Should().NotBeNull();
            enderecoSalvo.Id.Should().Be(idEsperado);
            _enderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Atualizar_DevePassar()
        {
            _endereco = ObjectMother.EnderecoValido();
            var novaCidade = "aaaa";
            _endereco.Cidade = novaCidade;
            _enderecoRepositorio.Setup(er => er.Atualizar(_endereco))
                .Returns(new Endereco { Id = 2, Cidade = "aaaa" });

            var enderecoAtualizado = _enderecoService.Atualizar(_endereco);

            _enderecoRepositorio.Verify(er => er.Atualizar(_endereco));
            enderecoAtualizado.Cidade.Should().Be(novaCidade);
            _enderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Atualizar_IdInvalido_DeveFalhar()
        {
            var idInvalido = -40;
            _endereco = ObjectMother.EnderecoValido();
            _endereco.Id = idInvalido;

            Action action = () => _enderecoService.Atualizar(_endereco);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Endereco_Aplicacao_PegarTodos_DevePassar()
        {
            var totalEnderecos = 2;
            var idEsperado = 3;
            Endereco ender = ObjectMother.EnderecoValido();
            ender.Id = idEsperado;
            var enderecos = new List<Endereco>();
            enderecos.Add(ender);
            enderecos.Add(ObjectMother.EnderecoValido());
            _enderecoRepositorio.Setup(er => er.PegarTodos())
                .Returns(enderecos);

            var listaEnderecos = _enderecoService.PegarTodos();
            
            listaEnderecos.Count.Should().Be(totalEnderecos);
            listaEnderecos.First().Id.Should().Be(idEsperado);
            _enderecoRepositorio.Verify(er => er.PegarTodos());
            _enderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_PegarPorId_DevePassar()
        {
            var id = 2;
            _enderecoRepositorio.Setup(x => x.PegarPorId(2)).Returns(ObjectMother.EnderecoValido());

            Endereco enderecoObtido = _enderecoService.PegarPorId(id);

            enderecoObtido.Id.Should().Be(id);
            _enderecoRepositorio.Verify(x => x.PegarPorId(2));
            _enderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_PegarPorId_DeveFalharIdInvalido()
        {
            Action action = () => _enderecoService.PegarPorId(0);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Endereco_Aplicacao_Deletar_DeveDeletar()
        {
            Endereco endereco = ObjectMother.EnderecoValido();
            _enderecoRepositorio.Setup(x => x.Deletar(endereco));

            _enderecoService.Deletar(endereco);

            _enderecoRepositorio.Verify(x => x.Deletar(endereco));
            _enderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Deletar_DeveFalharIdInvalido()
        {
            Endereco endereco = ObjectMother.EnderecoValido();
            endereco.Id = 0;

            Action action = () => _enderecoService.Deletar(endereco);

            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
