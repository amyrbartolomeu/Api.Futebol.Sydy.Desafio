    using application.Models;
using Domain.Entities;
using Domain.Interfaces.Services.Time;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace application.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class TimesController : ControllerBase
    {
        private ITimeService _service;
        public TimesController(ITimeService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            //o que está vindo é valido ? ex: trabalhando com Guid e envia uma string q n é do tipo guid retorna bad request(400)
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {

                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]

        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateTimeModel time)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Post(time.ToEntity());
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result); 
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put ([FromRoute] Guid id,[FromBody] CreateTimeModel time)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var entidade = time.ToEntity();
                entidade.Id = id;
                var result = await _service.Put(entidade);
            
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
