using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.CPFs
{
    public class Cpf
    {
        private readonly string PADRAO_INVALIDO = "00000000000";
        private readonly int NUMERO_DIGITOS = 11;

        public string Valor { get; set; }
        public string ValorFormatado { get => SetarMascara(Valor); }

        public virtual void Validar()
        {
            RemoverMascara(Valor);

            if (string.IsNullOrEmpty(Valor))
                throw new CpfValorNuloOuVazioExcecao();

            if (Valor.Length < NUMERO_DIGITOS)
                throw new CpfValorMenorQueOnzeExcecao();

            if (Valor.Length > NUMERO_DIGITOS)
                throw new CpfValorOverFlowExcecao();

            if (PADRAO_INVALIDO.Equals(Valor))
                throw new CpfValorIgualZeroExcecao();

            long x = 0;
            if (!long.TryParse(Valor, out x))
                throw new CpfValorIncorretoExcecao();

            if (!Valido())
                throw new CpfInvalidValueException();


        }

        private bool Valido() //EValido?
        {
            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (Valor[i] != Valor[0])
                    igual = false;

            if (igual || Valor == "12345678909")
                return false;

            int[] numeros = new int[11];
            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(
                Valor[i].ToString());

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

        private void RemoverMascara(string valor)
        {
            valor = valor.Replace(".", "");
            valor = valor.Replace("-", "");

            Valor = valor;
        }

        private string SetarMascara(string valor)
        {
            return Convert.ToUInt64(valor).ToString(@"000\.000\.000\-00");
        }
    }
}
