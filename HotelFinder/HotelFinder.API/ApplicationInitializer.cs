using HotelFinder.DataAccess;
using HotelFinder.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.API
{
    public class ApplicationInitializer
    {
        private readonly HotelFinderDbContext _context;

        public ApplicationInitializer(HotelFinderDbContext context)
        {
            _context = context;
        }

        public async Task StartAsync()
        {
            await HotelSeed();
            await EmployeeSeed();
        }


        private async Task<bool> HotelSeed()
        {
            
                if (_context.Hotels.Count() <= 1)
                {

                    var recordList = new List<Hotel>(){

                         new Hotel{
                             Name = "Ramada",
                             City = "Sakarya",
                             PostCode = "11111"
                            
                         },
                           new Hotel{
                             Name = "N'Ala",
                             City = "Sakarya",
                             PostCode = "222222"
                         }

                    };

                    await _context.Hotels.AddRangeAsync(recordList);
                    await _context.SaveChangesAsync();

                    return true;
                }

            

            return false;
        }

        private async Task<bool> EmployeeSeed()
        {
            
                if (_context.Employees.Count() <= 1)
                {

                    var recordList = new List<Employee>(){

                         new Employee{
                             Name = "Jacob",
                             Surname = "Toretto",
                             HotelId = 1

                         },
                           new Employee{
                             Name = "Kristen",
                             Surname = "Kewall",
                             HotelId= 2
                         }

                    };

                    await _context.Employees.AddRangeAsync(recordList);
                    await _context.SaveChangesAsync();

                    return true;
                }

            

            return false;
        }

    }
}
