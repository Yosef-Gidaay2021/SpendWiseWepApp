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

        // more test methods here...
    }
}