using HotelClubApi.DTOs;
using HotelClubApi.Models;
using HotelClubApi.Repositories;

namespace HotelClubApi.Servicios
{
    public class ReservacionService : IReservacionService
    {
        private readonly IReservacionRepository _reservacionRepository;

        private readonly ITipoHabitacionRepository _tipoHabitacionRepository;

        public ReservacionService(IReservacionRepository reservacionRepository, ITipoHabitacionRepository tipoHabitacionRepository)
        {
            _reservacionRepository = reservacionRepository;
            _tipoHabitacionRepository = tipoHabitacionRepository;
        }

        public async Task<IEnumerable<ReservacionDto>> obtenerReservacionesAsync()
        {

            var reservaciones = await _reservacionRepository.obtenerReservacionesAsync();

            var reservacionesDto = new List<ReservacionDto>();

            var tipoHabitaciones = await _tipoHabitacionRepository.ObtenerHabitacionesAsync();
            foreach (var reservacion in reservaciones)
            {
                var tipoHabitacion = tipoHabitaciones.FirstOrDefault(th => th.Id == reservacion.Tipo_habitacion_Id);
                var reservacionDto = new ReservacionDto
                {
                    Id = reservacion.Id,
                    CheckInDate = reservacion.CheckInDate,
                    CheckOutDate = reservacion.CheckOutDate,
                    Precio_total = reservacion.Precio_total,
                    Nombre = reservacion.Nombre,
                    Celular = reservacion.Celular,
                    isCancel = reservacion.IsCancel,
                    Habitacion = tipoHabitacion != null ? tipoHabitacion.Type : ""
                };

                reservacionesDto.Add(reservacionDto);
            }

            return reservacionesDto;


        }
        public async Task<Reservacion> crearReservacionAsync(Reservacion reservation)
        {
            if (reservation.CheckInDate >= reservation.CheckOutDate)
            {
                throw new ArgumentException("La reserva no es válida");
            }
            return await _reservacionRepository.crearReservacionAsync(reservation);
        }

        public async Task<double> calcularPrecioTotalAsync(int idHabitacion, int totalDias)
        {

            TipoHabitacion habitacion = await _tipoHabitacionRepository.ObtenerHabitacionIdAsync(idHabitacion);
            double precio_total = (double)habitacion.Precio_noche * totalDias;

            //descuento despues de cinco días de reserva
            if (totalDias > 5)
            {
                precio_total -= precio_total * 0.1;
            }

            return precio_total;
        }

        public async Task<Reservacion> cancelarReservacionAsync(int id)
        {
            
            var reservacion = await _reservacionRepository.obtenerReservacionIdAsync(id);

            var daysDifference = (reservacion.CheckInDate - DateTime.Today).TotalDays;

            
            if (daysDifference <= 5)
            {
                reservacion.IsCancel = true;
                reservacion.Precio_total *= 1.05m;
            }
            else
            {
                reservacion.IsCancel = true;
            }

            
            return await _reservacionRepository.actualizarReservacionAsync(reservacion);
        }

        public async Task<bool> eliminarReservacionAsync(int id)
        {
            
            var reservation = await _reservacionRepository.obtenerReservacionIdAsync(id);

            
            if (reservation == null)
            {
                return false;
            }

            
            await _reservacionRepository.eliminarReservacionAsync(reservation);

            return true; 
        }
    }
}
