namespace CharacterApi.DTOs
{
    // update a character's level or class
    public record UpdateCharacterDTO(int ClassId, string Level);
}
