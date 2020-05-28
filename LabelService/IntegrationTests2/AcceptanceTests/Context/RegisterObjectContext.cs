using AcceptanceTests;
using BoDi;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Context
{
    [Binding]
    public class RegisterObjectContext
    {
        private readonly IObjectContainer _objectContainer;

        public RegisterObjectContext(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeLabellingRequest()
        {
            LabelDTO label = new LabelDTO
            {
                Features = new FeaturesDTO()
            };

            LabellingServer server = new LabellingServer(new HttpClient());

            _objectContainer.RegisterInstanceAs(label);
            _objectContainer.RegisterInstanceAs(server);
        }
    }
}
