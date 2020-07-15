using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vaccinationmonitoring.Models;

namespace vaccinationmonitoring.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesApiController : ControllerBase
    {
        private readonly vaccinationmonitoringdbContext _context;

        public HousesApiController(vaccinationmonitoringdbContext context)
        {
            _context = context;
        }

        // GET: api/HousesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<House>>> GetHouse()
        {
            return await _context.House.ToListAsync();
        }

        // GET: api/HousesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<House>> GetHouse(int id)
        {
            var house = await _context.House.FindAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            return house;
        }

        // PUT: api/HousesApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHouse(int id, House house)
        {
            if (id != house.Id)
            {
                return BadRequest();
            }

            _context.Entry(house).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HouseExists(id))
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

        // POST: api/HousesApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<House>> PostHouse(House house)
        {
            _context.House.Add(house);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHouse", new { id = house.Id }, house);
        }

        // DELETE: api/HousesApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<House>> DeleteHouse(int id)
        {
            var house = await _context.House.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }

            _context.House.Remove(house);
            await _context.SaveChangesAsync();

            return house;
        }

        private bool HouseExists(int id)
        {
            return _context.House.Any(e => e.Id == id);
        }
    }
}
