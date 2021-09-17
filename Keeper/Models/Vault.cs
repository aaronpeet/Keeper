using System.ComponentModel.DataAnnotations;

namespace Keeper.Models
{
    public class Vault
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public bool? IsPrivate { get; set; } = false;
        public string CreatorId { get; set; }
        public Profile Creator { get; set; }
        
    }
}