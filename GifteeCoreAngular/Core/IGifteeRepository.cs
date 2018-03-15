using GifteeCoreAngular.Core.Models;
using System.Threading.Tasks;

namespace GifteeCoreAngular.Core
{
    public interface IGifteeRepository
    {
        void AddGiftee(Giftee giftee);
        Task<Giftee> GetGifteeAsync(int id, bool includeRelatedUser = false);
        void RemoveGiftee(Giftee giftee);
    }
}
