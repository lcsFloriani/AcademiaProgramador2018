using ORM01.Dominio.Features.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Comum.Testes.Features
{
    public static partial class ObjectMother
    {
        public static Endereco endereco
        {
            get
            {
                return new Endereco
                {
                    Id = 1,
                    Logradouro = "oitava",
                    Bairro = "Pedra-Papel-E-Tesoura",
                    Cidade = "Namekuzem",
                    UF = "HL",
                    Numero = 123,
                    Complemento = "Po"
                };
            }
        }
        public static List<Endereco> ListEndereco
        {
            get
            {
                List<Endereco> list = new List<Endereco>();
                list.Add(endereco);
                list.Add(endereco);
                list.Add(endereco);

                return list;
            }
        }
    }
}
