using System.ComponentModel.DataAnnotations.Schema;

namespace LabelService.Models
{
    public class Label : BaseLabel<Address, Features>
    {
        public int LabelId { get; set; }

        [ForeignKey("Sender")]
        public int SenderId { get; set; }

        [ForeignKey("Receiver")]
        public int ReceiverId { get; set; }

        [ForeignKey("Features")]
        public int FeaturesId { get; set; }

        public string Identcode { get; set; }

        public string Base64 { get; set; }
    }
}