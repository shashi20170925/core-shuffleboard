using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shuffleboard.web.ebt.deploy.Configuration.ConfigProviders
{
    public static class AmazonEBExtensions
    {
        public static IConfigurationBuilder AddAmazonElasticBeanstalk(this IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Add(new AmazonEBConfigurationSource());
            return configurationBuilder;
        }
    }
}
