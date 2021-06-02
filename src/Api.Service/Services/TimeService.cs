using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Time;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TimeService : ITimeService
    {
        private IRepository<TimeEntity> _repository;
        private ITimeRepository _timeRepository;

        public TimeService(IRepository<TimeEntity> repository, ITimeRepository timeRepository)
        {
            _repository = repository;
            _timeRepository = timeRepository;

        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<TimeEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<TimeEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<TimeEntity> Post(TimeEntity Time)
        {
            var resultByName = await _timeRepository.SelectByName(Time.Nome);
            if (resultByName == null)
            {
                return await _repository.InsertAsync(Time);
            }
            else
            {
                throw new Exception("nomes duplicados");
            }
        }

        public async Task<TimeEntity> Put(TimeEntity Time)
        {
            return await _repository.UpdateAsync(Time);
        }
    }
}
