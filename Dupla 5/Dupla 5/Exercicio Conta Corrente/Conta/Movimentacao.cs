using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioContaCorrente.Domain
{
    public class Movimentacao
    {
        public int numero;
        public string operacao;
        public double valor;

        private static List<Movimentacao> _contas = new List<Movimentacao>();

        public void Insert(int numero, string operacao, double valor)
        {
            Movimentacao movimentacao = new Movimentacao();
            movimentacao.numero = numero;
            movimentacao.operacao = operacao;
            movimentacao.valor = valor;

            _contas.Add(movimentacao);
        }

        public List<Movimentacao> GetAll(int numero)
        {
            return _contas.FindAll(
                delegate (Movimentacao _contas)
                {
                    return _contas.numero == numero;
                }
            );
        }

        public override string ToString()
        {
            return string.Format("{0} de {1}R$", operacao, valor);
        }
    }
}

