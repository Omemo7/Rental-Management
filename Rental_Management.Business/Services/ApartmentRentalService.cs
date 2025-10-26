using AutoMapper;
using Microsoft.Extensions.Logging;
using Rental_Management.Business.DTOs.ApartmentRental;
using Rental_Management.Business.Interfaces;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;
using Shared.DTOs.ApartmentRental;
using System.IO;
using System.Linq;

namespace Rental_Management.Business.Services;

public class ApartmentRentalService : BaseService<ApartmentsRental, ApartmentRentalDTO, AddApartmentRentalDTO, UpdateApartmentRentalDTO>, IApartmentRentalService
{
    private readonly IApartmentRentalRepository _apartmentRentalRepository;

    public ApartmentRentalService(
        IApartmentRentalRepository repository,
        ILogger<ApartmentRentalService> logger,
        IMapper mapper)
        : base(repository, logger, mapper)
    {
        _apartmentRentalRepository = repository;
    }

    public async Task<ICollection<ApartmentRentalDTOForUI>> GetAllApartmentRentalsForLandlordForUI(int landlordId)
    {
        var rentals = await _apartmentRentalRepository.GetAllForLandlordAsync(landlordId);
        return rentals.Select(MapToApartmentRentalDtoForUi).ToList();
    }

    public async Task<ICollection<ApartmentRentalDTOForUI>> GetAllApartmentRentalsForApartment(int apartmentId)
    {
        var rentals = await _apartmentRentalRepository.GetAllForApartmentAsync(apartmentId);
        return rentals.Select(MapToApartmentRentalDtoForUi).ToList();
    }

    public async Task<ICollection<ApartmentRentalDTOForTenant>> GetAllApartmentRentalsForTenant(int tenantId)
    {
        var rentals = await _apartmentRentalRepository.GetAllForTenantAsync(tenantId);
        return rentals.Select(MapToApartmentRentalDtoForTenant).ToList();
    }

    public Task<ICollection<string>> GetContractImageUrlsAsync(int apartmentRentalId, string baseUrl)
    {
        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ContractImages", apartmentRentalId.ToString());
        if (!Directory.Exists(folderPath))
        {
            return Task.FromResult<ICollection<string>>(Array.Empty<string>());
        }

        var fileNames = Directory.GetFiles(folderPath)
            .Select(Path.GetFileName)
            .Where(name => !string.IsNullOrWhiteSpace(name))
            .ToList();

        if (fileNames.Count == 0)
        {
            return Task.FromResult<ICollection<string>>(Array.Empty<string>());
        }

        var urls = fileNames
            .Select(file => $"{baseUrl}/ContractImages/{apartmentRentalId}/{file}")
            .ToList();

        return Task.FromResult<ICollection<string>>(urls);
    }

    private static ApartmentRentalDTOForUI MapToApartmentRentalDtoForUi(ApartmentsRental rental)
    {
        var rentalEntity = rental.Rental;
        var apartment = rental.Apartment;

        return new ApartmentRentalDTOForUI
        {
            Id = rental.Id,
            RentalId = rentalEntity?.Id ?? 0,
            ApartmentId = rental.ApartmentId,
            IsActive = rentalEntity?.IsActive ?? false,
            ApartmentName = apartment?.Name ?? string.Empty,
            TenantId = rentalEntity?.TenantId ?? 0,
            TenantName = rentalEntity?.Tenant?.Name ?? string.Empty,
            RentValue = rentalEntity?.RentValue ?? 0,
            StartDate = rentalEntity?.StartDate ?? default,
            EndDate = rentalEntity?.EndDate ?? default,
            RentPaymentFrequency = rentalEntity?.RentPaymentFrequency?.Frequency ?? string.Empty,
        };
    }

    private static ApartmentRentalDTOForTenant MapToApartmentRentalDtoForTenant(ApartmentsRental rental)
    {
        var rentalEntity = rental.Rental;

        return new ApartmentRentalDTOForTenant
        {
            Id = rental.Id,
            RentalId = rentalEntity?.Id ?? 0,
            IsActive = rentalEntity?.IsActive ?? false,
            ApartmentId = rental.ApartmentId,
            ApartmentName = rental.Apartment?.Name ?? string.Empty,
            RentValue = rentalEntity?.RentValue ?? 0,
            StartDate = rentalEntity?.StartDate ?? default,
            EndDate = rentalEntity?.EndDate ?? default,
            RentPaymentFrequency = rentalEntity?.RentPaymentFrequency?.Frequency ?? string.Empty,
        };
    }
}
