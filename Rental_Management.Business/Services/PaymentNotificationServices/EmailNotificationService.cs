using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Rental_Management.Business.Interfaces;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;
using Rental_Management.DataAccess.Migrations;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Services.PaymentNotificationServices
{
    public class EmailNotificationService /*: IPaymentNotification*/
    {
        ILandlordRepository _landlordRepository;
        
        ILogger<EmailNotificationService> _logger;

        public EmailNotificationService(ILandlordRepository repository,  ILogger<EmailNotificationService> logger)
        {
            _landlordRepository = repository;
            
            _logger = logger;
        }
        public async Task NotifyAllLandlords()
        {
            ICollection<Landlord> landlords = await _landlordRepository.GetAllAsync();
            foreach (var landlord in landlords)
            {
                await NotifyLandlord(landlord);
            }

        }
        public async Task NotifyLandlord(Landlord landlord)
        {
            try
            {
                var RentalsForLandlord = await _landlordRepository.GetAllActiveApartmentRentalsForLandlord(landlord.Id);
                var RentalsWithDueDate = RentalsForLandlord.Where(r => (DateTime.Now - r.Rental.LastNotificationDate.ToDateTime(TimeOnly.MinValue)).Days >= GetDaysForRentalPaymentFrequency(r.Rental));

                string message = RentalsReport(RentalsWithDueDate.ToList());

                await MailHelper.SendMailAsync(landlord.Email, "Apartment Rentals Report", message);
                _logger.LogInformation($"Email sent to {landlord.Name} at {landlord.Email} successfully");
            }
            catch (Exception)
            {
                _logger.LogError($"Error sending email to {landlord.Name} at {landlord.Email}");
            }

        }
        private string RentalsReport(ICollection<ApartmentsRental> rentals)
        {
            decimal TotalRentToBeCollected=rentals.Sum(r => r.Rental.RentValue);
            string RentalsInfo=string.Join("\n", rentals.Select(r => $"{r.Apartment.ApartmentBuilding.StreetAddress}/{r.Apartment.FloorNumber}/{r.Rental.Tenant.Name}/{r.Rental.RentValue}"));
            string report = $@"Dear Landlord, 
                This is a reminder that the following apartment rentals are due for payment:
                {RentalsInfo}
                with total amount = {TotalRentToBeCollected}";

            return report;
        }
        private int GetDaysForRentalPaymentFrequency(Rental rental)
        {

            switch (rental.RentPaymentFrequency)
            {
                case RentPaymentFrequency.Daily:
                    return 1;
                case RentPaymentFrequency.Weekly:
                    return 7;
                case RentPaymentFrequency.Monthly:
                    return 30;
                case RentPaymentFrequency.Yearly:
                    return 365;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
    }
}
