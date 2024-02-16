using System.CommandLine;
using IDentityDisorder.Core;

namespace IDentityDisorder.Commands;

public sealed class UuidCommand : Command
{
    private readonly Option<bool> upperCaseOption;

    public UuidCommand()
        : base("uuid", CommandDescription.UuidCommandDescription)
    {
        this.upperCaseOption = new Option<bool>(
            aliases: ["--upper-case"],
            description: CommandDescription.UuidUpperCaseOptionDescription);
        this.AddOption(this.upperCaseOption);
        this.SetHandlers();
    }

    private void SetHandlers()
    {
        this.SetHandler(async (context) =>
        {
            var upperCase = context.ParseResult.GetValueForOption(this.upperCaseOption);

            await this.RunAsync(upperCase).ConfigureAwait(false);
        });
    }

    private async ValueTask RunAsync(bool upperCase)
    {
        try
        {
            var uuid = IdGenerator.GenerateGuid();
            var uuidString = uuid.ToString();

            Console.WriteLine(upperCase ? uuidString.ToUpperInvariant() : uuidString.ToLowerInvariant());
            await ValueTask.CompletedTask.ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            await Console.Error.WriteLineAsync(exception.ToString()).ConfigureAwait(false);
            Environment.Exit(1);
        }
    }
}
