using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace vaccinationmonitoring.Controllers
{
    public class HousesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}