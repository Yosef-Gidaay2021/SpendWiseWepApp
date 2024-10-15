using Microsoft.EntityFrameworkCore;
using spendwisebase.Models;

namespace SpendWiseWebApp.Data
{
    public class SpendWiseContext : DbContext {

         public SpendWiseContext(DbContextOptions<SpendWiseContext> options) : base(options)
        {
        }
        public DbSet<Goal> Goals { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<ExpenseCategory> ExpenseCategories { get; set; } 
    }
}