using HotelClubApi.Models;

namespace HotelClubApi.Repositories
{
    public interface IReservacionRepository
    {
        Task<IEnumerable<Reservacion>> obtenerReservacionesAsync();
        Task<Reservacion> obtenerReservacionIdAsync(int id);
        Task<Reservacion> crearReservacionAsync(Reservacion reservacion);
        Task<Reservacion> actualizarReservacionAsync(Reservacion reservacion);

        Task<bool> eliminarReservacionAsync(Reservacion reservacion);
    }
}
