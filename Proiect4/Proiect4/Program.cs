using blood_donation_backend.BLL.Interfaces;
using blood_donation_backend.blood_donation_backend.BLL.Interfaces;
using blood_donation_backend.blood_donation_backend.BLL.Services;
using blood_donation_backend.blood_donation_backend.DAL.Interfaces;
using blood_donation_backend.blood_donation_backend.DAL.Repositories;
using blood_donation_backend.Data;
using blood_donation_backend.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IPatientRepository, PatientRepository>();
builder.Services.AddTransient<IPatientService, PatientService>();
builder.Services.AddTransient<IDoctorService, DoctorService>();
builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();
builder.Services.AddTransient<IDonorService, DonorService>();
builder.Services.AddTransient<IDonorRepository, DonorRepository>();
builder.Services.AddTransient<IMedicineService, MedicineService>();
builder.Services.AddTransient<IMedicineRepository, MedicineRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
