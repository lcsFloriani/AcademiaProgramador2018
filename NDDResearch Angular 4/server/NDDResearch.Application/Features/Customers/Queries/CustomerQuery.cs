namespace NDDResearch.Application.Features.Customers.Queries
{
    /// <summary>
    /// 
    /// Representa uma consulta de um customer da base de dados
    ///  
    /// </summary>
    public class CustomerQuery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
