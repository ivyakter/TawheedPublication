using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Set_Category : System.Web.UI.Page
{
    DAL categoryManager = new DAL();
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
            GetAllCategoryRecord();
        }
    }

    protected void btnAddCategory_Click(object sender, EventArgs e)
    {
        panelCategoryTable.Visible = false;
        panelAddCategory.Visible = true;
        btnSubmit.Visible = true;
        btnUpdate.Visible = false;
    }
    protected void gridViewCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GetAllCategoryRecord();
        gridViewCategory.PageIndex = e.NewPageIndex;
        gridViewCategory.DataBind();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    private void AddCategory()
    {
        DataTable CategoryID = categoryManager.GetSubjectNo();
        txtsubcatid.Text = "B/" + CategoryID.Rows[0][0].ToString();
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
        string date = now.ToString("yyyy-MM-dd hh:mm:ss tt");

        //tblCategory category = new tblCategory();
        string[] insert = new string[10];
        insert[0] = txtCategoryName.Text;
        insert[1] = txtDescription.Text;
        insert[2] = "Active";
        insert[3] = "Admin";
        insert[4] = date;
        insert[5] = "Admin";
        insert[6] = date;
        insert[7] = txtsubcatid.Text;
        bool save = categoryManager.InsertPublicationBook(insert);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //DataTable check = categoryManager.CheckSubject(txtCategoryName.Text);
        //if (check.Rows.Count != 0)
        //{
        //    Page.ClientScript.RegisterStartupScript
        //        (GetType(), "msgbox", "alert('" + txtCategoryName.Text + " " + "already exists!" + "');", true);
        //    txtCategoryName.Focus();
        //}
        //else
        //{

        //}
        AddCategory();
        Response.Redirect(Request.RawUrl);
    }

    private void GetAllCategoryRecord()
    {
        DataTable dt = categoryManager.GetAllPublication();
        //gridViewCategory.DataSourceID = "SqlDataSource1";
        gridViewCategory.DataSource = dt;
        gridViewCategory.DataBind();
    }

    private void GetCategoryById(int categoryId)
    {
        var result = categoryManager.getPublicationBook(categoryId);
        if (result.Rows.Count > 0)
        {
            //var category = result.First();
            txtCategoryName.Text = result.Rows[0]["Name"].ToString();
        }
        else
        {
            txtCategoryName.Text = string.Empty;
        }
    }

    private void GetCategoryByIdForDetailView(int categoryId)
    {
        var result = categoryManager.getPublicationBook(categoryId);
        if (result.Rows.Count > 0)
        {
            //var category = result.First();
            lblCategoryIdView.Text = result.Rows[0]["Id"].ToString();
            lblCategoryNameView.Text = result.Rows[0]["Name"].ToString();
            lblStatusView.Text = result.Rows[0]["Status"].ToString();
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

    protected void gridViewCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditCategory" && e.CommandName != "RemoveCategory"
            && e.CommandName != "DetailCategory" && e.CommandName != "ActivateDeactivate")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewCategory.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int categoryId = Convert.ToInt32(lblhiddenFieldForId.Text);

            GetCategoryById(categoryId);

            panelCategoryTable.Visible = false;
            panelAddCategory.Visible = true;
            btnSubmit.Visible = false;
            btnUpdate.Visible = true;
        }
        else if (e.CommandName == "DetailCategory" && e.CommandName != "RemoveCategory"
            && e.CommandName != "EditCategory" && e.CommandName != "ActivateDeactivate")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewCategory.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int categoryId = Convert.ToInt32(lblhiddenFieldForId.Text);

            GetCategoryByIdForDetailView(categoryId);

            panelDetail.Visible = true;
            panelCategoryTable.Visible = false;
            panelAddCategory.Visible = false;
            btnSubmit.Visible = false;
            btnUpdate.Visible = false;
        }
        else if (e.CommandName == "RemoveCategory" && e.CommandName != "EditCategory"
            && e.CommandName != "DetailCategory" && e.CommandName != "ActivateDeactivate")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewCategory.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int categoryId = Convert.ToInt32(lblhiddenFieldForId.Text);

            categoryManager.DeletePublication(categoryId);
            GetAllCategoryRecord();
        }
        else if (e.CommandName == "ActivateDeactivate" && e.CommandName != "RemoveCategory"
            && e.CommandName != "EditCategory" && e.CommandName != "DetailCategory")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewCategory.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int categoryId = Convert.ToInt32(lblhiddenFieldForId.Text);

            var result = categoryManager.getPublicationBook(categoryId);
            if (result.Rows.Count > 0)
            {
                //var data = entities.tblCategories.Where(c => c.Id == categoryId).FirstOrDefault();
                var data = categoryManager.getPublicationBook(categoryId);
                var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
                var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
                string date = now.ToString("yyyy-MM-dd hh:mm:ss tt");

                if (data.Rows[0]["Status"].ToString() == "Active")
                {
                    string[] insert = new string[10];
                    insert[0] = "Inactive";
                    insert[1] = "Admin";
                    insert[2] = date;
                    bool update = categoryManager.UpdatePublicationStatus(insert, categoryId);
                    GetAllCategoryRecord();
                }
                else if (data.Rows[0]["Status"].ToString() == "Inactive")
                {
                    string[] insert = new string[10];
                    insert[0] = "Active";
                    insert[1] = "Admin";
                    insert[2] = date;
                    bool update = categoryManager.UpdatePublicationStatus(insert, categoryId);
                    GetAllCategoryRecord();
                }
            }
        }
    }

    protected void gridViewCategory_RowDataBound(object sender, GridViewRowEventArgs e)
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
        int categoryId = Convert.ToInt32(lblhiddenFieldForId.Text);
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
        string date = now.ToString("yyyy-MM-dd hh:mm:ss tt");

        string[] insert = new string[10];
        insert[0] = txtCategoryName.Text;
        insert[2] = "Admin";
        insert[3] = date;
        categoryManager.UpdatePublication(insert, categoryId);
        Response.Redirect(Request.RawUrl);

    }

    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        var result = categoryManager.getPublicationBookByName(txtSearch.Text);
        gridViewCategory.DataSource = result;
        gridViewCategory.DataBind();
    }
}