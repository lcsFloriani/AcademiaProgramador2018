using Projeto_NFe.Infra.CNPJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Base
{
    public partial class ObjectMother
    {
        public static Cnpj GetCnpj()
        {
            return new Cnpj()
            {
                Value = "08671696000190",
            };
        }

        public static Cnpj GetCnpjWithValueEmpty()
        {
            return new Cnpj()
            {
                Value = "",
            };
        }

        public static Cnpj GetCnpjInvalidValue()
        {
            return new Cnpj()
            {
                Value = "00000000000001",
            };
        }

        public static Cnpj GetCnpjEqualToZero()
        {
            return new Cnpj()
            {
                Value = "00000000000000",
            };
        }

        public static Cnpj GetCnpjLessThanFourTeen()
        {
            return new Cnpj()
            {
                Value = "0000000000",
            };
        }

        public static Cnpj GetCnpjOverFlow()
        {
            return new Cnpj()
            {
                Value = "000000000000000",
            };
        }


        public static Cnpj GetCnpjIncorrectValue()
        {
            return new Cnpj()
            {
                Value = "BB000000000000",
            };
        }
    }
}
