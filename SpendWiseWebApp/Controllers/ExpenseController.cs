using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spendwisebase.Models;
using SpendWiseWebApp.Data;
using System.Collections.Generic;
 using System.Linq;
using System.Threading.Tasks;

namespace SpendWiseWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly SpendWiseContext _context;

        public ExpenseController(SpendWiseContext context)
        {
            _context = context;
        }

        // GET: api/Expense
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseCategory>>> GetExpenseCategories()
        {
            return await _context.ExpenseCategories.ToListAsync();
        }

        // GET: api/Expense/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseCategory>> GetExpenseCategory(int id)
        {
            var expenseCategory = await _context.ExpenseCategories.FindAsync(id);

            if (expenseCategory == null)
            {
                return NotFound();
            }

            return expenseCategory;
        }

        // POST: api/Expense
        [HttpPost]
        public async Task<ActionResult<ExpenseCategory>> PostExpenseCategory(ExpenseCategory expenseCategory)
        {
            _context.ExpenseCategories.Add(expenseCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExpenseCategory), new { id = expenseCategory.ExpenseCategoryId }, expenseCategory);
        }

        // PUT: api/Expense/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpenseCategory(int id, ExpenseCategory expenseCategory)
        {
            if (id != expenseCategory.ExpenseCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(expenseCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Expense/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpenseCategory(int id)
        {
            var expenseCategory = await _context.ExpenseCategories.FindAsync(id);
            if (expenseCategory == null)
            {
                return NotFound();
            }

            _context.ExpenseCategories.Remove(expenseCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExpenseCategoryExists(int id)
        {
            return _context.ExpenseCategories.Any(e => e.ExpenseCategoryId == id);
        }
    }
}