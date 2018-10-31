using NDDResearch.Infra.Structs;
using System;
using System.Linq;

namespace NDDResearch.Domain.Features.Customers
{
    /// <summary>
    /// Representa o repositório de customers
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Método que retorna uma lista de customers cadastrados na base de dados
        /// </summary>
        IQueryable<Customer> GetAll();

        /// <summary>
        /// Adiciona um novo customer na base de dados
        /// </summary>
        // <param name="customer">É o customer que será adicionado da base de dados</param>
        /// <returns>Retorna o novo customer com os atributos atualizados (como id)</returns>
        Try<Exception, Customer> Add(Customer customer);

        /// <summary>
        /// Retorna se um nome de cliente é único. 
        /// </summary>
        /// <param name="name">nome do cliente</param>
        /// <param name="id">id a ser ignorado. (util. em caso de update)</param>
        /// <returns>Caso seja único retorna true, senão retorna false</returns>
        Try<Exception, bool> IsUnique(string name, int id = 0);

        /// <summary>
        /// Mátodo para atualizar um customer na base de dados
        /// </summary>
        Try<Exception, Result> Update(Customer customer);

        /// <summary>
        /// Mátodo para obter um customer específico pelo id
        /// </summary>
        /// <param name="customerId">O id do customer ue está sendo pesquisado</param>
        Try<Exception, Customer> GetById(int customerId);

        /// <summary>
        /// Altera a propriedade isRemoved para true.
        /// </summary>
        // <param name="customer">É o customer que será removido da base de dados</param>
        /// <returns>Retorna um objeto do tipo Result contendo o resultado da operação</returns>
        Try<Exception, Result> Remove(Customer customer);
    }
}
