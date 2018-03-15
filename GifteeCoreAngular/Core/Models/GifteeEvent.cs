using System.ComponentModel.DataAnnotations.Schema;

namespace GifteeCoreAngular.Core.Models
{
    [Table("GifteesEvents")]
    public class GifteeEvent
    {
        public int Id { get; set; }

        public int GifteeId { get; set; }
        public Giftee Giftee { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
