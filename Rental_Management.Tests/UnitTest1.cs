using Microsoft.Extensions.Logging;
using Moq;
using Rental_Management.Business;
using Rental_Management.Business.Interfaces;
using Rental_Management.Business.Services;
using Rental_Management.Business.Entities;
using Rental_Management.Business.Interfaces.Repositories;

namespace Rental_Management.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task SendMailAsync_SendsEmailWithoutThrowing()
        {
            // Act & Assert
            var exception = await Record.ExceptionAsync(() =>
                MailHelper.SendMailAsync("saqerabuhadhoud@gmail.com", "Hi", "This is a test."));

            Assert.Null(exception); // Passes if no error thrown (email sent)
        }

    }
}