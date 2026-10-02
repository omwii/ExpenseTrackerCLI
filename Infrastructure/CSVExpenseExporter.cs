using System.Collections;
using System.Globalization;
using CsvHelper;
using ExpenseTrackerCLI.Models;

namespace ExpenseTrackerCLI.Infrastructure;

public class CsvExpenseExporter : IExpenseExporter
{
    public void Export(IEnumerable<Expense> expenses, FileInfo path)
    {
        using var writer = new StreamWriter(path.FullName);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords((IEnumerable)expenses);
    }
}