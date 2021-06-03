using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Campeonato;
using Domain.Interfaces.Services.Partida;
using Domain.Interfaces.Services.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CampeonatoService : ICampeonatoService
    {
        private IPartidaService _partidaService;
        private ITimeService _timeService;
        public CampeonatoService(IPartidaService partida, ITimeService timeService)
        {
            _partidaService = partida;
            _timeService = timeService;
        }

        public async Task<CampeonatoModel> CriaCampeonato()
        {
            var campeonato = new CampeonatoModel();
            var partidas = await _partidaService.CriaPartidas();
            campeonato.Partidas = partidas;

            Dictionary<string, int> timesEPontos = new Dictionary<string, int> { };
            var times = await _timeService.GetAll();
            foreach (var time in times)
            {
                timesEPontos.Add(time.Nome, 0);
            }
            foreach (var item in campeonato.Partidas)
            {
                if (item.GolsTimeUm > item.GolsTimeDois)
                {
                    timesEPontos[item.TimeUm.Nome] += 3;
                }
                if (item.GolsTimeUm == item.GolsTimeDois)
                {
                    timesEPontos[item.TimeUm.Nome] += 1;
                    timesEPontos[item.TimeDois.Nome] += 1;
                }
                if (item.GolsTimeUm < item.GolsTimeDois)
                {
                    timesEPontos[item.TimeDois.Nome] += 3;
                }
            }


            var timesOrdenados = timesEPontos.OrderByDescending(key => key.Value).ToList();


            campeonato.Campeao = timesOrdenados[0].Key;
            campeonato.ViceCampeao = timesOrdenados[1].Key;
            campeonato.TerceiroLugar = timesOrdenados[2].Key;
            
            return campeonato;

        }

        
    }
}
