namespace DiploMate.Objects;

public sealed class Email : ValueObject
{ 
    public string Value { get; }

    public Email(string value)
    {
        if (!value.Contains("@")) throw new Exception("Email is invalid");

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #region Conversion

    public static implicit operator string(Email value)
    {
        return value.Value;
    }

    public static implicit operator Email(string value)
    {
        return new Email(value);
    }

    #endregion
}