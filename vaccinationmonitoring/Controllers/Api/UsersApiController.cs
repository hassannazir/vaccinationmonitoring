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
    [Route("api/usersapi")]
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        private readonly vaccinationmonitoringdbContext _context;

        public UsersApiController(vaccinationmonitoringdbContext context)
        {
            _context = context;
        }

        // GET: api/UsersApi
        [Route("~/api/usersapi/getusers")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/UsersApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/UsersApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/UsersApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{user}")]
        public async Task<string> PostUser(string user)
        {
            User user1 = JsonConvert.DeserializeObject<User>(user);
            _context.User.Add(user1);
            await _context.SaveChangesAsync();

            return AppConstants.ok;
        }

        // DELETE: api/UsersApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
        [Route("~/api/usersapi/getusersbyrole/{role:string}")]
        //[HttpPost("{role}")]
        public async Task<string> GetUsersList(string role)
        {
            try
            {
                var result = await (from u in _context.User
                              join a in _context.Area on u.AreaId equals a.Id
                              join c in _context.City on a.CityId equals c.Id
                              select new UsersJoinModel
                              {
                                  Id=u.Id,
                                  FirstName=u.FirstName,
                                  LastName=u.LastName,
                                  Area=a.Name,
                                  AreaId=a.Id,
                                  City=c.Name,
                                  Status=u.Status,
                                  IsActive=u.IsActive,
                                  PhoneNumber=u.PhoneNumber,
                                  EmailAddress=u.EmailAddress,
                                  Address=u.Address,
                                  Role=u.Role
                              }).ToListAsync();
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
