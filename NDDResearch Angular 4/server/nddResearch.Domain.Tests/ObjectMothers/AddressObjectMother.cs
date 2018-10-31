using NDDResearch.Domain.Features.Addresses;

namespace nddResearch.Domain.Tests.ObjectMothers
{
    public static partial class ObjectMother
    {
        public static class AddressObjectMother
        {
            public static Address Default
            {
                get
                {
                    return new Address()
                    {
                        City = "Lages",
                        Country = "Brasil",
                        State = "Santa Catarina",
                        PostalCode = "88509290",
                        Street = "Rua Acre, 502,  São Cristovão"
                    };
                }
            }
        }
    }
}
