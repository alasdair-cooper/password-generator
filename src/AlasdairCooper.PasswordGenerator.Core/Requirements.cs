namespace AlasdairCooper.PasswordGenerator.Core;

public class Requirements
{
    private Requirements() { }

    public int Length { get; private set; } = 16;

    public bool HasLowercaseCharacters { get; private set; } = true;

    public bool HasUppercaseCharacters { get; private set; } = true;

    public bool HasNumericCharacters { get; private set; } = true;

    public bool HasSpecialCharacters { get; private set; } = true;

    public Requirements WithLength(int length)
    {
        Length = length;
        return this;
    }

    public Requirements WithHasLowercase(bool hasLowercaseCharacters)
    {
        HasLowercaseCharacters = hasLowercaseCharacters;
        return this;
    }
    
    public Requirements WithHasUppercase(bool hasUppercaseCharacters)
    { 
        HasUppercaseCharacters = hasUppercaseCharacters;
        return this;
    }

    public Requirements WithHasNumeric(bool hasNumericCharacters)
    {
        HasNumericCharacters = hasNumericCharacters;
        return this;
    }

    public Requirements WithHasSpecial(bool hasSpecialCharacters)
    {
        HasSpecialCharacters = hasSpecialCharacters;
        return this;
    }
    
    public static Requirements Default => new();
}