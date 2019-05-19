using Android.App;
using Android.Content;
using CarPooling.Android.AppConfiguration;
using CarPooling.Configuration.AppConfig;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(AppConfigReader))]
namespace CarPooling.Android.AppConfiguration
{
    class AppConfigReader : IAppConfigReader
    {
        private Context _context = Application.Context;

        public IConfiguration LoadConfig(string fileName)
        {
            using (var asset = _context.Assets.Open(fileName))
            {
                using (var streamReader = new StreamReader(asset))
                {
                    var configJson = streamReader.ReadToEnd();

                    var configParser = new ConfigParser();

                    return configParser.Parse(configJson);
                }
            }
        }
    }
}
