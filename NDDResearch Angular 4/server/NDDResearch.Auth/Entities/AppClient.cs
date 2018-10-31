using System.ComponentModel.DataAnnotations;

namespace NDDResearch.Auth.Entities
{
    /// <summary>
    /// Classe que presenta uma aplicação que confia para a NDDResearch.Auth a autenticação (client)
    /// </summary>
    public class AppClient
    {
        [Key]
        [MaxLength(32)]
        public string ClientId { get; set; }

        [MaxLength(80)]
        [Required]
        public string Base64Secret { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
    }
}