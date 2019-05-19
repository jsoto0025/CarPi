using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarPi.DataAccess.Repositories;
using CarPi.DTOs.DTO;
using CarPi.Web.Auth;
using DataAccess.Database;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarPi.Web.Api
{
    [Route("api/[controller]")]
    [BasicAuthorize("my_username", "my_password")]
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionController(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        [HttpGet("UserSubscriptions/{userId}")]
        public async Task<IEnumerable<SubscriptionDTO>> Subscribe(int userId)
        {
            var result = await _subscriptionRepository.GetUserSubscriptions(userId);

            return result.Select(x => AutoMapper.Mapper.Map<SubscriptionDTO>(x));
        }

        [HttpPost]
        public async Task<SubscriptionDTO> Subscribe([FromBody] SubscriptionDTO subscriptionDTO)
        {
            var subscription = AutoMapper.Mapper.Map<Subscription>(subscriptionDTO);

            var result = await _subscriptionRepository.Create(subscription);

            return AutoMapper.Mapper.Map<SubscriptionDTO>(result);
        }

        [HttpDelete("Unsubscribe/{subscriptionId}")]
        public async Task Unsubscribe(int subscriptionId)
        {
            await _subscriptionRepository.DeleteById(subscriptionId);
        }
    }
}