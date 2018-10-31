using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Infra.ORM.Context;
using System.Data.Entity;

namespace Projeto_NFe.Infra.ORM.Features.ItemInvoices
{
    public class ItemInvoiceRepository : IItemInvoiceRepository
    {

        private readonly long _biggerThan = 0;
        private ProjetoNFeContext _context;

        public ItemInvoiceRepository(ProjetoNFeContext context)
        {
            this._context = context;
        }

        public bool Delete(ItemInvoice itemInvoice)
        {
            _context.ItemInvoices.Remove(itemInvoice);
            _context.Entry(itemInvoice).State = EntityState.Deleted;
            return _context.SaveChanges() > _biggerThan;
        }
    }
}
