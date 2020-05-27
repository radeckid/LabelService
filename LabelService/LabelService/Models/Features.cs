using LabelService.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace LabelService.Models
{
    public class Features : IFeatures
    {
        public int Id { get; set; }

        public virtual Label Label { get; set; }

        public string DeliveryIns { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public string Weight { get; set; }
    }
}
