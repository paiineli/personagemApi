using CharacterApi.Data;
using CharacterApi.DTOs;
using Dapper;

namespace CharacterApi.Repositories
{
    public class CharacterRepository(DatabaseConnection databaseConnection, ILogger<CharacterRepository> logger) : ICharacterRepository
    {
        #region read

        // aliases are required because Dapper matches the constructor by parameter name; without them the underscores break the mapping
        public async Task<List<CharacterDTO>> GetAllCharactersAsync()
        {
            try
            {
                using var connection = databaseConnection.CreateConnection();

                var query = @"SELECT X.CD_PERSONAGEM CharacterId,
                                            X.CD_CLASSE ClassId,
                                            X.NM_PERSONAGEM CharacterName,
                                            X.NR_NIVEL Level,
                                            X.DT_CADASTRO CreatedAt,
                                            Z.NM_CLASSE ClassName
                                        FROM TESTE_PERSONAGEM X, TESTE_CLASSE Z
                                        WHERE 1 = 1
                                        AND X.CD_CLASSE = Z.CD_CLASSE";

                var result = await connection.QueryAsync<CharacterDTO>(query);

                return result.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching all characters.");
                throw;
            }
        }

        // aliases are required because Dapper matches the constructor by parameter name; without them the underscores break the mapping
        public async Task<List<CharacterDTO>> GetCharactersByFiltersAsync(int? characterId, int? classId, string? characterName)
        {
            try
            {
                using var connection = databaseConnection.CreateConnection();

                var parameters = new DynamicParameters();

                var query = @"SELECT X.CD_PERSONAGEM CharacterId,
                                            X.CD_CLASSE ClassId,
                                            X.NM_PERSONAGEM CharacterName,
                                            X.NR_NIVEL Level,
                                            X.DT_CADASTRO CreatedAt,
                                            Z.NM_CLASSE ClassName
                                        FROM TESTE_PERSONAGEM X, TESTE_CLASSE Z
                                        WHERE 1 = 1
                                        AND X.CD_CLASSE = Z.CD_CLASSE";

                if (characterId.HasValue)
                {
                    query += @" AND X.CD_PERSONAGEM = :CharacterId";
                    parameters.Add(":CharacterId", characterId);
                }

                if (classId.HasValue)
                {
                    query += @" AND X.CD_CLASSE = :ClassId";
                    parameters.Add(":ClassId", classId);
                }

                if (!string.IsNullOrEmpty(characterName))
                {
                    query += @" AND UPPER(X.NM_PERSONAGEM) LIKE UPPER(:CharacterName)";
                    parameters.Add(":CharacterName", $"%{characterName}%");
                }

                var result = await connection.QueryAsync<CharacterDTO>(query, parameters);

                return result.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching characters with filters.");
                throw;
            }
        }

        #endregion

        #region create

        public async Task CreateCharacterAsync(CreateCharacterDTO createCharacterDTO)
        {
            try
            {
                using var connection = databaseConnection.CreateConnection();

                var query = @"INSERT INTO TESTE_PERSONAGEM (CD_CLASSE, NM_PERSONAGEM, NR_NIVEL)
                                    VALUES (:ClassId, :CharacterName, :Level)";

                var parameters = new DynamicParameters();

                parameters.Add(":ClassId", createCharacterDTO.ClassId);
                parameters.Add(":CharacterName", createCharacterDTO.CharacterName);
                parameters.Add(":Level", createCharacterDTO.Level);

                await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error creating character.");
                throw;
            }
        }

        #endregion

        #region update

        public async Task<int> UpdateCharacterAsync(int characterId, UpdateCharacterDTO updateCharacter)
        {
            try
            {
                using var connection = databaseConnection.CreateConnection();

                var query = @"UPDATE TESTE_PERSONAGEM
                                    SET NR_NIVEL = :Level, CD_CLASSE = :ClassId
                                    WHERE CD_PERSONAGEM = :CharacterId";

                var parameters = new DynamicParameters();

                parameters.Add(":ClassId", updateCharacter.ClassId);
                parameters.Add(":Level", updateCharacter.Level);
                parameters.Add(":CharacterId", characterId);

                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error updating character {CharacterId}.", characterId);
                throw;
            }
        }

        #endregion

        #region delete

        public async Task<int> DeleteCharacterAsync(int characterId)
        {
            try
            {
                using var connection = databaseConnection.CreateConnection();

                var query = @"DELETE FROM TESTE_PERSONAGEM
                                    WHERE CD_PERSONAGEM = :CharacterId";

                var parameters = new DynamicParameters();
                parameters.Add(":CharacterId", characterId);

                return await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error deleting character {CharacterId}.", characterId);
                throw;
            }
        }

        #endregion
    }
}
