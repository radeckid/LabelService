using LabelService.DTO;
using LabelService.Extensions;

namespace LabelService.Helpers
{
    public class LabelDataProvider
    {
        private LabelDTO _label;

        public LabelDataProvider()
        {}

        public void Inicialize(LabelDTO label)
        {
            _label = label;
        }

        public string GetSenderZipCity
        {
            get
            {
                return ConnectStringWithSpace(_label.SenderZip, _label.SenderCity);
            }
        }

        public string GetSenderStreetHomeNo
        {
            get
            {
                return ConnectStringWithSpace(_label.SenderStreet, _label.SenderHomeNo);
            }
        }

        public string GetSenderCompanyNameOrName
        {
            get
            {
                if (!_label.SenderCompany.IsNullOrWhiteSpace())
                {
                    return _label.SenderCompany;
                }

                return ConnectStringWithSpace(_label.SenderName, _label.SenderSurname);
            }
        }

        public string GetReceiverZipCity
        {
            get
            {
                return ConnectStringWithSpace(_label.ReceiverZip, _label.ReceiverCity);
            }
        }

        public string GetReceiverStreetHomeNo
        {
            get
            {
                return ConnectStringWithSpace(_label.ReceiverStreet, _label.ReceiverHomeNo);
            }
        }

        public string GetReceiverCompanyNameOrName
        {
            get
            {
                if (!_label.ReceiverCompany.IsNullOrWhiteSpace())
                {
                    return _label.ReceiverCompany;
                }

                return ConnectStringWithSpace(_label.ReceiverName, _label.ReceiverSurname);
            }
        }

        public string GetReceiverAnyContact
        {
            get
            {
                return _label.ReceiverMobile.IsNullOrWhiteSpace() ? _label.ReceiverEmail.IsNullOrWhiteSpace() ? string.Empty : _label.ReceiverEmail : _label.ReceiverMobile;
            }
        }

        public string GetDeliveryInstruction
        {
            get
            {
                return string.Concat("Delivery instruction: ", _label.DeliveryIns ?? string.Empty);
            }
        }

        public string GetPrice
        {
            get
            {
                return string.Concat("Price: ", ConnectStringWithSpace(_label.Price, _label.Currency));
            }
        }

        public string GetWeight
        {
            get
            {
                if(_label.Weight.IsNullOrWhiteSpace())
                {
                    _label.Weight = "0";
                }
                return string.Concat("Weight: ", _label.Weight, " kg");
            }
        }

        private string ConnectStringWithSpace(string first, string second)
        {
            if (first.IsNullOrWhiteSpace())
            {
                if (second.IsNullOrWhiteSpace())
                {
                    return string.Empty;
                }

                return second;
            }

            if (second.IsNullOrWhiteSpace())
            {
                return first;
            }

            return string.Concat(first, " ", second);
        }
    }
}
