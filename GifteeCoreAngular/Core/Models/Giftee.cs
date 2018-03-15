using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GifteeCoreAngular.Core.Models
{
    [Table("Giftees")]
    public class Giftee
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string FirstName { get; set; }
        [MaxLength(255)]
        public string LastName { get; set; }
        [MaxLength(255)]
        public string NickName { get; set; }
        [MaxLength(64)]
        public string Email { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<GifteeEvent> GifteeEvents { get; set; }
        public ICollection<Wishlist> Wishlist { get; set; }
    }
}
