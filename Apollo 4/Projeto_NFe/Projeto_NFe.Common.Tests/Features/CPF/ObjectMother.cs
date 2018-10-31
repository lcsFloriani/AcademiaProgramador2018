using Projeto_NFe.Infra.CPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Base
{
    public partial class ObjectMother
    {
        public static Cpf GetCpf()
        {
            return new Cpf()
            {
                Value = "32999959010"
            };
        }

        public static Cpf GetCpfWithValueFormat()
        {
            return new Cpf()
            {
                Value = "979.009.460-47"
            };
        }

        public static Cpf GetCpfWithValueEmpty()
        {
            return new Cpf()
            {
                Value = "",
            };
        }

        public static Cpf GetCpfInvalidValue()
        {
            return new Cpf()
            {
                Value = "12345678909",
            };
        }

        public static Cpf GetCpfEqualToZero()
        {
            return new Cpf()
            {
                Value = "00000000000",
            };
        }

        public static Cpf GetCpfLessThanEleven()
        {
            return new Cpf()
            {
                Value = "0000000000",
            };
        }

        public static Cpf GetCpfOverFlow()
        {
            return new Cpf()
            {
                Value = "000000000000",
            };
        }


        public static Cpf GetCpfIncorrectValue()
        {
            return new Cpf()
            {
                Value = "BB000000000",
            };
        }
    }
}
