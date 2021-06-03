using Domain.Interfaces.Services.Campeonato;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonatosController : ControllerBase
    {
        private ICampeonatoService _serviceCampeonato;

        public CampeonatosController(ICampeonatoService serviceCampeonato)
        {
            _serviceCampeonato = serviceCampeonato;
        }

        [HttpGet]
        public async Task<ActionResult> Campeonato()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _serviceCampeonato.CriaCampeonato();

                return Ok(result);
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
