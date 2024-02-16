using HotelClubApi.Data;
using HotelClubApi.DTOs;
using HotelClubApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelClubApi.Repositories
{
    public class ReservacionRepository : IReservacionRepository
    {
        private readonly DataContext _context;

        public ReservacionRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Reservacion> crearReservacionAsync(Reservacion reservacion)
        {
            _context.Reservaciones.Add(reservacion);
            await _context.SaveChangesAsync();
            return reservacion; 
        }

        public async Task<IEnumerable<Reservacion>> obtenerReservacionesAsync()
        {
            var habitaciones = await _context.Reservaciones.ToListAsync();
            return habitaciones;
        }

        public async Task<Reservacion> obtenerReservacionIdAsync(int id)
        {
            return await _context.Reservaciones.FindAsync(id);
        }

        public async Task<Reservacion> actualizarReservacionAsync(Reservacion reservacion)
        {
            var existingReservation = await _context.Reservaciones.FindAsync(reservacion.Id);

            existingReservation.IsCancel = reservacion.IsCancel;

            existingReservation.Precio_total = reservacion.Precio_total;

            await _context.SaveChangesAsync();

            return existingReservation;
        }

        public async Task<bool> eliminarReservacionAsync(Reservacion reservacion)
        {

            _context.Reservaciones.Remove(reservacion);
            await _context.SaveChangesAsync();

            return true;
        }
        
    }
}
