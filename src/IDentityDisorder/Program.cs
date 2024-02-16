using System.CommandLine;
using IDentityDisorder.Commands;

var rootCommand = new RootCommand();
var uuidCommand = new UuidCommand();
var ulidCommand = new UlidCommand();

rootCommand.AddCommand(uuidCommand);
rootCommand.AddCommand(ulidCommand);
await rootCommand.InvokeAsync(args).ConfigureAwait(false);
