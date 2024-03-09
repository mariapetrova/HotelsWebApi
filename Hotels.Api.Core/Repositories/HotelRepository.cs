using Hotels.Api.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace Hotels.Api.Core.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly IMemoryCache memoryCache;
        private const string CacheKey = "HotelData";

        public HotelRepository(IMemoryCache memoryCache, string jsonFilePath)
        {
            this.memoryCache = memoryCache;

            if (!memoryCache.TryGetValue(CacheKey, out _))
            {
                // Load your hotel data from the provided JSON @"./hoteldata.json"
                using StreamReader reader = new(jsonFilePath);
                var json = reader.ReadToEnd();

                var travelSite = JsonConvert.DeserializeObject<TravelSite>(json);
                var hotels = travelSite?.Hotels.ToList();

                // Cache the data with an absolute expiration of, for example, 1 hour
                memoryCache.Set(CacheKey, hotels, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
                });
            }
        }

        public List<Hotel> GetAllHotels()
        {
            return memoryCache.Get<List<Hotel>>(CacheKey) ?? new List<Hotel>();
        }
    }
}
