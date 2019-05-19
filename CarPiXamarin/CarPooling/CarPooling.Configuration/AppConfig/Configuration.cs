using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Configuration.AppConfig
{
    public class Configuration : IConfiguration
    {
        public string BaseApiUrl { get; set; }

        public Authentication Authentication { get; set; }

        IAuthentication IConfiguration.Authentication
        {
            get => Authentication;
        }
    }

    public class Authentication : IAuthentication
    {
        public string User { get; set; }
        public string Password { get; set; }
    }
}
