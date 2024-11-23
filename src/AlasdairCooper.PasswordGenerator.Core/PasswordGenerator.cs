using System.Security.Cryptography;
using System.Text;

using AlasdairCooper.PasswordGenerator.Core.CharacterRequirements;

namespace AlasdairCooper.PasswordGenerator.Core;

public static class PasswordGenerator
{
    public static string Generate(Requirements requirements)
    {
        var characterRequirements =
            new List<ICharacterRequirement>
            {
                new LowerCaseCharacterRequirement(),
                new UpperCaseCharacterRequirement(),
                new NumericCharacterRequirement(),
                new SpecialCharacterRequirement(),
            }.Where(x => x.IsActive(requirements)).ToList();

        if (characterRequirements.Count == 0) return "";
        if (characterRequirements.Count > requirements.Length) return "";

        var builder = new StringBuilder();

        foreach (var requirement in characterRequirements)
            builder.Append(RandomNumberGenerator.GetString(requirement.ValidCharacters, 1));

        var remainingCharsCount = requirements.Length - builder.Length;

        switch (remainingCharsCount)
        {
            case > 0:
                var allCharacters = characterRequirements.SelectMany(x => x.ValidCharacters.ToArray()).ToArray();
                builder.Append(RandomNumberGenerator.GetString(allCharacters, remainingCharsCount));
                break;
            case < 0:
                return "";
        }

        var passwordChars = builder.ToString().ToArray().AsSpan();
        RandomNumberGenerator.Shuffle(passwordChars);
        return string.Join("", passwordChars.ToArray());
    }
}