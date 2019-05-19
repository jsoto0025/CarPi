using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarPi.DTOs.DTO;
using CarPi.Web.Auth;
using DataAccess.Database;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarPi.Web.Api
{
    [Route("api/[controller]")]
    [BasicAuthorize("my_username", "my_password")]
    public class RouteController : Controller
    {
        private readonly IRouteRepository _routeRepository;

        public RouteController(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        //GET: api/<controller>
        [HttpGet("GetAll")]
        public async Task<IEnumerable<RouteDTO>> GetAll()
        {
            var result = await _routeRepository.GetAll();

            return result
                .Select(x => AutoMapper.Mapper.Map<Route, RouteDTO>(x))
                .ToList();
        }
    }
}