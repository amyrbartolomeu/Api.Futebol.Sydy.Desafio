using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class TimeRepository : ITimeRepository
    {
        private readonly MyContext _context;
        private readonly DbSet<TimeEntity> _times;

        public TimeRepository(MyContext context)
        {
            _context = context;
            _times = _context.Set<TimeEntity>();
        }

        public async Task<IEnumerable<TimeEntity>> SelectAllAsync()
        {
            return await _times.ToListAsync();
        }
        public async Task<IEnumerable<TimeEntity>> SelectAsync(int page = 1, int pageSize = 10)
        {
            return await _times.OrderBy(x => x.Nome).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public Task<TimeEntity> SelectByName(string name)
        {
            return _times.FirstOrDefaultAsync(p => p.Nome == name);
        }
    }
}
