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
    public class HangaresController : ControllerBase
    {
        private readonly ILogger<HangaresController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public HangaresController(
            ILogger<HangaresController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        [Route("")]
        [HttpPost]
        public IActionResult Post([FromBody] Hangar hangar)
        {
            _aplicacionContexto.Hangares.Add(hangar);
            _aplicacionContexto.SaveChanges();
            return Ok(hangar);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Hangar> Get()
        {
            return _aplicacionContexto.Hangares.ToList();
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Hangar hangar)
        {
            hangar.HangarID = id;
            _aplicacionContexto.Hangares.Update(hangar);
            _aplicacionContexto.SaveChanges();
            return Ok(hangar);
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var hangar = _aplicacionContexto.Hangares.FirstOrDefault(x => x.HangarID == id);
            if (hangar != null)
            {
                _aplicacionContexto.Hangares.Remove(hangar);
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
