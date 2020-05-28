using LabelService.Helpers;
using NUnit.Framework;
using LabelService.Models;

namespace LabelServiceTests
{
    [TestFixture]
    internal class LabelDataProviderTests
    {
        LabelDataProvider _provider;
        Label _label;

        [SetUp]
        public void SetUp()
        {
            _provider = new LabelDataProvider();
        }

        [TestCase("54321", "Pomykowo", "54321 Pomykowo")]
        [TestCase("", "Pomykowo", "Pomykowo")]
        [TestCase("54321", "", "54321")]
        [TestCase("", "", "")]
        public void GetSenderZipCity_CheckField_Expected(string zip, string city, string expected)
        {
            _label.Sender.Zip = zip;
            _label.Sender.City = city;

            _provider.Inicialize(_label);

            Assert.AreEqual(expected, _provider.GetSenderZipCity);
        }

        [TestCase("Street", "12/3a", "Street 12/3a")]
        [TestCase("", "12/3a", "12/3a")]
        [TestCase("Street", "", "Street")]
        [TestCase("", "", "")]
        public void GetSenderStreetHomeNo_CheckField_Expected(string street, string homeNo, string expected)
        {
            _label.Sender.Street = street;
            _label.Sender.HomeNo = homeNo;

            _provider.Inicialize(_label);

            Assert.AreEqual(expected, _provider.GetSenderStreetHomeNo);
        }

        [TestCase("CompanyName", "Name", "Surname", "CompanyName")]
        [TestCase("", "Name", "Surname", "Name Surname")]
        [TestCase("", "Name", "", "Name")]
        [TestCase("", "", "Surname", "Surname")]
        [TestCase("CompanyName", "", "Surname", "CompanyName")]
        [TestCase("CompanyName", "Name", "", "CompanyName")]
        [TestCase("", "", "", "")]
        public void GetSenderCompanyNameOrName_CheckField_Expected(string company, string name, string surname, string expected)
        {
            _label.Sender.Company = company;
            _label.Sender.Name = name;
            _label.Sender.Surname = surname;

            _provider.Inicialize(_label);

            Assert.AreEqual(expected, _provider.GetSenderCompanyNameOrName);
        }

        [TestCase("54321", "Pomykowo", "54321 Pomykowo")]
        [TestCase("", "Pomykowo", "Pomykowo")]
        [TestCase("54321", "", "54321")]
        [TestCase("", "", "")]
        public void GetReceiverZipCity_CheckField_Expected(string zip, string city, string expected)
        {
            _label.Receiver.Zip = zip;
            _label.Receiver.City = city;

            _provider.Inicialize(_label);

            Assert.AreEqual(expected, _provider.GetReceiverZipCity);
        }

        [TestCase("Street", "12/3a", "Street 12/3a")]
        [TestCase("", "12/3a", "12/3a")]
        [TestCase("Street", "", "Street")]
        [TestCase("", "", "")]
        public void GetReceiverStreetHomeNo_CheckField_Expected(string street, string homeNo, string expected)
        {
            _label.Receiver.Street = street;
            _label.Receiver.HomeNo = homeNo;

            _provider.Inicialize(_label);

            Assert.AreEqual(expected, _provider.GetReceiverStreetHomeNo);
        }

        [TestCase("CompanyName", "Name", "Surname", "CompanyName")]
        [TestCase("", "Name", "Surname", "Name Surname")]
        [TestCase("", "Name", "", "Name")]
        [TestCase("", "", "Surname", "Surname")]
        [TestCase("CompanyName", "", "Surname", "CompanyName")]
        [TestCase("CompanyName", "Name", "", "CompanyName")]
        [TestCase("", "", "", "")]
        public void GetReceiverCompanyNameOrName_CheckField_Expected(string company, string name, string surname, string expected)
        {
            _label.Receiver.Company = company;
            _label.Receiver.Name = name;
            _label.Receiver.Surname = surname;

            _provider.Inicialize(_label);

            Assert.AreEqual(expected, _provider.GetReceiverCompanyNameOrName);
        }

        [TestCase("123456789", "Email@test.test", "123456789")]
        [TestCase("123456789", "", "123456789")]
        [TestCase("", "Email@test.test", "Email@test.test")]
        [TestCase("", "", "")]
        public void GetReceiverAnyContact_CheckField_Expected(string mobile, string email, string expected)
        {
            _label.Receiver.Mobile = mobile;
            _label.Receiver.Email = email;

            _provider.Inicialize(_label);

            Assert.AreEqual(expected, _provider.GetReceiverAnyContact);
        }

        [TestCase("DeliveryIns", "Delivery instruction: DeliveryIns")]
        [TestCase("", "Delivery instruction: ")]
        public void GetDeliveryInstruction_CheckField_Expected(string deliveryIns, string expected)
        {
            _label.Features.DeliveryIns = deliveryIns;

            _provider.Inicialize(_label);

            Assert.AreEqual(expected, _provider.GetDeliveryInstruction);
        }

        [TestCase(1, "EUR", "Price: 1 EUR")]
        [TestCase(0, "EUR", "Price: EUR")]
        [TestCase(1, "", "Price: 1")]
        [TestCase(0, "", "Price: ")]
        public void GetPrice_CheckField_Expected(decimal price, string currency, string expected)
        {

            _label.Features.Price = price;
            _label.Features.Currency = currency;

            _provider.Inicialize(_label);

            Assert.AreEqual(expected, _provider.GetPrice);
        }

        [TestCase(15, "Weight: 15 kg")]
        [TestCase(0, "Weight: 0 kg")]
        public void GetWeight(decimal weight, string expected)
        {
            _label.Features.Weight = weight;

            _provider.Inicialize(_label);

            Assert.AreEqual(expected, _provider.GetWeight);
        }
    }
}
