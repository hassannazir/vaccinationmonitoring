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
    public class HousesController : Controller
    {
        private readonly vaccinationmonitoringdbContext _context;

        public HousesController(vaccinationmonitoringdbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HouseViewModel houseViewModel = new HouseViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(AppConstants.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage areaResponse = await client.GetAsync($"api/areasapi/getarea");
                if (areaResponse.IsSuccessStatusCode)
                    if (areaResponse.IsSuccessStatusCode)
                    {
                        String areas = await areaResponse.Content.ReadAsAsync<string>();
                        houseViewModel.AreaList = JsonConvert.DeserializeObject<List<Area>>(areas);
                    }
                    else
                    { return NotFound(); }

                HttpResponseMessage areahouseResponse = await client.GetAsync($"api/housesapi/areahouse");
                if (areahouseResponse.IsSuccessStatusCode)
                {
                    String areahouse = await areahouseResponse.Content.ReadAsAsync<string>();
                    houseViewModel.AHList = JsonConvert.DeserializeObject<List<AreaHouseModel>>(areahouse);
                }
                else
                { return NotFound(); }
                if (TempData[AppConstants.SuccessMessage] != null)
                {
                    string message = TempData[AppConstants.SuccessMessage].ToString();
                    ViewBag.success = message;
                }


            }
            return View(houseViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string housename, int? Id, int areaId)
        {
            var house = new House();
            house.HouseNo = housename;
            house.Id = Id.Value;
            house.AreaId = areaId;
            string c = JsonConvert.SerializeObject(house);
            var stringContent = new StringContent(c, UnicodeEncoding.UTF8, "application/json");
            Uri u = new Uri(AppConstants.BaseUrl + "api/housesapi/" + c);
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
            Uri u = new Uri(AppConstants.BaseUrl + "api/housesapi/" + Id);
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