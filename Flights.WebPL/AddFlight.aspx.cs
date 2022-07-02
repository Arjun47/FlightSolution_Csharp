using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Flights.BL;
using Flights.DAL;

public partial class AddFlight : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            FlightInfo flightInfo = new FlightInfo();
            flightInfo.FlightNumber = txtflightNo.Text;
            flightInfo.FlightName = txtflightName.Text;
            flightInfo.Origin = txtoriginCity.Text;
            flightInfo.Destination = txtdestCity.Text;
            flightInfo.SeatsAvailable = Convert.ToInt32(txtseatsAvailable.Text);
            FlightsBO flightBo = new FlightsBO();
            bool result = flightBo.AddNewFlight(flightInfo);
            if (result == true)
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script type='text/javascript'>alert('Flight Added successfully!');</script>");
            else
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script type='text/javascript'>alert('Error while adding Flight!!');</script>");
        }
        catch (SqlException ex)
        {
            Response.Write(ex.Message);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}
