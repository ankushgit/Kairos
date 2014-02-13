using Kairos.WEB.Helpers;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Kairos.WEB
{
    public static class GlobalConfig
    {
        public static void CustomizeConfig(HttpConfiguration config)
        {
            // Remove Xml formatters. This means when we visit an endpoint from a browser,
            // Instead of returning Xml, it will return Json.
            // More information from Dave Ward: http://jpapa.me/P4vdx6
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Configure json camelCasing per the following post: http://jpapa.me/NqC2HH
            // Here we configure it to write JSON property names with camel casing
            // without changing our server-side data model:
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            /* The below line configures the date serialisation to universal time zone
             * This is very important when the application is accessed from different time zones
             * The solution is to 
             * a) always store the date time in utc format in the database
             * b) serialize it in utc format - this setting helps there
             * c) On the client conver the date to local before display
             */
            json.SerializerSettings.DateTimeZoneHandling =
                Newtonsoft.Json.DateTimeZoneHandling.Utc;


            // Add model validation, globally
            config.Filters.Add(new ValidationActionFilter());

            // config.EnableSystemDiagnosticsTracing();
        }
    }

}