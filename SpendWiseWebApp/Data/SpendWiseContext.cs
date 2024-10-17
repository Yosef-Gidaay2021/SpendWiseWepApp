using Microsoft.EntityFrameworkCore;
using spendwisebase.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SpendWiseWebApp.Data
{
    public class SpendWiseContext : IdentityDbContext<IdentityUser>  {

         public SpendWiseContext(DbContextOptions<SpendWiseContext> options) : base(options){}
        public DbSet<Goal> Goals { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<ExpenseCategory> ExpenseCategories { get; set; } 
    }
}