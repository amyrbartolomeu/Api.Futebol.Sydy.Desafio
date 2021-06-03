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
        private IRepository<CampeonatoEntity> _repository;
        private IPartidaService _partidaService;
        private ITimeService _timeService;
        public CampeonatoService(IRepository<CampeonatoEntity> repository, IPartidaService partida, ITimeService timeService)
        {
            _partidaService = partida;
            _repository = repository;
            _timeService = timeService;
        }

        //implementar a criação dos campeonatos, arrumar
        public async Task<CampeonatoEntity> CriaCampeonato()
        {
            var campeonato = new CampeonatoEntity();
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
            //pegar todos os times e criar uma lista(ou dicionario) para pontuação
            //pegar os pontos nas partidas
            //pegar o maior time, adicionar como campeao, apagar repitir (ou ordemby)
            //var campeonatoFim = await _repository.InsertAsync(campeonato);

            //partidas.ForEach(partida => _partidaService.Post(partida));
            return campeonato;

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
