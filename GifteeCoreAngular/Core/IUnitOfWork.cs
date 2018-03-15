using System.Threading.Tasks;

namespace GifteeCoreAngular.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
