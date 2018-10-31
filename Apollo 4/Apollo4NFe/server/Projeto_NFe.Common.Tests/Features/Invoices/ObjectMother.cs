using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Domain.Features.Taxes;
using Projeto_NFe.Infra.AccessKeys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Base
{
    public partial class ObjectMother
    {
        public static InvoiceIssued GetInvoiceIssued(Conveyor conveyor, Emitter emitter, Receiver receiver, List<ItemInvoice> itens)
        {
            return new InvoiceIssued
            {
                Conveyor = conveyor,
                Emitter = emitter,
                Receiver = receiver,
                EntryDate = DateTime.Now.AddDays(-1),
                Items = itens,
                NatureOperation = "Teste",
                ValueFreight = 10.5
            };
        }

        public static InvoiceInProcess GetInvoiceInProcess(Conveyor conveyor, Emitter emitter, Receiver receiver, List<ItemInvoice> itens)
        {
            return new InvoiceInProcess
            {
                Conveyor = conveyor,
                Emitter = emitter,
                Receiver = receiver,
                EntryDate = DateTime.Now.AddDays(-1),
                Items = itens,
                NatureOperation = "Teste",
                ValueFreight = 10.5
            };
        }

        public static InvoiceInProcess GetInvoiceInProcessWithOutConveyor(Emitter conveyor, Receiver receiver, List<ItemInvoice> itens)
        {
            return new InvoiceInProcess
            {
                Emitter = conveyor,
                Receiver = receiver,
                EntryDate = DateTime.Now.AddDays(-1),
                Items = itens,
                NatureOperation = "Teste",
                ValueFreight = 10
            };
        }

        public static InvoiceInProcess GetInvoiceInProcessWithOutNatureOperation()
        {
            return new InvoiceInProcess
            {
                EntryDate = DateTime.Now.AddDays(-1),
                ValueFreight = 10

            };
        }

        public static InvoiceInProcess GetInvoiceInProcessWithValueFreightInvalid()
        {
            return new InvoiceInProcess
            {
                NatureOperation = "Teste",
                EntryDate = DateTime.Now.AddDays(-1),
                ValueFreight = -1

            };
        }

        public static InvoiceInProcess GetInvoiceInProcessWithNullEmitter(Conveyor conveyor, Receiver receiver, List<ItemInvoice> itens)
        {
            return new InvoiceInProcess
            {
                Conveyor = conveyor,
                Receiver = receiver,
                EntryDate = DateTime.Now.AddDays(-1),
                Items = itens,
                NatureOperation = "Teste",
                ValueFreight = 10
            };
        }

        public static InvoiceInProcess GetInvoiceInProcessWithNullReceiver(Conveyor conveyor, Emitter emitter, List<ItemInvoice> itens)
        {
            return new InvoiceInProcess
            {
                Conveyor = conveyor,
                Emitter = emitter,
                EntryDate = DateTime.Now.AddDays(-1),
                Items = itens,
                NatureOperation = "Teste",
                ValueFreight = 10
            };
        }

        public static InvoiceInProcess GetInvoiceInProcessWithNullItems(Conveyor conveyor, Emitter emitter, Receiver receiver)
        {
            return new InvoiceInProcess
            {
                Conveyor = conveyor,
                Emitter = emitter,
                Receiver = receiver,
                EntryDate = DateTime.Now.AddDays(-1),
                NatureOperation = "Teste",
                ValueFreight = 10
            };
        }

        public static InvoiceIssued GetInvoiceIssuedWithInvalidId()
        {
            return new InvoiceIssued
            {
                Id = 0
            };
        }

        public static InvoiceIssued GetInvoiceIssuedWithoutTax(Conveyor conveyor, Emitter emitter, Receiver receiver, List<ItemInvoice> itens, AccessKey key)
        {
            return new InvoiceIssued
            {
                Conveyor = conveyor,
                Emitter = emitter,
                Receiver = receiver,
                EntryDate = DateTime.Now.AddDays(-1),
                NatureOperation = "Teste",
                IssuanceDate = DateTime.Now,
                //Key = key,
                Items = itens
            };
        }

        public static InvoiceIssued GetInvoiceIssuedWithoutAccessKey(Conveyor conveyor, Emitter emitter, Receiver receiver, List<ItemInvoice> itens, Tax tax)
        {
            return new InvoiceIssued
            {
                Conveyor = conveyor,
                Emitter = emitter,
                Receiver = receiver,
                EntryDate = DateTime.Now.AddDays(-1),
                NatureOperation = "Teste",
                IssuanceDate = DateTime.Now,
                //Tax = tax,
                Items = itens
            };
        }

        public static InvoiceIssued GetInvoiceIssuedWithInvalidIssuanceDate(Conveyor conveyor, Emitter emitter, Receiver receiver, List<ItemInvoice> itens, Tax tax, AccessKey key)
        {
            return new InvoiceIssued
            {
                Conveyor = conveyor,
                Emitter = emitter,
                Receiver = receiver,
                EntryDate = DateTime.Now,
                NatureOperation = "Teste",
                IssuanceDate = DateTime.Now.AddDays(-1),
                //Tax = tax,
                //Key = key,
                Items = itens
            };
        }
    }
}
