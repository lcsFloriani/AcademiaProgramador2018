using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Application.Features.Addresses;
using Projeto_NFe.Domain.Features.Addresses;

namespace Projeto_NFe.Application.Features.Receivers.ViewModels
{
	public class ReceiverViewModel
	{
		public long Id { get; set; }
		public int Type { get; set; }
		public string NameCompanyName { get; set; }
		public string CpfCnpj { get; set; }
		public string StateRegistration { get; set; }
		public AddressViewModel Address { get; set; }
	}
}
