using LabelPlatform.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace LabelPlatform.DTO
{
    public class AddressDTO : IAddress
    {
        public string Company { get; set; }

        [Required]
        public string Name { get; set; }

        public string Surname { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string HomeNo { get; set; }

        [Required]
        public string Zip { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }
    }
}
