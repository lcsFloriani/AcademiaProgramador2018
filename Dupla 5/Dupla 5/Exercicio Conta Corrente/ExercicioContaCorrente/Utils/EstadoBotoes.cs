using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioContaCorrente
{
    public class EstadoBotoes
    {
        public bool Adicionar { get; internal set; }
        public bool Excluir { get; internal set; }
        public bool Atualizar { get; internal set; }
        public bool Sacar { get; internal set; }
        public bool Depositar { get; internal set; }
        public bool Transferir { get; internal set; }
        public bool Extrato { get; internal set; }
    }
}
