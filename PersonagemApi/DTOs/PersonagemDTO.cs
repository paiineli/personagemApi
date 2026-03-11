namespace PersonagemApi.DTOs
{
    // buscar todos os personagens da base
    // buscar todos os personagens com filtros de códigos ou de nome

    // tive que colocar como decimal pq o dapper não acha o construtor com o tipo int (oracle mapeia para system.decimal mas dapper exige que bata os tipos)
    public record PersonagemDTO(decimal CdPersonagem, decimal CdClasse, string NmPersonagem, string? NrNivel, DateTime? DtCadastro, string? NmClasse);
}
