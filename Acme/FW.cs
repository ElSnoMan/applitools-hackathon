using System;
using System.IO;
using Acme.Configuration;
using Newtonsoft.Json;

namespace Acme
{
    public class FW
    {
        public static string WORKSPACE_DIRECTORY = Path.GetFullPath(@"../../../../");

        public static Config Config => _configuration ?? throw new NullReferenceException("_configuration is null.");

        public static void SetConfig()
        {
            if (_configuration == null)
            {
                var jsonStr = File.ReadAllText(WORKSPACE_DIRECTORY + "/config.json");
                _configuration = JsonConvert.DeserializeObject<Config>(jsonStr);
            }
        }

        private static Config _configuration;
    }
}
