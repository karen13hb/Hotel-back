using HotelClubApi.Models;

namespace HotelClubApi.Servicios
{
    public interface ITipoHabitacionService
    {
        Task<IEnumerable<TipoHabitacion>> obtenerHabitacionesAsync();
    }
}
