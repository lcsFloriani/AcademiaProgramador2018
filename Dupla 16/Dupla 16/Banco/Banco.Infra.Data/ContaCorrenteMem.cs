using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Dominio;

namespace Banco.Infra.Data
{
    public class ContaCorrenteMem
    {
        private List<ContaCorrente> contas = new List<ContaCorrente>();
           

        public void AdicionarConta(ContaCorrente novaConta) {
            if(novaConta != null)
                contas.Add(novaConta);
        }

        public List<ContaCorrente> TrazerContas() {
            return contas;
        }
        public void ExcluirConta(ContaCorrente conta) {
            contas.Remove(conta);
        }
    }
}
