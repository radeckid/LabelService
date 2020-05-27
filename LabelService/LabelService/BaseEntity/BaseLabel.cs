using LabelService.Interfaces;

namespace LabelService.Models
{
    public abstract class BaseLabel<A, F> : ILabel where A: IAddress where F: IFeatures
    {
        public virtual A Sender { get; set; }

        public virtual A Receiver { get; set; }

        public virtual F Features { get; set; }

        IAddress ILabel.Sender
        {
            get
            {
                return Sender;
            }
            set
            {
                Sender = (A)value;
            }
        }

        IAddress ILabel.Receiver
        {
            get
            {
                return Receiver;
            }
            set
            {
                Receiver = (A)value;
            }
        }

        IFeatures ILabel.Features
        {
            get
            {
                return Features;
            }
            set
            {
                Features = (F)value;
            }
        }
    }
}
