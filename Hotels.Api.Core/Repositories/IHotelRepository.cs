using Hotels.Api.Models;

namespace Hotels.Api.Core.Repositories
{ 
    public interface IHotelRepository
    {
        public List<Hotel> GetAllHotels();
    }
}
