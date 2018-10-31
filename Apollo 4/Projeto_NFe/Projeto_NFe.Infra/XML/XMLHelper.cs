using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML
{
    public class XMLHelper<E>
    {
        private XmlSerializer serializer;

        public XMLHelper()
        {
            serializer = new XmlSerializer(typeof(E));
        }

        public string Serialize(E entity)
        {
            string xml;
            using (StringWriter wr = new StringWriter())
            {
                serializer.Serialize(wr, entity);
                xml = wr.ToString();
            }

            return xml;
        }

        public E Deserialize(string xml)
        {
            var stringReader = new StringReader(xml);
            return (E)serializer.Deserialize(stringReader);
        }
    }
}
