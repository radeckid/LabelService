using LabelService.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace LabelService.DTO
{
    public class FeaturesDTO : IFeatures
    {
        public string DeliveryIns { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public string Weight { get; set; }
    }
}
