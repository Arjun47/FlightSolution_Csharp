using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using Flights.Common;
using System.Data;

namespace Flights.DAL
{
    public class FlightsDAO
    {

        public DataTable ViewFlight(int id)
        {
            DataSet ds = null;
            try
            {
                SqlParameter param = new SqlParameter("@id", id);

                ds = SqlHelper.ExecuteDataset(Database.ConnectionString, System.Data.CommandType.StoredProcedure, Database.SP_SEARCHFLIGHTBYID, param);

            }
            catch(SqlException ex)
            {
                throw ex;
            }
            return ds.Tables[0];  // datatable banane ki jarurat nahi hai na ye ds.Tables[0] table hi de raha hai returnmein//thik hai 
        }

        public bool UpdateFlight(FlightInfo flightInfo)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[5] = new SqlParameter("@id", flightInfo.Id);

                param[0] = new SqlParameter("@flightNo", flightInfo.FlightNumber);

                param[1] = new SqlParameter("@flightName", flightInfo.FlightName);

                param[2] = new SqlParameter("@origin", flightInfo.Origin);

                param[3] = new SqlParameter("@destination", flightInfo.Destination);

                param[4] = new SqlParameter("@seatsAvailable", flightInfo.SeatsAvailable);

                int rowsAffected = SqlHelper.ExecuteNonQuery(Database.ConnectionString, CommandType.StoredProcedure, Database.SP_UPDATEFLIGHT, param);

                if (rowsAffected > 0)
                    return true;
                else
                    return false;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        public SqlDataReader SearchFlights(string origin,string destination)
        {
            SqlDataReader reader = null;
            try
            {
                //create sql paramater objects for passing origin and destination to stored proc
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@origin", origin);
                param[1] = new SqlParameter("@destination", destination);

                reader = SqlHelper.ExecuteReader(Database.ConnectionString, System.Data.CommandType.StoredProcedure,
                    Database.SP_SEARCHFLIGHTS, param);
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            return reader;
        }

        public bool AddNewFlight(FlightInfo flightInfo)
        {
            bool isAdded = false;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@fnumber", flightInfo.FlightNumber);
                param[1] = new SqlParameter("@fname", flightInfo.FlightName);
                param[2] = new SqlParameter("@forigin", flightInfo.Origin);
                param[3] = new SqlParameter("@fdestination", flightInfo.Destination);
                param[4] = new SqlParameter("@seats", flightInfo.SeatsAvailable);

                int rowsAffected = SqlHelper.ExecuteNonQuery(Database.ConnectionString, System.Data.CommandType.StoredProcedure,
                    Database.SP_ADDFLIGHTS, param);
                if (rowsAffected > 0)
                    isAdded = true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return isAdded;
        }

        public bool DeleteFlight(int id)
        {
            try
            {
                SqlParameter param = new SqlParameter("@id", id);  // ye dekh bina array banaye bhi pass ho raha hai//oh acha
                int rowsAffected = SqlHelper.ExecuteNonQuery(Database.ConnectionString, CommandType.StoredProcedure, Database.SP_DELETEFLIGHT, param);
                if (rowsAffected > 0)
                    return true;
                else
                    return false;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
