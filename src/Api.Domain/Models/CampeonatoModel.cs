using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class CampeonatoModel
    {
        public List<PartidaModel> Partidas { get; set; }

        public string Campeao { get; set; }
        public string ViceCampeao { get; set; }
        public string TerceiroLugar { get; set; }

    }
}
