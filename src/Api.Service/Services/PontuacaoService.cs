using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Pontuacao;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PontuacaoService : IPontuacaoService
    {
        private IRepository<PontuacaoEntity> _repository;

        public PontuacaoService(IRepository<PontuacaoEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        //implementar a pontuação das partidas do campeonato
        public List<PontuacaoEntity> FinalPontuacaoCampeonato(List<PartidaEntity> PartidasJogadas, CampeonatoEntity CampeonatoJogado, List<TimeEntity> Times)
        {
            throw new NotImplementedException();
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
