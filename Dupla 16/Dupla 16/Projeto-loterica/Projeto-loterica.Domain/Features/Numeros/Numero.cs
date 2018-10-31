using Projeto_loterica.Domain.Enums;
using Projeto_loterica.Domain.Features.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_loterica.Domain.Features.Numeros
{
    public class Numero
    {
        public int Valor { get; set; }
        
        
        public Numero(int numero)
        {
            if (numero < (int)ValorMinMaxAposta.Min || numero > (int)ValorMinMaxAposta.Max)
                throw new NumeroInvalidoException();
            Valor = numero;
        }

        public static implicit operator Numero(int n)
        {
            return new Numero(n);
        }

        public static implicit operator int(Numero n)
        {
            return n.Valor;
        }

        public override string ToString()
        {
            return this.Valor.ToString();
        }
    }
}
