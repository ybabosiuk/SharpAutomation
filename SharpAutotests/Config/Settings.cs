using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SharpAutotests.Factories.WebDriverFactory;

namespace SharpAutotests.Config
{
    class Settings
    {
        public static string TestType { get; set; }

        public static BrowserType BrowserType { get; set; }

        public static string Enviroment { get; set; }
    }
}
