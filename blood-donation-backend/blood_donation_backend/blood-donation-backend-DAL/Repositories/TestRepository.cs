using blood_donation_backend.Data;
using blood_donation_backend.Entities;
using Proiect4.blood_donation_backend_DAL.Interfaces;

namespace Proiect4.blood_donation_backend_DAL.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly AppDbContext _db;

        public TestRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task Create(Test test)
        {
            await _db.Tests.AddAsync(test);
            await _db.SaveChangesAsync();
        }
        public async Task<List<Test>> GetAllPositives()
        {
            var tests = _db.Tests
            .Where(t => t.Type == "Blood Test" && t.Result == "Positive")
            .ToList();
            return tests;
        }
    }
}
