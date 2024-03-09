namespace Hotels.Api.Models
{
    public class Hotel
    {
        public string Code { get; set; }
        public string HotelName { get; set; }
        public decimal LocalCategory { get; set; }
        public string City { get; set; }
        public List<GuestRoom> GuestRooms { get; set; }
    }
}
