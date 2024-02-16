using System.CommandLine;
using IDentityDisorder.Core;

namespace IDentityDisorder.Commands;

public sealed class UlidCommand : Command
{
    private readonly Option<DateTimeOffset?> timestampOption;

    private readonly Option<bool> uuidFormatOption;

    private readonly Option<bool> upperCaseOption;

    public UlidCommand()
        : base("ulid", CommandDescription.UlidCommandDescription)
    {
        this.timestampOption = new Option<DateTimeOffset?>(
            aliases: ["-t", "--timestamp"],
            description: CommandDescription.UlidTimestampOptionDescription,
            parseArgument: result =>
            {
                if (result.Tokens.Count is 0)
                {
                    return null;
                }

                if (DateTimeOffset.TryParse(result.Tokens[0].Value, out var timestamp))
                {
                    return timestamp;
                }

                return null;
            });
        this.uuidFormatOption = new Option<bool>(
            aliases: ["--uuid-format"],
            description: CommandDescription.UlidUuidFormatOptionDescription);
        this.upperCaseOption = new Option<bool>(
            aliases: ["--upper-case"],
            description: CommandDescription.UlidUpperCaseOptionDescription);
        this.AddOption(this.timestampOption);
        this.AddOption(this.uuidFormatOption);
        this.AddOption(this.upperCaseOption);
        this.SetHandlers();
    }

    private void SetHandlers()
    {
        this.SetHandler(async (context) =>
        {
            var timestamp = context.ParseResult.GetValueForOption(this.timestampOption);
            var uuidFormat = context.ParseResult.GetValueForOption(this.uuidFormatOption);
            var upperCase = context.ParseResult.GetValueForOption(this.upperCaseOption);

            await this.RunAsync(timestamp, uuidFormat, upperCase).ConfigureAwait(false);
        });
    }

    private async ValueTask RunAsync(
        DateTimeOffset? timestamp,
        bool uuidFormat,
        bool upperCase)
    {
        try
        {
            var ulid = IdGenerator.GenerateUlid(timestamp);
            var ulidString = uuidFormat ? ulid.ToGuid().ToString() : ulid.ToString();

            Console.WriteLine(upperCase ? ulidString.ToUpperInvariant() : ulidString.ToLowerInvariant());
            await ValueTask.CompletedTask.ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            await Console.Error.WriteLineAsync(exception.ToString()).ConfigureAwait(false);
            Environment.Exit(1);
        }
    }
}
