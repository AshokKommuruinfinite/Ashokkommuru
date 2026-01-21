
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using System.Web.Http;

namespace CC9
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enable attribute routing
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // ===== FORCE JSON OUTPUT =====
            // Remove XML formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Use camelCase for JSON
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Make browsers get JSON even if they say "text/html"
            json.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}

