using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Dominio.Features.Enderecos
{
    public class Endereco
    {
        public virtual int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }

        public virtual void Validar()
        {
            ValidarLougradouro();
            ValidarBairro();
            ValidarCidade();
            ValidarUF();
            ValidarComplemento();
            ValidarNumero();
        }

        private void ValidarNumero()
        {
            if (Numero < 1)
                throw new NumeroEnderecoInvalidoException();
        }

        private void ValidarComplemento()
        {
            if (string.IsNullOrEmpty(Complemento))
                throw new ComplementoVazioEnderecoException();
        }

        private void ValidarUF()
        {
            if (string.IsNullOrEmpty(UF))
                throw new UFVazioEnderecoException();
        }

        private void ValidarCidade()
        {
            if (string.IsNullOrEmpty(Cidade))
                throw new CidadeVazioEnderecoException();
        }

        private void ValidarBairro()
        {
            if (string.IsNullOrEmpty(Bairro))
                throw new BairroVazioEnderecoException();
        }

        private void ValidarLougradouro()
        {
            if (string.IsNullOrEmpty(Logradouro))
                throw new LougradouroVazioEnderecoException();
        }

    }
}
