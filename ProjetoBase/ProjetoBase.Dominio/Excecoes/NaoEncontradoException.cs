using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase.Dominio.Excecoes
{
    public class NaoEncontradoException : ExcecaoDeNegocio
    {
        public NaoEncontradoException() : base(CodigoErros.NotFound, "Registro não encontrado")
        {
        }
    }
}
