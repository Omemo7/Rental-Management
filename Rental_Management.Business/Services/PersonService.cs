using Rental_Management.Business.DTOs;
using Rental_Management.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental_Management.DataAccess.Repositories;
using Rental_Management.DataAccess.Interfaces;
using Rental_Management.DataAccess.Entities;
using Microsoft.Identity.Client;

namespace Rental_Management.Business.Services
{
    public class PersonService : IPersonService
    {
        readonly IRepository<Person> _personRepository;

        public PersonService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<bool> AddPersonAsync(AddPersonDTO dto)
        {
            if (dto == null)
                return false;

            Person person = new Person
            {
                NationalNumber = dto.NationalNumber,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
               
            };

            try
            {
                await _personRepository.AddAsync(person);
                return true;
            }
            catch
            {
                return false;
            }


        }
    }
}
