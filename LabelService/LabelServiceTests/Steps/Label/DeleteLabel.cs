using LabelService.Interfaces;
using LabelServiceTests.Steps;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LabelServiceTests
{
    [Binding]
    public class DeleteLabel : BaseStep
    {
        private string _identcode;
        private int _status;

        public DeleteLabel(ILabel label, ILabelController controller) : base(label, controller) { }

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
                await Controller.DeleteLabel(_identcode);
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
                IActionResult response = await Controller.GetLabel(_identcode);
                _status = (response as NotFoundResult).StatusCode;
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
