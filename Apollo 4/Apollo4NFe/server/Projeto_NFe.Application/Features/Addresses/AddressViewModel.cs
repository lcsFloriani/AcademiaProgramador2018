using Projeto_NFe.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Addresses
{
	public class AddressViewModel
	{
		public string Street { get; set; }
		public int Number { get; set; }
		public string Neighbourhood { get; set; }
		public string City { get; set; }
		public State State { get; set; }
	}
}
