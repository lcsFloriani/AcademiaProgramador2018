using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Floriani.MF7.API.Models.Gastos.ViewModel;
using Floriani.MF7.Aplicacao.Funcionalidades.Gastos.Comandos;
using Floriani.MF7.Dominio.Funcionalidades.Gastos;

namespace Floriani.MF7.API.Models.Gastos.MapeadorGastos
{
	public class MappingProfileGastos : Profile
	{
		public MappingProfileGastos()
		{
			CreateMap<ComandoRegistrarGasto, Gasto>();
			CreateMap<Gasto, GastoViewModel>();		
			CreateMap<ComandoDeletarGasto, Gasto>();
		}
	}
}