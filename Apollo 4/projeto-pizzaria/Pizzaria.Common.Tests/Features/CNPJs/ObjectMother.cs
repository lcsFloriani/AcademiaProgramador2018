using Pizzaria.Infra.CNPJs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Common.Tests.Base
{
    public partial class ObjectMother
    {
        public static Cnpj ObterCnpj()
        {
            return new Cnpj()
            {
                Valor = "08671696000190",
            };
        }

        public static Cnpj ObterCnpjComValorNuloOuVazio()
        {
            return new Cnpj()
            {
                Valor = "",
            };
        }

        public static Cnpj ObterCnpjComValorInvalido()
        {
            return new Cnpj()
            {
                Valor = "00000000000001",
            };
        }

        public static Cnpj ObterCnjComValorIgualZero()
        {
            return new Cnpj()
            {
                Valor = "00000000000000",
            };
        }

        public static Cnpj ObterCnpjComValorMenorQueCatorze()
        {
            return new Cnpj()
            {
                Valor = "0000000000",
            };
        }

        public static Cnpj ObterCnpjOverFlow()
        {
            return new Cnpj()
            {
                Valor = "000000000000000",
            };
        }


        public static Cnpj ObterCnpjComValorIncorreto()
        {
            return new Cnpj()
            {
                Valor = "BB000000000000",
            };
        }
    }
}
