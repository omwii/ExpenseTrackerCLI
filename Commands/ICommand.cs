using System.CommandLine;

namespace ExpenseTrackerCLI.Commands;

public interface ICommand
{
    Command Build();
}