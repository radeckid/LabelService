using LabelService.Interfaces;
using TechTalk.SpecFlow;

namespace LabelServiceTests.Driver
{
    [Binding]
    public class LabelControllerDriver : DriverTypeRegister<ILabelController>
    {
        public LabelControllerDriver(ILabelController labelController) : base(labelController) { }
    }
}
