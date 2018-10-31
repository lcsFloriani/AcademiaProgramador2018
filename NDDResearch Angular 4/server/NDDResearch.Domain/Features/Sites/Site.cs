using NDDResearch.Domain.Features.Addresses;
using NDDResearch.Domain.Features.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDResearch.Domain.Features.Sites
{
    /// <summary>
    /// Representa um Site como entidade de negócio
    /// </summary>
    public class Site : Entity
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public string NationalIdNumber { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
