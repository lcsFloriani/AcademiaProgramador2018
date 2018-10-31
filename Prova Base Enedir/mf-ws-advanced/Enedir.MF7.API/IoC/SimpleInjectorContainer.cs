using Enedir.MF7.Application.Features.Functionaries;
using Enedir.MF7.Application.Features.Outgoing;
using Enedir.MF7.Domain.Features.Functionaries;
using Enedir.MF7.Domain.Features.Outgoing;
using Enedir.MF7.Infra.ORM.Context;
using Enedir.MF7.Infra.ORM.Features.Functionaries;
using Enedir.MF7.Infra.ORM.Features.Outgoing;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

using System.Web.Http;

namespace Enedir.MF7.API.IoC
{
    public static class SimpleInjectorContainer
    {
        public static Container ContainerInstance { get; set; }
        public static MF7DbContext ContextInstance { get; set; }

        /// <summary>
        /// Método que inicializa a injeção de dependência
        /// </summary>
        public static void Initialize()
        {
            ContainerInstance = new Container();
            ContextInstance = new MF7DbContext();

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
            ContainerInstance.Register(() => ContextInstance, Lifestyle.Singleton);

            //Registrando as Implementações
            ContainerInstance.Register<IFunctionaryService, FunctionaryService>();
            ContainerInstance.Register<IFunctionaryRepository, FunctionaryRepository>();

            ContainerInstance.Register<IOutgoService, OutgoService>();
            ContainerInstance.Register<IOutgoRepository, OutgoRepository>();
        }
    }
}