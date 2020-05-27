using LabelService.DTO;
using LabelService.Interfaces;
using LabelService.Models;
using LabelServiceTests.Steps;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace LabelServiceTests
{
    [Binding]
    public class CreateLabel : BaseStep
    {
        private string _labelBase64;

        public CreateLabel(ILabel label, ILabelController controller) : base(label, controller) { }

        [Given(@"I have provided sender address")]
        public void GivenIHaveProvidedSenderAddress(Table table)
        {
            Label.Sender = table.CreateInstance<AddressDTO>();
        }

        [Given(@"I have provided sender mobile number of '(.*)' and sender email of '(.*)'")]
        public void GivenIHaveProvidedSenderMobileNumberOfAndSenderEmailOf(string mobile, string email)
        {
            Label.Sender.Mobile = mobile;
            Label.Sender.Email = email;
        }

        [Given(@"I have provided receiver address")]
        public void GivenIHaveProvidedReceiverAddress(Table table)
        {
            Label.Receiver = table.CreateInstance<AddressDTO>();
        }

        [Given(@"I have provided receiver mobile number of '(.*)' and receiver email of '(.*)'")]
        public void GivenIHaveProvidedReceiverMobileNumberOfAndReceiverEmailOf(string mobile, string email)
        {
            Label.Receiver.Mobile = mobile;
            Label.Receiver.Email = email;
        }

        [Given(@"I have provided Price of '(.*)' with Currency '(.*)'")]
        public void GivenIHaveProvidedPriceOfWithCurrency(int price, string currency)
        {
            Label.Features.Price = price.ToString();
            Label.Features.Currency = currency;
        }
        
        [Given(@"I have provided Delivery Instruction of '(.*)'")]
        public void GivenIHaveProvidedDeliveryInstructionOf(string deliveryIns)
        {
            Label.Features.DeliveryIns = deliveryIns;
        }

        [When(@"I send a consigment")]
        public async Task WhenISendAConsigment()
        {
            try
            {
                IActionResult response = await Controller.CreateLabel(Label as LabelDTO);
                OkObjectResult result = response as OkObjectResult;
                _labelBase64 = result.Value.ToString();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }


        [Then(@"The result should be correct label")]
        public void ThenTheResultShouldBeCorrectLabel()
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
