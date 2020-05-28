using LabelPlatform.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace LabelPlatform.DTO
{
    public class FeaturesDTO : IFeatures
    {
        public string DeliveryIns { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public decimal Weight { get; set; }
    }
}
