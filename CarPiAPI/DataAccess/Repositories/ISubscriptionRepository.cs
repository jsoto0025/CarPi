using System.Linq;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Repositories;

namespace CarPi.DataAccess.Repositories
{
    public interface ISubscriptionRepository : IRepository<Subscription>
    {
        Task<IQueryable<Subscription>> GetUserSubscriptions(int userId);
    }
}