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
        public IActionResult GetRoomsForHotel(string hotelCode)
        {
            var rooms = _hotelDataService.GetRoomsForHotel(hotelCode);
            return Ok(rooms);
        }

        [HttpGet("CheapestHotel/{roomType}")]
        public IActionResult GetCheapestHotel(string roomType)
        {
            var cheapestHotel = _hotelDataService.GetCheapestHotel(roomType);
            return Ok(cheapestHotel);
        }

        [HttpGet("AllHotelsInCity/{city}")]
        public IActionResult GetAllHotelsInCity(string city)
        {
            var hotelsInCity = _hotelDataService.GetAllHotelsInCity(city);
            return Ok(hotelsInCity);
        }
    }
}