using System.Web.Http;
using NDDResearch.Application.Features.Customers;
using NDDResearch.Domain.Features.Customers;
using NDDResearch.Domain.Features.Sites;
using NDDResearch.Application.Features.Sites;
using NDDResearch.Domain.Features.Sites.Service;
using NDDResearch.Infra.Data.Features.Customers;
using NDDResearch.Infra.Data.Features.Sites;
using NDDResearch.Infra.Data.Contexts;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace NDDResearch.API.IoC
{
    /// <summary>
    /// Classe responsável por realizar as configurações de injeção de depêndencia.
    /// </summary>
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


        /// <summary>
        /// Registra todos os serviços que podem ser injetados nos construtores
        /// </summary>
        /// <param name="container">É o contexto de injeção que deve conter as classes que podem ser injetadas</param>
        public static void RegisterServices(Container container)
        {
            container.Register<ISiteRepository, SiteRepository>();
            container.Register<ISitesService, SitesService>();
            container.Register<ISiteDomainService, SiteDomainService>();

            container.Register<ICustomersService, CustomersService>();
            container.Register<ICustomerRepository, CustomerRepository>();

            // TODO: Por enquanto estaremos criando o contexto do EF por aqui. Precisaremos trocar por uma Factory
            container.Register<NDDResearchDbContext>(() => new NDDResearchDbContext(), Lifestyle.Scoped);
        }
    }
}