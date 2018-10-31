using GerenciadorProvas.Infra.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.Infra.Data.Singleton
{
    public class ConfigurationSingleton
    {
        private static ConfigurationSingleton instance;
        public DatabaseType Type { get; set; }

        private ConfigurationSingleton() { }

        public static ConfigurationSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConfigurationSingleton();
                }
                return instance;
            }
        }
    }
}
