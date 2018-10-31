using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.CNPJs
{
    public class Cnpj
    {
        private readonly string PADRAO_INVALIDO = "00000000000000";
        private readonly int NUMERO_DIGITOS = 14;

        public string Valor { get; set; }
        public string ValorFormatado { get => SetarMascara(Valor); }

        public virtual void Validar()
        {
            RemoverMascara(Valor);

            if (string.IsNullOrEmpty(Valor))
                throw new CnpjValorNuloOuVazioExcecao();

            if (Valor.Length < NUMERO_DIGITOS)
                throw new CnpjValorMenorQueCatorzeExcecao();

            if (Valor.Length > NUMERO_DIGITOS)
                throw new CnpjValorOverFlowExcecao();

            if (PADRAO_INVALIDO.Equals(Valor))
                throw new CnpjValorIgualZeroExcecao();

            if (!Valido())
                throw new CnpjValorInvalidoExcecao();
        }

        private bool Valido()
        {
            int[] digitos, soma, resultado;
            int nrDig;
            string ftmt;
            bool[] CNPJOk;

            ftmt = "6543298765432";
            digitos = new int[NUMERO_DIGITOS];
            soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;
            resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;
            CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;

            try
            {
                for (nrDig = 0; nrDig < NUMERO_DIGITOS; nrDig++)
                {
                    digitos[nrDig] = int.Parse(
                     Valor.Substring(nrDig, 1));
                    if (nrDig <= 11)
                        soma[0] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1)));
                    if (nrDig <= 12)
                        soma[1] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig, 1)));
                }

                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);
                    if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == 0);

                    else
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));

                }

                return (CNPJOk[0] && CNPJOk[1]);
            }
            catch
            {
                return false;
            }
        }

        private void RemoverMascara(string valor)
        {
            valor = valor.Replace(".", "");
            valor = valor.Replace("/", "");
            valor = valor.Replace("-", "");
    
            Valor = valor;
        }

        private string SetarMascara(string valor)
        {
           return Convert.ToUInt64(Valor).ToString(@"00\.000\.000\/0000\-00");
        }
    }
}
