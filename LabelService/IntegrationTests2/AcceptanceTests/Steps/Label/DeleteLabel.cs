using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class DeleteLabel : BaseStep
    {
        private string _identcode;
        private int _status;

        public DeleteLabel(LabelDTO label, LabellingServer controller) : base(label, controller) { }

        [Given(@"I have provided label identcode of '(.*)' to delete")]
        public void GivenIHaveProvidedLabelIdentcodeOfToDelete(string identcode)
        {
            _identcode = identcode;
        }

        [When(@"I send post request to delete label")]
        public async Task WhenISendPostRequestToDeleteLabelAsync()
        {
            try
            {
                await Server.DeleteLabelAsync(_identcode);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        [When(@"I send get request to get deletion label with identcode provided to deletion")]
        public async Task WhenISendGetRequestToGetDeletionLabelWithIdentcodeProvidedToDeletion()
        {
            try
            {
                FileResponse response = await Server.GetLabelAsync(_identcode);
                _status = response.StatusCode;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        [Then(@"The result should be Not Found status")]
        public void ThenTheResultShouldBeNotFoundStatus()
        {
            Assert.AreEqual(404, _status);
        }
    }
}
