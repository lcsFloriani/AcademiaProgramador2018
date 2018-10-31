using GerenciadorProvas.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GerenciadorProvas.Dominio.Modal
{

    public class Serie: Entidade
    {
        public int Grau { get; set; }

        public override void Validacoes()
        {
            if (Grau == 0) {
                throw new ValidacoesExcepection("\n O campo grau é um campo obrigatório.");
            }

            if (Grau > 9)
            {
                throw new ValidacoesExcepection("\n O campo grau não pode ter um valor maior que 9.");
            }   
        }

        public override string ToString()
        {
            return string.Format("{0}ª Série", Grau);
        }


    }
}
