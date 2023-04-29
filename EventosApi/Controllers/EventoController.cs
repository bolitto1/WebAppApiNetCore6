using EventosDal.Contratos;
using EventosDal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace EventosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private IEventosRepositorio _eventoRepositorio;
        public EventoController(IEventosRepositorio eventoRepositorio)
        {
            this._eventoRepositorio = eventoRepositorio;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Eventos>>> Get() {
            try { 
                List<Eventos> eventos = await _eventoRepositorio.GetListadoEventos();
                return Ok(eventos);
            }catch (Exception) {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Eventos>>> Get(int id)
        {
            try
            {
                Eventos evento = await _eventoRepositorio.GetEventosID(id);
                return Ok(evento);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> Post(Eventos evento)
        {
            try
            {
                bool result = await _eventoRepositorio.Grabar(evento);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPut("{Id}/{Fecha}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> Actualizar(int Id, string? Fecha)
        {
            try
            {
                DateTime fecha1 = DateTime.ParseExact(Fecha, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                bool result = await _eventoRepositorio.Actualizar(Id,fecha1);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                bool resultado = await _eventoRepositorio.Eliminar(id);
                if (!resultado) {
                    return BadRequest();
                }
                return Ok("Ok");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
