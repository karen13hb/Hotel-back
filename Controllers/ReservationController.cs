using HotelClubApi.Models;
using HotelClubApi.Servicios;
using HotelClubApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelClubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservacionService _reservacionService;


        public ReservationController(IReservacionService reservacionService)
        {
            _reservacionService = reservacionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservacionDto>>> obetnerReservaciones()
        {
            var reservations = await _reservacionService.obtenerReservacionesAsync();
            return Ok(reservations);
        }

        [HttpPost("calculateprice")]
        public async Task<ActionResult<double>> calcularPrecioTotal([FromBody] CalculatePriceRequest request)
        {
            var totalPrice = await _reservacionService.calcularPrecioTotalAsync(request.idHabitacion, request.totalDias);
            return Ok(totalPrice);
        }

        [HttpPost]
        public async Task<ActionResult<Reservacion>> crearReservacion([FromBody] Reservacion reservation)
        {
            var addedReservation = await _reservacionService.crearReservacionAsync(reservation);
            return Ok();
        }

        [HttpPut("cancel/{id}")]
        public async Task<ActionResult<Reservacion>> cancelarReservacion(int id)
        {
            var cancelledReservation = await _reservacionService.cancelarReservacionAsync(id);
            if (cancelledReservation == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminarReservacion(int id)
        {

            var result = await _reservacionService.eliminarReservacionAsync(id);

           
            return NoContent();
        }
    }
}

