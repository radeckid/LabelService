using LabelService.DTO;
using LabelService.Models;

namespace LabelServiceTests
{
    internal static class FakeLabelGenerator
    {
        public static Label Generate(
            string senderCompany = "senderCompany",
            string senderName = "senderName",
            string senderSurname = "senderSurname",
            string senderStreet = "senderStreet",
            string senderHomeNo = "HomeNo",
            string senderZip = "senderZip",
            string senderCity = "senderCity",
            string receiverCompany = "receiverCompany",
            string receiverName = "receiverName",
            string receiverSurname = "receiverSurname",
            string receiverStreet = "receiverStreet",
            string receiverHomeNo = "HomeNo",
            string receiverZip = "receiverZip",
            string receiverCity = "receiverCity",
            string receiverMobile = "123456789",
            string receiverEmail = "receiverEmail",
            string deliveryIns = "deliveryIns",
            string price = "5.5",
            string currency = "EUR",
            string weight = "1"
        )
        {
            return new Label
            {
            };
        }
    }
}