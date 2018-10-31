using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.WindowsApp.Features.Compartilhado
{
    public class EstadoBotoes
    {
        public bool Cadastrar { get; set; }
        public bool Excluir { get; set; }
        public bool Saque { get; set; }
        public bool Deposito { get; set; }
        public bool Transferencia { get; set; }
        public bool Extrato { get; set; }
    }
}
