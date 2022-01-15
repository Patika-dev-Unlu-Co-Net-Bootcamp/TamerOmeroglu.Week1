using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Entity.DTO
{
    public class HotelCreateDto
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
    }
}
