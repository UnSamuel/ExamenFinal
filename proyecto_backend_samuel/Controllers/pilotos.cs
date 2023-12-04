using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PilotosController : ControllerBase
    {
        private readonly ILogger<PilotosController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public PilotosController(
            ILogger<PilotosController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        [Route("")]
        [HttpPost]
        public IActionResult Post([FromBody] Piloto piloto)
        {
            _aplicacionContexto.Pilotos.Add(piloto);
            _aplicacionContexto.SaveChanges();
            return Ok(piloto);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Piloto> Get()
        {
            return _aplicacionContexto.Pilotos.ToList();
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Piloto piloto)
        {
            piloto.PilotoID = id;
            _aplicacionContexto.Pilotos.Update(piloto);
            _aplicacionContexto.SaveChanges();
            return Ok(piloto);
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var piloto = _aplicacionContexto.Pilotos.FirstOrDefault(x => x.PilotoID == id);
            if (piloto != null)
            {
                _aplicacionContexto.Pilotos.Remove(piloto);
                _aplicacionContexto.SaveChanges();
                return Ok(id);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
