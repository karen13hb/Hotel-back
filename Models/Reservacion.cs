namespace HotelClubApi.Models
{
    public class Reservacion { 


        public int Id { get; set; }
        public int Tipo_habitacion_Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal Precio_total { get; set; }
        public bool IsCancel { get; set; }
        public string Nombre { get; set; }
        public string Celular { get; set; }

    }
}
