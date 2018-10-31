using NDDResearch.Domain.Features.Customers;
using NDDResearch.Domain.Features.Sites;
using System.Collections.Generic;

namespace nddResearch.Domain.Tests.ObjectMothers
{
    public static partial class ObjectMother
    {
        public static class CustomerObjectMother
        {
            public static Customer Default
            {
                get
                {
                    var defaultCustomer = new Customer()
                    {
                        Name = "Empresa01",
                        DisplayName = "Empresa 1",
                        NationalIdNumber = "0000000000",
                        Phone = "49999433351",
                        WebSite = "http://nddresearch/",
                        Address = AddressObjectMother.Default,
                        Sites = new List<Site>()
                    };

                    defaultCustomer.SetCreationDate();
                    defaultCustomer.SetKey();

                    return defaultCustomer;
                }
            }
        }
    }
}
