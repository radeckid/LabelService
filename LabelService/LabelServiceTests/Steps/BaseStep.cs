using LabelService.DTO;
using LabelService.Interfaces;
using TechTalk.SpecFlow;

namespace LabelServiceTests.Steps
{
    [Binding]
    public class BaseStep : TechTalk.SpecFlow.Steps
    {
        protected ILabel Label { get; }
        protected ILabelController Controller { get; }

        public BaseStep(ILabel label, ILabelController controller)
        {
            Label = label;
            Controller = controller;
        }
    }
}
