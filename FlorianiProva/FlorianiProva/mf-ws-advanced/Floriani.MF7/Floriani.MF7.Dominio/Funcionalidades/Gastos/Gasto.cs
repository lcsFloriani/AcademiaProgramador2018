using System;
using Floriani.MF7.Dominio.Base;
using Floriani.MF7.Dominio.Funcionalidades.Funcionarios;

namespace Floriani.MF7.Dominio.Funcionalidades.Gastos
{
	public class Gasto : Entidade
	{
		public string Descricao { get; set; }
		public DateTime Data { get; set; }
		public double Preco { get; set; }
		public TipoEnum Tipo { get; set; }
		public virtual Funcionario Funcionario { get; set; }
	}
}
