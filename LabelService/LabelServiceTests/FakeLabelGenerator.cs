﻿using LabelService.DTO;

namespace LabelServiceTests
{
    internal static class FakeLabelGenerator
    {
        public static LabelDTO Generate(string senderCompany = "senderCompany", string senderName = "senderName", string senderSurname = "senderSurname", string senderStreet = "senderStreet", string senderHomeNo = "HomeNo", string senderZip = "senderZip", string senderCity = "senderCity", string receiverCompany = "receiverCompany", string receiverName = "receiverName", string receiverSurname = "receiverSurname", string receiverStreet = "receiverStreet", string receiverHomeNo = "HomeNo", string receiverZip = "receiverZip", string receiverCity = "receiverCity", string receiverMobile = "123456789", string receiverEmail = "receiverEmail", string deliveryIns = "deliveryIns", string price = "5.5", string currency = "EUR", string weight = "1")
        {
            return new LabelDTO
            {
                SenderCompany = senderCompany,
                SenderName = senderName,
                SenderSurname = senderSurname,
                SenderStreet = senderStreet,
                SenderHomeNo = senderHomeNo,
                SenderZip = senderZip,
                SenderCity = senderCity,
                ReceiverCompany = receiverCompany,
                ReceiverName = receiverName,
                ReceiverSurname = receiverSurname,
                ReceiverStreet = receiverStreet,
                ReceiverHomeNo = receiverHomeNo,
                ReceiverZip = receiverZip,
                ReceiverCity = receiverCity,
                ReceiverEmail = receiverEmail,
                ReceiverMobile = receiverMobile,
                DeliveryIns = deliveryIns,
                Price = price,
                Currency = currency,
                Weight = weight
            };
        }
    }
}