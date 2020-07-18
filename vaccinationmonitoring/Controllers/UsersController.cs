using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using vaccinationmonitoring.Helpers;
using vaccinationmonitoring.Models;

namespace vaccinationmonitoring.Controllers
{
    public class UsersController : Controller
    {
        public async Task<IActionResult> Workers()
        {
            IList<User> users = null;
            string c = "2";
            var stringContent = new StringContent(c, UnicodeEncoding.UTF8, "application/json");
            Uri u = new Uri(AppConstants.BaseUrl + "/api/usersapi/getusersbyrole/role?" + c);
            var client = new HttpClient();
            var response = await client.PostAsync(u, stringContent);
            //using (var client=new HttpClient())
            //{
            //    client.BaseAddress = new Uri(AppConstants.BaseUrl);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    //GET Method  
            //    HttpResponseMessage response = await client.GetAsync($"~/api/usersapi/getusers");
            //    if (response.IsSuccessStatusCode)
            //    {
            //        String usersResult = await response.Content.ReadAsAsync<string>();
            //        users = JsonConvert.DeserializeObject<List<User>>(usersResult);
            //    }
            //    else
            //    { return NotFound(); }
            //}
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            return View();
        }
    }
}