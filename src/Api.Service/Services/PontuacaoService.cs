using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Campeonato;
using Domain.Interfaces.Services.Partida;
using Domain.Interfaces.Services.Pontuacao;
using Domain.Interfaces.Services.Time;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PontuacaoService : IPontuacaoService
    {
        private readonly IRepository<PontuacaoEntity> _repository;
        private readonly ITimeService _timeService;
        private readonly IPartidaService _partidaService;
        private readonly ICampeonatoService _campeonatoService;

        public PontuacaoService(IRepository<PontuacaoEntity> repository, ITimeService timeService, IPartidaService partidaService, ICampeonatoService campeonatoService)
        {
            _repository = repository;
            _timeService = timeService;
            _campeonatoService = campeonatoService;
            _partidaService = partidaService;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        //implementar a pontuação das partidas do campeonato
        public List<PontuacaoEntity> FinalPontuacaoCampeonato(Guid CampeonatoID)
        {
            var times = _timeService.GetAll();
            var partidas = _partidaService.GetAll();
            var campeonato = _campeonatoService.Get(CampeonatoID);



            return null;
        }

        public async Task<PontuacaoEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<PontuacaoEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<PontuacaoEntity> Post(PontuacaoEntity Pontuacao)
        {
            return await _repository.InsertAsync(Pontuacao);
        }

        public async Task<PontuacaoEntity> Put(PontuacaoEntity Pontuacao)
        {
            return await _repository.UpdateAsync(Pontuacao);
        }
    }
}
