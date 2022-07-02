using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Flights.BL;
using Flights.DAL;
public partial class UpdateFlights : System.Web.UI.Page
{
    private int id;
    private string flightNumber;
    private string flightName;
    private string origin;
    private string dest;
    private int seatsAvailable;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            FlightsBO flightbo = new FlightsBO();
            DataTable dt = flightbo.ViewFlight(Convert.ToInt32(Session["Id"]));
            txtflightNo.Text = dt.Rows[0]["FlightNumber"].ToString();
            txtflightName.Text = dt.Rows[0]["FlightName"].ToString();
            txtoriginCity.Text = dt.Rows[0]["Origin"].ToString();
            txtdestCity.Text = dt.Rows[0]["Destination"].ToString();
            txtseatsAvailable.Text = dt.Rows[0]["SeatsAvailable"].ToString();
        }
    }





    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            FlightInfo flightInfo = new FlightInfo();
            flightInfo.Id  = Convert.ToInt32(Session["Id"]);
            flightInfo.FlightNumber = txtflightNo.Text;
            flightInfo.FlightName = txtflightName.Text;
            flightInfo.Origin = txtoriginCity.Text;
            flightInfo.Destination = txtdestCity.Text;
            flightInfo.SeatsAvailable = Convert.ToInt32(txtseatsAvailable.Text);
            FlightsBO flightBo = new FlightsBO();
            bool res = flightBo.UpdateFlight(flightInfo);
            if (res)
                ClientScript.RegisterStartupScript(this.GetType(), "success", "<script type='text/javascript'>alert('Update sucess!!');</script>");
            else
                ClientScript.RegisterStartupScript(this.GetType(), "fail", "<script type='text/javascript'>alert('Update failed!!');</script>");
            Response.Redirect("SearchFlights.aspx");
        }
        catch(SqlException ex)
        {
            Response.Write(ex.Message);
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}