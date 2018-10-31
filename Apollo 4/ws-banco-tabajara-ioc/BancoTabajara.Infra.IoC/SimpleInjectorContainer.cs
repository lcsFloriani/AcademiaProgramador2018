using BancoTabajara.Aplicacao.Funcionalidades.Clientes;
using BancoTabajara.Aplicacao.Funcionalidades.Contas;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using BancoTabajara.Dominio.Funcionalidades.Contas;
using BancoTabajara.Infra.ORM.Contexto;
using BancoTabajara.Infra.ORM.Funcionalidades.Clientes;
using BancoTabajara.Infra.ORM.Funcionalidades.Contas;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Infra.IoC
{
    public static class SimpleInjectorContainer
    {
        public static Container RegisterServices()
        {
            var container = new Container();

            // DbContext
            //container.Register<BancoTabajaraDbContexto>(Lifestyle.Singleton);

            container.Register(() => new BancoTabajaraDbContexto(), Lifestyle.Singleton);

            //Registrando as Implementações
            container.Register<IClienteServico, ClienteServico>();
            container.Register<IClienteRepositorio, ClienteRepositorio>();

            container.Register<IContaServico, ContaServico>();
            container.Register<IContaRepositorio, ContaRepositorio>();

            container.Verify();

            return container;
        }
    }
}
