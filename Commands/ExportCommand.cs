using System.CommandLine;
using ExpenseTrackerCLI.Infrastructure;
using ExpenseTrackerCLI.Services;

namespace ExpenseTrackerCLI.Commands;

public class ExportCommand(IExpenseService expenseService, IExpenseExporter expenseExporter) : ICommand
{
    public Command Build()
    {
        var command = new Command("export", "Export all expenses into CSV file");
        
        var pathArgument = new Argument<FileInfo>("path");
        
        command.Add(pathArgument);
        
        command.SetAction(result =>
        {
            var expenses = expenseService.Expenses;
            var path = result.GetRequiredValue(pathArgument);
            
            expenseExporter.Export(expenses.Values.ToList(), path);
        });
        
        return command;
    }
}