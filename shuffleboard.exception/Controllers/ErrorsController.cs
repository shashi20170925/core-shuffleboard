using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shuffleboard.exception.Controllers
{
    public class ErrorsController:Controller
    {
        public IActionResult Index() {
            return View("Error");
        }
    }
}
