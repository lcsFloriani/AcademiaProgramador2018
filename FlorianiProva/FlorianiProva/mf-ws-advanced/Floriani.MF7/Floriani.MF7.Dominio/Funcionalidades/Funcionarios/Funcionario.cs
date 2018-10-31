using Floriani.MF7.Dominio.Base;

namespace Floriani.MF7.Dominio.Funcionalidades.Funcionarios
{
	public class Funcionario : Entidade
	{
		public string PrimeiroNome { get; set; }
		public string Sobrenome { get; set; }
		public string Usuario { get; set; }
		public string Senha { get; set; }
		public CargoEnum Cargo { get; set; }
		public bool Status { get; private set; }

		public void AtualizarStatus()
		{
			if (Status)
				Status = false;
			else
				Status = true;
		}
	}
}
