using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spendwisebase.Models;
using SpendWiseWebApp.Data; // Added namespace declaration

namespace SpendWiseWebApp.Controllers // Added namespace declaration
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        public ExpenseController(DbContextOptions<SpendWiseContext> options) : base() { }

        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }  
        public DbSet<Goal> Goals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
                
    }
}