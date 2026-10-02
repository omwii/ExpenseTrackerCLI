using ExpenseTrackerCLI.Models;

namespace ExpenseTrackerCLI.Services;

public interface IExpenseService
{
    public Dictionary<Guid, Expense> Expenses { get; }
    public void Add(decimal amount, string? description, string? category, DateTime createdAt);
    public void Update(Guid id, decimal? amount, string? description, string? category);
    public void Delete(Guid id);
}