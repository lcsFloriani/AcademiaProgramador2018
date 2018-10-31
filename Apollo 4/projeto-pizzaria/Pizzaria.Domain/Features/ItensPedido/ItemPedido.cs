using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.Domain.Features.Produtos;

using System;
using System.Linq;
using System.Text;

namespace Pizzaria.Domain.Features.ItensPedido
{
    public class ItemPedido
    {
        private int _menorQue = 1;

        public long Id { get; set; }
        public int Quantidade { get; set; }
        public long PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
        public long PrimeiroProdutoId { get; set; }
        public virtual Produto PrimeiroProduto { get; set; }
        public long? SegundoProdutoId { get; set; }
        public virtual Produto SegundoProduto { get; set; }
        public long? AdicionalId { get; set; }
        public virtual Produto Adicional { get; set; }

        public ItemPedido()
        {
            Quantidade = 1;
        }

        public ItemPedido(Produto produto, int quantidade)
        {
            PrimeiroProduto = produto;
            Quantidade = quantidade;
        }

        public ItemPedido(Produto primeiraPizza, Produto segundaPizza, Produto adicional, int quantidade)
        {
            PrimeiroProduto = primeiraPizza;
            SegundoProduto = segundaPizza;
            Adicional = adicional;
            Quantidade = quantidade;
        }


        public virtual void Validar()
        {
            if (Pedido == null)
            {
                throw new ItemPedidoPedidoNuloExcecao();
            }

            if (PrimeiroProduto == null)
            {
                throw new ItemPedidoPrimeiroProdutoNuloOuVazioExcecao();
            }

            if (Quantidade < _menorQue)
            {
                throw new ItemPedidoQuantidadeZeroExcecao();
            }

            if (Adicional != null && Adicional.Tipo != TipoProdutoEnum.Adicional)
            {
                throw new ItemPedidoAdicionalInvalidoExcecao();
            }

            if (SegundoProduto != null)
            {
                if (PrimeiroProduto.Descricao.Equals(SegundoProduto.Descricao))
                {
                    throw new ItemPedidoPrimeiroProdutoIgualSegundoProdutoInvalidoExcecao();
                }
            }
        }
        
        public double ValorParcial
        {
            get
            {
                return SomatorioValoresProdutos() * Quantidade;
            }
        }

        private double SomatorioValoresProdutos()
        {
            double somatorio = 0;

            if (SegundoProduto != null)
            {
                somatorio = VerificarMaiorValor(PrimeiroProduto, SegundoProduto);
            }
            else
            {
                somatorio = PrimeiroProduto.Valor;
            }

            somatorio += Adicional == null ? 0 : Adicional.Valor;

            return somatorio;
        }

        private double VerificarMaiorValor(params Produto[] produtos)
        {
            return produtos.Max(x => x.Valor);
        }

        public override string ToString()
        {
            StringBuilder mensagem = new StringBuilder();

            switch (PrimeiroProduto.Tipo)
            {
                case TipoProdutoEnum.Pizza:
                    mensagem.Append(ToStringPizza());
                    break;
                case TipoProdutoEnum.Calzone:
                    mensagem.Append(ToStringCalzone());
                    break;
                case TipoProdutoEnum.Bebida:
                    mensagem.Append(ToStringBebida());
                    break;
            }

            mensagem.Append(" - Qtd: " + Quantidade);
            mensagem.Append(" - Subtotal R$: " + ValorParcial);

            return mensagem.ToString();
        }

        private string ToStringBebida()
        {
            StringBuilder mensagem = new StringBuilder();
            mensagem.Append(string.Format("Bedida - {0}", PrimeiroProduto.Descricao));

            return mensagem.ToString();
        }

        private string ToStringCalzone()
        {
            StringBuilder mensagem = new StringBuilder();
            mensagem.Append(string.Format("Calzone de {0}", PrimeiroProduto.Descricao));

            return mensagem.ToString();
        }

        private string ToStringPizza()
        {
            StringBuilder mensagem = new StringBuilder(string.Format("Pizza {0} - ", PrimeiroProduto.Tamanho));

            string tipoPizza = SegundoProduto != null ? "Meia" : "sabor";

            mensagem.Append(string.Format("{0} de {1} ", tipoPizza, PrimeiroProduto.Descricao));

            if (SegundoProduto != null)
            {
                mensagem.Append(string.Format("com {0} ", SegundoProduto.Descricao));
            }

            if (Adicional != null)
            {
                mensagem.Append(string.Format(" - {0} ", Adicional.Descricao));
            }

            return mensagem.ToString();
        }
    }
}