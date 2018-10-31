namespace Projeto_NFe.Infra.ORM.Migrations
{
    using Projeto_NFe.Domain.Enums;
    using Projeto_NFe.Domain.Features.Addresses;
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
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Projeto_NFe.Infra.ORM.Context.ProjetoNFeContext>
    {
        private Product firstProduct;
        private Product secondProduct;
        private Conveyor conveyorLegal;
        private Conveyor conveyorPhysical;
        private Receiver receiverLegal;
        private Receiver receiverPhysical;
        private Emitter firstEmitter;
        private Emitter secondEmitter;
        private InvoiceInProcess invoice;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        public void CallSeed(ProjetoNFeContext context)
        {
            Seed(context);
        }

        protected override void Seed(ProjetoNFeContext context)
        {
            GetProduct(context);
            GetConveyor(context);
            GetEmitter(context);
            GetReceiver(context);
            GetInvoice(context);

            context.SaveChanges();
        }

        private void GetProduct(ProjetoNFeContext context)
        {
            firstProduct = new Product
            {
                Code = "0001",
                Description = "Tenis",
                UnitaryValue = 12.32
            };

            secondProduct = new Product
            {
                Code = "0002",
                Description = "Sapato",
                UnitaryValue = 22.32
            };

            context.Products.Add(firstProduct);
            context.Products.Add(secondProduct);
        }

        private void GetConveyor(ProjetoNFeContext context)
        {
            conveyorLegal = new Conveyor
            {
                NameCompanyName = "NDD",
                PersonType = PersonType.LEGAL,
                CpfCnpj = "20396756000109",
                Address = new Address()
                {
                    Street = "ABC",
                    Number = 12,
                    Neighbourhood = "Coral",
                    City = "Lages",
                    State = State.SC
                },
                FreightResponsibility = FreightResponsibility.RECEIVER
            };

            conveyorPhysical = new Conveyor
            {
                NameCompanyName = "José da Silva",
                Address = new Address()
                {
                    Street = "DEF",
                    Number = 15,
                    Neighbourhood = "Popular",
                    City = "Lages",
                    State = State.SC
                },
                PersonType = PersonType.PHYSICAL,
                FreightResponsibility = FreightResponsibility.EMITTER,
                CpfCnpj = "94570617999",
            };

            context.Conveyors.Add(conveyorLegal);
            context.Conveyors.Add(conveyorPhysical);
        }

        private void GetEmitter(ProjetoNFeContext context)
        {
            firstEmitter = new Emitter()
            {
                FantasyName = "asd",
                CompanyName = "Jequiti",
                MunicipalRegistration = "2039102",
                StateRegistration = "3123123",
                Address = new Address()
                {
                    Street = "GHI",
                    Number = 19,
                    Neighbourhood = "Penha",
                    City = "Lages",
                    State = State.SC
                },
                Cnpj = "74252150000129"
            };

            secondEmitter = new Emitter()
            {
                FantasyName = "asd - 2",
                CompanyName = "Jequiti - 2",
                MunicipalRegistration = "2039102",
                StateRegistration = "3123123",
                Address = new Address()
                {
                    Street = "GHI",
                    Number = 19,
                    Neighbourhood = "Penha",
                    City = "Lages",
                    State = State.SC
                },
                Cnpj = "74252150000129"
            };

            context.Emitters.Add(firstEmitter);
            context.Emitters.Add(secondEmitter);
        }

        private void GetReceiver(ProjetoNFeContext context)
        {
            receiverLegal = new Receiver()
            {
                NameCompanyName = "Test",
                StateRegistration = "Test",
                Address = new Address()
                {
                    Street = "JKM",
                    Number = 25,
                    Neighbourhood = "Varzia",
                    City = "Lages",
                    State = State.SC
                },
                CpfCnpj = "73029790000101",
                Type = PersonType.LEGAL
            };

            receiverPhysical = new Receiver()
            {
                NameCompanyName = "Test",
                StateRegistration = "Test",
                Address = new Address()
                {
                    Street = "NOP",
                    Number = 320,
                    Neighbourhood = "Centro",
                    City = "Lages",
                    State = State.SC
                },
                CpfCnpj = "58026616073",
                Type = PersonType.PHYSICAL
            };

            context.Receivers.Add(receiverLegal);
            context.Receivers.Add(receiverPhysical);
        }

        private void GetInvoice(ProjetoNFeContext context)
        {

            invoice = new InvoiceInProcess
            {
                Conveyor = this.conveyorLegal,
                Emitter = this.firstEmitter,
                Receiver = this.receiverPhysical,
                EntryDate = DateTime.Now.AddDays(-1),
                NatureOperation = "Teste",
                ValueFreight = 10
            };

            ItemInvoice item = new ItemInvoice { Product = firstProduct, Quantity = 2, InvoiceInProcess = invoice };

            List<ItemInvoice> itens = new List<ItemInvoice>();
            itens.Add(item);
            invoice.Items = itens;

            context.InvoicesInProcess.Add(invoice);
        }
    }
}
