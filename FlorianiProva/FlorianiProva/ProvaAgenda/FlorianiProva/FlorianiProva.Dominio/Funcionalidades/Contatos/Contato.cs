using FlorianiProva.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Dominio.Funcionalidades.Contatos
{
    public class Contato : Entidade
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Departamento { get; set; }
        public string Endereco{ get; set; }
        public string Telefone { get; set; }

        public override void Valida()
        {
            if (string.IsNullOrEmpty(Nome) || Nome.Trim() == "")
                throw new Exception("O Nome não pode ser em branco");

            if (Nome.Length < 3)
                throw new Exception("O Nome deve ter mais que 3 caracteres");

            if (Nome.Length > 100)
                throw new Exception("O Nome deve ser menor que 100 caracteres");

            if (string.IsNullOrEmpty(Email) || Email.Trim() == "")
                throw new Exception("O Email não pode ser em branco");

            if (Email.Length < 3)
                throw new Exception("O Email deve ter mais que 3 caracteres");

            if (Email.Length > 100)
                throw new Exception("O Email deve ser menor que 50 caracteres");

            if (string.IsNullOrEmpty(Departamento) || Departamento.Trim() == "")
                throw new Exception("O Departamento não pode ser em branco");

            if (Departamento.Length < 3)
                throw new Exception("O Departamento deve ter mais que 3 caracteres");

            if (Departamento.Length > 100)
                throw new Exception("O Departamento deve ser menor que 100 caracteres");

            if (string.IsNullOrEmpty(Endereco) || Endereco.Trim() == "")
                throw new Exception("O Endereço não pode ser em branco");

            if (Endereco.Length < 3)
                throw new Exception("O Endereco deve ter mais que 3 caracteres");

            if (Endereco.Length > 100)
                throw new Exception("O Endereco deve ser menor que 200 caracteres");

            if (string.IsNullOrEmpty(Telefone) || Telefone.Trim() == "")
                throw new Exception("O Telefone não pode ser em branco");

            if (Telefone.Length < 3)
                throw new Exception("O Telefone deve ter mais que 3 caracteres");

            if (Telefone.Length > 100)
                throw new Exception("O Telefone deve ser menor que 50 caracteres");
            if (!ValidarTelefoneNumeros())
                throw new Exception("O Telefone deve conter apenas números");
        }

        private bool ValidarTelefoneNumeros()
        {
            string numeros = "0123456789";
            for (int i = 0; i < Telefone.Length; i++)
            {
                if (numeros.Contains(Telefone[i]))
                    continue;
                else
                    return false;
            }

            return true;

        }
        public override string ToString()
        {
            return String.Format("{0} - Departamento: {1}", Nome, Departamento);
        }
    }
}
