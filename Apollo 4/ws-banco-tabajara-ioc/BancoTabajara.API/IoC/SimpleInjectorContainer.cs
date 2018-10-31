using BancoTabajara.Aplicacao.Funcionalidades.Clientes;
using BancoTabajara.Aplicacao.Funcionalidades.Contas;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using BancoTabajara.Dominio.Funcionalidades.Contas;
using BancoTabajara.Infra.ORM.Contexto;
using BancoTabajara.Infra.ORM.Funcionalidades.Clientes;
using BancoTabajara.Infra.ORM.Funcionalidades.Contas;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BancoTabajara.API.IoC
{
    public static class SimpleInjectorContainer
    {
        /// <summary>
        /// Método que inicializa a injeção de depêndencia
        /// </summary>
        public static void Initialize()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            RegisterServices(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();
            // Informa que para resolver as depedências nos construtores será usado o container criado
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }


        public static void RegisterServices(Container container)
        {
            // Contexto de banco de dados(Entity)
            //container.Register<BancoTabajaraDbContexto>(Lifestyle.Singleton);
            container.Register(() => new BancoTabajaraDbContexto(), Lifestyle.Singleton);

            //Registrando as Implementações
            container.Register<IClienteServico, ClienteServico>();
            container.Register<IClienteRepositorio, ClienteRepositorio>();

            container.Register<IContaServico, ContaServico>();
            container.Register<IContaRepositorio, ContaRepositorio>();
        }
    }
}
