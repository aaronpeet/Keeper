using System.ComponentModel.DataAnnotations;

namespace Keeper.Models
{
    public class Keep
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Img { get; set; } = "http://placehold.it/200x200";
        public int? Views { get; set; } = 0;
        public int? Shares { get; set; } = 0;
        public int? Keeps { get; set; } = 0;
        public string CreatorId { get; set; }
        public Profile Creator { get; set; }

    }
}