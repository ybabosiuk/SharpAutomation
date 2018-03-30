using System;
using TechTalk.SpecFlow;

namespace SharpAutotests
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Then(@"something is stuck")]
        public void ThenSomethingIsStuck()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
