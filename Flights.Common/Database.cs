using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Common
{
    public class Database
    {
        private const string connectionString = @"Data Source=ARJUNSINGHANIYA;Initial Catalog=TrainingPractice;Integrated Security=true";

        public static string ConnectionString => connectionString;

        //stored procedure constants
        public const string SP_SEARCHFLIGHTS = "uspSearchFlights";
        public const string SP_ADDFLIGHTS = "uspAddFlight";
        public const string SP_SEARCHFLIGHTBYID = "uspSearchFlightById";
        public const string SP_UPDATEFLIGHT = "uspUpdateFlightById";
        public const string SP_DELETEFLIGHT = "uspDeleteFlight";
    }
}
