using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.DTOs.DTOs
{
    public class PositionDTO
    {
        public int PositionId { get; set; }
        public int RouteId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
