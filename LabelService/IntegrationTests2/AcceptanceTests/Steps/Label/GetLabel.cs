using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Steps.Label
{
    [Binding]
    public class GetLabel : BaseStep
    {
        private string _identcode;
        private string _labelBase64;

        public GetLabel(LabelDTO label, LabellingServer controller) : base(label, controller) { }

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
                FileResponse response = await Server.GetLabelAsync(_identcode);
                _labelBase64 = Read(response.Stream);
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
            using (StreamReader reader = new StreamReader(pathToSampleLabel))
            {
                sampleLabel = reader.ReadToEnd();
            };

            Assert.AreEqual(sampleLabel, _labelBase64);
        }
    }
}
