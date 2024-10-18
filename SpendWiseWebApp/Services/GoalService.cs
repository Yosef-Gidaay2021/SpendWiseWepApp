using System.Collections.Generic;
using System.Threading.Tasks;
using spendwisebase.Models;
using SpendWiseWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace SpendWiseWebApp.Services
{
    public class GoalService : IGoalService
    {
        private readonly SpendWiseContext _context;

        public GoalService(SpendWiseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Goal>> GetAllGoalsAsync()
        {
            return await _context.Goals.ToListAsync();
        }

        public async Task<Goal> GetGoalByIdAsync(int id)
        {
            return await _context.Goals.FindAsync(id);
        }

        public async Task<Goal> AddGoalAsync(Goal goal)
        {
            _context.Goals.Add(goal);
            await _context.SaveChangesAsync();
            return goal;
        }

        public async Task<bool> UpdateGoalAsync(int id, Goal goal)
        {
            if (id != goal.GoalId)
            {
                return false;
            }

            _context.Entry(goal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteGoalAsync(int id)
        {
            var goal = await _context.Goals.FindAsync(id);
            if (goal == null)
            {
                return false;
            }

            _context.Goals.Remove(goal);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
