using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleInfoService
{
    public class StartParameters
    {

        private readonly IConfiguration _config = null;
        public static String LogPath;
        public static String ConnectionString;
        public static String ServiceUserName;
        public static String ServicePassword;
        public StartParameters(IConfiguration config)
        {
            _config = config;
            LogPath = _config.GetValue<string>("DefaultSettings:LogPath");
            ConnectionString = _config.GetValue<string>("DefaultSettings:ConnectionString");
            ServiceUserName = _config.GetValue<string>("DefaultSettings:username");
            ServicePassword = _config.GetValue<string>("DefaultSettings:password");

        }
    }
}
