using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Pontuacao
{
    public interface IPontuacaoService
    {
        Task<PontuacaoEntity> Get(Guid id);
        Task<IEnumerable<PontuacaoEntity>> GetAll();
        Task<PontuacaoEntity> Post(PontuacaoEntity Pontuacao);
        Task<PontuacaoEntity> Put(PontuacaoEntity Pontuacao);
        Task<bool> Delete(Guid id);
        List<PontuacaoEntity> FinalPontuacaoCampeonato(Guid CampeonatoJogado);
    }
}
