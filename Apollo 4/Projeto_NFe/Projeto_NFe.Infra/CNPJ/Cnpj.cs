using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.CNPJ
{
    public class Cnpj
    {
        private readonly string INVALID_PATTER = "00000000000000";
        private readonly int NUMBER_DIGITIS = 14;

        public string Value { get; set; }
        public string FormattedValue { get => SetMask(Value); }

        public virtual void Validate()
        {
            RemoveMask(Value);

            if (string.IsNullOrEmpty(Value))
                throw new CnpjValueNullOrEmptyException();

            if (Value.Length < NUMBER_DIGITIS)
                throw new CnpjValueLessThanFourteenException();

            if (Value.Length > NUMBER_DIGITIS)
                throw new CnpjValueOverFlowException();

            if (INVALID_PATTER.Equals(Value))
                throw new CnpjValueEqualToZeroException();

            if (!IsValid())
                throw new CnpjInvalidValueException();

        }


        private bool IsValid()
        {
            int[] digits, sum, result;
            int nrDig;
            string ftmt;
            bool[] CNPJOk;

            ftmt = "6543298765432";
            digits = new int[NUMBER_DIGITIS];
            sum = new int[2];
            sum[0] = 0;
            sum[1] = 0;
            result = new int[2];
            result[0] = 0;
            result[1] = 0;
            CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;

            try
            {
                for (nrDig = 0; nrDig < NUMBER_DIGITIS; nrDig++)
                {
                    digits[nrDig] = int.Parse(
                     Value.Substring(nrDig, 1));
                    if (nrDig <= 11)
                        sum[0] += (digits[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1)));
                    if (nrDig <= 12)
                        sum[1] += (digits[nrDig] * int.Parse(ftmt.Substring(nrDig, 1)));
                }

                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    result[nrDig] = (sum[nrDig] % 11);
                    if ((result[nrDig] == 0) || (result[nrDig] == 1))
                        CNPJOk[nrDig] = (digits[12 + nrDig] == 0);

                    else
                        CNPJOk[nrDig] = (digits[12 + nrDig] == (11 - result[nrDig]));

                }

                return (CNPJOk[0] && CNPJOk[1]);

            }
            catch
            {
                return false;
            }
        }

        private void RemoveMask(string value)
        {
            value = value.Replace(".", "");
            value = value.Replace("/", "");
            value = value.Replace("-", "");
    
            Value = value;
        }

        private string SetMask(string value)
        {
           return Convert.ToUInt64(Value).ToString(@"00\.000\.000\/0000\-00");
        }
    }
}
