using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Flights.DAL;

namespace Flights.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        FlightsDAO flightsDao = null;
        public DataSet GetFlights(string origin, string destination)
        {
            SqlDataReader reader = null;
            DataTable table = null;
            DataSet ds = new DataSet();//
            try
            {
                flightsDao = new FlightsDAO();
                reader = flightsDao.SearchFlights(origin, destination);
                table = new DataTable();
                table.Load(reader);
                ds.Tables.Add(table);//
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            return ds;//
        }
    }
}
