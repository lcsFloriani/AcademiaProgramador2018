using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Data;

namespace Projeto_NFe.Infra.Data.Features.ItemInvoices
{
    public class ItemInvoiceSQLRepository : IItemInvoiceRepository
    {
        private readonly string SQL_INSERT = "INSERT INTO TBItemInvoice(InvoiceId, ProductId, Quantity) VALUES (@InvoiceId, @ProductId, @Quantity)";
        private readonly string SQL_UPDATE = "UPDATE TBItemInvoice SET InvoiceId = @InvoiceId, Quantity = @Quantity WHERE IdItemInvoice = @IdItemInvoice";
        private readonly string SQL_DELETE = "DELETE FROM TBItemInvoice WHERE IdItemInvoice = @IdItemInvoice";
        private readonly string SQL_GET = "SELECT it.*, p.IdProduct, p.Code, p.Description, p.UnitaryValue FROM TBItemInvoice AS it INNER JOIN TBProduct AS p ON it.ProductId = p.IdProduct ";
        private readonly string SQL_GETBYINVOICE = "SELECT it.*, p.IdProduct, p.Code, p.Description, p.UnitaryValue FROM TBItemInvoice AS it " +
                                                   "INNER JOIN TBProduct AS p ON it.ProductId = p.IdProduct " +
                                                   "WHERE InvoiceId = @InvoiceId";

        private readonly long _lessThan = 1;

        public ItemInvoice Save(ItemInvoice itemInvoice)
        {
            itemInvoice.Validate();

            itemInvoice.Id = Db.Insert(SQL_INSERT, Take(itemInvoice, false));

            return itemInvoice;
        }

        public ItemInvoice Update(ItemInvoice itemInvoice)
        {
            if (itemInvoice.Id < _lessThan)
                throw new IdentifierUndefinedException();

            itemInvoice.Validate();

            Db.Update(SQL_UPDATE, Take(itemInvoice));

            return itemInvoice;
        }

        public IEnumerable<ItemInvoice> GetByInvoice(InvoiceInProcess invoiceInProcess)
        {
            return Db.GetAll(SQL_GETBYINVOICE, Make, new object[] { "@InvoiceId", invoiceInProcess.Id });
        }

        public void Delete(ItemInvoice itemInvoice)
        {
            if (itemInvoice.Id < _lessThan)
                throw new IdentifierUndefinedException();

            Db.Delete(SQL_DELETE,new object[] { "@IdItemInvoice", itemInvoice.Id });
        }

        public ItemInvoice Get(long id)
        {
            if (id < _lessThan)
                throw new IdentifierUndefinedException();

            return Db.Get(SQL_GET,Make,new object[] { "@IdItemInvoice", id });
        }

        private static Func<IDataReader, ItemInvoice> Make = reader =>
         new ItemInvoice
         {
             Id = Convert.ToInt64(reader["IdItemInvoice"]),
             Invoice = new InvoiceInProcess
             {
                 Id = Convert.ToInt64(reader["InvoiceId"])
             },
             Product = new Product
             {
                 Id = Convert.ToInt64(reader["IdProduct"]),
                 Code = Convert.ToString(reader["Code"]),
                 Description = Convert.ToString(reader["Description"]),
                 UnitaryValue = Convert.ToDouble(reader["UnitaryValue"])
             },
             Quantity = Convert.ToInt32(reader["Quantity"])
         };

        private object[] Take(ItemInvoice itemInvoice, bool hasId = true)
        {
            object[] parametros = null;
            if (hasId)
            {
                parametros = new object[]
                    {
                "@InvoiceId", itemInvoice.Invoice.Id,
                "@Quantity", itemInvoice.Quantity,
                "@IdItemInvoice", itemInvoice.Id
                };
            }
            else
            {
                parametros = new object[]
              {
                "@InvoiceId", itemInvoice.Invoice.Id,
                "@ProductId", itemInvoice.Product.Id,
                "@Quantity", itemInvoice.Quantity
              };
            }

            return parametros;
        }
    }
}
