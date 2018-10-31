using Projeto_NFe.Application.Features.Conveyors;
using Projeto_NFe.Application.Features.Emitters;
using Projeto_NFe.Application.Features.Invoices;
using Projeto_NFe.Application.Features.Products;
using Projeto_NFe.Application.Features.Receivers;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Infra.Data.Features.Conveyors;
using Projeto_NFe.Infra.Data.Features.Emitters;
using Projeto_NFe.Infra.Data.Features.Invoices;
using Projeto_NFe.Infra.Data.Features.Products;
using Projeto_NFe.Infra.Data.Features.Receivers;
using Projeto_NFe.Infra.ORM.Context;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;

namespace Projeto_NFe.WebApi.IoC
{
    public static class SimpleInjectorContainer
    {
        public static Container ContainerInstance { get; private set; }
        public static void Initializer()
        {
            ContainerInstance = new Container();

            ContainerInstance.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            Registers();

            ContainerInstance.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            ContainerInstance.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(ContainerInstance);
        }
        public static void Registers()
        {
            ContainerInstance.Register<IProductService, ProductService>();
            ContainerInstance.Register<IReceiverService, ReceiverService>();
            ContainerInstance.Register<IEmitterService, EmitterService>();
            ContainerInstance.Register<IConveyorService, ConveyorService>();
            ContainerInstance.Register<IInvoiceInProcessService, InvoiceInProcessService>();

            ContainerInstance.Register<IProductRepository, ProductRepository>();
            ContainerInstance.Register<IReceiverRepository, ReceiverRepository>();
            ContainerInstance.Register<IEmitterRepository, EmitterRepository>();
            ContainerInstance.Register<IConveyorRepository, ConveyorsRepository>();
            ContainerInstance.Register<IInvoiceInProcessRepository, InvoiceInProcessRepository>();

            ContainerInstance.Register(() => new ProjetoNFeContext(), Lifestyle.Scoped);
        }
    }
}