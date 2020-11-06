using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Webmedicas
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                                  name: "DefaultApi",
                                  routeTemplate: "api/{controller}/{id}",
                                  defaults: new { id = RouteParameter.Optional }
                              );
            config.Routes.MapHttpRoute(
                            name: "ActionApi",
                            routeTemplate: "api/{controller}/{action}/{id}",
                            defaults: new { id = RouteParameter.Optional }
                        );
            config.Routes.MapHttpRoute(
                           name: "ActionApi2",
                           routeTemplate: "api/{controller}/{action}/{id}/{idC}/{CC}",
                           defaults: new { id = RouteParameter.Optional, idC = RouteParameter.Optional, CC = RouteParameter.Optional }
                       );

            config.Routes.MapHttpRoute(
              name: "ActionApi3",
              routeTemplate: "api/{controller}/{action}/{id}/{idC}/{CC}/{CC1}",
              defaults: new { id = RouteParameter.Optional, idC = RouteParameter.Optional, CC = RouteParameter.Optional, CC1 = RouteParameter.Optional }
          );

            config.Routes.MapHttpRoute(
              name: "ActionApi4",
              routeTemplate: "api/{controller}/{action}/{id}/{idC}/{CC}/{CC1}/{CC2}",
              defaults: new { id = RouteParameter.Optional, idC = RouteParameter.Optional, CC = RouteParameter.Optional, CC1 = RouteParameter.Optional, CC2 = RouteParameter.Optional }
          );
        }
    }
}
