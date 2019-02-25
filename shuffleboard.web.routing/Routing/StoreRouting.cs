using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shuffleboard.web.routing.Routing
{
    public static class StoreRouting
    {
        public static void LoadRoutes(IRouteBuilder routeBuilder)
        {

            routeBuilder.MapRoute("default", "{controller=Customer}/{action=Add}/{id?}");


            routeBuilder.MapRoute("route1", "", new
            {
                controller = "Customer",
                actions = "Add"
            });

            routeBuilder.MapRoute("route2", "Customer/New", new
            {
                controller = "Customer",
                actions = "Add"
            });

        }
    }
}
