using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shuffleboard.exception.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index() {

            throw new Exception("Error");
            return View("Index");
        }
    }
}
