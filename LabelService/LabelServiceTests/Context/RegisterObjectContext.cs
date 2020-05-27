using BoDi;
using LabelService.DatabaseContext;
using LabelService.DTO;
using LabelService.Interfaces;
using LabelService.Services;
using LabelServiceTests.Context;
using LabelServiceTests.Driver;
using TechTalk.SpecFlow;

namespace LabelServiceTests
{
	[Binding]
    public class RegisterObjectContext
    {
		private readonly IObjectContainer _objectContainer;
		private readonly DriverTypeRegister<IIdentcodeGenerator> _identcodeGeneratorDriver;
		private readonly DriverTypeRegister<ILabelGenerator> _labelGeneratorDriver;
		private readonly DriverTypeRegister<ILabelRepository> _labelRepositoryDriver;
		private readonly DriverTypeRegister<ILabelController> _labelControllerDriver;

		public RegisterObjectContext(IObjectContainer objectContainer, TypeRegisterContext typeRegisterContext)
		{
			_objectContainer = objectContainer;

			_identcodeGeneratorDriver = typeRegisterContext.IdentcodeGeneratorDriver;
			_labelGeneratorDriver = typeRegisterContext.LabelGeneratorDriver;
			_labelRepositoryDriver = typeRegisterContext.LabelRepositoryDriver;
			_labelControllerDriver = typeRegisterContext.LabelControllerDriver;
		}

		[BeforeScenario]
		public void InitializeLabellingRequest()
		{
			ILabel label = new LabelDTO
			{
				Features = new FeaturesDTO()
			};

			_objectContainer.RegisterInstanceAs<ILabel>(label);
			_objectContainer.RegisterInstanceAs<IIdentcodeGenerator>(_identcodeGeneratorDriver.Driver);
			_objectContainer.RegisterInstanceAs<ILabelGenerator>(_labelGeneratorDriver.Driver);
			_objectContainer.RegisterInstanceAs<ILabelRepository>(_labelRepositoryDriver.Driver);
			_objectContainer.RegisterInstanceAs<ILabelController>(_labelControllerDriver.Driver);
		}
	}
}
