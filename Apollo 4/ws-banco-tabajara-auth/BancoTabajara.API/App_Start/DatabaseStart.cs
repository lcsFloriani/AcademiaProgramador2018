using BancoTabajara.Infra.ORM.Contexto;
using BancoTabajara.Infra.ORM.Inicializar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoTabajara.API.App_Start
{
    public static class DatabaseStart
    {
        public static void Initialize()
        {
            InitializeDatabase();
        }

        private static void InitializeDatabase()
        {
            var contexto = new BancoTabajaraDbContexto();
            var init = new InicializadorDB(contexto);
            init.Configurar();
        }
    }
}