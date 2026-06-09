using System.ComponentModel.DataAnnotations;

namespace CharacterApi.Models
{
    // mirrors the database table
    public class CharacterClass
    {
        [Required]
        public int ClassId { get; set; }

        [MaxLength(25)]
        public string? ClassName { get; set; }

        [MaxLength(1)]
        public string? IsActive { get; set; }
    }
}
