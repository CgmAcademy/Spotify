using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Read
{
    internal class Config
    {
        public static Config config;

        Config() 
        { 
            Utility.GetSettings();
        }
        public static Config getInstance()
        {
            if (config == null)
            {
                return config = new Config();
            }
            else
            {
                return config;
            }
        }
    }
}
