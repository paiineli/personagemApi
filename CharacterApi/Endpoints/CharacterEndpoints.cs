using CharacterApi.DTOs;
using CharacterApi.Repositories;

namespace CharacterApi.Endpoints
{
    public static class CharacterEndpoints
    {
        public static void MapCharacterEndpoints(this IEndpointRouteBuilder app)
        {
            var characterGroup = app.MapGroup("/api/character");

            #region read

            characterGroup.MapGet("/get-all", async (ICharacterRepository characterRepository) =>
            {
                try
                {
                    var result = await characterRepository.GetAllCharactersAsync();
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            });

            // query strings only carry text, so I parse them manually to int?, handling the case where the parameter was not sent (empty or null string).
            characterGroup.MapGet("/search", async (string? characterId, string? classId, string? characterName, ICharacterRepository characterRepository) =>
            {
                try
                {
                    var result = await characterRepository.GetCharactersByFiltersAsync(
                        int.TryParse(characterId, out var character) ? character : null,
                        int.TryParse(classId, out var characterClass) ? characterClass : null,
                        characterName);

                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            });

            #endregion

            #region create

            characterGroup.MapPost("/create", async (CreateCharacterDTO createCharacterDTO, ICharacterRepository characterRepository) =>
            {
                try
                {
                    await characterRepository.CreateCharacterAsync(createCharacterDTO);
                    return Results.Created("/api/character/create", "Character created successfully.");
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            });

            #endregion

            #region update

            characterGroup.MapPut("/update/{characterId}", async (int characterId, UpdateCharacterDTO updateCharacterDTO, ICharacterRepository characterRepository) =>
            {
                try
                {
                    var affectedRows = await characterRepository.UpdateCharacterAsync(characterId, updateCharacterDTO);

                    if (affectedRows == 0)
                    {
                        return Results.NotFound("Character not found.");
                    }

                    return Results.Ok("Character updated successfully.");
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            });

            #endregion

            #region delete

            characterGroup.MapDelete("/delete/{characterId}", async (int characterId, ICharacterRepository characterRepository) =>
            {
                try
                {
                    var affectedRows = await characterRepository.DeleteCharacterAsync(characterId);

                    if (affectedRows == 0)
                    {
                        return Results.NotFound("Character not found.");
                    }

                    return Results.Ok("Character deleted successfully.");
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
