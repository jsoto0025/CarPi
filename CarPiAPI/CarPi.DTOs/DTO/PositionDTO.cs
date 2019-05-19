using System;
using System.Collections.Generic;

namespace CarPi.DTOs.DTO
{
    public class PositionDTO
    {
        public int PositionId { get; set; }
        public int RouteId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
       
    }
}
