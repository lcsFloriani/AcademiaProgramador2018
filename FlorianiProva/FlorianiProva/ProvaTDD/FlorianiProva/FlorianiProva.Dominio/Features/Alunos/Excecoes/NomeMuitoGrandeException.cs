using FlorianiProva.Dominio.Exceções;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Dominio.Features.Alunos.Excecoes
{
    public class NomeMuitoGrandeException : ExcecaoDeNegocio
    {
        public NomeMuitoGrandeException() : base("Nome deve ser menor que 150 caracteres!")
        {
        }
    }
}
