using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using configs.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IO;
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
            string configJson;

                        string ConfigurationFilename = @"C:\Program Files\Amazon\ElasticBeanstalk\config\containerconfiguration";

        configJson = System.IO.File.ReadAllText(ConfigurationFilename);
            if (!System.IO.File.Exists(ConfigurationFilename))

                 return "Index action 1 " + _appSettings.Environment; ;

            return "Index action 2 " + _appSettings.Environment +"  "+ configJson.ToString();
        }
    }
}