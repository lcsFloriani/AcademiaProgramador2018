using NDDResearch.Application.Features.Customers.Commands;
using NDDResearch.Application.Features.Customers.Queries;
using NDDResearch.Domain.Features.Customers;
using NDDResearch.Infra.Structs;
using System;
using System.Linq;

namespace NDDResearch.Application.Features.Customers
{
    /// <summary>
    /// Representa um serviço de customer
    /// </summary>
    public interface ICustomersService
    {
        /// <summary>
        /// Obtém todos os customers
        /// </summary>
        IQueryable<Customer> GetAll();

        /// <summary>
        /// Obtém um customer pelo identificador "id"
        /// </summary>
        /// <param name="id">É o id que será pesquisado para buscar um customer</param>
        Try<Exception, CustomerDetailQuery> GetById(int id);

        /// <summary>
        /// Adiciona um custumer na base de dados
        /// </summary>
        /// <param name="custumer">É o command para o custumer que será adicionado</param>
        Try<Exception, int> Add(CustomerRegisterCommand custumer);

        /// <summary>
        /// Atualiza as propriedades de um customer. 
        /// </summary>
        /// <param name="customer">É o command para o customer que será atualizado</param>
        Try<Exception, Result> Update(CustomerUpdateCommand customer);
 
        /// <summary>
        /// Remove um cliente da base de dados
        /// </summary>
        /// <param name="command">É o command para o customer que será removido</param>
        Try<Exception, Result> Remove(CustomerRemoveCommand command);
    }
}
