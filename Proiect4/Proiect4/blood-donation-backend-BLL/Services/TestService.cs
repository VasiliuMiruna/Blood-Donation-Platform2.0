using blood_donation_backend.Entities;
using Proiect4.blood_donation_backend_BLL.Interfaces;
using Proiect4.blood_donation_backend_BLL.Models;
using Proiect4.blood_donation_backend_DAL.Interfaces;

namespace Proiect4.blood_donation_backend_BLL.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task Create(TestModel test)
        {

            var newTest = new Test
            {
                TestId = new Guid(),
                Date = DateTime.Now,
                Type = test.Type,
                Result = test.Result,
                DoctorId = test.DoctorId,
                PatientId = test.PatientId,
                DonorId = test.DonorId,

            };

            await _testRepository.Create(newTest);

        }
        public async Task<List<Guid>> GetPositives()
        {
            var tests = await _testRepository.GetAllPositives();
            var list = new List<Guid>();
            foreach (var test in tests)
            {
                list.Add(test.TestId);
            }
            return list;

        }
    }
}
