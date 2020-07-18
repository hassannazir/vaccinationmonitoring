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
using vaccinationmonitoring.Models.JoinModels;
using vaccinationmonitoring.Models.ViewModels;

namespace vaccinationmonitoring.Controllers
{
    public class CitiesController : Controller
    {
        private readonly vaccinationmonitoringdbContext _context;

        public CitiesController(vaccinationmonitoringdbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            CityViewModel cityViewModel = new CityViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(AppConstants.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage provinceResponse = await client.GetAsync($"api/provincesapi/getprovince");
                if (provinceResponse.IsSuccessStatusCode)
                if (provinceResponse.IsSuccessStatusCode)
                {
                    String provinces = await provinceResponse.Content.ReadAsAsync<string>();
                    cityViewModel.ProvinceList = JsonConvert.DeserializeObject<List<Province>>(provinces);
                }
                else
                { return NotFound(); }

                HttpResponseMessage procityResponse = await client.GetAsync($"api/citiesapi/provincecity");
                if (procityResponse.IsSuccessStatusCode)
                {
                    String procity = await procityResponse.Content.ReadAsAsync<string>();
                    cityViewModel.PCList = JsonConvert.DeserializeObject<List<ProvinceCityModel>>(procity);
                }
                else
                { return NotFound(); }

                if (TempData[AppConstants.SuccessMessage] != null)
                {
                    string message = TempData[AppConstants.SuccessMessage].ToString();
                    ViewBag.success = message;
                }


            }
            return View(cityViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string cityname, int? Id, int provinceId)
        {
            var city = new City();
            city.Name = cityname;
            city.Id = Id.Value;
            city.ProvinceId = provinceId;
            string c = JsonConvert.SerializeObject(city);
            var stringContent = new StringContent(c, UnicodeEncoding.UTF8, "application/json");
            Uri u = new Uri(AppConstants.BaseUrl + "api/citiesapi/" + c);
            var client = new HttpClient();
            var response = await client.PostAsync(u, stringContent);
            if (response.IsSuccessStatusCode)
            {
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
            Uri u = new Uri(AppConstants.BaseUrl + "api/citiesapi/" + Id);
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