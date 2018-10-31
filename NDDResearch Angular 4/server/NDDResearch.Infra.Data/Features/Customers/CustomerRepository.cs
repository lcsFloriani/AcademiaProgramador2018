using System;
using System.Linq;
using NDDResearch.Domain.Exceptions;
using NDDResearch.Domain.Features.Customers;
using NDDResearch.Infra.Data.Contexts;
using System.Data.Entity;
using NDDResearch.Infra.Structs;

namespace NDDResearch.Infra.Data.Features.Customers
{
    /// <summary>
    /// Repositório de customers
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        private NDDResearchDbContext _context;

        public CustomerRepository(NDDResearchDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adiciona um novo customer na base de dados
        /// </summary>
        // <param name="customer">É o customer que será adicionado da base de dados</param>
        /// <returns>Retorna o novo customer com os atributos atualizados (como id)</returns>
        public Try<Exception, Customer> Add(Customer customer)
        {
            var newCustomer = _context.Customers.Add(customer);
            _context.SaveChanges();
            return newCustomer;
        }

        /// <summary>
        /// Retorna se um nome de cliente é único. 
        /// </summary>
        /// <param name="name">nome do cliente</param>
        /// <param name="id">id a ser ignorado. (util. em caso de update)</param>
        /// <returns>Caso seja único retorna true, senão retorna false</returns>
        public Try<Exception, bool> IsUnique(string name, int id = 0)
        {
            return !_context.Customers.Any(c => c.Name.ToLower().Equals(name.ToLower()) && (id == 0 || c.Id != id));
        }

        /// <summary>
        /// Método que retorna uma lista de customers cadastrados na base de dados
        /// </summary>
        public IQueryable<Customer> GetAll()
        {
            return _context.Customers;
        }

        /// <summary>
        /// Mátodo para obter um customer específico pelo id
        /// </summary>
        /// <param name="customerId">O id do customer ue está sendo pesquisado</param>
        public Try<Exception, Customer> GetById(int customerId)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
                return new NotFoundException();
            return customer;
        }

        /// <summary>
        /// Método para atualizar um customer na base de dados
        /// </summary>
        public Try<Exception, Result> Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
            return Result.Successful;
        }

        /// <summary>
        /// Altera a propriedade isRemoved para true.
        /// </summary>
        // <param name="customer">É o customer que será removido da base de dados</param>
        /// <returns>Retorna um objeto do tipo Result contendo o resultado da operação</returns>
        public Try<Exception, Result> Remove(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Deleted;
            _context.SaveChanges();
            return Result.Successful;
        }
    }
}
