using Proiect4.blood_donation_backend_BLL.Models;

namespace Proiect4.blood_donation_backend_BLL.Interfaces
{
    public interface ITestService
    {
        Task Create(TestModel test);
        Task<List<Guid>> GetPositives();
    }
}
