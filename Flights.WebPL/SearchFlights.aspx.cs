using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Flights.BL;

public partial class SearchFlights : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    FlightsBO flightsBo = null;
    DataTable dt = null;
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            flightsBo = new FlightsBO();
            dt = flightsBo.SearchFlights(txtOrigin.Text, txtDestination.Text);
            BindGrid();
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

    public void BindGrid()
    {
        gridView1.DataSource = dt;
        gridView1.DataBind();
    }
    protected void gridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="Edit")
        {
            int index = int.Parse(e.CommandArgument.ToString());
            Session["Id"] = (int)gridView1.DataKeys[index].Value;
            Response.RedirectPermanent("UpdateFlights.aspx");
        }

        if(e.CommandName=="Delete")
        {
            int index = int.Parse(e.CommandArgument.ToString());
            int id = (int)gridView1.DataKeys[index].Value;
            FlightsBO fb = new FlightsBO();
            bool res = fb.DeleteFlight(id);
            if(res==true)
                ClientScript.RegisterStartupScript(this.GetType(), "success", "<script type='text/javascript'>alert('Delete sucess!!');</script>");
            else
                ClientScript.RegisterStartupScript(this.GetType(), "fail", "<script type='text/javascript'>alert('Delete failed!!');</script>");
            BindGrid();      
        }
    }



    protected void gridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}