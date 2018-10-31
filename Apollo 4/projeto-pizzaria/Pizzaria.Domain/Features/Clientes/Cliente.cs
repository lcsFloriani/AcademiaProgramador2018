using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Enderecos;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.Infra.CNPJs;
using Pizzaria.Infra.CPFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzaria.Domain.Features.Clientes
{
    public class Cliente
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string NumeroDocumento { get; set; }
        public virtual Endereco Endereco { get; set; }
        public TipoClienteEnum TipoCliente { get; set; }

        public virtual void Validar()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new ClienteNomeNuloOuVazioExcecao();

            if (string.IsNullOrEmpty(Telefone))
                throw new ClienteTelefoneNuloOuVazioExcecao();

            if (string.IsNullOrEmpty(NumeroDocumento))
                throw new ClienteNumeroDocumentoNuloOuVazioExcecao();

            if (Endereco == null)
                throw new ClienteEnderecoNuloExcecao();

            ValidarNumeroDocumento();

            Endereco.Validar();
        }

        private void ValidarNumeroDocumento()
        {
            switch (TipoCliente)
            {
                case TipoClienteEnum.Fisico:
                    Cpf cpf = new Cpf { Valor = NumeroDocumento };
                    cpf.Validar();
                    break;
                case TipoClienteEnum.Juridico:
                    Cnpj cnpj = new Cnpj { Valor = NumeroDocumento };
                    cnpj.Validar();
                    break;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - Telefone: {1} - Número do documento: {2} - Tipo cliente: {3}",
                Nome, Telefone, NumeroDocumento, TipoCliente);
        }
    }
}