using GifteeCoreAngular.Core;
using GifteeCoreAngular.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GifteeCoreAngular.Persistence
{
    // A collection of Domain objects in memory
    public class GifteeRepository : IGifteeRepository
    {
        private readonly GifteeDbContext context;

        public GifteeRepository(GifteeDbContext context)
        {
            this.context = context;
        }


        public void AddGiftee(Giftee giftee)
        {
            context.Add(giftee);
        }

        public async Task<Giftee> GetGifteeAsync(int id, bool getRelatedUser = false)
        {
            if (!getRelatedUser)
            {
                return await context.Giftees.FindAsync(id);
            }

            return await context.Giftees.Include(g => g.User).SingleOrDefaultAsync(g => g.Id == id);

        }

        public void RemoveGiftee(Giftee giftee)
        {
            context.Giftees.Remove(giftee);
        }
    }
}
