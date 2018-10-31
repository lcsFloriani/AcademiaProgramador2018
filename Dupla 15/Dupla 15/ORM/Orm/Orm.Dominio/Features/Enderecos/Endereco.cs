using Orm.Dominio.Base;
using System;

namespace Orm.Dominio.Features.Enderecos
{
    public class Endereco : Entidade
    {
        public string Logradouro { get; set; }

        public string Bairro { get; set; }

        public string Cidade{ get; set; }

        public string UF { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public override void Validar()
        {
            if (String.IsNullOrEmpty(Logradouro))
                throw new EnderecoLogradouroEmBrancoException();
            if (String.IsNullOrEmpty(Bairro))
                throw new EnderecoBairroEmBrancoException();
            if (String.IsNullOrEmpty(Cidade))
                throw new EnderecoCidadeEmBrancoException();
            if (String.IsNullOrEmpty(UF))
                throw new EnderecoUFEmBrancoException();
            if (string.IsNullOrEmpty(Numero))
                Numero = "S/N";
            if (string.IsNullOrEmpty(Complemento))
                throw new EnderecoComplementoVazioException();
        }
    }
}
