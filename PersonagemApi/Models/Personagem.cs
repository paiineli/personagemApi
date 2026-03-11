using System.ComponentModel.DataAnnotations;

namespace PersonagemApi.Models
{
    // criado igual a tabela do banco
    public class Personagem
    {
        [Required]
        public int CdPersonagem { get; set; }

        [Required]
        public int CdClasse { get; set; }

        [Required]
        [MaxLength(5)]
        public string NmPersonagem { get; set; } = string.Empty;

        [MaxLength(1)]
        public string? NrNivel { get; set; }

        public DateTime? DtCadastro { get; set; }

    }
}