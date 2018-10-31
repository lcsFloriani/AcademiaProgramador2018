using NDDResearch.Application.Features.Addresses.Queries;

namespace NDDResearch.Application.Features.Sites.Queries
{
    /// <summary>
    /// 
    /// Representa uma consulta de um site da base de dados
    ///  
    /// </summary>
    public class SiteQuery
    {
        public int Id { get; set; }
        public bool IsDefault { get; set; }
        public string NationalIdNumber { get; set; }
        public string Name { get; set; }
        public AddressQuery Address { get; set; }
    }
}
