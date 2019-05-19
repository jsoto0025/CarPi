using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Configuration.AppConfig
{
    public interface IConfiguration
    {
        string BaseApiUrl { get; }

        IAuthentication Authentication { get; }
    }

    public interface IAuthentication
    {
        string User { get; set; }
        string Password { get; set; }
    }
}
