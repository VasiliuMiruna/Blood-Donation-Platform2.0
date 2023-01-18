using blood_donation_backend.blood_donation_backend.BLL.Models;

namespace blood_donation_backend.blood_donation_backend.BLL.Interfaces
{
    public interface IAuthService
    {
        Task Register(RegisterModel registerModel);
        Task<LoginResult> Login(LoginModel loginModel);
    }
}
