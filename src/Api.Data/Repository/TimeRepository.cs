using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Task<TimeEntity> SelectByName(string name)
        {
            return _times.FirstOrDefaultAsync(p => p.Nome == name);
        }
    }
}
