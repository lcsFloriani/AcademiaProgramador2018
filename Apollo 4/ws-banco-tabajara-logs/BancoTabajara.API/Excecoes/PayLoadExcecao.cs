using BancoTabajara.Dominio.Excecoes;
using Newtonsoft.Json;
using System;

namespace BancoTabajara.API.Excecoes
{
    public class PayLoadExcecao
    {
        public int CodigoErro { get; set; }

        public string MensagemErro { get; set; }

        [JsonIgnore]
        public Exception Excecao { get; set; }

        public static PayLoadExcecao New<T>(T exception) where T : Exception
        {
            int errorCode;
            if (exception is NegocioExcecao)
                errorCode = (exception as NegocioExcecao).CodigoErro.GetHashCode();
            else
                errorCode = Dominio.Excecoes.CodigoErro.Unhandled.GetHashCode();
            return new PayLoadExcecao
            {
                CodigoErro = errorCode,
                MensagemErro = exception.Message,
            };
        }
    }
}