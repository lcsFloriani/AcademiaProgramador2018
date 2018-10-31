using NDDResearch.Domain.Exceptions;
using NDDResearch.Domain.Features.Addresses;
using NDDResearch.Domain.Features.Sites;
using NDDResearch.Infra.Structs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NDDResearch.Domain.Features.Customers
{
    /// <summary>
    /// Representa um Customer como entidade de negócio
    /// </summary>
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string NationalIdNumber { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public virtual Address Address { get; set; }
        public int AddressId { get; set; }
        public string Key { get; private set; }
        public DateTime CreationDate { get; private set; }
        public virtual List<Site> Sites { get; set; }

        /// <summary>
        /// Seta a data de criação do cliente para hoje
        /// </summary>
        public void SetCreationDate()
        {
            CreationDate = DateTime.Now;
        }

        /// <summary>
        /// Cria nova chave
        /// </summary>
        public void SetKey()
        {
            Key = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Define, o site passado por parâmetro, como default do cliente.
        /// </summary>
        /// <param name="site">site para se tornar padrão</param>
        /// <returns>Um objeto do tipo Result que contém o resultado da operação</returns>
        public Try<Exception, Result> SetDefaultSite(Site site)
        {
            if (site.CustomerId != Id)
                /* se o site não pertencer ao cliente não pode marcar como padrão. */
                return new InvalidObjectException();
            site.IsDefault = true;
            Sites.Where(s => s.Id != site.Id && s.IsDefault).ToList().ForEach(s => s.IsDefault = false);
            return Result.Successful;
        }
    }
}
