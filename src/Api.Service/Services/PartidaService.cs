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
        private ITimeService _timeService;

        public PartidaService(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public async Task<List<PartidaModel>> CriaPartidas()
        {
            List<PartidaModel> partidas = new List<PartidaModel>();
            var todosTimes = (await _timeService.GetAll()).ToList();


            for (int i = 0; i < todosTimes.Count; i++)
            {
                for (int j = i + 1; j < todosTimes.Count; j++)
                {
                    var partida = new PartidaModel();
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

    }
}
