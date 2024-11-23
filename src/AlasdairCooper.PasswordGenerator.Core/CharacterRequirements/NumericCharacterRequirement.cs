namespace AlasdairCooper.PasswordGenerator.Core.CharacterRequirements;

public class NumericCharacterRequirement : ICharacterRequirement
{
    private const string Characters = "0123456789";

    public ReadOnlySpan<char> ValidCharacters => Characters.AsSpan();

    public bool IsActive(Requirements requirements) => requirements.HasNumericCharacters;
}