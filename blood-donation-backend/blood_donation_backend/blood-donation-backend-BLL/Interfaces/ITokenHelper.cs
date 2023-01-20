using blood_donation_backend.blood_donation_backend.DAL.Entities;
using System.Security.Claims;

namespace blood_donation_backend.blood_donation_backend.BLL.Interfaces
{
    public interface ITokenHelper
    {
        Task<String> CreateAccessToken(AppUser _User);
        string CreateRefreshToken(AppUser _User);
        ClaimsPrincipal GetPrincipalFromRefreshToken(string _Token);

    }
}
