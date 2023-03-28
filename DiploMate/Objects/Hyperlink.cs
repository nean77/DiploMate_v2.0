namespace DiploMate.Objects;

public class Hyperlink : ValueObject
{
    public string Value { get; }

    public Hyperlink(string value)
    {
        if (!string.IsNullOrEmpty(value) && (!value.Contains("http://") || !value.Contains("https://"))) throw new Exception("Link is invalid");

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #region Conversion

    public static implicit operator string(Hyperlink value)
    {
        return value.Value;
    }

    public static implicit operator Hyperlink(string value)
    {
        return new Hyperlink(value);
    }

    #endregion
}