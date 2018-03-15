using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GifteeCoreAngular.Core.Models
{
    [Table("Events")]
    public class Event
    {
        public int Id { get; set; }
        public DateTime EventDate { get; set; }
        [MaxLength(255)]
        public string EventName { get; set; }

        public ICollection<GifteeEvent> GifteeEvents { get; set; }
        public ICollection<EventGift> EventGifts { get; set; }
    }
}
