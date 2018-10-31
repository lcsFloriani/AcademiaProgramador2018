using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.MF7.Dominio.Excecoes
{
	[ExcludeFromCodeCoverage]
	public class ExcecaoDeNegocio : Exception
	{
		public CodigosDeErros CodigoErro { get; }
		public ExcecaoDeNegocio(CodigosDeErros codigo, string message) : base( message )
		{
			CodigoErro = codigo;
		}
	}
}
