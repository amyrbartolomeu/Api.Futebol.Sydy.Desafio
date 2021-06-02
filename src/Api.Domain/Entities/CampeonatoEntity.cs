using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class CampeonatoEntity : BaseEntity
    {
        public List<PartidaEntity> Partidas { get; set; }

    
    }
}
