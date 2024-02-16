using HotelClubApi.DTOs;
using HotelClubApi.Models;

namespace HotelClubApi.Servicios
{
    public interface IReservacionService
    {
        Task<IEnumerable<ReservacionDto>> obtenerReservacionesAsync();
        //Task<Reservation> GetReservationByIdAsync(int id);
        //Task<IEnumerable<Room>> CheckRoomAvailabilityAsync(string roomType, DateTime checkInDate, DateTime checkOutDate);
        Task<Reservacion> crearReservacionAsync(Reservacion reservacion);
        Task<double> calcularPrecioTotalAsync(int idHabitacion, int totalDías);
        Task<Reservacion> cancelarReservacionAsync(int id);
        
        Task<bool> eliminarReservacionAsync(int id);
    }
}
