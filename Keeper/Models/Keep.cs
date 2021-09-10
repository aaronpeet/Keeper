using System.ComponentModel.DataAnnotations;

namespace Keeper.Models
{
    public class Keep
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Img { get; set; } = "http://placehold.it/200x200";
        public int Views { get; set; }
        public int Shares { get; set; }
        public int Keeps { get; set; }
        public string CreatorId { get; set; }
        public Profile Creator { get; set; }

    }
}