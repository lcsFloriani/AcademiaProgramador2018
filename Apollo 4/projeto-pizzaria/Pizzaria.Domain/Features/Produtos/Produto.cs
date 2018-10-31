using Pizzaria.Domain.Enums;

namespace Pizzaria.Domain.Features.Produtos
{
    public class Produto
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public TipoProdutoEnum Tipo { get; set; }
        public TamanhoProdutoEnum Tamanho { get; set; }
        public double Valor { get; set; }

        public virtual void Validar()
        {
            if (string.IsNullOrEmpty(Descricao))
            {
                throw new ProdutoDescricaoNulaOuVaziaExcecao();
            }

            if (Valor == 0 || Valor < 0)
            {
                throw new ProdutoValorNegativoOuZeradoExcecao();
            }
        }

        public override string ToString()
        {
            return string.Format("Descrição: {0} - Tipo: {1} - Tamanho: {2} - Valor: {3}",
                Descricao, Tipo, Tamanho, Valor);
        }

    }
}