using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Campeonato;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CampeonatoService : ICampeonatoService
    {
        private IRepository<CampeonatoEntity> _repository;

        public CampeonatoService(IRepository<CampeonatoEntity> repository)
        {
            _repository = repository;
        }

        //implementar a criação dos campeonatos
        public Task<CampeonatoEntity> CriaCampeonato()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<CampeonatoEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<CampeonatoEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<CampeonatoEntity> Post(CampeonatoEntity Campeonato)
        {
            return await _repository.InsertAsync(Campeonato);
        }

        public async Task<CampeonatoEntity> Put(CampeonatoEntity Campeonato)
        {
            return await _repository.UpdateAsync(Campeonato);
        }
    }
}
