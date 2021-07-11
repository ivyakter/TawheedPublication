using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage_AdminMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {
            loggedInName.InnerText = Session["name"].ToString();
            loggedInUserId.InnerText = Session["userId"].ToString();
            
        }
        logout.Visible = true;
        logout.ServerClick += Logout_ServerClick;
    }

    private void Logout_ServerClick(object sender, EventArgs e)
    {
        Session.RemoveAll();

        Session["userId"] = null;
        Session["name"] = null;
        Session["username"] = null;
        Session["roleId"] = null;
        Response.Redirect("~/Default.aspx");
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("~/Default.aspx");
    }
}

