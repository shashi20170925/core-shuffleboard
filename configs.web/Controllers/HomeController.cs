using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using configs.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace configs.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppSettings _appSettings;
     //   private readonly EnvironmentTest _environmentName;

        public HomeController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
         ///   _environmentName = envName.Value;

        }
        public string Index()
        {
            return "Index action " + _appSettings.Environment;
        }
    }
}