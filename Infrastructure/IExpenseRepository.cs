using ExpenseTrackerCLI.Models;

namespace ExpenseTrackerCLI.Infrastructure;

public interface IExpenseRepository
{
    public IEnumerable<Expense> GetAll();
    public Expense? GetById(Guid id);
    public void Write(Expense expense);
    public void Delete(Guid id);
}