using System.Globalization;
using Transaction.Application.Interfaces;

namespace Transaction.Application.Services;

public class TransactionParser : ITransactionParser
{
    public bool TryParseDateTimeValue(string value, out DateTime dateTimeValue)
    {
        if (DateTime.TryParse(value, out dateTimeValue))
        {
            return true;
        }
        return false;

    }

    public bool TryParseIntValue(string value, out int intValue)
    {
        if (int.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out intValue))
        {
            return true;
        }
        return false;
    }

    public bool TryParseDecimalValue(string value, out decimal decimalValue)
    {
        if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimalValue))
        {
            return true;
        }
        return false;
    }
}