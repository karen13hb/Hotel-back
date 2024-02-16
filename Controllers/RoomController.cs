using HotelClubApi.Models;
using HotelClubApi.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace HotelClubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly ITipoHabitacionService _tipoHabitacionService;


        public RoomController(ITipoHabitacionService tipoHabitacionService)
        {
            _tipoHabitacionService = tipoHabitacionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoHabitacion>>> GetAllReservations()
        {
            var rooms = await _tipoHabitacionService.obtenerHabitacionesAsync();
            return Ok(rooms);
        }
    }
}
