using GerenciadorProvas.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.Infra.SQL
{
    public static class FabricaConexoes
    {
        public static DbConnection CriarConexao(TipoBancoDados tipo)
        {
            ConnectionStringSettings config = PegarStringDaConexao(tipo);

            DbProviderFactory factory = DbProviderFactories.GetFactory(config.ProviderName);

            return factory.CreateConnection();
        }

        public static ConnectionStringSettings PegarStringDaConexao(TipoBancoDados tipo)
        {
            string nome= SQLUtil.PegarNomeDoBanco(tipo);
            foreach (ConnectionStringSettings css in ConfigurationManager.ConnectionStrings)
            {
                if (css.Name.Equals(nome))
                    return css;
            }

            return null;
        }

    }
}
