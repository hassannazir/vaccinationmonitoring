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
    public class AreasApiController : ControllerBase
    {
        private readonly vaccinationmonitoringdbContext _context;

        public AreasApiController(vaccinationmonitoringdbContext context)
        {
            _context = context;
        }

        // GET: api/AreasApi
        [Route("~/api/areasapi/getarea")]
        [HttpGet]
        public async Task<string> GetArea()
        {
            List<Area> areas = await _context.Area.OrderBy(i => i.Id).ToListAsync();

            return Newtonsoft.Json.JsonConvert.SerializeObject(areas);
        }

        // GET: api/AreasApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> GetArea(int id)
        {
            var area = await _context.Area.FindAsync(id);

            if (area == null)
            {
                return NotFound();
            }

            return area;
        }

        // PUT: api/AreasApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArea(int id, Area area)
        {
            if (id != area.Id)
            {
                return BadRequest();
            }

            _context.Entry(area).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaExists(id))
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

        // POST: api/AreasApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{area}")]
        [HttpPost]
        public async Task<string> PostArea(string area)
        {
            try
            {
                Area Oarea = JsonConvert.DeserializeObject<Area>(area);
                if (Oarea.Id == 0)
                {
                    Oarea.CreatedDate = DateTime.Now;
                    _context.Area.Add(Oarea);
                }
                else if (Oarea.Id > 0)
                {
                    Area area1 = _context.Area.FirstOrDefault(i => i.Id == Oarea.Id);
                    area1.Name = Oarea.Name;
                    area1.CityId = Oarea.CityId;
                    area1.ModifiedDate = DateTime.Now;

                    _context.Entry(area1).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return AppConstants.ok;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        // DELETE: api/AreasApi/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteArea(int id)
        {
            try
            {
                var area = await _context.Area.FindAsync(id);
                if (area == null)
                {
                    return AppConstants.notOk;
                }

                _context.Area.Remove(area);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


            return AppConstants.ok;
        }

        private bool AreaExists(int id)
        {
            return _context.Area.Any(e => e.Id == id);
        }

        [Route("~/api/areasapi/cityarea")]
        [HttpGet]
        public async Task<string> CityArea()
        {
            try
            {
                var result = await (from a in _context.Area
                                    join c in _context.City
                                    on a.CityId equals c.Id
                                    select new CityAreaModel
                                    {
                                        CityId = c.Id,
                                        AreaId = a.Id,
                                        CityName = c.Name,
                                        AreaName = a.Name,
                                        CreatedDate = a.CreatedDate,
                                        ModifiedDate = a.ModifiedDate,
                                    }).ToListAsync<CityAreaModel>();

                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
