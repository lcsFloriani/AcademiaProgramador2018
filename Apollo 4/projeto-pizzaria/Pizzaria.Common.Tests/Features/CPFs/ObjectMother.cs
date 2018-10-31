using Pizzaria.Infra.CPFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Common.Tests.Base
{
    public partial class ObjectMother
    {
        public static Cpf ObterCpf()
        {
            return new Cpf()
            {
                Valor = "32999959010"
            };
        }

        public static Cpf ObterCpfComValorFormatado()
        {
            return new Cpf()
            {
                Valor = "979.009.460-47"
            };
        }

        public static Cpf ObterCpfComValorNuloOuVazio()
        {
            return new Cpf()
            {
                Valor = "",
            };
        }

        public static Cpf ObterCpfComValorInvalido()
        {
            return new Cpf()
            {
                Valor = "12345678909",
            };
        }

        public static Cpf ObterCpfComValorIgualZero()
        {
            return new Cpf()
            {
                Valor = "00000000000",
            };
        }

        public static Cpf ObterCpfComValorMenorQueOnze()
        {
            return new Cpf()
            {
                Valor = "0000000000",
            };
        }

        public static Cpf ObterCpfComValorOverFlow()
        {
            return new Cpf()
            {
                Valor = "000000000000",
            };
        }


        public static Cpf ObterCpfComValorIncorreto()
        {
            return new Cpf()
            {
                Valor = "BB000000000",
            };
        }
    }
}
