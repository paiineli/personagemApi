using CharacterApi.DTOs;

namespace CharacterApi.Repositories
{
    public interface ICharacterRepository
    {
        #region read

        public Task<List<CharacterDTO>> GetAllCharactersAsync();

        public Task<List<CharacterDTO>> GetCharactersByFiltersAsync(int? characterId, int? classId, string? characterName);

        #endregion

        #region create

        public Task CreateCharacterAsync(CreateCharacterDTO createCharacterDTO);

        #endregion

        #region update

        Task<int> UpdateCharacterAsync(int characterId, UpdateCharacterDTO updateCharacterDTO);

        #endregion

        #region delete

        Task<int> DeleteCharacterAsync(int characterId);

        #endregion
    }
}
