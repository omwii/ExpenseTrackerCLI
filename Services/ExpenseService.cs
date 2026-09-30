using ExpenseTrackerCLI.Infrastructure;
using ExpenseTrackerCLI.Models;

namespace ExpenseTrackerCLI.Services;

public class ExpenseService(IExpenseRepository repository) : IExpenseService
{
    private readonly Dictionary<Guid, Expense> _expenses = new();
    
    public void Add(decimal amount, string? description, string? category, DateTime createdAt)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

        var expense = new Expense(Guid.NewGuid(), amount, description, category, createdAt);
        
        _expenses.Add(expense.Id, expense);

        try
        {
            repository.Write(expense);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.Message);
            throw;
        }
    }

    public void Update(Guid id, decimal? amount, string? description, string? category)
    {
        if (!_expenses.TryGetValue(id, out var expense)) throw new KeyNotFoundException();
        
        expense.Amount = amount ??  expense.Amount;
        expense.Description = description ??  expense.Description;
        expense.Category = category ??  expense.Category;
        expense.ModifiedAt = DateTime.Now;
        
        repository.Write(expense);
    }

    public void Delete(Guid id)
    {
        if (!_expenses.Remove(id)) throw new KeyNotFoundException();
        
        repository.Delete(id);
    }
}