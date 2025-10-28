using Microsoft.Extensions.Logging;
using Rental_Management.Business.Interfaces;
using Rental_Management.Business.Interfaces.Repositories;
using Rental_Management.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Rental_Management.Business.Services
{
    public abstract class BaseService<TEntity, TDTO, TAddDTO, TUpdateDTO>
     : IService<TDTO, TAddDTO, TUpdateDTO>
     where TEntity : class
     where TDTO : class
     where TAddDTO : class
     where TUpdateDTO : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly ILogger<BaseService<TEntity, TDTO, TAddDTO, TUpdateDTO>> _logger;
        protected readonly IMapper _mapper;

        public BaseService(IRepository<TEntity> repository,
                           ILogger<BaseService<TEntity, TDTO, TAddDTO, TUpdateDTO>> logger,
                           IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public virtual async Task<int> AddAsync(TAddDTO dto)
        {
            if (dto == null)
            {
                _logger.LogWarning($"Invalid {typeof(TAddDTO).Name}");
                return -1;
            }

            var entity = _mapper.Map<TEntity>(dto);
            return await _repository.AddAsync(entity);
        }

        public virtual async Task<OperationResultStatus> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public virtual async Task<TDTO?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<TDTO>(entity);
        }

        public virtual async Task<OperationResultStatus> UpdateAsync(TUpdateDTO dto)
        {
            if (dto == null)
            {
                _logger.LogWarning($"Invalid {typeof(TUpdateDTO).Name}");
                return OperationResultStatus.Failure;
            }

           
            var idProperty = dto.GetType().GetProperty("Id");
            if (idProperty == null)
            {
                _logger.LogWarning($"DTO {typeof(TUpdateDTO).Name} does not have an Id property.");
                return OperationResultStatus.Failure;
            }

            var idValue = idProperty.GetValue(dto);
            if (idValue == null || !(idValue is int id))
            {
                _logger.LogWarning($"Invalid Id value in {typeof(TUpdateDTO).Name}.");
                return OperationResultStatus.Failure;
            }

            
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                _logger.LogWarning($"Entity with Id {id} not found.");
                return OperationResultStatus.NotFound;
            }

            
            _mapper.Map(dto, entity);

            
            return await _repository.UpdateAsync(entity);
        }

    }

}
