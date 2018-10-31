using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Dominio
{
    public class Movimentacao
    {
        private double _valor;
        private string _tipo;

        public Movimentacao(string tipo, double valor)
        {
            _valor = valor;
            _tipo = tipo;
        }

        public string ObtemMovimentacao()
        {
            return "=> " + _tipo + " de R$" + _valor;
        }
    }
}
