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
    public class AvionesController : ControllerBase
    {
        private readonly ILogger<AvionesController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public AvionesController(
            ILogger<AvionesController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        [Route("")]
        [HttpPost]
        public IActionResult Post([FromBody] Avion avion)
        {
            _aplicacionContexto.Aviones.Add(avion);
            _aplicacionContexto.SaveChanges();
            return Ok(avion);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Avion> Get()
        {
            return _aplicacionContexto.Aviones.ToList();
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Avion avion)
        {
            avion.AvionID = id;
            _aplicacionContexto.Aviones.Update(avion);
            _aplicacionContexto.SaveChanges();
            return Ok(avion);
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var avion = _aplicacionContexto.Aviones.FirstOrDefault(x => x.AvionID == id);
            if (avion != null)
            {
                _aplicacionContexto.Aviones.Remove(avion);
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
