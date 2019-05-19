using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.Configuration.AppConfig
{
    public interface IAppConfigReader
    {
        IConfiguration LoadConfig(string fileName);
    }
}
