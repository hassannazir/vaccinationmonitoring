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
    public class ProvincesController : Controller
    {
        private readonly vaccinationmonitoringdbContext _context;

        public ProvincesController(vaccinationmonitoringdbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ProvinceViewModel provinceViewModel = new ProvinceViewModel();
           
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(AppConstants.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage countryResponse = await client.GetAsync($"api/countriesapi/getcountry");
                if (countryResponse.IsSuccessStatusCode)
                {
                    String countries = await countryResponse.Content.ReadAsAsync<string>();
                    provinceViewModel.CountryList = JsonConvert.DeserializeObject<List<Country>>(countries);
                }
                else
                { return NotFound(); }

                HttpResponseMessage countproResponse = await client.GetAsync($"api/provincesapi/countryprovince");
                if (countproResponse.IsSuccessStatusCode)
                {
                    String countpro = await countproResponse.Content.ReadAsAsync<string>();
                    provinceViewModel.CPList = JsonConvert.DeserializeObject<List<CountryProvinceModel>>(countpro);
                }
                else
                { return NotFound(); }

                if (TempData[AppConstants.SuccessMessage] != null)
                {
                    string message = TempData[AppConstants.SuccessMessage].ToString();
                    ViewBag.success = message;
                }


            }
            return View(provinceViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string provincename, int? Id,int countryId)
        {
            var province = new Province();
            province.Name = provincename;
            province.Id = Id.Value;
            province.CountryId = countryId;
            string c = JsonConvert.SerializeObject(province);
            var stringContent = new StringContent(c, UnicodeEncoding.UTF8, "application/json");
            Uri u = new Uri(AppConstants.BaseUrl + "api/provincesapi/" + c);
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
            Uri u = new Uri(AppConstants.BaseUrl + "api/provincesapi/" + Id);
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