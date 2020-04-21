using LabelService.Services;
using NUnit.Framework;

namespace LabelServiceTests
{
    [TestFixture]
    public class IdentcodeGeneratorTests
    {
        IdentcodeGenerator _generator;
        [SetUp]
        public void Setup()
        {
            _generator = new IdentcodeGenerator();
        }

        [Test]
        public void Call_CheckStartupNumber_1()
        {
            Assert.AreEqual("1", _generator.Call());
        }

        [Test]
        public void Call_CheckIncrementNumber_2()
        {
            _generator.Call();
            Assert.AreEqual("2", _generator.Call());
        }
    }
}
