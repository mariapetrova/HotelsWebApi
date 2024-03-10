using Hotels.Api.Models;

namespace Hotels.Api.Core.Repositories
{ 
    public interface IHotelRepository
    {
        public Task<List<Hotel>> GetAllHotelsAsync();
    }
}
