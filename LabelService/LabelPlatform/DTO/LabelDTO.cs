using LabelPlatform.Models;
using System.ComponentModel.DataAnnotations;

namespace LabelPlatform.DTO
{
    public class LabelDTO : BaseLabel<AddressDTO, FeaturesDTO>
    {
        [Required]
        public override AddressDTO Sender { get; set; }

        [Required]
        public override AddressDTO Receiver { get; set; }

        [Required]
        public override FeaturesDTO Features { get; set; }
    }
}
