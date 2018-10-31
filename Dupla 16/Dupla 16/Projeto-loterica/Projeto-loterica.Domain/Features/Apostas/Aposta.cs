using Projeto_loterica.Domain.Entidades;
using Projeto_loterica.Domain.Exceptions;
using Projeto_loterica.Domain.Features.Concursos;
using Projeto_loterica.Domain.Features.Enums;
using Projeto_loterica.Domain.Features.Exceptions;
using Projeto_loterica.Domain.Features.Numeros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_loterica.Domain.Features.Apostas
{
    public class Aposta : Entidade
    {
        public List<Numero> Numeros { get; set; }
        public Vencedora Resultado { get; set; }
        public double ValorRecebido { get; set; }
        public double ValorPago { get; set; }
        public Aposta()
        {
            Numeros = new List<Numero>();
        }
        public void Validar()
        {
            if (Numeros.Count < 6)
                throw new ApostaInvalidaException();
            var ArrayNumeros = Numeros.ToArray();
            for (int i = 0; i < ArrayNumeros.Length; i++)
            {
                for (int x = i + 1; x < ArrayNumeros.Length; x++)
                {
                    if (ArrayNumeros[x].Valor == ArrayNumeros[i].Valor)
                        throw new NumeroRepetidoEmApostaException();
                }
            }
        }

        public static List<Numero> ConversaoParaLista(string s)
        {
            var numeros = new List<Numero>();
            if (!string.IsNullOrEmpty(s))
            {
                var ConvertArrayNumeros = s.Split(',');
                for (int i = 0; i < ConvertArrayNumeros.Length; i++)
                {
                    numeros.Add(Int32.Parse(ConvertArrayNumeros[i]));
                }
            }
            return numeros;
        }
        public static string ConversaoParaString(List<Numero> s)
        {
            string numeros = "";

            foreach (var item in s)
            {
                numeros += item.Valor + ",";
            }
            int ateUltimoNumero = numeros.Length - 1;
            return numeros.Substring(0, ateUltimoNumero);
        }
        


    }
}
