using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Partida;
using Domain.Interfaces.Services.Time;
using System;
using System.Collections.Generic;
using System.Linq;
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


        // implementar criação das partidas (Round-Robin)
        public async Task<List<PartidaEntity>> CriaPartidas()
        {
            List<TimeEntity> todosTimes = new List<TimeEntity>();
            List<PartidaEntity> partidas = new List<PartidaEntity>(); 
            todosTimes = (List<TimeEntity>)await _timeService.GetAll();


            for (int i = 0; i < todosTimes.Count; i++)
            {
                for (int j = i + 1; j < todosTimes.Count; j++)
                {
                    var partida = new PartidaEntity();
                    partida.TimeUm = todosTimes[i];
                    partida.TimeDois = todosTimes[j];
                    Random rnd = new Random();
                    partida.GolsTimeUm = rnd.Next(1, 5);
                    partida.GolsTimeDois = rnd.Next(1, 5);
                    partidas.Add(partida);
                }

            }
         
            return (partidas);
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
