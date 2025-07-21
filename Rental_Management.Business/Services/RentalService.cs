using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Rental_Management.Business.Interfaces;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;
using Rental_Management.DataAccess.Repositories;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Services
{
    public abstract class RentalService<TEntity, TDTO, TAddDTO, TUpdateDTO> : IService<TDTO, TAddDTO, TUpdateDTO>
        where TEntity : class
        where TDTO : class
        where TAddDTO : class
        where TUpdateDTO : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IRentalRepository _rentalRepository;
        protected readonly ILogger<RentalService<TEntity, TDTO, TAddDTO, TUpdateDTO>> _logger;
        protected readonly IMapper _mapper;

        public RentalService(IRentalRepository rentalRepository,IRepository<TEntity> repository,
                           ILogger<RentalService<TEntity, TDTO, TAddDTO, TUpdateDTO>> logger,
                           IMapper mapper)
        {
           _rentalRepository = rentalRepository;
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<int> AddAsync(TAddDTO AddDTO)
        {
            if (AddDTO == null)
            {
                _logger.LogWarning($"Invalid {typeof(TAddDTO).Name}");
                return -1;
            }



            return await _repository.AddAsync(_mapper.Map<TEntity>(AddDTO));
        }

        public async Task<OperationResultStatus> DeleteAsync(int Id)
        {

            throw new NotImplementedException();

        }

        public Task<TDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResultStatus> UpdateAsync(TUpdateDTO UpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
