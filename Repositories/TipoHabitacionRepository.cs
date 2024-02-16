using HotelClubApi.Data;
using HotelClubApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelClubApi.Repositories
{
    public class TipoHabitacionRepository : ITipoHabitacionRepository
    {
        private readonly DataContext _context;

        public TipoHabitacionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoHabitacion>> ObtenerHabitacionesAsync()
        {
            return await _context.TipoHabitaciones.ToListAsync();
        }

        public async Task<TipoHabitacion> ObtenerHabitacionIdAsync(int id)
        {
            var habitacion = await _context.TipoHabitaciones.FindAsync(id);

            return habitacion;
        }
    }
}

