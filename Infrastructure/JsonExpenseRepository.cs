using System.Text.Json;
using ExpenseTrackerCLI.Models;

namespace ExpenseTrackerCLI.Infrastructure;

public class JsonExpenseRepository : IExpenseRepository
{
    private static readonly JsonSerializerOptions SerializerOptions = new() { WriteIndented = true };

    public IEnumerable<Expense> GetAll()
    {
        EnsureDirectoryExists();

        var expensesPaths = Directory.EnumerateFiles("Expenses");
        return
        [
            .. expensesPaths.Select(File.ReadAllText)
                .Select(file => JsonSerializer.Deserialize<Expense>(file))
                .OfType<Expense>()
        ];
    }

    public Expense? GetById(Guid id)
    {
        EnsureDirectoryExists();

        var path = Path.Combine("Expenses", $"{id.ToString()}.json");

        return File.Exists(path) ? JsonSerializer.Deserialize<Expense>(File.ReadAllText(path)) : null;
    }

    public void Write(Expense expense)
    {
        EnsureDirectoryExists();

        var path = Path.Combine("Expenses", $"{expense.Id.ToString()}.json");

        var json = JsonSerializer.Serialize(expense, SerializerOptions);

        File.WriteAllText(path, json);
    }

    public void Delete(Guid id)
    {
        EnsureDirectoryExists();

        var path = Path.Combine("Expenses", id.ToString());
        
        File.Delete(path);
    }

    private void EnsureDirectoryExists()
    {
        if (!Directory.Exists("Expenses"))
            Directory.CreateDirectory("Expenses");
    }
}