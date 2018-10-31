using AutoMapper;

namespace Floriani.MF7.API.Models.Mapeador
{
	public class InicializadorAutoMapper
	{
		public static void Inicializador()
		{
			Mapper.Initialize( config =>
			{
				config.AddProfiles( typeof( InicializadorAutoMapper ) );
			} );
		}

		public static void Reset() => Mapper.Reset();
	}
}
