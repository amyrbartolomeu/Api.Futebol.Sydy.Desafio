using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Partida
{
    public interface IPartidaService
    {
        Task<List<PartidaModel>> CriaPartidas();
    }
}
