using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.DTOs.DTOs
{
    public class RouteDTO
    {
        public int RouteId { get; set; }
        public string Name { get; set; }

        public List<PositionDTO> Position { get; set; }
    }
}
