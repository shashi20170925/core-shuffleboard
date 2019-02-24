using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;


namespace shuffleboard.web.ebt.deploy.Configuration.ConfigProviders
{
   
        public class AmazonEBConfigurationProvider : ConfigurationProvider
        {
            private const string ConfigurationFilename = @"C:\Program Files\Amazon\ElasticBeanstalk\config\containerconfiguration";

            public override void Load()
            {
                if (!File.Exists(ConfigurationFilename))
                    return;

                string configJson;
                try
                {
                
                    configJson = File.ReadAllText(ConfigurationFilename);
                }
                catch
                {
                    return;
                }

                var config = JObject.Parse(configJson);
                var env = (JArray)config["iis"]["env"];

                if (env.Count == 0)
                    return;

                foreach (var item in env.Select(i => (string)i))
                {
                    int eqIndex = item.IndexOf('=');
                    Data[item.Substring(0, eqIndex)] = item.Substring(eqIndex + 1);
                }
            }
        }
    
}
