using Projeto_loterica.Domain.Features.Apostas;
using Projeto_loterica.Domain.Features.Enums;
using Projeto_loterica.Domain.Features.Numeros;
using System.Collections.Generic;

namespace Projeto_loterica.Common.Tests.Features.ObjectMothers
{
    public static partial class ObjectMother
    {
        public static Aposta apostaValida
        {
            get
            {
                var aposta = new Aposta();
                aposta.Id = 1;
                aposta.Numeros = new List<Numero>();
                for (int i = 0; i < 6; i++)
                {
                    aposta.Numeros.Add(i + 15);
                }
                aposta.ValorPago = 10;
                return aposta;
            }
        }
        public static Aposta apostaValidaMega
        {
            get
            {
                var aposta = new Aposta();
                aposta.Numeros = new List<Numero>();
                for (int i = 0; i < 6; i++)
                {
                    aposta.Numeros.Add(i + 1);
                }
                aposta.ValorPago = 10;
                return aposta;
            }
        }
        public static Aposta apostaValidaQuina
        {
            get
            {
                var aposta = new Aposta();
                aposta.Numeros = new List<Numero>();
                for (int i = 0; i < 5; i++)
                {
                    aposta.Numeros.Add(i + 1);
                }
                aposta.Numeros.Add(20);
                aposta.ValorPago = 10;
                return aposta;
            }
        }
        public static Aposta apostaValidaQuadra
        {
            get
            {
                var aposta = new Aposta();
                aposta.Numeros = new List<Numero>();
                for (int i = 0; i < 4; i++)
                {
                    aposta.Numeros.Add(i + 1);
                }
                aposta.Numeros.Add(20);
                aposta.Numeros.Add(21);
                aposta.ValorPago = 10;
                return aposta;
            }
        }

        public static Aposta apostaInvalidaNumerosIguais
        {
            get
            {
                var aposta = new Aposta();
                aposta.Numeros = new List<Numero>();
                for (int i = 0; i < 6; i++)
                {
                    aposta.Numeros.Add(1);
                }
                aposta.ValorPago = 3.50;
                aposta.ValorRecebido = 150.00;
                aposta.Resultado = Vencedora.Quina;
                return aposta;
            }
        }

        public static Aposta apostaInvalidaMenosDe6Numeros
        {
            get
            {
                var aposta = new Aposta();
                aposta.Numeros = new List<Numero>();
                for (int i = 0; i < 5; i++)
                {
                    aposta.Numeros.Add(i + 1);
                }
                aposta.ValorPago = 3.50;
                aposta.ValorRecebido = 150.00;
                aposta.Resultado = Vencedora.Quina;
                return aposta;
            }
        }

    }
}
