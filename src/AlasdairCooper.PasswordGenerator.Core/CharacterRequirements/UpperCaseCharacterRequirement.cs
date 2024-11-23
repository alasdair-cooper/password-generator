namespace AlasdairCooper.PasswordGenerator.Core.CharacterRequirements;

public class UpperCaseCharacterRequirement : ICharacterRequirement
{
    private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public ReadOnlySpan<char> ValidCharacters => Characters.AsSpan();

    public bool IsActive(Requirements requirements) => requirements.HasUppercaseCharacters;
}