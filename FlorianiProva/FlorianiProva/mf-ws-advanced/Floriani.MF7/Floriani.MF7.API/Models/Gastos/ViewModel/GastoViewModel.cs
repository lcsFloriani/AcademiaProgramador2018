using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Floriani.MF7.Dominio.Funcionalidades.Funcionarios;
using Floriani.MF7.Dominio.Funcionalidades.Gastos;

namespace Floriani.MF7.API.Models.Gastos.ViewModel
{
	public class GastoViewModel
	{
		public string Descricao { get; set; }
		public DateTime Data { get; set; }
		public double Preco { get; set; }
		public TipoEnum Tipo { get; set; }
		public Funcionario Funcionario { get; set; }
	}
}