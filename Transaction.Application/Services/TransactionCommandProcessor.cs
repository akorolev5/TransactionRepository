using MediatR;
using Transaction.Application.Commands;
using Transaction.Application.Interfaces;

namespace Transaction.Application.Services;

public class TransactionCommandProcessor : ITransactionCommandProcessor
{
    private readonly ITransactionParser _transactionParser;
    private readonly IMediator _mediator;
    private const string addCommand = "add";
    private const string getCommand = "get";
    private const string exitCommand = "exit";

    public TransactionCommandProcessor(ITransactionParser transactionParser, IMediator mediator)
    {
        this._transactionParser = transactionParser;
        this._mediator = mediator;
    }

    public void Process()
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Введите название команды:");
            var command = Console.ReadLine();
            if (command.Equals(addCommand, StringComparison.InvariantCultureIgnoreCase))
            {
                var transactionId = GetIntFromCommandInput("Введите Id:", "Некорректно введены чсиловые данные");
                var transactionDateTime = GetDateTimeFromCommandInput("Введите дату:", "Некорректно введены данные даты/времени");
                var amount = GetDecimalFromCommandInput("Введите сумму:", "Некорректно введена сумма");
                _mediator.Send(new AddTransactionCommand(transactionId, transactionDateTime, amount));
            }
            else if (command.Equals(getCommand, StringComparison.InvariantCultureIgnoreCase))
            {
                var transactionId = GetIntFromCommandInput("Введите Id:", "Некорректно введены чсиловые данные");
                _mediator.Send(new GetTransactionCommand(transactionId));
            }
            else if (command.Equals(exitCommand, StringComparison.InvariantCultureIgnoreCase))
            {
                break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} {1}", "Введена некорректная команда", Environment.NewLine);
            }
        }
    }

    private int GetIntFromCommandInput(string commandMessage, string errorMessage)
    {
        while (true)
        {
            PrintInputMessage(commandMessage);
            string commandValue = Console.ReadLine();
            int value = 0;
            if (_transactionParser.TryParseIntValue(commandValue, out value))
            {
                return value;
            }
            PrintError(errorMessage);
        }
    }

    private decimal GetDecimalFromCommandInput(string commandMessage, string errorMessage)
    {
        while (true)
        {
            PrintInputMessage(commandMessage);
            string commandValue = Console.ReadLine();
            decimal value = 0;
            if (_transactionParser.TryParseDecimalValue(commandValue, out value))
            {
                return value;
            }
            PrintError(errorMessage);
        }
    }

    private DateTime GetDateTimeFromCommandInput(string commandMessage, string errorMessage)
    {
        while (true)
        {
            PrintInputMessage(commandMessage);
            string commandValue = Console.ReadLine();
            DateTime dateTimeValue;
            if (_transactionParser.TryParseDateTimeValue(commandValue, out dateTimeValue))
            {
                return dateTimeValue;
            }
            PrintError(errorMessage);
        }
    }

    private void PrintInputMessage(string commandMessage)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(commandMessage);
    }

    private void PrintError(string errorMessage)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("{0} {1}", errorMessage, Environment.NewLine);
    }
}