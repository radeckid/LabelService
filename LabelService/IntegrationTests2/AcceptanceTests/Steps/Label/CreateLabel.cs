using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class CreateLabel : BaseStep
    {
        private string _labelBase64;

        public CreateLabel(LabelDTO label, LabellingServer server) : base(label, server) { }

        [Given(@"I have provided sender address")]
        public void GivenIHaveProvidedSenderAddress(Table table)
        {
            Label.Sender = table.CreateInstance<AddressDTO>();
        }

        [Given(@"I have provided sender country of '(.*)'")]
        public void GivenIHaveProvidedSenderCountryOf(string country)
        {
            Label.Sender.Country = country;
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

        [Given(@"I have provided receiver country of '(.*)'")]
        public void GivenIHaveProvidedReceiverCountryOf(string country)
        {
            Label.Receiver.Country = country;
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
            Label.Features.Price = price;
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
                FileResponse response = await Server.CreateLabelAsync(Label as LabelDTO);
                _labelBase64 = Read(response.Stream);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        [Then(@"The result should be correct label")]
        public void ThenTheResultShouldBeCorrectLabel()
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
