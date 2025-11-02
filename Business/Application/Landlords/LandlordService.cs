using Business.Application.Abstractions;
using Business.Application.Landlords.Commands;
using RentalManagement.Business.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Application.Landlords
{
    public class LandlordService : ILandlordService
    {
        private readonly IIdentityService _identity;
        private readonly ILandlordRepository _landlords;
        private readonly IUnitOfWork _uow;

        public LandlordService(
            IIdentityService identity,
            ILandlordRepository landlords,
            IUnitOfWork uow)
        {
            _identity = identity;
            _landlords = landlords;
            _uow = uow;
        }

        public async Task<Guid> Add(AddLandlordCommand cmd)
        {
            // Basic in-service validation
            if (string.IsNullOrWhiteSpace(cmd.Email) || !Regex.IsMatch(cmd.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Invalid email format.", nameof(cmd.Email));

            if (string.IsNullOrWhiteSpace(cmd.Password) || cmd.Password.Length < 6)
                throw new ArgumentException("Password must be at least 6 characters long.", nameof(cmd.Password));

            if (string.IsNullOrWhiteSpace(cmd.FirstName))
                throw new ArgumentException("First name is required.", nameof(cmd.FirstName));

            if (await _identity.IsEmailTaken(cmd.Email))
                throw new InvalidOperationException("Email is already registered.");

            var userId = await _identity.CreateUser(cmd.Email, cmd.Password); //this here has its own AppDbContext 

            var landlord = new Landlord(userId, cmd.FirstName, cmd.LastName);


            await _landlords.AddAsync(landlord);

            await _uow.SaveChanges(); //this is just for landlord, doesn't affect identity user(not transaction)

            return landlord.Id;
        }

        public async Task<Landlord?> GetById(Guid id)
        {
            return await _landlords.GetByIdAsync(id);
        }

        public async Task<bool> Update(Guid id, UpdateLandlordCommand cmd)
        {
            var landlord = await _landlords.GetByIdAsync(id);
            if (landlord == null) return false;

            landlord.ChangeFullName(cmd.FirstName, cmd.LastName);
            _landlords.Update(landlord);

            await _uow.SaveChanges();
            return true;
        }
    }
}
