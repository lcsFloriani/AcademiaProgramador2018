using GerenciadorProvas.Dominio.Modal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GerenciadorProvas.infra.XML
{
    public class XMLUtil<T> where T : Entidade
    {

        private StreamWriter _escrita;


        public void Exportar(T entidade, string caminho)
        {
            using (_escrita = new StreamWriter(caminho))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextWriter escrita = _escrita;
                serializer.Serialize(escrita, entidade);
                escrita.Close();
            }
        }


        public void Exportar(List<T> entidades, string caminho)
        {
            //using (_escrita = new StreamWriter(caminho))
            //{
            //    XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            //    TextWriter escrita = _escrita;
            //    serializer.Serialize(escrita, entidades);
            //    escrita.Close();
            //}
        }
    }
}
