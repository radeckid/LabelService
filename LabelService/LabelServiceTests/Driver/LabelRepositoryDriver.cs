using LabelService.DatabaseContext;
using TechTalk.SpecFlow;

namespace LabelServiceTests.Driver
{
    [Binding]
    public class LabelRepositoryDriver : DriverTypeRegister<ILabelRepository>
    {
        public LabelRepositoryDriver(ILabelRepository labelRepository) : base(labelRepository) { }
    }
}
