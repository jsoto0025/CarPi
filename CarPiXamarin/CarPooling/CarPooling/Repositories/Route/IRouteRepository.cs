using CarPooling.DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Route
{
    public interface IRouteRepository
    {
        Task<List<RouteDTO>> GetAllRoutes();
        Task<SubscriptionDTO> Subscribe(SubscriptionDTO subscriptionDTO);
        Task Unsubscribe(int subscriptionId);
        Task<List<SubscriptionDTO>> GetUserSubscription(int userId);
    }
}
