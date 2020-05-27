using LabelService.Controllers;
using LabelService.DatabaseContext;
using LabelService.Interfaces;
using LabelService.Services;
using LabelServiceTests.Driver;
using Microsoft.EntityFrameworkCore;
using TechTalk.SpecFlow;

namespace LabelServiceTests.Context
{
    public class TypeRegisterContext
    {
		public DataContext Context { get; }

		public DriverTypeRegister<IIdentcodeGenerator> IdentcodeGeneratorDriver { get; private set; }
		public DriverTypeRegister<ILabelGenerator> LabelGeneratorDriver { get; private set; }
		public DriverTypeRegister<ILabelRepository> LabelRepositoryDriver { get; private set; }
		public DriverTypeRegister<ILabelController> LabelControllerDriver { get; private set; }

		private IIdentcodeGenerator IdentcodeGenerator { get; }
		private ILabelGenerator LabelGenerator { get; }
		private ILabelRepository LabelRepository { get; }
		private ILabelController LabelController { get; } 

		public TypeRegisterContext()
		{

			DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>()
							.UseInMemoryDatabase(databaseName: "TestDatabase")
							.Options;
			Context = new DataContext(options);

			IdentcodeGenerator = new IdentcodeGenerator();
			LabelGenerator = new LabelGenerator();
			LabelRepository = new LabelRepository(Context, LabelGenerator, IdentcodeGenerator);
			LabelController = new LabelController(LabelRepository);

			Register();
		}

		public void Register()
		{
			IdentcodeGeneratorDriver = new IdentcodeGeneratorDriver(IdentcodeGenerator);
			LabelGeneratorDriver = new LabelGeneratorDriver(LabelGenerator);
			LabelRepositoryDriver = new LabelRepositoryDriver(LabelRepository);
			LabelControllerDriver = new LabelControllerDriver(LabelController);
		}
	}
}
