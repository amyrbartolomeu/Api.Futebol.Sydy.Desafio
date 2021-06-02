namespace Domain.Entities
{
    public class PontuacaoEntity : BaseEntity
    {
        public TimeEntity Time { get; set; }
        public CampeonatoEntity Campeonato { get; set; }
        public int Pontuacao { get; set; }
    }
}
