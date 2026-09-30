using System.CommandLine;
using ExpenseTrackerCLI.Services;

namespace ExpenseTrackerCLI.Commands;

public class DeleteCommand(IExpenseService expenseService) : ICommand
{
    public Command Build()
    {
        var command = new Command("delete", "Delete an existing expense");

        var idArgument = new Argument<Guid>("id");
        
        command.SetAction(result =>
        {
            var id = result.GetRequiredValue(idArgument);
            
            expenseService.Delete(id);
        });
        
        return command;
    }
}