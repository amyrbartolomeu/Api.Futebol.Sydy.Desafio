using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Partida;
using Domain.Interfaces.Services.Time;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PartidaService : IPartidaService
    {
        private IRepository<PartidaEntity> _repository;
        private ITimeService _timeService;

        public PartidaService(IRepository<PartidaEntity> repository, ITimeService timeService)
        {
            _repository = repository;
            _timeService = timeService;
        }


        // implementar criação das partidas
        public Task<List<PartidaEntity>> CriaPartidas()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<PartidaEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<PartidaEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<PartidaEntity> Post(PartidaEntity Partida)
        {
            return await _repository.InsertAsync(Partida);
        }

        public async Task<PartidaEntity> Put(PartidaEntity Partida)
        {
            return await _repository.UpdateAsync(Partida);
        }
    }
}
