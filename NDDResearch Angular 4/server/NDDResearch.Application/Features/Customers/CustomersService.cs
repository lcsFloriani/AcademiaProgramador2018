using System;
using System.Linq;
using NDDResearch.Application.Features.Customers.Commands;
using NDDResearch.Application.Features.Customers.Queries;
using NDDResearch.Domain.Exceptions;
using NDDResearch.Domain.Features.Customers;
using AutoMapper;
using NDDResearch.Domain.Features.Sites.Service;
using NDDResearch.Domain.Features.Sites;
using NDDResearch.Infra.Structs;

namespace NDDResearch.Application.Features.Customers
{
    /// <summary>
    /// Serviço de gerenciamento de customers
    /// </summary>
    public class CustomersService : ICustomersService
    {
        private readonly ICustomerRepository _repositoryCustomer;
        private readonly ISiteRepository _repositorySite;
        private readonly ISiteDomainService _siteDomainService;

        public CustomersService(ICustomerRepository customerRepository,
                        ISiteDomainService siteDomainService,
                        ISiteRepository repositorySite)
        {
            _repositoryCustomer = customerRepository;
            _siteDomainService = siteDomainService;
            _repositorySite = repositorySite;
        }


        /// <summary>
        /// Adiciona um customer na base de dados
        /// </summary>
        /// <param name="customer">É o command para o customer que será adicionado</param>
        public Try<Exception, int> Add(CustomerRegisterCommand customerCmd)
        {
            var customer = Mapper.Map<CustomerRegisterCommand, Customer>(customerCmd);

            customer.SetCreationDate();
            customer.SetKey();

            var isUniqueCallback = _repositoryCustomer.IsUnique(customer.Name);

            if (isUniqueCallback.IsFailure)
                return isUniqueCallback.Failure;
            if (!isUniqueCallback.Result)
                return new AlreadyExistsException();

            var addCustomerCallback = _repositoryCustomer.Add(customer);

            if (addCustomerCallback.IsFailure)
                return addCustomerCallback.Failure;

            var newCustomer = addCustomerCallback.Result;

            var siteCallback = _repositorySite.Add(_siteDomainService.CreateDefaultSite(newCustomer));
            if (siteCallback.IsFailure)
                return siteCallback.Failure;

            return newCustomer.Id;
        }

        /// <summary>
        /// Obtém todos os customers
        /// </summary>
        public IQueryable<Customer> GetAll()
        {
            return _repositoryCustomer.GetAll();
        }

        /// <summary>
        /// Obtém um customer pelo identificador "id"
        /// </summary>
        /// <param name="id">É o id que será pesquisado para buscar um customer</param>
        public Try<Exception, CustomerDetailQuery> GetById(int id)
        {
            var callback = _repositoryCustomer.GetById(id);
            if (callback.IsFailure)
                return callback.Failure;

            return Mapper.Map<Customer, CustomerDetailQuery>(callback.Result); ;
        }

        /// <summary>
        /// Remove um cliente da base de dados
        /// </summary>
        /// <param name="command">É o command para o customer que será removido</param>
        public Try<Exception, Result> Remove(CustomerRemoveCommand command)
        {
            foreach (var customerId in command.CustomerIds)
            {
                var customerCB = _repositoryCustomer.GetById(customerId);

                if (customerCB.IsFailure)
                    return customerCB.Failure;

                _repositoryCustomer.Remove(customerCB.Result);
            }

            return Result.Successful;
        }

        /// <summary>
        /// Atualiza as propriedades de um customer. 
        /// </summary>
        /// <param name="customer">É o command para o customer que será atualizado</param>
        public Try<Exception, Result> Update(CustomerUpdateCommand cmd)
        {
            var customerCB = _repositoryCustomer.GetById(cmd.Id);

            if (customerCB.IsFailure)
                return customerCB.Failure;

            var customer = customerCB.Result;
            Mapper.Map(cmd, customer);

            _repositoryCustomer.Update(customer);

            return Result.Successful;
        }
    }
}
