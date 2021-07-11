using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Set_Policy : System.Web.UI.Page
{
    private DAL policyManager = new DAL();

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
            GetAllPolicyRecord();
        }
    }

    protected void btnAddPolicy_Click(object sender, EventArgs e)
    {
        panelPolicyTable.Visible = false;
        panelAddPolicy.Visible = true;
        btnSubmit.Visible = true;
        btnUpdate.Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
        string date = now.ToString("yyyy-MM-dd hh:mm:ss tt");

        string[] insert = new string[10];

        insert[0] = txtDeliveryCharge.Text;
        insert[1] = txtShippingCharge.Text;
        insert[2] = txtVat.Text;
        insert[3] = "Active";
        insert[4] = "Admin";
        insert[5] = date;
        insert[6] = "Admin";
        insert[7] = date;

        bool save = policyManager.InsertPolicy(insert);

        Response.Redirect(Request.RawUrl);
    }

    private void GetAllPolicyRecord()
    {
        gridViewPolicy.DataSourceID = "SqlDataSource1";
        gridViewPolicy.DataBind();
    }

    private void GetPolicyById(int policyId)
    {
        var result = policyManager.GetPolicyById(policyId);
        if (result.Rows.Count > 0)
        {
            //var policy = result.First();
            txtDeliveryCharge.Text = result.Rows[0]["DeliveryCharge"].ToString();
            txtShippingCharge.Text = result.Rows[0]["ShippingCharge"].ToString();
            txtVat.Text = result.Rows[0]["Vat"].ToString();
        }
        else
        {
            txtDeliveryCharge.Text = string.Empty; ;
            txtShippingCharge.Text = string.Empty; ;
            txtVat.Text = string.Empty;
        }
    }

    private void GetPolicyByIdForDetailView(int policyId)
    {
        var result = policyManager.GetPolicyById(policyId);
        if (result.Rows.Count > 0)
        {
            //var policy = result.First();
            lblPolicyIdView.Text = result.Rows[0]["Id"].ToString();
            lblDeliveryChargeView.Text = result.Rows[0]["DeliveryCharge"].ToString();
            lblShippingChargeView.Text = result.Rows[0]["ShippingCharge"].ToString();
            lblVatView.Text = result.Rows[0]["Vat"].ToString();
            lblCreatedByView.Text = result.Rows[0]["CreatedBy"].ToString();
            lblCreateDateTimeView.Text = result.Rows[0]["CreatedDateTime"].ToString();
            lblLastUpdatedByView.Text = result.Rows[0]["LastUpdatedBy"].ToString();
            lblLastUpdatedOnView.Text = result.Rows[0]["LastUpdatedDateTime"].ToString();
        }
    }

    protected void btnGoBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    protected void gridViewPolicy_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditPolicy" && e.CommandName != "RemovePolicy"
            && e.CommandName != "DetailPolicy" && e.CommandName != "ActivateDeactivate")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewPolicy.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int policyId = Convert.ToInt32(lblhiddenFieldForId.Text);

            GetPolicyById(policyId);

            panelPolicyTable.Visible = false;
            panelAddPolicy.Visible = true;
            btnSubmit.Visible = false;
            btnUpdate.Visible = true;
        }
        else if (e.CommandName == "DetailPolicy" && e.CommandName != "RemovePolicy"
            && e.CommandName != "EditPolicy" && e.CommandName != "ActivateDeactivate")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewPolicy.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int policyId = Convert.ToInt32(lblhiddenFieldForId.Text);

            GetPolicyByIdForDetailView(policyId);

            panelDetail.Visible = true;
            panelPolicyTable.Visible = false;
            panelAddPolicy.Visible = false;
            btnSubmit.Visible = false;
            btnUpdate.Visible = false;
        }
        else if (e.CommandName == "RemovePolicy" && e.CommandName != "EditPolicy"
            && e.CommandName != "DetailPolicy" && e.CommandName != "ActivateDeactivate")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewPolicy.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int policyId = Convert.ToInt32(lblhiddenFieldForId.Text);

            policyManager.DeletePolicy(policyId);
            GetAllPolicyRecord();
        }
        else if (e.CommandName == "ActivateDeactivate" && e.CommandName != "RemovePolicy"
            && e.CommandName != "EditPolicy" && e.CommandName != "DetailPolicy")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewPolicy.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int policyId = Convert.ToInt32(lblhiddenFieldForId.Text);

            var result = policyManager.GetPolicyById(policyId);
            if (result.Rows.Count > 0)
            {
                var data = result.Rows[0]["Status"].ToString();
                var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
                var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
                string date = now.ToString("yyyy-MM-dd hh:mm:ss tt");

                if (result.Rows[0]["Status"].ToString() == "Active")
                {
                    string Status = "Inactive";
                    string LastUpdatedBy = "Admin";
                    string LastUpdatedDateTime = date;
                    bool update  = policyManager.UpdatePolicyStatus(Status, LastUpdatedBy, LastUpdatedDateTime, policyId);
                    GetAllPolicyRecord();
                }
                else if (result.Rows[0]["Status"].ToString() == "Inactive")
                {
                    string Status = "Active";
                    string LastUpdatedBy = "Admin";
                    string LastUpdatedDateTime = date;
                    bool update = policyManager.UpdatePolicyStatus(Status, LastUpdatedBy, LastUpdatedDateTime, policyId);
                    GetAllPolicyRecord();
                }
            }
        }
    }

    protected void gridViewPolicy_RowDataBound(object sender, GridViewRowEventArgs e)
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

    //private void UpdatePolicyDetail(PolicyViewModel policyViewModel)
    //{
    //    policyManager.UpdatePolicy(policyViewModel);
    //}
    private void UpdatePolicyDetail()
    {
        //policyManager.UpdatePolicy(policyViewModel);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int policyId = Convert.ToInt32(lblhiddenFieldForId.Text);
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
        string date = now.ToString("yyyy-MM-dd hh:mm:ss tt");
        
        string[] insert = new string[10];
        insert[0] = txtDeliveryCharge.Text;
        insert[1] = txtShippingCharge.Text;
        insert[2] = txtVat.Text;
        insert[6] = "Admin";
        insert[7] = date;

        bool save = policyManager.UpdatePolicy(insert, policyId);

        Response.Redirect(Request.RawUrl);
        
    }
}