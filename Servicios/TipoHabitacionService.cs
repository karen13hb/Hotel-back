using HotelClubApi.Models;
using HotelClubApi.Repositories;

namespace HotelClubApi.Servicios
{
    public class TipoHabitacionService : ITipoHabitacionService
    {
        private readonly ITipoHabitacionRepository _tipoHabitacionRepository;

        public TipoHabitacionService( ITipoHabitacionRepository tipoHabitacionRepository)
        {

            _tipoHabitacionRepository = tipoHabitacionRepository;
        }
        public async Task<IEnumerable<TipoHabitacion>> obtenerHabitacionesAsync()
        {
            return await _tipoHabitacionRepository.ObtenerHabitacionesAsync();  
        }
    }
}
