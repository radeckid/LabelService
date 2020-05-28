using LabelPlatform.Interfaces;
using LabelService.Models;

namespace LabelServiceTests
{
    internal static class FakeLabelGenerator
    {
        internal static ILabel GetLabel()
        {
            return new Label
            {
                Sender = GetSender(),
                Receiver = GetReceiver(),
                Features = GetFeatures()
            };
        }

        internal static Address GetSender(string company = "senderCompany", string name = "senderName", string surname = "senderSurname", string street = "senderStreet", string homeNo = "senderHomeNo", string city = "senderCity", string zip = "senderZip",
            string country = "United States", string mobile = "123456789", string email = "sender@text.eu")
        {
            return new Address
            {
                Company = company,
                Name = name,
                Surname = surname,
                Street = street,
                HomeNo = homeNo,
                City = city,
                Country = country,
                Mobile = mobile,
                Email = email
            };
        }

        internal static Address GetReceiver(string company = "receiverCompany", string name = "receiverName", string surname = "receiverSurname", string street = "receiverStreet", string homeNo = "receiverHomeNo", string city = "receiverCity", string zip = "receiverZip", string country = "United States", string mobile = "123456789", string email = "receiver@text.eu")
        {
            return new Address
            {
                Company = company,
                Name = name,
                Surname = surname,
                Street = street,
                HomeNo = homeNo,
                City = city,
                Country = country,
                Mobile = mobile,
                Email = email
            };
        }

        internal static LabelService.Models.Features GetFeatures(string deliveryIns = "deliveryIns", string currency = "USD", decimal price = (decimal)5.5, decimal weight = 3)
        {
            return new LabelService.Models.Features
            {
                DeliveryIns = deliveryIns,
                Currency = currency,
                Price = price,
                Weight = weight
            };
        }
    }
}