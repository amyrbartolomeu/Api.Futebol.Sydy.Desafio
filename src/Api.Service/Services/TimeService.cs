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

        public TimeService(IRepository<TimeEntity> repository)
        {
            _repository = repository;
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
            return await _repository.InsertAsync(Time);
        }

        public async Task<TimeEntity> Put(TimeEntity Time)
        {
            return await _repository.UpdateAsync(Time);
        }
    }
}
