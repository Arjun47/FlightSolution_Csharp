using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flights.DAL;
using System.Data.SqlClient;
using System.Data;


namespace Flights.BL
{
    public class FlightsBO
    {
        FlightsDAO flightDao = null;
        public bool AddNewFlight(FlightInfo flightInfo)
        {
            bool isAdded = false;
            try
            {
                flightDao = new FlightsDAO();
                isAdded = flightDao.AddNewFlight(flightInfo);
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return isAdded;
        }

        ServiceReference1.IService1 serviceClient = null;
        public DataTable SearchFlights(string origin, string destination)
        {
            //call WCF service method for search functionality
            DataSet ds = null;//add
            try
            {
                serviceClient = new ServiceReference1.Service1Client();
                ds = serviceClient.GetFlights(origin, destination);//update
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return ds.Tables[0];//update
        }

        public DataTable ViewFlight(int id)
        {
            FlightsDAO flightDao = new FlightsDAO();
            return flightDao.ViewFlight(id);
        }

        public bool UpdateFlight(FlightInfo flightInfo)
        {
            FlightsDAO flightDao = new FlightsDAO();
            return flightDao.UpdateFlight(flightInfo);
        }

        public bool DeleteFlight(int id)
        {
            FlightsDAO flightDao = new FlightsDAO();
            return flightDao.DeleteFlight(id);

        }

    }
}
