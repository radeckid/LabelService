namespace LabelPlatform.Interfaces
{
    public interface IFeatures
    {
        string DeliveryIns { get; set; }

        decimal Price { get; set; }

        string Currency { get; set; }

        decimal Weight { get; set; }
    }
}
