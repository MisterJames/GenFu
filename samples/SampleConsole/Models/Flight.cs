using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsole.Models
{
    class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }

        public string PilotFirstName { get; set; }
        public string PilotLastName { get; set; }

        public string CoPilotFirstName { get; set; }
        public string CoPilotLastName { get; set; }

        public string PlaneType { get; set; }
        public int Range { get; set; }

        public override string ToString()
        {
            return String.Format("Flight Number {0}. Is being piloted by {1} {2} and assisted by {3} {4}.  The plane is a {5} with a range of {6}km",
                FlightNumber,
                PilotFirstName,
                PilotLastName,
                CoPilotFirstName,
                CoPilotLastName,
                PlaneType,
                Range);
        }
    }
}
