using Hotels.Api.Models;

namespace Hotels.Api.Core.Services
{
    public interface IHotelDataService
    {
        List<GuestRoom> GetRoomsForHotel(string hotelCode);
        Hotel? GetCheapestHotel(string roomType);
        List<Hotel> GetAllHotelsInCity(string city);
    }
}
