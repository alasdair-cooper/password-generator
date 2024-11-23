namespace AlasdairCooper.PasswordGenerator.Core.CharacterRequirements;

public class SpecialCharacterRequirement : ICharacterRequirement
{
    private const string Characters = "!$£@#%&";

    public ReadOnlySpan<char> ValidCharacters => Characters.AsSpan();

    public bool IsActive(Requirements requirements) => requirements.HasSpecialCharacters;
}