
using System.ComponentModel.DataAnnotations;

namespace LabelService.DTO
{
    public class LabelDTO
    {
        public string SenderCompany { get; set; }

        [Required]
        public string SenderName { get; set; }

        public string SenderSurname { get; set; }

        [Required]
        public string SenderStreet { get; set; }

        [Required]
        public string SenderHomeNo { get; set; }

        [Required]
        public string SenderZip { get; set; }

        [Required]
        public string SenderCity { get; set; }


        public string ReceiverCompany { get; set; }

        [Required]
        public string ReceiverName { get; set; }

        public string ReceiverSurname { get; set; }

        [Required]
        public string ReceiverStreet { get; set; }

        [Required]
        public string ReceiverHomeNo { get; set; }

        [Required]
        public string ReceiverZip { get; set; }

        [Required]
        public string ReceiverCity { get; set; }

        public string ReceiverMobile { get; set; }

        public string ReceiverEmail { get; set; }


        public string DeliveryIns { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public string Weight { get; set; }
    }
}
