using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Set_Admin : System.Web.UI.Page
{
    private DAL userManager = new DAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["roleId"] == null)
        //{
        //    Response.Redirect("~/ViewsAndControllers/Home/Login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        //}
        //else if (Session["roleId"].ToString() == "1")
        //{
        //    if (string.IsNullOrEmpty(Convert.ToString(Session["userId"])))
        //    {
        //        Response.Redirect("~/ViewsAndControllers/Home/Login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        //    }
        //}
        //else if (Session["roleId"].ToString() == "2")
        //{
        //    Server.Transfer("~/ViewsAndControllers/Shared/AccessDenied.aspx");
        //}

        if (!IsPostBack)
        {
            GetAllAdminRecord();
        }
    }

    protected void btnAddAdmin_Click(object sender, EventArgs e)
    {
        panelAdminTable.Visible = false;
        panelAddAdmin.Visible = true;
        btnSubmit.Visible = true;
        btnUpdate.Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    private void AddAdmin()
    {
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
        string date = now.ToString("yyyy-MM-dd hh:mm:ss tt");

        string[] insert = new string[10];
        insert[0] = txtName.Text;
        insert[1] = txtEmail.Text;
        insert[2] = txtConfirmPassword.Text;
        insert[3] = txtPhone.Text;
        insert[4] = "Admin";
        insert[5] = date;
        insert[6] = "Active";
        bool save = userManager.InsertAdmin(insert);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {      
        DataTable checkAdmin = userManager.GetAdmin(txtName.Text, txtEmail.Text, txtPhone.Text);
        if (checkAdmin.Rows.Count > 0)
        {
            Page.ClientScript.RegisterStartupScript
                (GetType(), "msgbox", "alert('" + "User already exists!" + "');", true);
        }
        else
        {
            AddAdmin();
            Response.Redirect(Request.RawUrl);
        }
    }

    private void GetAllAdminRecord()
    {
        gridViewAdmin.DataSourceID = "SqlDataSource1";
        gridViewAdmin.DataBind();
    }

    private void GetAdminById(int adminId)
    {
        var result = userManager.GetAdminById(adminId);
        if (result.Rows.Count > 0)
        {
            txtName.Text = result.Rows[0]["Name"].ToString();
            txtPhone.Text = result.Rows[0]["MobileNo"].ToString();
            txtEmail.Text = result.Rows[0]["Email"].ToString();
            txtPassword.Text = result.Rows[0]["Password"].ToString();
        }
        else
        {
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
    }

    private void GetAdminByIdForDetailView(int adminId)
    {
        var result = userManager.GetAdminById(adminId);
        if (result.Rows.Count > 0)
        {
            lblAdminIdView.Text = result.Rows[0]["Id"].ToString();
            lblAdminNameView.Text = result.Rows[0]["Name"].ToString();
            lblMobileView.Text = result.Rows[0]["MobileNo"].ToString();
            lblEmailView.Text = result.Rows[0]["Email"].ToString();
            lblStatusView.Text = result.Rows[0]["Status"].ToString();
            lblCreateDateTimeView.Text = result.Rows[0]["CreatedDate"].ToString();
        }
    }

    protected void btnGoBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    protected void gridViewAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditAdmin" && e.CommandName != "RemoveAdmin"
            && e.CommandName != "DetailAdmin" && e.CommandName != "ActivateDeactivate")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewAdmin.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int adminId = Convert.ToInt32(lblhiddenFieldForId.Text);

            GetAdminById(adminId);

            panelAdminTable.Visible = false;
            panelAddAdmin.Visible = true;
            btnSubmit.Visible = false;
            btnUpdate.Visible = true;
        }
        else if (e.CommandName == "DetailAdmin" && e.CommandName != "RemoveAdmin"
            && e.CommandName != "EditAdmin" && e.CommandName != "ActivateDeactivate")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewAdmin.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int adminId = Convert.ToInt32(lblhiddenFieldForId.Text);

            GetAdminByIdForDetailView(adminId);

            panelDetail.Visible = true;
            panelAdminTable.Visible = false;
            panelAddAdmin.Visible = false;
            btnSubmit.Visible = false;
            btnUpdate.Visible = false;
        }
        else if (e.CommandName == "RemoveAdmin" && e.CommandName != "EditAdmin"
            && e.CommandName != "DetailAdmin" && e.CommandName != "ActivateDeactivate")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewAdmin.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int AdminId = Convert.ToInt32(lblhiddenFieldForId.Text);

            userManager.DeleteAdmin(AdminId);
            GetAllAdminRecord();
        }
        else if (e.CommandName == "ActivateDeactivate" && e.CommandName != "RemoveAdmin"
            && e.CommandName != "EditAdmin" && e.CommandName != "DetailAdmin")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewAdmin.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int adminId = Convert.ToInt32(lblhiddenFieldForId.Text);

            var result = userManager.GetAdminById(adminId);
            if (result.Rows.Count > 0)
            {
                var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
                var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
                string date = now.ToString("yyyy-MM-dd hh:mm:ss tt");

                if (result.Rows[0]["Status"].ToString() == "Active")
                {
                    string[] update = new string[5];
                    update[0] = "Inactive";
                    update[1] = date;
                    bool save = userManager.UpdateAdminStatus(update, adminId);
                    GetAllAdminRecord();
                }
                else if (result.Rows[0]["Status"].ToString() == "Inactive")
                {
                    string[] update = new string[5];
                    update[0] = "Active";
                    update[1] = date;
                    bool save = userManager.UpdateAdminStatus(update, adminId);
                    GetAllAdminRecord();
                }
            }
        }
    }

    protected void gridViewAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Normal)))
            {
                string statusValue = DataBinder.Eval(e.Row.DataItem, "Status").ToString();

                LinkButton btnStatus = (LinkButton)e.Row.FindControl("btnStatus");

                if (statusValue == "Active")
                {
                    btnStatus.CssClass = "badge badge-success";
                    btnStatus.ForeColor = System.Drawing.Color.White;
                }
                else if (statusValue == "Inactive")
                {
                    btnStatus.CssClass = "badge badge-danger";
                    btnStatus.ForeColor = System.Drawing.Color.White;
                }
            }
        }
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
        string date = now.ToString("yyyy-MM-dd hh:mm:ss tt");
        int adminId = Convert.ToInt32(lblhiddenFieldForId.Text);
        string[] insert = new string[10];
        insert[0] = txtName.Text;
        insert[1] = txtEmail.Text;
        insert[2] = txtConfirmPassword.Text;
        insert[3] = txtPhone.Text;
        insert[4] = "Admin";
        insert[5] = date;
        bool save = userManager.UpdateAdmin(insert, adminId);
        Response.Redirect(Request.RawUrl);
    }
}