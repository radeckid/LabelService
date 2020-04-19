using LabelService.DTO;
using LabelService.Extensions;

namespace LabelService.Helpers
{
    public class LabelDataProvider
    {
        private LabelDTO _label;

        public LabelDataProvider(LabelDTO label)
        {
            _label = label;
        }

        public string GetSenderZipCity
        {
            get
            {
                return string.Concat(_label.SenderZip, " ", _label.SenderCity);
            }
        }

        public string GetSenderStreetHomeNo
        {
            get
            {
                return string.Concat(_label.SenderStreet, " ", _label.SenderHomeNo);
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

                return string.Concat(_label.SenderName, " ", _label.SenderSurname);
            }
        }

        public string GetReceiverZipCity
        {
            get
            {
                return string.Concat(_label.ReceiverZip, " ", _label.ReceiverCity);
            }
        }

        public string GetReceiverStreetHomeNo
        {
            get
            {
                return string.Concat(_label.ReceiverStreet, " ", _label.ReceiverHomeNo);
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

                return string.Concat(_label.ReceiverName, " ", _label.ReceiverSurname);
            }
        }

        public string GetReceiverAnyContact
        {
            get
            {
                return _label.ReceiverMobile.IsNullOrWhiteSpace() ? _label.ReceiverEmail : _label.ReceiverMobile;
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
                return string.Concat("Price: ", _label.Price, " ", _label.Currency);
            }
        }

        public string GetWeight
        {
            get
            {
                return string.Concat("Weight: ", _label.Weight, " kg");
            }
        }
    }
}
