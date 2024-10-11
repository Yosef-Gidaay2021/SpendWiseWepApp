namespace spendwisebase.Models;


using System;

public class Transaction
{
    public int TransactionId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public int ExpenseCategoryId { get; set; } // Foreign Key to ExpenseCategory
    public int UserId { get; set; } // Foreign Key to User

    public User User { get; set; }

    // Navigation for linked receipt
    public Receipt Receipt { get; set; }
}