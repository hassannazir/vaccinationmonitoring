using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using vaccinationmonitoring.Helpers;
using vaccinationmonitoring.Models;

namespace vaccinationmonitoring.Controllers
{

    public class CountriesController : Controller
    {
        private readonly vaccinationmonitoringdbContext _context;

        public CountriesController(vaccinationmonitoringdbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Country> country = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(AppConstants.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync($"api/countriesapi/getcountry");
                if (response.IsSuccessStatusCode)
                {
                    String countries = await response.Content.ReadAsAsync<string>();
                     country = JsonConvert.DeserializeObject<List<Country>>(countries);
                }
                else
                { return NotFound();  }
            }
            if (TempData[AppConstants.SuccessMessage]!=null)
            {
                ViewBag.success = TempData[AppConstants.SuccessMessage].ToString();
            }
            else if(TempData[AppConstants.ErrorMessage]!=null)
            {
                ViewBag.error = TempData[AppConstants.ErrorMessage].ToString();
            }
            
            return View(country);
        }
      
        [HttpPost]
        public async Task<IActionResult> Add(string countryname,int? Id)
        {
            var country = new Country();
            country.Name = countryname;
            country.Id = Id.Value;
            string c = JsonConvert.SerializeObject(country);
            var stringContent = new StringContent(c, UnicodeEncoding.UTF8, "application/json");
            Uri u = new Uri(AppConstants.BaseUrl + "api/Countriesapi/"+c);
            var client = new HttpClient();
            var response = await client.PostAsync(u, stringContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                if (message==AppConstants.notOk)
                {
                    TempData[AppConstants.ErrorMessage] = "Opps! Already Exist";
                    TempData.Peek(AppConstants.ErrorMessage);
                    return RedirectToAction(nameof(Index));
                }
                TempData[AppConstants.SuccessMessage] = "Successfully Saved";
                TempData.Peek(AppConstants.SuccessMessage);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }
       
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            Uri u = new Uri(AppConstants.BaseUrl + "api/Countriesapi/" + Id);
            var client = new HttpClient();
            var response = await client.DeleteAsync(u);
            if (response.IsSuccessStatusCode)
            {

                TempData[AppConstants.SuccessMessage] = "Successfully Deleted";
                TempData.Peek(AppConstants.SuccessMessage);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }

        }
    }

    
}