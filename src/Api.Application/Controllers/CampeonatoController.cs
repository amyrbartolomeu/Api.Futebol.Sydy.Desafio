using Domain.Interfaces.Services.Campeonato;
using Microsoft.AspNetCore.Mvc;

namespace application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonatoController : ControllerBase
    {
        private ICampeonatoService _serviceCampeonato;
    }
}
