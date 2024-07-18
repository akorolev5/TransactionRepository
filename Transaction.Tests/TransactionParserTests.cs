using NUnit.Framework;
using Transaction.Application.Services;

namespace Transaction.Tests
{
    public class TransactionParserTests
    {
        [Test(Description = "TryParseDateTimeValue - парсинг даты с нормальным форматом проходит штатно")]
        public void TransactionParser_TryParseDateTimeValue_WithCorrectData_SholdParseNormally()
        {
            // Arrange
            string parsedValue = "2024-04-12 11:12:34";
            DateTime parsedDate;
            var transactionParser = new TransactionParser();

            // Act
            var parseResult = transactionParser.TryParseDateTimeValue(parsedValue, out parsedDate);

            // Assert
            Assert.IsTrue(parseResult);
            Assert.That(parsedDate.Equals(new DateTime(2024, 4, 12, 11, 12, 34)));
        }

        [Test(Description = "TryParseDateTimeValue - парсинг даты с некорректным форматом ломается")]
        public void TransactionParser_TryParseDateTimeValue_WithIncorrectData_SholdBeNotParse()
        {
            // Arrange
            string parsedValue = "2024-04-12 11:12123";
            DateTime parsedDate;
            var transactionParser = new TransactionParser();

            // Act
            var parseResult = transactionParser.TryParseDateTimeValue(parsedValue, out parsedDate);

            // Assert
            Assert.IsFalse(parseResult);
        }

        [Test(Description = "TryParseIntValue - парсинг некорректного числа должен падать")]
        public void TransactionParser_TryParseIntValue_WithIncorrectData_SholdBeNotParse()
        {
            // Arrange
            string parsedValue = "123d";
            int parsedInt;
            var transactionParser = new TransactionParser();

            // Act
            var parseResult = transactionParser.TryParseIntValue(parsedValue, out parsedInt);

            // Assert
            Assert.IsFalse(parseResult);
        }

        [Test(Description = "TryParseIntValue - парсинг корректного числа должен работать нормально")]
        public void TransactionParser_TryParseIntValue_WithCorrectData_SholdBeParse()
        {
            // Arrange
            string parsedValue = "123.00";
            int parsedInt;
            var transactionParser = new TransactionParser();

            // Act
            var parseResult = transactionParser.TryParseIntValue(parsedValue, out parsedInt);

            // Assert
            Assert.IsTrue(parseResult);
            Assert.That(parsedInt.Equals(123));
        }

        [Test(Description = "TryParseDecimalValue - парсинг корректного числа должен работать нормально")]
        public void TransactionParser_TryParseDecimalValue_WithCorrectData_SholdBeParse()
        {
            // Arrange
            string parsedValue = "123.42";
            decimal parsedDecimal;
            var transactionParser = new TransactionParser();

            // Act
            var parseResult = transactionParser.TryParseDecimalValue(parsedValue, out parsedDecimal);

            // Assert
            Assert.IsTrue(parseResult);
            Assert.That(parsedDecimal.Equals(new decimal(123.42)));
        }

        [Test(Description = "TryParseDecimalValue - парсинг некорректного числа должен падать")]
        public void TransactionParser_TryParseDecimalValue_WithIncorrectData_SholdBeNotParse()
        {
            // Arrange
            string parsedValue = "123qw.42";
            decimal parsedDecimal;
            var transactionParser = new TransactionParser();

            // Act
            var parseResult = transactionParser.TryParseDecimalValue(parsedValue, out parsedDecimal);

            // Assert
            Assert.IsFalse(parseResult);
        }
    }
}