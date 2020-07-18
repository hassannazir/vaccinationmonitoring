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
    public class AreasController : Controller
    {
   
            private readonly vaccinationmonitoringdbContext _context;

            public AreasController(vaccinationmonitoringdbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<IActionResult> Index()
            {
                AreaViewModel areaViewModel = new AreaViewModel();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(AppConstants.BaseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //GET Method  
                    HttpResponseMessage cityResponse = await client.GetAsync($"api/citiesapi/getcity");
                    if (cityResponse.IsSuccessStatusCode)
                        if (cityResponse.IsSuccessStatusCode)
                        {
                            String cities = await cityResponse.Content.ReadAsAsync<string>();
                        areaViewModel.CityList = JsonConvert.DeserializeObject<List<City>>(cities);
                        }
                        else
                        { return NotFound(); }

                    HttpResponseMessage cityareaResponse = await client.GetAsync($"api/areasapi/cityarea");
                    if (cityareaResponse.IsSuccessStatusCode)
                    {
                        String cityarea = await cityareaResponse.Content.ReadAsAsync<string>();
                        areaViewModel.CAList = JsonConvert.DeserializeObject<List<CityAreaModel>>(cityarea);
                    }
                    else
                    { return NotFound(); }
                if (TempData[AppConstants.SuccessMessage] != null)
                {
                    string message = TempData[AppConstants.SuccessMessage].ToString();
                    ViewBag.success = message;
                }


            }
                return View(areaViewModel);
            }

            [HttpPost]
            public async Task<IActionResult> Add(string areaname, int? Id, int cityId)
            {
                var area = new Area();
            area.Name = areaname;
            area.Id = Id.Value;
            area.CityId = cityId;
                string c = JsonConvert.SerializeObject(area);
                var stringContent = new StringContent(c, UnicodeEncoding.UTF8, "application/json");
                Uri u = new Uri(AppConstants.BaseUrl + "api/areasapi/" + c);
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
                Uri u = new Uri(AppConstants.BaseUrl + "api/areasapi/" + Id);
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