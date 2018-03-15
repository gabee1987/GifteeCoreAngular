using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GifteeCoreAngular.Controllers.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public ICollection<GifteeResource> Giftees { get; set; }

        public UserResource()
        {
            Giftees = new Collection<GifteeResource>();
        }
    }
}
