namespace CharacterApi.DTOs
{
    // create a new character
    public record CreateCharacterDTO(int ClassId, string CharacterName, string Level);
}
