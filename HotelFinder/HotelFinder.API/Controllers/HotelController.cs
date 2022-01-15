using HotelFinder.DataAccess;
using HotelFinder.Entity;
using HotelFinder.Entity.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelFinderDbContext _context;
        public HotelController(HotelFinderDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAllHotel()
        {
            var hotels = _context.Hotels.Select(x => ItemToDTO(x)).ToList();

            if (hotels.Count == 0)
            {
                return NotFound("No registered hotel");
            }
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public ActionResult GetHotel(int id)
        {
            var hotel = _context.Hotels.FirstOrDefault(x => x.Id == id);

            if (hotel == null)
            {
                return NotFound("Hotel not found");
            }
            return Ok(ItemToDTO(hotel));
        }


        [HttpPost("create")]
        public ActionResult CreateHotel([FromBody] HotelCreateDto hotelDto)
        {
            var hotel = new Hotel()
            {
                Name = hotelDto.Name,
                City = hotelDto.City,
                PostCode = hotelDto.PostCode
            };

            _context.Hotels.Add(hotel);
            _context.SaveChanges();

           
            return CreatedAtAction(
                    nameof(GetHotel),
                    new { id = hotel.Id },
                    ItemToDTO(hotel));
        }


        [HttpPut("{id}")]
        public ActionResult UpdateHotel(int id,[FromBody] HotelCreateDto hotelDto)
        {
            var hotel = _context.Hotels.FirstOrDefault(x => x.Id == id);

            if (hotel == null)
            {
                return NotFound("Hotel Not Found");
            }

            hotel.Name = hotelDto.Name;
            hotel.City = hotelDto.City;
            hotel.PostCode = hotelDto.PostCode;

            _context.SaveChanges();

            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteHotel(int id)
        {
            var hotel = _context.Hotels.FirstOrDefault(x => x.Id == id);

            if (hotel == null)
            {
                return NotFound("Hotel Not Found");
            }

            _context.Remove(hotel);

            return Ok();
        }

        private static HotelDto ItemToDTO(Hotel todoItem) =>
        new HotelDto
        {
            Id = todoItem.Id,
            Name = todoItem.Name,
            City = todoItem.City,
            PostCode = todoItem.PostCode
        };
    }
}
