using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace shuffleboard.web.routing.Controllers
{
    [Route("")]

    public class DashboardController : Controller
    {
        [Route("")]

        public IActionResult Home()
        {
            return View();
        }
    }
}