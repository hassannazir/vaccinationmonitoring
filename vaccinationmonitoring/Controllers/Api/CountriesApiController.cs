using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using vaccinationmonitoring.Helpers;
using vaccinationmonitoring.Models;
using vaccinationmonitoring.Models.ResponceModals;

namespace vaccinationmonitoring.Controllers.Api
{
  
    [Route("api/countriesapi")]
    [ApiController]

    public class CountriesApiController : ControllerBase
    {
        private readonly vaccinationmonitoringdbContext _context;

        public CountriesApiController(vaccinationmonitoringdbContext context)
        {
            _context = context;
        }

        [Route("~/api/countriesapi/getcountry")]
        // GET: api/Countries
        [HttpGet]
        public async Task<string> GetCountry()
        {
            List<Country> countries= await _context.Country.OrderBy(i=>i.Id).ToListAsync();

            return Newtonsoft.Json.JsonConvert.SerializeObject(countries);
            //return Newtonsoft.Json.JsonConvert.SerializeObject(await _context.Country.ToArrayAsync());
        }
       

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _context.Country.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
                if (!CountryExists(id))
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

        // POST: api/Countries
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[Route("~/api/countries/addcountry")]
        [HttpPost("{country}")]
        public async Task<string> PostCountry(string country)
        {
            try
            {
                Country Ocountry = JsonConvert.DeserializeObject<Country>(country);
                
                if (Ocountry.Id == 0)
                {
                    Country getCountry = _context.Country.FirstOrDefault(i=>i.Name.Trim().ToLower()==Ocountry.Name.Trim().ToLower());
                    if (getCountry!=null)
                    {
                        return AppConstants.notOk;
                    }
                    Ocountry.CreatedDate = DateTime.Now;
                    _context.Country.Add(Ocountry);
                }
                else if (Ocountry.Id > 0)
                {
                    Country country1 = _context.Country.FirstOrDefault(i => i.Id == Ocountry.Id);
                    country1.Name = Ocountry.Name;
                    country1.ModifiedDate = DateTime.Now;

                    _context.Entry(country1).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return AppConstants.ok;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            

            //return CreatedAtAction("GetCountry", new { id = country.Id }, country);
            
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteCountry(int id)
        {
            try
            {
                var country = await _context.Country.FindAsync(id);
                if (country == null)
                {
                    return AppConstants.notOk;
                }
                _context.Country.Remove(country);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
           
            return AppConstants.ok;
        }

        private bool CountryExists(int id)
        {
            return _context.Country.Any(e => e.Id == id);
        }
    }
}
