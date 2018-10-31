using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.MF7.Dominio.Excecoes
{
	public class CredenciaisInvalidasException : ExcecaoDeNegocio
	{
		public CredenciaisInvalidasException() : base( CodigosDeErros.Unauthorized, "O usuário e/ou senha estão incorretos")
		{
		}
	}
}
