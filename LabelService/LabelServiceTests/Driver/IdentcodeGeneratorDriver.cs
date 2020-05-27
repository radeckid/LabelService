using LabelService.Services;
using TechTalk.SpecFlow;

namespace LabelServiceTests.Driver
{
    [Binding]
    public class IdentcodeGeneratorDriver : DriverTypeRegister<IIdentcodeGenerator>
    {
        public IdentcodeGeneratorDriver(IIdentcodeGenerator identcodeGenerator) : base(identcodeGenerator) { }
    }
}
