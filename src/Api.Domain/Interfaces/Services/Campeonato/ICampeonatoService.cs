using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Campeonato
{
    public interface ICampeonatoService
    {
        Task<CampeonatoModel> CriaCampeonato();
    }
}
