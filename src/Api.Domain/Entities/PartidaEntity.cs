namespace Domain.Entities
{
    public class PartidaEntity : BaseEntity 
    {
        public TimeEntity TimeUm { get; set; }
        public TimeEntity TimeDois { get; set; }
        public int GolsTimeUm { get; set; }
        public int GolsTimeDois { get; set; }
    }
}
