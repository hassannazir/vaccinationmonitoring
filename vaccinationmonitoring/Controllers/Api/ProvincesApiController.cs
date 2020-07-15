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
    public class ProvincesApiController : ControllerBase
    {
        private readonly vaccinationmonitoringdbContext _context;

        public ProvincesApiController(vaccinationmonitoringdbContext context)
        {
            _context = context;
        }

        [Route("~/api/provincesapi/getprovince")]
        // GET: api/ProvincesApi
        [HttpGet]
        public async Task<string> GetProvince()
        {
            List<Province> provinces = await _context.Province.OrderBy(i => i.Id).ToListAsync();

            return Newtonsoft.Json.JsonConvert.SerializeObject(provinces);
           
        }

        // GET: api/ProvincesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Province>> GetProvince(int id)
        {
            var province = await _context.Province.FindAsync(id);

            if (province == null)
            {
                return NotFound();
            }

            return province;
        }

        // PUT: api/ProvincesApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvince(int id, Province province)
        {
            if (id != province.Id)
            {
                return BadRequest();
            }

            _context.Entry(province).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinceExists(id))
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

        // POST: api/ProvincesApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{province}")]
        public async Task<string> PostProvince(string province)
        {
            try
            {
                Province Oprovince = JsonConvert.DeserializeObject<Province>(province);
                if (Oprovince.Id == 0)
                {
                    Oprovince.CreatedDate = DateTime.Now;
                    _context.Province.Add(Oprovince);
                }
                else if (Oprovince.Id > 0)
                {
                    Province province1 = _context.Province.FirstOrDefault(i => i.Id == Oprovince.Id);
                    province1.Name = Oprovince.Name;
                    province1.CountryId = Oprovince.CountryId;
                    province1.ModifiedDate = DateTime.Now;

                    _context.Entry(province1).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return AppConstants.ok;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        // DELETE: api/ProvincesApi/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteProvince(int id)
        {
            try
            {
                var province = await _context.Province.FindAsync(id);
                if (province == null)
                {
                    return AppConstants.notOk;
                }

                _context.Province.Remove(province);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
           

            return AppConstants.ok;
        }

        private bool ProvinceExists(int id)
        {
            return _context.Province.Any(e => e.Id == id);
        }

        [Route("~/api/provincesapi/countryprovince")]
        [HttpGet]
        public async Task<string> CountryProvince()
        {
            try
            {
                var result = await (from p in _context.Province
                                    join c in _context.Country
                                    on p.CountryId equals c.Id
                                    select new CountryProvinceModel
                                    {
                                        CountryId = c.Id,
                                        ProvinceId = p.Id,
                                        CountryName = c.Name,
                                        ProvinceName = p.Name,
                                        CreatedDate=p.CreatedDate,
                                        ModifiedDate = p.ModifiedDate,
                                    }).ToListAsync<CountryProvinceModel>();

                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
