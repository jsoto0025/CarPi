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
    public class RouteRepository : IRouteRepository
    {
        private readonly CarPiContext _context;

        public RouteRepository(CarPiContext context)
        {
            _context = context;
        }

        public Task<Route> Create(Route model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Route>> GetAll()
        {
            var result = _context.Route
                .Include(x => x.Position)
                .AsQueryable();

            return Task.FromResult(result);
        }

        public Task<Route> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Route model)
        {
            throw new NotImplementedException();
        }
    }
}
