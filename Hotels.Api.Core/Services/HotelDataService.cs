using Hotels.Api.Core.Repositories;
using Hotels.Api.Models;

namespace Hotels.Api.Core.Services
{
    public class HotelDataService : IHotelDataService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelDataService(IHotelRepository repository)
        {
            _hotelRepository = repository;
        }

        public List<GuestRoom> GetRoomsForHotel(string hotelCode)
        {
            var hotel = _hotelRepository.GetAllHotels()
                .FirstOrDefault(h => h.Code.Equals(hotelCode, StringComparison.InvariantCultureIgnoreCase));

            return hotel?.GuestRooms ?? new List<GuestRoom>();
        }

        public Hotel? GetCheapestHotel(string roomType)
        {
            var hotels = _hotelRepository.GetAllHotels();

            var cheapestHotel = hotels.SelectMany(h => h.GuestRooms
                                        .Where(r => r.Room.Equals(roomType, StringComparison.InvariantCultureIgnoreCase))
                                        .Select(r => new { Hotel = h, Price = r.PricePerNight }))
                                        .OrderBy(r => r.Price)
                                        .FirstOrDefault();

            return cheapestHotel?.Hotel;
        }

        public List<Hotel> GetAllHotelsInCity(string city)
        {
            return _hotelRepository.GetAllHotels()
                .Where(h => h.City.Equals(city, StringComparison.InvariantCultureIgnoreCase))
                .OrderByDescending(h => h.LocalCategory)
                .ToList();
        }
    }
}
