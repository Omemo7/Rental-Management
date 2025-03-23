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

           
           return await _personRepository.AddAsync(person);
             
        }

        public async Task<bool> DeletePersonAsync(int Id)
        {
            return await _personRepository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<PersonDTO>> GetAllPeopleAsync()
        {
            IEnumerable<Person> people = await _personRepository.GetAllAsync();
            return people.Select(p => new PersonDTO
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                DateOfBirth = p.DateOfBirth,
                Email = p.Email
            });
        }

        public async Task<PersonDTO?> GetPersonByIdAsync(int id)
        {
            var person= await _personRepository.GetByIdAsync(id);
            if (person == null)
                return null;
            return new PersonDTO
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                Email = person.Email
            };
        }

        public async Task<bool> UpdatePersonAsync(UpdatePersonDTO dto)
        {
            if(dto == null)
                return false;

            Person person = new Person
            {
                Id =dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
            };
            return await _personRepository.UpdateAsync(person);
        }
    }
}
