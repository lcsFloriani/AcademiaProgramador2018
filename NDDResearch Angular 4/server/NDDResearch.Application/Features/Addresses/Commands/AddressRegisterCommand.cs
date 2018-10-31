
namespace NDDResearch.Application.Features.Addresses.Commands
{
    /// <summary>
    /// 
    /// Representa o comando (dados necessário) para registrar um novo Address.
    ///  
    /// </summary>
    public class AddressRegisterCommand
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
