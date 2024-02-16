using HotelClubApi.Models;

namespace HotelClubApi.Repositories
{
    public interface ITipoHabitacionRepository
    {
        Task<IEnumerable<TipoHabitacion>> ObtenerHabitacionesAsync();
        Task<TipoHabitacion> ObtenerHabitacionIdAsync(int id);

    }
}
