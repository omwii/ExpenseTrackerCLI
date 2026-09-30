namespace ExpenseTrackerCLI.Models;

public struct Expense(
    Guid id,
    decimal amount,
    string? description,
    string? category,
    DateTime createdAt)
{
    public Guid Id { get; init; } = id;
    public decimal Amount { get; set; } = amount;
    public string? Description { get; set; } = description;
    public string? Category { get; set; } = category;
    public DateTime CreatedAt { get; init; } = createdAt;
    public DateTime ModifiedAt { get; set; } = createdAt;
}