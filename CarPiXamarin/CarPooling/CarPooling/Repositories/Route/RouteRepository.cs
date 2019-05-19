using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarPooling.Configuration.AppConfig;
using CarPooling.DTOs.DTOs;
using ServiceStack;

namespace Repositories.Route
{
    class RouteRepository : IRouteRepository
    {
        string BaseUrl { get; set; }

        public RouteRepository(IConfiguration configuration)
        {
            BaseUrl = configuration.BaseApiUrl;
        }

        public Task<List<RouteDTO>> GetAllRoutes()
        {
            var client = new JsonServiceClient(BaseUrl);

            client.AddHeader("Authorization", "Basic bXlfdXNlcm5hbWU6bXlfcGFzc3dvcmQ=");

            var result = client.GetAsync<List<RouteDTO>>("/api/Route/GetAll");

            return result;
        }

        public Task<SubscriptionDTO> Subscribe(SubscriptionDTO subscriptionDTO)
        {
            var client = new JsonServiceClient(BaseUrl);

            client.AddHeader("Authorization", "Basic bXlfdXNlcm5hbWU6bXlfcGFzc3dvcmQ=");

            var result = client.PostAsync<SubscriptionDTO>("/api/Subscription", subscriptionDTO);

            return result;
        }

        public Task Unsubscribe(int subscriptionId)
        {
            var client = new JsonServiceClient(BaseUrl);

            client.AddHeader("Authorization", "Basic bXlfdXNlcm5hbWU6bXlfcGFzc3dvcmQ=");

            var result = client.DeleteAsync<SubscriptionDTO>($"/api/Subscription/Unsubscribe/{subscriptionId}");

            return result;
        }

        public Task<List<SubscriptionDTO>> GetUserSubscription(int userId)
        {
            var client = new JsonServiceClient(BaseUrl);

            client.AddHeader("Authorization", "Basic bXlfdXNlcm5hbWU6bXlfcGFzc3dvcmQ=");

            var result = client.GetAsync<List<SubscriptionDTO>>($"/api/subscription/UserSubscriptions/{userId}");

            return result;
        }
    }
}
