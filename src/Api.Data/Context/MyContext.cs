using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<TimeEntity> Times { get; set; }
        public DbSet<CampeonatoEntity> Campeonato { get; set; }
        public DbSet<PartidaEntity> Partidas { get; set; }
        public DbSet<PontuacaoEntity> PontuacaoCampeonato { get; set; }

        public MyContext (DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TimeEntity>(new TimeMap().Configure);
        }


    }
}
