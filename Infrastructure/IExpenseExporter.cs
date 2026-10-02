using ExpenseTrackerCLI.Models;

namespace ExpenseTrackerCLI.Infrastructure;

public interface IExpenseExporter
{
    void Export(IEnumerable<Expense> expenses, FileInfo path);
}