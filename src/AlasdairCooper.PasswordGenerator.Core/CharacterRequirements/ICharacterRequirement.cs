using System.Security.Cryptography;

namespace AlasdairCooper.PasswordGenerator.Core.CharacterRequirements;

public interface ICharacterRequirement
{
    public ReadOnlySpan<char> ValidCharacters { get; }

    public bool IsActive(Requirements requirements);

    public char[] GetCharacters(int count) => RandomNumberGenerator.GetItems(ValidCharacters, count);
}