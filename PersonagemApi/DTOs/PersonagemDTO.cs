namespace PersonagemApi.DTOs
{
    // buscar todos os personagens da base
    // buscar todos os personagens com filtros de códigos ou de nome
    public record PersonagemDTO(int CdPersonagem, int CdClasse, string NmPersonagem, string? NrNivel, DateTime? DtCadastro, string? NmClasse);
}
