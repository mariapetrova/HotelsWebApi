using Hotels.Api.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hotels.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelDataService _hotelDataService;

        public HotelsController(IHotelDataService dataService)
        {
            _hotelDataService = dataService;
        }

        [HttpGet("AllRooms/{hotelCode}")]
        public async Task<IActionResult> GetRoomsForHotel(string hotelCode)
        {
            var rooms = await _hotelDataService.GetRoomsForHotelAsync(hotelCode);
            return Ok(rooms);
        }

        [HttpGet("CheapestHotel/{roomType}")]
        public async Task<IActionResult> GetCheapestHotel(string roomType)
        {
            var cheapestHotel = await _hotelDataService.GetCheapestHotelAsync(roomType);
            return Ok(cheapestHotel);
        }

        [HttpGet("AllHotelsInCity/{city}")]
        public async Task<IActionResult> GetAllHotelsInCity(string city)
        {
            var hotelsInCity = await _hotelDataService.GetAllHotelsInCityAsync(city);
            return Ok(hotelsInCity);
        }
    }
}