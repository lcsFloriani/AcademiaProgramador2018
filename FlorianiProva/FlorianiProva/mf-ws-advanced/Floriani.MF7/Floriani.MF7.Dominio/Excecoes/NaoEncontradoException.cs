namespace Floriani.MF7.Dominio.Excecoes
{
	public class NaoEncontradoException : ExcecaoDeNegocio
	{
		public NaoEncontradoException() : base(CodigosDeErros.NotFound, "Registro Não Encontrado")
		{
		}
	}
}
