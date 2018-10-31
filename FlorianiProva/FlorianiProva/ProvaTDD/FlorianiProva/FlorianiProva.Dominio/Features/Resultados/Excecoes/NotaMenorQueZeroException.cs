using FlorianiProva.Dominio.Exceções;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Dominio.Features.Resultados.Excecoes
{
    public class NotaMenorQueZeroException : ExcecaoDeNegocio
    {
        public NotaMenorQueZeroException() : base("Nota não pode ser negativa")
        {
        }
    }
}
