

namespace LabelService.Interfaces
{
    public interface ILabel
    {
        IAddress Sender { get; set; }

        IAddress Receiver { get; set; }

        IFeatures Features { get; set; }
    }
}
