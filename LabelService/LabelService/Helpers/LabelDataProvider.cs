﻿using LabelService.Models;

namespace LabelService.Helpers
{
    public class LabelDataProvider
    {
        private Label _label;

        public LabelDataProvider()
        { }

        public void Inicialize(Label label)
        {
            _label = label;
        }

        public string GetSenderZipCity
        {
            get
            {
                return ConnectStringWithSpace(_label.Sender.Zip, _label.Sender.City);
            }
        }

        public string GetSenderStreetHomeNo
        {
            get
            {
                return ConnectStringWithSpace(_label.Sender.Street, _label.Sender.HomeNo);
            }
        }

        public string GetSenderCompanyNameOrName
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_label.Sender.Company))
                {
                    return _label.Sender.Company;
                }

                return ConnectStringWithSpace(_label.Sender.Name, _label.Sender.Surname);
            }
        }

        public string GetReceiverZipCity
        {
            get
            {
                return ConnectStringWithSpace(_label.Receiver.Zip, _label.Receiver.City);
            }
        }

        public string GetReceiverStreetHomeNo
        {
            get
            {
                return ConnectStringWithSpace(_label.Receiver.Street, _label.Receiver.HomeNo);
            }
        }

        public string GetReceiverCompanyNameOrName
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_label.Receiver.Company))
                {
                    return _label.Receiver.Company;
                }

                return ConnectStringWithSpace(_label.Receiver.Name, _label.Receiver.Surname);
            }
        }

        public string GetReceiverAnyContact
        {
            get
            {
                return string.IsNullOrWhiteSpace(_label.Receiver.Mobile) ? string.IsNullOrWhiteSpace(_label.Receiver.Email) ? string.Empty : _label.Receiver.Email : _label.Receiver.Mobile;
            }
        }

        public string GetDeliveryInstruction
        {
            get
            {
                return string.Concat("Delivery instruction: ", _label.Features.DeliveryIns ?? string.Empty);
            }
        }

        public string GetPrice
        {
            get
            {
                return string.Concat("Price: ", ConnectStringWithSpace(_label.Features.Price.ToString(), _label.Features.Currency));
            }
        }

        public string GetWeight
        {
            get
            {
                return string.Concat("Weight: ", _label.Features.Weight, " kg");
            }
        }

        private string ConnectStringWithSpace(string first, string second)
        {
            if (string.IsNullOrWhiteSpace(first))
            {
                if (string.IsNullOrWhiteSpace(second))
                {
                    return string.Empty;
                }

                return second;
            }

            if (string.IsNullOrWhiteSpace(second))
            {
                return first;
            }

            return string.Concat(first, " ", second);
        }
    }
}
