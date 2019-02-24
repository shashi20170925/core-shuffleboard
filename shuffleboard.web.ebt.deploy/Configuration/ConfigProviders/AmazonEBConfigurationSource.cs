using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace shuffleboard.web.ebt.deploy.Configuration.ConfigProviders
{
    public class AmazonEBConfigurationSource : IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new AmazonEBConfigurationProvider();
        }
    }
}
