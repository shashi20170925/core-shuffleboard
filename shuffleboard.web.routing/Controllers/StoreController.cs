using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace shuffleboard.web.routing.Controllers
{
    [Route("store")]
    public class StoreController : Controller
    {
       
        [Route("{category?}")]
       // [Route("{}")]
       //if no category is passed in, should be redirected to sotre home category
        public IActionResult home(string category)
        {

            return Content("Viewing the "+ category +" category");
        }
    }
}