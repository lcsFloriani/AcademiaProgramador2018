namespace NDDResearch.Application.Features.Addresses.Queries
{
    /// <summary>
    /// 
    /// Representa uma consulta de um Address da base de dados
    ///  
    /// </summary>
    public class AddressQuery
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
