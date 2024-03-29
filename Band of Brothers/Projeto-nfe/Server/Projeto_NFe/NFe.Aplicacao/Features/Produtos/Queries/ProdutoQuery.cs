﻿namespace NFe.Aplicacao.Features.Produtos.Queries
{
    public class ProdutoQuery
    {
        public virtual int Id { get; set; }
        public virtual int CodigoProduto { get; set; }
        public virtual string Descricao { get; set; }
        public virtual int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ICMS { get; set; }
        public decimal Ipi { get; set; }
    }
}
