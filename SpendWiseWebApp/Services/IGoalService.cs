using spendwisebase.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpendWiseWebApp.Services
{
    public interface IGoalService
    {
        Task<IEnumerable<Goal>> GetAllGoalsAsync();
        Task<Goal> GetGoalByIdAsync(int id);
        Task<Goal> AddGoalAsync(Goal goal);
        Task<bool> UpdateGoalAsync(int id, Goal goal);
        Task<bool> DeleteGoalAsync(int id);
    }
}
