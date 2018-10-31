using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Aplicacao.Funcionalidades.Clientes.Querys
{
    public class ClienteQuery
    {
        public int Quantidade { get; set; }

        public ClienteQuery(int quantidade)
        {
            Quantidade = quantidade;
        }
    }
}
