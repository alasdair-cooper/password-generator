namespace AlasdairCooper.PasswordGenerator.Core.CharacterRequirements;

public class LowerCaseCharacterRequirement : ICharacterRequirement
{
    private const string Characters = "abcdefghijklmnopqrstuvwxyz";

    public ReadOnlySpan<char> ValidCharacters => Characters.AsSpan();

    public bool IsActive(Requirements requirements) => requirements.HasLowercaseCharacters;
}