namespace HotelClubApi.DTOs
{
    public class ReservacionDto
    {
        public int Id { get; set; }
        
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal Precio_total { get; set; }
        public string Nombre { get; set; }
        public string Celular { get; set; }
        public Boolean isCancel { get; set; }
        public string Habitacion { get; set; }
    }
}
