namespace NDDResearch.Application.Features.Addresses.Commands
{
    /// <summary>
    /// 
    /// Representa o comando (dados necessário) para atualizar um novo address.
    ///  
    /// </summary>
    public class AddressUpdateCommand
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
