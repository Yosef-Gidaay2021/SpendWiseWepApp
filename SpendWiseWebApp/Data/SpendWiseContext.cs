namespace SpendWiseWebApp.Data;


using Microsoft.EntityFrameworkCore;
using spendwisebase.Models;

public class SpendWiseContext: DbContext {
    public DbSet<Goal> Goals {get; set;} = null;

    public DbSet<User> Users { get; set; }

    public DbSet<Receipt> Receipts { get; set; }

    public DbSet<Transaction> Transactions {get; set;} = null;


}