using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shuffleboard.routing.conventional.Routes
{
    public static class AppRoutes
    {
        public static void LoadRoutes(IRouteBuilder builder)
        {
            builder.MapRoute("route1", "", new
            {
                controller = "Customer",
                action = "Add"
            });

            builder.MapRoute("route2", "customer/customer-new", new
            {
                controller = "Customer",
                action = "Add"
            });
        }
    }
}
