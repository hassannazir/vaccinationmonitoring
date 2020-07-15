using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using vaccinationmonitoring.Helpers;
using vaccinationmonitoring.Models;
using vaccinationmonitoring.Models.JoinModels;

namespace vaccinationmonitoring.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesApiController : ControllerBase
    {
        private readonly vaccinationmonitoringdbContext _context;

        public CitiesApiController(vaccinationmonitoringdbContext context)
        {
            _context = context;
        }

        // GET: api/CitiesApi
        [Route("~/api/citiesapi/getcity")]
        [HttpGet]
        public async Task<string> GetCity()
        {
            List<City> cities = await _context.City.OrderBy(i => i.Id).ToListAsync();

            return Newtonsoft.Json.JsonConvert.SerializeObject(cities);
        }

        // GET: api/CitiesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var city = await _context.City.FindAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            return city;
        }

        // PUT: api/CitiesApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, City city)
        {
            if (id != city.Id)
            {
                return BadRequest();
            }

            _context.Entry(city).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CitiesApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{city}")]
        public async Task<string> PostCity(string city)
        {
            try
            {
                City Ocity = JsonConvert.DeserializeObject<City>(city);
                if (Ocity.Id == 0)
                {
                    Ocity.CreatedDate = DateTime.Now;
                    _context.City.Add(Ocity);
                }
                else if (Ocity.Id > 0)
                {
                    City city1 = _context.City.FirstOrDefault(i => i.Id == Ocity.Id);
                    city1.Name = Ocity.Name;
                    city1.ProvinceId = Ocity.ProvinceId;
                    city1.ModifiedDate = DateTime.Now;

                    _context.Entry(city1).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return AppConstants.ok;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        // DELETE: api/CitiesApi/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteCity(int id)
        {
            try
            {
                var city = await _context.City.FindAsync(id);
                if (city == null)
                {
                    return AppConstants.notOk;
                }

                _context.City.Remove(city);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


            return AppConstants.ok;
        }

        private bool CityExists(int id)
        {
            return _context.City.Any(e => e.Id == id);
        }

        [Route("~/api/citiesapi/provincecity")]
        [HttpGet]
        public async Task<string> ProvinceCity()
        {
            try
            {
                var result = await (from c in _context.City
                                    join p in _context.Province
                                    on c.ProvinceId equals p.Id
                                    select new ProvinceCityModel
                                    {
                                        CityId =c.Id,
                                        ProvinceId = p.Id,
                                        CityName = c.Name,
                                        ProvinceName = p.Name,
                                        CreatedDate = c.CreatedDate,
                                        ModifiedDate = c.ModifiedDate,
                                    }).ToListAsync<ProvinceCityModel>();

                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
