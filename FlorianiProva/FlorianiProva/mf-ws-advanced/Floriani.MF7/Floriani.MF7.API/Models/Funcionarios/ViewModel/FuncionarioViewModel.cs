using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Floriani.MF7.Dominio.Funcionalidades.Funcionarios;

namespace Floriani.MF7.API.Models.Funcionarios.ViewModel
{
	public class FuncionarioViewModel
	{
		public string PrimeiroNome { get; set; }
		public string Sobrenome { get; set; }
		public string Usuario { get; set; }
		public string Senha { get; set; }
		public CargoEnum Cargo { get; set; }
		public bool Status { get; set; }
	}
}