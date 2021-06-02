using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITimeRepository
    {
        Task<TimeEntity> SelectByName(string name);   
    }
}
