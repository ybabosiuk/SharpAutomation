using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static SharpAutotests.Factories.WebDriverFactory;

namespace SharpAutotests.Config
{
    public class Settings
    {
        public string Browser { get; set; }

        public string Enviroment { get; set; }

        public string BrowserVersion { get; set; }

        public string RemoteUri { get; set; }

        public BrowserType BrowserType { get; set; }

        public int Width { get; set;}

        public int Height { get; set; }
    }
}
