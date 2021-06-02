using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TimeEntity : BaseEntity
    {
        [MinLength(3)]
        public string Nome { get; set; }

    }
}
