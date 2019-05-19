using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Configuration.AppConfig
{
    public class ConfigParser
    {
        public IConfiguration Parse(string configJson)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Configuration>(configJson);
        }
    }
}
