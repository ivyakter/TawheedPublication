using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Set_DashBoard : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        LoadDetails();
    }
    private void LoadDetails()
    {
        //if (Request.Cookies["AInfo"]["Email"] != null)
        //{
        //    string email = Request.Cookies["AInfo"]["Email"];
        //    string name = Request.Cookies["AInfo"]["Name"];
        //    string password = Request.Cookies["AInfo"]["Password"];
        //}
        string date = DateTime.Now.ToString("dd/MM/yyyy");

        DataTable dt = mydal.GetOrderByDate();
        rptRecentOrder.DataSource = dt;
        rptRecentOrder.DataBind();
    }
}