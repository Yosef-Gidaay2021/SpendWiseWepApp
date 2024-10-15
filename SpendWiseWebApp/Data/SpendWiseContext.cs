namespace SpendWiseWebApp.Data;


using Microsoft.EntityFrameworkCore;
using spendwisebase.Models;

public class SpendWiseContext: DbContext {
     public SpendWiseContext(DbContextOptions<SpendWiseContext> options)
        : base(options) {}
    public DbSet<Goal> Goals {get; set;} = null;

    public DbSet<User> Users {get; set;} = null;

    public DbSet<Receipt>  Receipts {get; set;} = null;

    public DbSet<Transaction> Transactions {get; set;} = null;

    public DbSet<ExpenseCategory> ExpenseCategories {get; set;} = null;




}