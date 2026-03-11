using PersonagemApi.DTOs;
using PersonagemApi.Repositories;

namespace PersonagemApi.Endpoints
{
    public static class PersonagemEndpoints
    {
        public static void MapPersonagemEndpoints(this IEndpointRouteBuilder app)
        {
            var grupoPersonagem = app.MapGroup("/api/personagem");

            #region buscar

            grupoPersonagem.MapGet("/buscar", async (IPersonagemREP personagemREP) =>
            {
                try
                {
                    var result = await personagemREP.BuscarTodosPersonagensAsync();
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            });

            grupoPersonagem.MapGet("/buscarcomfiltro", async (int? cdPersonagem, int? cdClasse, string? nmPersonagem, IPersonagemREP personagemREP) =>
            {
                try
                {
                    var result = await personagemREP.BuscarPersonagensComFiltrosAsync(cdPersonagem, cdClasse, nmPersonagem);
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            });

            #endregion

            #region cadastrar

            grupoPersonagem.MapPost("/cadastrar", async (CriarPersonagemDTO criarPersonagemDTO, IPersonagemREP personagemREP) =>
            {
                try
                {
                    await personagemREP.CriarPersonagemAsync(criarPersonagemDTO);
                    return Results.Created("/api/personagem/cadastrar", "Personagem criado com sucesso.");
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            });

            #endregion

            #region atualizar

            grupoPersonagem.MapPut("/atualizar/{cdPersonagem}", async (int cdPersonagem, AtualizarPersonagemDTO atualizarPersonagemDTO, IPersonagemREP personagemREP) =>
            {
                try
                {
                    var linhasAfetadas = await personagemREP.AtualizarPersonagemAsync(cdPersonagem, atualizarPersonagemDTO);

                    if (linhasAfetadas == 0)
                    {
                        return Results.NotFound("Personagem não encontrado.");
                    }                        

                    return Results.Ok("Personagem atualizado com sucesso.");
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            });

            #endregion

            #region excluir

            grupoPersonagem.MapDelete("/excluir/{cdPersonagem}", async (int cdPersonagem, IPersonagemREP personagemREP) =>
            {
                try
                {
                    var linhasAfetadas = await personagemREP.ExcluirPersonagemAsync(cdPersonagem);

                    if (linhasAfetadas == 0)
                    {
                        return Results.NotFound("Personagem não encontrado.");
                    }

                    return Results.Ok("Personagem excluído com sucesso.");
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            });

            #endregion
        }
    }
}
