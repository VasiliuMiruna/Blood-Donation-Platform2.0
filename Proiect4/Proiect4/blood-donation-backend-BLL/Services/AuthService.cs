using blood_donation_backend.BLL.Interfaces;
using blood_donation_backend.blood_donation_backend.BLL.Interfaces;
using blood_donation_backend.blood_donation_backend.BLL.Models;
using blood_donation_backend.blood_donation_backend.DAL.Entities;
using blood_donation_backend.blood_donation_backend.DAL.Interfaces;
using blood_donation_backend.Entities;
using Microsoft.AspNetCore.Identity;
using Proiect4.blood_donation_backend_BLL.Interfaces;
using Proiect4.blood_donation_backend_DAL.Interfaces;

namespace blood_donation_backend.blood_donation_backend.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUnitofWork _unitOfWork;
        private readonly IDoctorRepository _dotorRepository;
        private readonly IDonorRepository _donorRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IAdminRepository _adminRepository;

        public AuthService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenHelper tokenHelper, IUnitofWork unitOfWork, IDoctorRepository doctorRepository, IDonorRepository donorRepository, IPatientRepository patientRepository, IAdminRepository adminRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHelper = tokenHelper;
            _unitOfWork = unitOfWork;
            
            
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user == null)
                return new LoginResult
                {
                    Success = false

                };
            else
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);
                if (result.Succeeded)
                {
                    var token = await _tokenHelper.CreateAccessToken(user);

                    return new LoginResult
                    {
                        Success = true,
                        AccessToken = token

                    };
                }
                else
                    return new LoginResult
                    {
                        Success = false
                    };
            }


        }
        public async Task Register(RegisterModel registerModel)
        {
            var user = new AppUser
            {
                Email = registerModel.Email,
                UserName = registerModel.Email
                
            };
            var result = await _userManager.CreateAsync(user, registerModel.Password);

                if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, registerModel.Role);
                if(registerModel.Role == "Admin")
                {
                    var admin = new Admin
                    {
                        FirstName = registerModel.FirstName,
                        LastName = registerModel.LastName,
                        User = user,
                        UserId = user.Id

                    };

                    await _unitOfWork.Admins.Create(admin);
                }

                else if (registerModel.Role == "Donor")
                {
                    var donor = new Donor
                    {
                        FirstName = registerModel.FirstName,
                        LastName = registerModel.LastName,
                        User = user,
                        UserId = user.Id

                    };

                    await _unitOfWork.Donors.Create(donor);

                }

                else if (registerModel.Role == "Patient")
                {
                    var patient = new Patient
                    {
                        FirstName = registerModel.Email,
                        LastName = registerModel.Email,
                        User = user,
                        UserId = user.Id

                    };

                    await _unitOfWork.Patients.Create(patient);


                }
                else if (registerModel.Role == "Doctor")
                {
                    var doctor = new Doctor
                    {
                        FirstName = registerModel.Email,
                        LastName = registerModel.Email,
                        User = user,
                        UserId = user.Id
                    };

                    await _unitOfWork.Doctors.Create(doctor);
                }

                await _unitOfWork.SaveChangesAsync();
                

            }
            else
            {
                throw new Exception(String.Join(",", result.Errors.Select(x => x.Code)));
            }

        }
    }
}
