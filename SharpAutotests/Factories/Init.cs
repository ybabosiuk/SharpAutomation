using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAutotests.Factories
{
    class Init
    {
        public static PageObjectFactory PageFactory = new PageObjectFactory(WebDriverFactory.Driver);
    }
}
