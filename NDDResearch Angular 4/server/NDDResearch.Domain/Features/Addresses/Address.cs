namespace NDDResearch.Domain.Features.Addresses
{
    /// <summary>
    /// Representa um Address como entidade de negócio
    /// </summary>
    public class Address : Entity
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Método para duplicar o Address
        /// </summary>
        /// <returns>Uma nova instância do this (address) com todas as propriedades preenchidas, menos o Id.</returns>
        public Address Clone()
        {
            var clone = new Address();
            clone.Country = Country;
            clone.State = State;
            clone.City = City;
            clone.PostalCode = PostalCode;
            clone.Street = Street;
            clone.AdditionalInfo = AdditionalInfo;
            return clone;
        }
    }
}
