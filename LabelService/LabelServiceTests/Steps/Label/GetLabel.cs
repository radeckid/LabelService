using LabelService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LabelServiceTests.Steps.Label
{
    [Binding]
    public class GetLabel : BaseStep
    {
        private string _identcode;
        private string _labelBase64;

        public GetLabel(ILabel label, ILabelController controller) : base(label, controller) { }

        [Given(@"I have provided label identcode of '(.*)'")]
        public void GivenIHaveProvidedLabelIdentcodeOf(string identcode)
        {
            _identcode = identcode;
        }

        [When(@"I send get request to get label")]
        public async Task WhenISendGetRequestToGetLabel()
        {
            try
            {
                IActionResult response = await Controller.GetLabel(_identcode);
                OkObjectResult result = response as OkObjectResult;
                _labelBase64 = result.Value.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        [Then(@"The result should be correct existing label")]
        public void ThenTheResultShouldBeCorrectExistingLabel()
        {
            string sampleLabel;
            using (StreamReader reader = new StreamReader("..\\..\\..\\acceptanceTestSampleLabel.txt"))
            {
                sampleLabel = reader.ReadToEnd();
            };

            Assert.AreEqual(sampleLabel, _labelBase64);
        }
    }
}
