using LabelService.Services;
using TechTalk.SpecFlow;

namespace LabelServiceTests.Driver
{
    [Binding]
    public class LabelGeneratorDriver : DriverTypeRegister<ILabelGenerator>
    {
        public LabelGeneratorDriver(ILabelGenerator labelController) : base(labelController) { }
    }
}
