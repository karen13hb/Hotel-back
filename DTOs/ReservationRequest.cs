namespace HotelClubApi.DTOs
{
    public class ReservationRequest
    {
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsCancelled { get; set; }
        public string GuestName { get; set; }
    }
}
