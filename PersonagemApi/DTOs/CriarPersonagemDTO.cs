namespace PersonagemApi.DTOs
{
    // cadastrar um novo personagem
    public record CriarPersonagemDTO(int CdClasse, string NmPersonagem, string? NrNivel);
}