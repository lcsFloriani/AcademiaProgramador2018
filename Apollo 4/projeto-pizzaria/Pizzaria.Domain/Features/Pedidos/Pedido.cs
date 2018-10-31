using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Produtos;
using Pizzaria.Infra.CNPJs;
using Pizzaria.Infra.CPFs;
using Pizzaria.Infra.Metodo_Extensao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzaria.Domain.Features.Pedidos
{
    public class Pedido
    {
        private int _igualA = 0;

        public long Id { get; set; }
        public string Setor { get; set; }
        public string Responsavel { get; set; }
        public string Documento { get; set; }
        public FormaPagamentoEnum FormaPagamento { get; set; }
        public bool EmitirNFe { get; set; }
        public string Observacao { get; set; }
        public DateTime Data { get; set; }
        public StatusPedidoEnum StatusPedido { get; set; }
        public long ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<ItemPedido> ItensPedidos { get; set; }

        public Pedido()
        {
            ItensPedidos = new List<ItemPedido>();
        }

        public virtual void Validar()
        {
            if (Cliente == null)
            {
                throw new PedidoClienteNuloExcecao();
            }

            if (ItensPedidos.Count == _igualA)
            {
                throw new PedidoItensPedidosVazioExcecao();
            }

            //Validações do Cliente
            switch (Cliente.TipoCliente)
            {
                case TipoClienteEnum.Fisico:
                    ValidarClienteFisico();
                    break;

                case TipoClienteEnum.Juridico:
                    ValidarClienteJuridico();
                    break;
            }
        }

        private void ValidarClienteJuridico()
        {
            if (string.IsNullOrEmpty(Setor))
                throw new PedidoSetorNuloOuVazioExcecao();

            if (string.IsNullOrEmpty(Responsavel))
                throw new PedidoResponsavelNuloOuVazioExcecao();

            if (EmitirNFe)
            {
                Cliente.Validar();

                if (string.IsNullOrEmpty(Documento))
                    throw new PedidoDocumentoNuloOuVazioExcecao();

                ValidarCnpj();
            }
        }

        private void ValidarCnpj()
        {
            Cnpj cnpf = new Cnpj();
            cnpf.Valor = Documento;
            cnpf.Validar();
        }

        private void ValidarClienteFisico()
        {
            if (EmitirNFe)
            {
                Cliente.Validar();

                if (string.IsNullOrEmpty(Documento))
                    throw new PedidoDocumentoNuloOuVazioExcecao();

                ValidarCpf();
            }
        }

        private void ValidarCpf()
        {
            Cpf cpf = new Cpf();
            cpf.Valor = Documento;
            cpf.Validar();
        }

        public double ValorTotal
        {
            get
            {
                return ItensPedidos.Sum(x => x.ValorParcial);
            }
        }

        public void AdicionarItem(ItemPedido itemPedido)
        {
            itemPedido.Pedido = this;
            itemPedido.Validar();
            ItensPedidos.Add(itemPedido);
        }

        public override string ToString()
        {
            return string.Format("Data: {0} - Status: {1} - Cliente: {2} - Forma de Pagamento: {3} - Qtd. Items: {4} - Valor R$: {5}", Data.ToString("MM/dd/yyyy HH:mm"), StatusPedido.ToString(), Cliente.Nome, FormaPagamento.ToString(), ItensPedidos.Count, ValorTotal);
        }
    }
}