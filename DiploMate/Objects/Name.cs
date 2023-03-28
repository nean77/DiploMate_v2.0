namespace DiploMate.Objects;

public sealed class Name : ValueObject
{
    public string Value { get; set; }
    public Name(string value)
    {
        if (string.IsNullOrEmpty(value)) throw new Exception("Name cannot be empty");

        Value = value;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #region Conversion

    public static implicit operator string(Name value)
    {
        return value.Value;
    }

    public static implicit operator Name(string value)
    {
        return new Name(value);
    }

    #endregion
}