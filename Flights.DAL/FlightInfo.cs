using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.DAL
{
    public class FlightInfo
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string FlightName { get; set; }
        public string Origin { get; set; }

        public string Destination { get; set; }

        public int SeatsAvailable { get; set; }

    }
}
