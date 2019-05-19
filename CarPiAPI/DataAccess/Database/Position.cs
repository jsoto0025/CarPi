using System;
using System.Collections.Generic;

namespace DataAccess.Database
{
    public partial class Position
    {
        public int PositionId { get; set; }
        public int RouteId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
        public Route Route { get; set; }
    }
}
