using System;
using System.Collections.Generic;

namespace DataAccess.Database
{
    public partial class Route
    {
        public Route()
        {
            Position = new HashSet<Position>();
        }

        public int RouteId { get; set; }
        public string Name { get; set; }

        public ICollection<Position> Position { get; set; }
    }
}
