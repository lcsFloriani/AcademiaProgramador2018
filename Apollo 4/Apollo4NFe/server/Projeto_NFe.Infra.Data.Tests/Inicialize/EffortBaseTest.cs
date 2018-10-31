using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Effort;
using Effort.Provider;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Infra.ORM.Context;
using Projeto_NFe.Infra.ORM.Tests.Context;

namespace Projeto_NFe.Infra.ORM.Tests.Inicialize
{
	public class EffortBaseTest
	{
		protected DBContextFake context;
        private Emitter emitter1;
        private Emitter emitter2;
        private Product product1;
        private Product product2;
        private Conveyor conveyorPhysical;
        private Conveyor conveyorLegal;
        private Receiver receiverPhysical;
        private Receiver receiverLegal;

        [OneTimeSetUp]
		public void InitializeOnce()
		{
			EffortProviderConfiguration.RegisterProvider();
		}

		[SetUp]
		public void Seed()
		{
			EffortConnections.ResetarDb();

			var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
			context = new DBContextFake( connection );

            GetConveyors();
            GetEmitter();
            GetProducts();
            GetReceivers();
            GetInvoiceInProcess();

            context.SaveChanges();
		}
       
        private void GetConveyors()
        {
            conveyorPhysical = ObjectMother.GetPhysicalConveyor(ObjectMother.GetAddress());
            conveyorLegal = ObjectMother.GetLegalConveyor(ObjectMother.GetAddress());

            context.Conveyors.Add(conveyorPhysical);
            context.Conveyors.Add(conveyorLegal);
        }

        private void GetEmitter()
        {
            emitter1 = ObjectMother.GetEmitter(ObjectMother.GetAddress());
            emitter2 = ObjectMother.GetEmitter(ObjectMother.GetAddress());

            context.Emitters.Add(emitter1);
            context.Emitters.Add(emitter2);
        }

        private void GetProducts()
        {
            product1 = ObjectMother.GetProduct();
            product2 = ObjectMother.GetProduct();

            context.Products.Add(product1);
            context.Products.Add(product2);
        }

        private void GetReceivers()
        {
            receiverPhysical = ObjectMother.GetReceiverPhysical(ObjectMother.GetAddress());
            receiverLegal = ObjectMother.GetReceiverLegal(ObjectMother.GetAddress());

            context.Receivers.Add(receiverPhysical);
            context.Receivers.Add(receiverLegal);
            context.Receivers.Add(receiverLegal);
        }
        private void GetInvoiceInProcess()
        {
            InvoiceInProcess Invoice = ObjectMother.GetInvoiceInProcess(conveyorLegal, emitter2, receiverLegal, new List<ItemInvoice>());
            ItemInvoice item = new ItemInvoice { Product = product1, Quantity = 2, InvoiceInProcess = Invoice };
            Invoice.Items.Add(item);

            context.InvoicesInProcess.Add(Invoice);
        }
    }
}
