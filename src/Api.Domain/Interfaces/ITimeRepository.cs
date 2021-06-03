using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITimeRepository
    {
        Task<IEnumerable<TimeEntity>> SelectAllAsync();
        Task<IEnumerable<TimeEntity>> SelectAsync(int page = 0, int pageSize = 10);
        Task<TimeEntity> SelectByName(string name);   
    }
}
