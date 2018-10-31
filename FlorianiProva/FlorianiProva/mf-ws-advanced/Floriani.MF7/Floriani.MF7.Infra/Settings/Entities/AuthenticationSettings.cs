using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Floriani.MF7.Infra.Settings.Entities
{
	public class AuthenticationSettings 
	{
		public int TokenExpiration { get; set; }
		public string AudienceId { get; set; }
		public string AudienceSecret { get; set; }
		public string Issuer { get; set; }
	}
}
