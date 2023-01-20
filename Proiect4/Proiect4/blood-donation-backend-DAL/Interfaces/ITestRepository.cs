using blood_donation_backend.Entities;

namespace Proiect4.blood_donation_backend_DAL.Interfaces
{
    public interface ITestRepository
    {
        Task Create(Test test);
        Task<List<Test>> GetAllPositives();
    }
}
