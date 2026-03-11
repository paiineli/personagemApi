using System.ComponentModel.DataAnnotations;

namespace PersonagemApi.Models
{
    // criado igual a tabela do banco
    public class Classe
    {
        [Required]
        public int CdClasse { get; set; }

        [MaxLength(25)]
        public string? NmClasse { get; set; }

        [MaxLength(1)]
        public string? SnAtivo { get; set; }
    }
}