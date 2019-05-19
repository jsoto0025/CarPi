using DataAccess.Database;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarPi.DataAccess.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly CarPiContext _context;

        public SubscriptionRepository(CarPiContext context)
        {
            _context = context;
        }

        public async Task<Subscription> Create(Subscription model)
        {
            var existingSubscription = _context.Subscription.FirstOrDefault(x => x.RouteId == model.RouteId && x.UserId == model.UserId);

            if (existingSubscription != null)
            {
                return existingSubscription;
            }

            _context.Subscription.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task DeleteById(int id)
        {
            var entity = await _context.Subscription.SingleOrDefaultAsync(m => m.SubscriptionId == id);

            if (entity != null)
            {
                _context.Subscription.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public Task<IQueryable<Subscription>> GetSubscription(int userId, int routeId)
        {
            var result = _context.Subscription
                .Where(x => x.UserId == userId && x.RouteId == routeId)
                .AsQueryable();

            return Task.FromResult(result);
        }

        public Task<Subscription> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Subscription model)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Subscription>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Subscription>> GetUserSubscriptions(int userId)
        {
            var result = _context.Subscription
                .Where(x => x.UserId == userId)
                .AsQueryable();

            return Task.FromResult(result);
        }
    }
}
