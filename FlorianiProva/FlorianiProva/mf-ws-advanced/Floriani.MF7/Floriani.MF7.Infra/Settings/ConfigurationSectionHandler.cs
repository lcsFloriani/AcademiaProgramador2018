using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Floriani.MF7.Infra.Settings
{
	public class ConfigurationSectionHandler : IConfigurationSectionHandler
	{
		private readonly string Namespace = "Floriani.MF7.Infra.Settings.Entities.{0}";

		public object Create(object parent, object configContext, XmlNode section)
		{
			MemoryStream stm = new MemoryStream();

			StreamWriter stw = new StreamWriter( stm );
			stw.Write( section.OuterXml );
			stw.Flush();

			stm.Position = 0;
			var type = System.Type.GetType( string.Format( Namespace, section.Name ) );

			XmlSerializer ser = new XmlSerializer( type );
			var result = ( ser.Deserialize( stm ) );

			return result;
		}
	}
}
