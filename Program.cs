using System.CommandLine;
using ExpenseTrackerCLI.Commands;

// Root command
var rootCommand = new RootCommand("CLI tool for tracking your expenses");
rootCommand.Add(new AddCommand());
rootCommand.Add(new DeleteCommand());
rootCommand.Add(new ExportCommand());
rootCommand.Add(new ListCommand());
rootCommand.Add(new SetBudgetCommand());
rootCommand.Add(new UpdateCommand());