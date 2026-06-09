namespace CharacterApi.DTOs
{
    // get all characters from the database
    // get all characters filtered by codes or name

    // had to use decimal because Dapper cannot match the constructor with int (Oracle maps to System.Decimal and Dapper requires the types to match)
    public record CharacterDTO(decimal CharacterId, decimal ClassId, string CharacterName, string Level, DateTime CreatedAt, string ClassName);
}
