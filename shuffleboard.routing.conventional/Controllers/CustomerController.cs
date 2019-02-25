using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace shuffleboard.routing.conventional.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Add()
        {
            return View("CUstomerScreen");
        }
    }
}