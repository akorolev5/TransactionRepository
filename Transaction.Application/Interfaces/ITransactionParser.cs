namespace Transaction.Application.Interfaces;

public interface ITransactionParser
{
    public bool TryParseIntValue(string value, out int intValue);

    public bool TryParseDecimalValue(string value, out decimal intValue);

    public bool TryParseDateTimeValue(string value, out DateTime dateTimeValue);
}