using Hotels.Api.Models;

namespace Hotels.Api.Core.Services
{
    public interface IHotelDataService
    {
        Task<List<GuestRoom>> GetRoomsForHotelAsync(string hotelCode);
        Task<Hotel?> GetCheapestHotelAsync(string roomType);
        Task<List<Hotel>> GetAllHotelsInCityAsync(string city);
    }
}
