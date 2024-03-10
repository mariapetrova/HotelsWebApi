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

        public async Task<List<GuestRoom>> GetRoomsForHotelAsync(string hotelCode)
        {
            var hotel = (await _hotelRepository.GetAllHotelsAsync())
                .FirstOrDefault(h => h.Code.Equals(hotelCode.Trim(), StringComparison.InvariantCultureIgnoreCase));

            return hotel?.GuestRooms ?? new List<GuestRoom>();
        }

        public async Task<Hotel?> GetCheapestHotelAsync(string roomType)
        {
            var hotels = await _hotelRepository.GetAllHotelsAsync();

            var cheapestHotel = hotels.SelectMany(h => h.GuestRooms
                                        .Where(r => r.Room.Equals(roomType.Trim(), StringComparison.InvariantCultureIgnoreCase))
                                        .Select(r => new { Hotel = h, Price = r.PricePerNight }))
                                        .OrderBy(r => r.Price)
                                        .FirstOrDefault();

            return cheapestHotel?.Hotel;
        }

        public async Task<List<Hotel>> GetAllHotelsInCityAsync(string city)
        {
            return (await _hotelRepository.GetAllHotelsAsync())
                .Where(h => h.City.Equals(city.Trim(), StringComparison.InvariantCultureIgnoreCase))
                .OrderByDescending(h => h.LocalCategory)
                .ToList();
        }
    }
}
