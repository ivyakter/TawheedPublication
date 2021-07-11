using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_MyAccount_Registration : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        string[] loginfo = new string[15];
        loginfo[0] = txtemaillog.Text;
        loginfo[1] = txtpasslog.Text;

        //bool Checklogin = mydal.checkloginfo(loginfo);
        DataTable dt = mydal.selectinfocustomer(loginfo);
        if (dt.Rows.Count > 0)
        {
            //Page pg = new System.Web.UI.Page();
            Session["CEmail"] = dt.Rows[0]["Email"].ToString();
            Session["FirstName"] = dt.Rows[0]["FirstName"].ToString();
            Session["SurName"] = dt.Rows[0]["SurName"].ToString();
            Session["Password"] = dt.Rows[0]["Password"].ToString();

            //MasterPage_DefaultMaster ms = new MasterPage_DefaultMaster();
            //Label lblEmail = Page.Master.FindControl("lblEmail") as Label;
            //Label lblSurname = Page.Master.FindControl("lblSurname") as Label;
            //Label lblPassword = Page.Master.FindControl("lblPassword") as Label;
            //lblEmail.Text = dt.Rows[0]["Email"].ToString();
            //lblSurname.Text = dt.Rows[0]["FirstName"].ToString();
            //lblPassword.Text = dt.Rows[0]["Password"].ToString();
            Response.Redirect("~/Pages/MyAccount/MyAccount.aspx");

        }
        DataTable dt1 = mydal.selectinfoAdmin(loginfo);
        if (dt1.Rows.Count > 0)
        {
            //Page pg = new System.Web.UI.Page();
            Session["AEmail"] = dt1.Rows[0]["Email"].ToString();
            Session["Email"] = dt1.Rows[0]["Email"].ToString();
            Session["name"] = dt1.Rows[0]["Name"].ToString();
            Session["userId"] = dt1.Rows[0]["Id"].ToString();
            Session["Password"] = dt1.Rows[0]["Password"].ToString();            
            Response.Redirect("~/Pages/Set/DashBoard.aspx");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('Something wrong please try again');", true);
        }
    }
   
}