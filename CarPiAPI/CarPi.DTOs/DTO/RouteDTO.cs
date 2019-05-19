using System;
using System.Collections.Generic;

namespace CarPi.DTOs.DTO
{
    public class RouteDTO
    {
        public int RouteId { get; set; }
        public string Name { get; set; }
        //Lista con las posiciones
        public List<PositionDTO> Position { get; set; }
       
    }
}
