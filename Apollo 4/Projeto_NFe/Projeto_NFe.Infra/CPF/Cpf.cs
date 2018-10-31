using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.CPF
{
    public class Cpf
    {
        private readonly string INVALID_PATTER = "00000000000";
        private readonly int NUMBER_DIGITIS = 11;

        public string Value { get; set; }
        public string FormattedValue { get => SetMask(Value); }

        public virtual void Validate()
        {
            RemoveMask(Value);

            if (string.IsNullOrEmpty(Value))
                throw new CpfValueNullOrEmptyException();

            if (Value.Length < NUMBER_DIGITIS)
                throw new CpfValueLessThanElevenException();

            if (Value.Length > NUMBER_DIGITIS)
                throw new CpfValueOverFlowException();

            if (INVALID_PATTER.Equals(Value))
                throw new CpfValueEqualToZeroException();

            long x = 0;
            if (!long.TryParse(Value, out x))
                throw new CpfIncorrectValueException();

            if (!IsValid())
                throw new CpfInvalidValueException();


        }

        private bool IsValid()
        {
            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (Value[i] != Value[0])
                    igual = false;

            if (igual || Value == "12345678909")
                return false;

            int[] numeros = new int[11];
            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(
                Value[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;

            }
            else
                if (numeros[10] != 11 - resultado)
                return false;
            return true;
        }

        private void RemoveMask(string value)
        {
            value = value.Replace(".", "");
            value = value.Replace("-", "");

            Value = value;
        }

        private string SetMask(string value)
        {
            return Convert.ToUInt64(value).ToString(@"000\.000\.000\-00");
        }
    }
}
