using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExercicioContaCorrente.Domain
{
    public class Cliente
    {
        public int id;
        public string cpf;
        public string nome;
        public string telefone;
        public string email;

        public void Valida()
        {
            if (cpf.Length != 11)
                throw new Exception("CPF inválido");
            if (nome.Length < 4)
                throw new Exception("O campo nome deve conter mais de 3 caracteres.");
            if (telefone.Length < 8)
                throw new Exception("O campo Telefone deve conter no mínimo 8 caracteres.");

            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (!rg.IsMatch(email))
                throw new Exception("Email inválido");
        }

        public override string ToString()
        {
            return string.Format("Nome: {0} - CPF: {1} - Telefone: {2} - EMail: {3}", nome, cpf, telefone, email);
        }
    }
}
