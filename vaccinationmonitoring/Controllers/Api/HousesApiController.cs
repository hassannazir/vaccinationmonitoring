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
    public class HousesApiController : ControllerBase
    {
        private readonly vaccinationmonitoringdbContext _context;

        public HousesApiController(vaccinationmonitoringdbContext context)
        {
            _context = context;
        }

        // GET: api/HousesApi
        [Route("~/api/housesapi/gethouse")]
        [HttpGet]
        public async Task<string> GetHouse()
        {
            List<House> houses = await _context.House.OrderBy(i => i.Id).ToListAsync();

            return Newtonsoft.Json.JsonConvert.SerializeObject(houses);
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
        [HttpPost("{house}")]
        public async Task<string> PostHouse(string house)
        {
            try
            {
                House Ohouse = JsonConvert.DeserializeObject<House>(house);
                if (Ohouse.Id == 0)
                {
                    Ohouse.CreatedDate = DateTime.Now;
                    _context.House.Add(Ohouse);
                }
                else if (Ohouse.Id > 0)
                {
                    House house1 = _context.House.FirstOrDefault(i => i.Id == Ohouse.Id);
                    house1.HouseNo = Ohouse.HouseNo;
                    house1.AreaId = Ohouse.AreaId;
                    house1.ModifiedDate = DateTime.Now;

                    _context.Entry(house1).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return AppConstants.ok;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        // DELETE: api/HousesApi/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteHouse(int id)
        {
            try
            {
                var house = await _context.House.FindAsync(id);
                if (house == null)
                {
                    return AppConstants.notOk;
                }

                _context.House.Remove(house);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


            return AppConstants.ok;
        }

        private bool HouseExists(int id)
        {
            return _context.House.Any(e => e.Id == id);
        }

        [Route("~/api/housesapi/areahouse")]
        [HttpGet]
        public async Task<string> AreaHouse()
        {
            try
            {
                var result = await (from h in _context.House
                                    join a in _context.Area
                                    on h.AreaId equals a.Id
                                    select new AreaHouseModel
                                    {
                                        AreaId = a.Id,
                                        HouseId = h.Id,
                                        HouseNo = h.HouseNo,
                                        AreaName = a.Name,
                                        CreatedDate = h.CreatedDate,
                                        ModifiedDate = h.ModifiedDate,
                                    }).ToListAsync<AreaHouseModel>();

                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
