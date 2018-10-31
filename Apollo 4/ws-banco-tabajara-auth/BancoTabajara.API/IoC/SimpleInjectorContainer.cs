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
        public static Container ContainerInstance { get; set; }

        /// <summary>
        /// Método que inicializa a injeção de dependência
        /// </summary>
        public static void Initialize()
        {
            ContainerInstance = new Container();

            ContainerInstance.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            RegisterServices(ContainerInstance);

            ContainerInstance.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            ContainerInstance.Verify();
            // Informa que para resolver as dependências nos construtores será usado o ContainerInstance criado
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(ContainerInstance);
        }


        public static void RegisterServices(Container ContainerInstance)
        {
            // Contexto de banco de dados(Entity)
            //ContainerInstance.Register<BancoTabajaraDbContexto>(Lifestyle.Singleton);
            ContainerInstance.Register(() => new BancoTabajaraDbContexto(), Lifestyle.Singleton);

            //Registrando as Implementações
            ContainerInstance.Register<IClienteServico, ClienteServico>();
            ContainerInstance.Register<IClienteRepositorio, ClienteRepositorio>();

            ContainerInstance.Register<IContaServico, ContaServico>();
            ContainerInstance.Register<IContaRepositorio, ContaRepositorio>();
        }
    }
}
