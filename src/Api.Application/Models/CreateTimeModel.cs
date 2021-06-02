using System.ComponentModel.DataAnnotations;

namespace application.Models
{
    public class CreateTimeModel
    {
        [MinLength(3)]
        public string Nome { get; set; }
    }
}
