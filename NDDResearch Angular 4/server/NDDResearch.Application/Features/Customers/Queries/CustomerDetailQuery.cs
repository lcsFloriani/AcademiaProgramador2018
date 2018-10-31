using NDDResearch.Application.Features.Addresses.Queries;
using System;

namespace NDDResearch.Application.Features.Customers.Queries
{
    /// <summary>
    /// 
    /// Representa uma consulta com mais dados de um customer da base de dados
    /// 
    /// É usado quando se precisa de mais dados sobre o usuário para atualizar posteriormente
    /// Exemplo: uma tela de edição de customer
    ///  
    /// </summary>
    public class CustomerDetailQuery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string NationalIdNumber { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public AddressQuery Address { get; set; }
        public DateTime CreationDate { get; set; }
        public string Key { get; set; }
    }
}
