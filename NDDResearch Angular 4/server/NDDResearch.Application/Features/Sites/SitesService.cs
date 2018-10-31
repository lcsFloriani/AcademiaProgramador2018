using AutoMapper;
using NDDResearch.Application.Features.Sites.Commands;
using NDDResearch.Domain.Exceptions;
using NDDResearch.Domain.Features.Customers;
using NDDResearch.Domain.Features.Sites;
using System;
using NDDResearch.Application.Features.Sites.Queries;
using System.Linq;
using NDDResearch.Infra.Structs;

namespace NDDResearch.Application.Features.Sites
{
    /// <summary>
    /// Serviço de gerenciamento de sites
    /// </summary>
    public class SitesService : ISitesService
    {
        private readonly ISiteRepository _repository;
        private readonly ICustomerRepository _customerRepository;

        public SitesService(ISiteRepository repository, ICustomerRepository customerRepository)
        {
            _repository = repository;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Adiciona um site na base de dados
        /// </summary>
        /// <param name="site">É o command para o site que será adicionado</param>
        public Try<Exception, int> Add(SiteRegisterCommand site)
        {
            var customerCallback = _customerRepository.GetById(site.CustomerId);
            if (customerCallback.IsFailure)
                return customerCallback.Failure;

            var isUniqueCallback = _repository.IsUnique(site.CustomerId, site.Name);


            if (isUniqueCallback.IsFailure)
                return isUniqueCallback.Failure;

            if (!isUniqueCallback.Result)
                return new AlreadyExistsException();

            var addSiteCallback = _repository.Add(Mapper.Map<SiteRegisterCommand, Site>(site));

            if (addSiteCallback.IsFailure)
                return addSiteCallback.Failure;
            var addedSite = addSiteCallback.Result;

            if (addedSite.IsDefault)
            {
                customerCallback.Result.SetDefaultSite(addedSite);
                _repository.SaveChanges();
            }

            return addedSite.Id;
        }
        /// <summary>
        /// Obtém todos os sites de um determinado customer
        /// </summary>
        /// <param name="customerId">É o id do customer que será buscado os sites que pertencem à ele</param>
        public IQueryable<Site> GetAll(int customerId)
        {
            return _repository.GetAll(customerId);
        }

        /// <summary>
        /// Obtém um site pelo identificador "id"
        /// </summary>
        /// <param name="siteId">É o id que será pesquisado para buscar um site</param>
        public Try<Exception, SiteQuery> GetById(int siteId)
        {
            var siteCallback = _repository.GetById(siteId);
            if (siteCallback.IsFailure)
                return siteCallback.Failure;
            return Mapper.Map<SiteQuery>(siteCallback.Result);
        }

        /// <summary>
        /// Atualiza as propriedades de um site. 
        /// </summary>
        /// <param name="site">É o command para o site que será atualizado</param>
        public Try<Exception, Result> Remove(SiteDeleteCommand site)
        {
            /* Remove as impressoras do site antes de remove-lo */
            var removeSiteCallback = _repository.Remove(site.Id);
            if (removeSiteCallback.IsFailure)
                return removeSiteCallback.Failure;

            return Result.Successful;
        }

        /// <summary>
        /// Remove um site da base de dados
        /// </summary>
        /// <param name="siteCmd">É o command para o site que será atualizado</param>
        public Try<Exception, Result> Update(SiteUpdateCommand siteCmd)
        {
            //Pega o site antes das alterações, para validações.
            var siteCallback = _repository.GetById(siteCmd.Id);
            if (siteCallback.IsFailure)
                return siteCallback.Failure;
            var foundSite = siteCallback.Result;

            var isUniqueCallback = _repository.IsUnique(foundSite.CustomerId, siteCmd.Name, foundSite.Id);

            if (isUniqueCallback.IsFailure)
                throw isUniqueCallback.Failure;

            if (!isUniqueCallback.Result)
                return new AlreadyExistsException();

            /*Verifica se alterou o IsDefault
             * obs: isDefault nunca é alterado para false no update.*/
            if (siteCmd.IsDefault != foundSite.IsDefault && !foundSite.IsDefault)
            {
                var setDefaultCallback = foundSite.Customer.SetDefaultSite(foundSite);
                if (setDefaultCallback.IsFailure)
                    return setDefaultCallback.Failure;
            }

            Mapper.Map(siteCmd, foundSite);

            _repository.SaveChanges();
            return Result.Successful;
        }
    }
}
