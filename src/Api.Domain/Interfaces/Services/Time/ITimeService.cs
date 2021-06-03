using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Time
{
    public interface ITimeService
    {
        Task<TimeEntity> Get(Guid id);
        Task<IEnumerable<TimeEntity>> GetPaginado(int page, int pageSize);
        Task<TimeEntity> Post(TimeEntity Time);
        Task<TimeEntity> Put(TimeEntity Time);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<TimeEntity>> GetAll();
    }
}
