using System.ComponentModel.DataAnnotations;

namespace CharacterApi.Models
{
    // mirrors the database table
    public class Character
    {
        [Required]
        public int CharacterId { get; set; }

        [Required]
        public int ClassId { get; set; }

        [Required]
        [MaxLength(5)]
        public string CharacterName { get; set; } = string.Empty;

        [MaxLength(1)]
        public string? Level { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
