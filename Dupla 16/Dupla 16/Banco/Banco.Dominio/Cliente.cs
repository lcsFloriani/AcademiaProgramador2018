using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Dominio
{
    public class Cliente
    {
        private string _nome;
        private string _email;
        public string Nome { get => _nome; set => _nome = value; }
        public string Email { get => _email; set => _email = value; }

        public void Validar() {
            if (Nome == "" || Nome == null)
                throw new Exception("Nome em branco ou invalido!");
            if (Email == "" || Email == null)
                throw new Exception("Email invalido!");
        }
        public override string ToString()
        {
            return String.Format("Nome: " + Nome + " / " + " Email: " + Email);
        }
    }
}
