using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Infra.ORM.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Base
{
    [ExcludeFromCodeCoverage]
    public class BaseIntegrationTest<T>: DropCreateDatabaseAlways<T> where T: ProjetoNFeContext
    {
        protected override void Seed(T context)
        {
            List<ItemInvoice> itens = new List<ItemInvoice>();
            Product product = ObjectMother.GetProduct();
            context.Products.Add(product);
            Conveyor conveyorLegal = ObjectMother.GetLegalConveyor(ObjectMother.GetAddress());
            Conveyor conveyorPhysical = ObjectMother.GetPhysicalConveyor(ObjectMother.GetAddress());
            context.Conveyors.Add(conveyorLegal);
            context.Conveyors.Add(conveyorPhysical);
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress());
            context.Emitters.Add(emitter);
            Receiver receiverLegal = ObjectMother.GetReceiverLegal(ObjectMother.GetAddress());
            Receiver receiverPhysical = ObjectMother.GetReceiverPhysical(ObjectMother.GetAddress());
            context.Receivers.Add(receiverLegal);
            context.Receivers.Add(receiverPhysical);
            //InvoiceIssued invoice = ObjectMother.GetInvoiceIssued(conveyorLegal, emitter, receiverLegal, itens);
            //context.InvoicesIssued.Add(invoice);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
