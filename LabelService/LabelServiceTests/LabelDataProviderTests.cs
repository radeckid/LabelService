using LabelService.DTO;
using LabelService.Helpers;
using NUnit.Framework;

namespace LabelServiceTests
{
    [TestFixture]
    class LabelDataProviderTests
    {
        LabelDataProvider _provider;
        LabelDTO _label;

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
            _label = FakeLabelGenerator.Generate(senderZip: zip, senderCity: city);

            _provider.Inicialize(_label);

            Assert.AreEqual(expected, _provider.GetSenderZipCity);
        }

        [TestCase("Street", "12/3a", "Street 12/3a")]
        [TestCase("", "12/3a", "12/3a")]
        [TestCase("Street", "", "Street")]
        [TestCase("", "", "")]
        public void GetSenderStreetHomeNo_CheckField_Expected(string street, string homeNo, string expected)
        {
            _label = FakeLabelGenerator.Generate(senderStreet: street, senderHomeNo: homeNo);

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
            _label = FakeLabelGenerator.Generate(senderCompany: company, senderName: name, senderSurname: surname);

            _provider.Inicialize(_label);

            Assert.AreEqual(expected, _provider.GetSenderCompanyNameOrName);
        }

        [TestCase("54321", "Pomykowo", "54321 Pomykowo")]
        [TestCase("", "Pomykowo", "Pomykowo")]
        [TestCase("54321", "", "54321")]
        [TestCase("", "", "")]
        public void GetReceiverZipCity_CheckField_Expected(string zip, string city, string expected)
        {
            _label = FakeLabelGenerator.Generate(receiverZip: zip, receiverCity: city);

            _provider.Inicialize(_label);

            Assert.AreEqual(expected, _provider.GetReceiverZipCity);
        }

        [TestCase("Street", "12/3a", "Street 12/3a")]
        [TestCase("", "12/3a", "12/3a")]
        [TestCase("Street", "", "Street")]
        [TestCase("", "", "")]
        public void GetReceiverStreetHomeNo_CheckField_Expected(string street, string homeNo, string expected)
        {
            _label = FakeLabelGenerator.Generate(receiverStreet: street, receiverHomeNo: homeNo);

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
            _label = FakeLabelGenerator.Generate(receiverCompany: company, receiverName: name, receiverSurname: surname);

            _provider.Inicialize(_label);

            Assert.AreEqual(expected, _provider.GetReceiverCompanyNameOrName);
        }

        [TestCase("123456789", "Email@test.test", "123456789")]
        [TestCase("123456789", "", "123456789")]
        [TestCase("", "Email@test.test", "Email@test.test")]
        [TestCase("", "", "")]
        public void GetReceiverAnyContact_CheckField_Expected(string mobile, string email, string expected)
        {
            _label = FakeLabelGenerator.Generate(receiverMobile: mobile, receiverEmail: email);

            _provider.Inicialize(_label);

            Assert.AreEqual(expected, _provider.GetReceiverAnyContact);
        }

        [TestCase("DeliveryIns", "Delivery instruction: DeliveryIns")]
        [TestCase("", "Delivery instruction: ")]
        public void GetDeliveryInstruction_CheckField_Expected(string deliveryIns, string expected)
        {
            _label = FakeLabelGenerator.Generate(deliveryIns: deliveryIns);

            _provider.Inicialize(_label);

            Assert.AreEqual(expected, _provider.GetDeliveryInstruction);
        }

        [TestCase("1", "EUR", "Price: 1 EUR")]
        [TestCase("", "EUR", "Price: EUR")]
        [TestCase("1", "", "Price: 1")]
        [TestCase("", "", "Price: ")]
        public void GetPrice_CheckField_Expected(string price, string currency, string expected)
        {
            _label = FakeLabelGenerator.Generate(price: price, currency: currency);

            _provider.Inicialize(_label);

            Assert.AreEqual(expected, _provider.GetPrice);
        }

        [TestCase("15", "Weight: 15 kg")]
        [TestCase("", "Weight: 0 kg")]
        public void GetWeight(string weight, string expected)
        {
            _label = FakeLabelGenerator.Generate(weight: weight);

            _provider.Inicialize(_label);

            Assert.AreEqual(expected, _provider.GetWeight);
        }
    }
}
