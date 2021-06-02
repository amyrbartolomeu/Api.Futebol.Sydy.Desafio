using Domain.Entities;

namespace application.Models
{
    public static class TimeMapper
    {
        public static TimeEntity ToEntity(this CreateTimeModel modelTime)
        {
            return new TimeEntity { Nome = modelTime.Nome };
        }
    }
}
