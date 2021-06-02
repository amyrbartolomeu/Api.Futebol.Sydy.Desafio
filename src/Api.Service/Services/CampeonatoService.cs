using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Campeonato;
using Domain.Interfaces.Services.Partida;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CampeonatoService : ICampeonatoService
    {
        private IRepository<CampeonatoEntity> _repository;
        private IPartidaService _partidaService;

        public CampeonatoService(IRepository<CampeonatoEntity> repository, IPartidaService partida)
        {
            _partidaService = partida;
            _repository = repository;
        }

        //implementar a criação dos campeonatos, arrumar
        public async Task<CampeonatoEntity> CriaCampeonato()
        {
            var campeonato = new CampeonatoEntity();
            var partidas = await _partidaService.CriaPartidas();
            campeonato.Partidas = partidas;

            var campeonatoFim = await _repository.InsertAsync(campeonato);

            partidas.ForEach(partida => _partidaService.Post(partida));
            return campeonatoFim;

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
