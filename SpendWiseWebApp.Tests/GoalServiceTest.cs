using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using spendwisebase.Models;
using SpendWiseWebApp.Data;
using SpendWiseWebApp.Services;

namespace SpendWiseWebApp.Tests.Services
{
    [TestClass]
    public class GoalServiceTest
    {
        private SpendWiseContext _context;
        private GoalService _goalService;

        [TestInitialize]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<SpendWiseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new SpendWiseContext(options);
            _goalService = new GoalService(_context);

            // Seed the in-memory database with test data
            _context.Goals.AddRange(new List<Goal>
            {
                new Goal { GoalId = 1, Name = "Goal1" },
                new Goal { GoalId = 2, Name = "Goal2" }
            });
            _context.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [TestMethod]
        public async Task GetAllGoalsAsync_ReturnsAllGoals()
        {
            var result = await _goalService.GetAllGoalsAsync();
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public async Task GetGoalByIdAsync_ReturnsGoal()
        {
            var result = await _goalService.GetGoalByIdAsync(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.GoalId);
        }

        [TestMethod]
        public async Task GetGoalByIdAsync_ReturnsNullWhenGoalNotFound()
        {
            var result = await _goalService.GetGoalByIdAsync(99);
            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task AddGoalAsync_AddsGoal()
        {
            var goal = new Goal { GoalId = 3, Name = "Goal3" };
            var result = await _goalService.AddGoalAsync(goal);
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.GoalId);
        }

        [TestMethod]
        public async Task AddGoalAsync_ThrowsExceptionWhenGoalIsNull()
        {
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _goalService.AddGoalAsync(null));
        }

        [TestMethod]
        public async Task UpdateGoalAsync_UpdatesGoal()
        {
            var goal = await _goalService.GetGoalByIdAsync(1);
            goal.Name = "UpdatedGoal";
            var result = await _goalService.UpdateGoalAsync(1, goal);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task UpdateGoalAsync_ReturnsFalseWhenIdMismatch()
        {
            var goal = new Goal { GoalId = 1, Name = "UpdatedGoal" };
            var result = await _goalService.UpdateGoalAsync(2, goal);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task DeleteGoalAsync_DeletesGoal()
        {
            var result = await _goalService.DeleteGoalAsync(1);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task DeleteGoalAsync_ReturnsFalseWhenGoalNotFound()
        {
            var result = await _goalService.DeleteGoalAsync(99);
            Assert.IsFalse(result);
        }
    }
}