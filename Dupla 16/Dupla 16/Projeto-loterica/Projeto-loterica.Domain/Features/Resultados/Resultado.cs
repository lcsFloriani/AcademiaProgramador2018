using Projeto_loterica.Domain.Entidades;
using Projeto_loterica.Domain.Enums;
using Projeto_loterica.Domain.Features.Numeros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_loterica.Domain.Features.Resultados
{
    public class Resultado 
    {
        public Numero[] numeros;

        public Resultado(Random r)
        {
            numeros = new Numero[6];
            GerarResultadoAleatorio(r);
        }

        private void GerarResultadoAleatorio(Random r)
        {
            bool NumeroNãoRepetido = false;

            for (int i = 0; i < numeros.Length; i++)
            {
                while (!NumeroNãoRepetido)
                {
                    NumeroNãoRepetido = true;
                    int novoResultado = (int)r.Next((int)ValorMinMaxAposta.Min, (int)ValorMinMaxAposta.Max);
                    for (int z = 0; z < i; z++)
                    {
                        if (numeros[z] == novoResultado)
                        {
                            NumeroNãoRepetido = false;
                        }
                    }
                    if (NumeroNãoRepetido)
                    {
                        numeros[i] = novoResultado;
                    }
                }
                NumeroNãoRepetido = false;
            }
        }

        private Resultado(Numero[] r)
        {
            numeros = r;
        }

        public static explicit operator Resultado(string s)
        {

            var numeros = new Numero[6];
            if (!string.IsNullOrEmpty(s))
            {
                var ConvertArrayNumeros = s.Split(',');
                for (int i = 0; i < ConvertArrayNumeros.Length; i++)
                {
                    numeros[i] = Int32.Parse(ConvertArrayNumeros[i]);
                }
            }
            return new Resultado(numeros);
        }

        public static explicit operator string(Resultado s)
        {
            string montarStringParaOBanco = "";
            for (int i = 0; i < s.numeros.Length; i++)
            {
                montarStringParaOBanco += s.numeros[i].Valor + (s.numeros.Length-1 == i ? "" : ",");
            }
            return montarStringParaOBanco;
        }

        public override string ToString()
        {
            return (string)this; 
        }
    }
}
