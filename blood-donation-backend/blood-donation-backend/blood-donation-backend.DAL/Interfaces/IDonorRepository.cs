﻿using blood_donation_backend.Entities;

namespace blood_donation_backend.blood_donation_backend.DAL.Interfaces
{
    public interface IDonorRepository
    {
        Task Create(Donor donor);
        Task<List<Donor>> GetAll();
        Task<Donor> GetById(Guid id);
        Task UpdateDonor(Donor donor);
    }
}
