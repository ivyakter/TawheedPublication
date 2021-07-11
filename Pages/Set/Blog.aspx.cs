using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Set_Blog : System.Web.UI.Page
{
    private DAL BlogManager = new DAL();

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
            GetAllBlogRecord();
        }
    }

    protected void btnAddBlog_Click(object sender, EventArgs e)
    {
        panelBlogTable.Visible = false;
        panelAddBlog.Visible = true;
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

        DataTable maxId = BlogManager.GetLastBlogId();
        string code = "B" + maxId.Rows[0]["Id"].ToString();
        string[] insert = new string[10];
        insert[0] = txtTitle.Text;
        insert[1] = txtDescription.Text;
        insert[2] = "Admin";
        insert[3] = "Admin";
        insert[4] = date;
        insert[5] = "Admin";
        insert[6] = date;
        insert[7] = "Inactive";
        insert[8] = "";
        insert[9] = ddlCategory.SelectedItem.Text;
        if (fileFrontImage.HasFile)
        {
            string SavePath = Server.MapPath("~/lib/Blog");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extention = Path.GetExtension(fileFrontImage.PostedFile.FileName);
            fileFrontImage.SaveAs(SavePath + "\\" + code + Extention);
            insert[8] = code + Extention;
        }
        else if (txtVideo.Text != "")
        {
            insert[8] = txtVideo.Text;
            insert[9] = "Video";
        }
        bool save = BlogManager.InsertBlog(insert);
        Response.Redirect(Request.RawUrl);
    }

    private void GetAllBlogRecord()
    {
        DataTable dt = BlogManager.GetBlog();
        //gridViewBlog.DataSourceID = "SqlDataSource1";
        gridViewBlog.DataSource = dt;
        gridViewBlog.DataBind();
    }

    private void GetBlogById(int blogId)
    {
        var result = BlogManager.GetBlogById(blogId);
        if (result.Rows.Count > 0)
        {
            //var policy = result.First();
            txtTitle.Text = result.Rows[0]["Title"].ToString();
            txtDescription.Text = result.Rows[0]["Description"].ToString();
            gridViewImage.DataSource = result;
            gridViewImage.DataBind();
            panelImageEditView.Visible = true;
        }
        else
        {
            txtTitle.Text = string.Empty; ;
            txtDescription.Text = string.Empty; ;
            //txtVat.Text = string.Empty;
        }
    }

    private void GetBlogByIdForDetailView(int blogId)
    {
        var result = BlogManager.GetBlogById(blogId);
        if (result.Rows.Count > 0)
        {
            //var policy = result.First();
            lblBlogIdView.Text = result.Rows[0]["Id"].ToString();
            lblBlogTitleView.Text = result.Rows[0]["Title"].ToString();
            lblDescriptionView.Text = result.Rows[0]["Description"].ToString();
            lblEmailView.Text = result.Rows[0]["Email"].ToString();
            lblCreatedByView.Text = result.Rows[0]["CreatedBy"].ToString();
            lblCreateDateTimeView.Text = result.Rows[0]["CreatedDate"].ToString();
            lblLastUpdatedByView.Text = result.Rows[0]["UpdatedBy"].ToString();
            lblLastUpdatedOnView.Text = result.Rows[0]["UpdatedDate"].ToString();
            ddlCategory.SelectedItem.Text = result.Rows[0]["Code"].ToString();
            rptBlogImage.DataSource = result;
            rptBlogImage.DataBind();
        }
    }

    protected void btnGoBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    protected void gridViewBlog_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditBlog" && e.CommandName != "RemoveBlog"
            && e.CommandName != "DetailBlog" && e.CommandName != "ActivateDeactivate")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewBlog.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int BlogId = Convert.ToInt32(lblhiddenFieldForId.Text);

            GetBlogById(BlogId);

            panelBlogTable.Visible = false;
            panelAddBlog.Visible = true;
            btnSubmit.Visible = false;
            btnUpdate.Visible = true;
        }
        else if (e.CommandName == "DetailBlog" && e.CommandName != "RemoveBlog"
            && e.CommandName != "EditBlog" && e.CommandName != "ActivateDeactivate")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewBlog.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int BlogId = Convert.ToInt32(lblhiddenFieldForId.Text);

            GetBlogByIdForDetailView(BlogId);

            panelDetail.Visible = true;
            panelBlogTable.Visible = false;
            panelAddBlog.Visible = false;
            btnSubmit.Visible = false;
            btnUpdate.Visible = false;
        }
        else if (e.CommandName == "RemoveBlog" && e.CommandName != "EditBlog"
            && e.CommandName != "DetailBlog" && e.CommandName != "ActivateDeactivate")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewBlog.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int BlogId = Convert.ToInt32(lblhiddenFieldForId.Text);

            BlogManager.DeleteBlog(BlogId);
            GetAllBlogRecord();
        }
        else if (e.CommandName == "ActivateDeactivate" && e.CommandName != "RemoveBlog"
            && e.CommandName != "EditBlog" && e.CommandName != "DetailBlog")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewBlog.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int BlogId = Convert.ToInt32(lblhiddenFieldForId.Text);

            var result = BlogManager.GetBlogById(BlogId);
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
                    bool update = BlogManager.UpdateBlogStatus(Status, LastUpdatedBy, LastUpdatedDateTime, BlogId);
                    GetAllBlogRecord();
                }
                else if (result.Rows[0]["Status"].ToString() == "Inactive")
                {
                    string Status = "Active";
                    string LastUpdatedBy = "Admin";
                    string LastUpdatedDateTime = date;
                    bool update = BlogManager.UpdateBlogStatus(Status, LastUpdatedBy, LastUpdatedDateTime, BlogId);
                    GetAllBlogRecord();
                }
            }
        }
    }

    protected void gridViewBlog_RowDataBound(object sender, GridViewRowEventArgs e)
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
        int blogId = Convert.ToInt32(lblhiddenFieldForId.Text);
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
        string date = now.ToString("yyyy-MM-dd hh:mm:ss tt");

        var result = BlogManager.GetBlogById(blogId);
        string code = result.Rows[0]["Code"].ToString();
        string[] insert = new string[10];
        insert[0] = txtTitle.Text;
        insert[1] = txtDescription.Text;
        insert[5] = "Admin";
        insert[6] = date;
        insert[8] = result.Rows[0]["img"].ToString();
        insert[9] = ddlCategory.SelectedItem.Text;
        if (fileFrontImage.HasFile)
        {
            string SavePath = Server.MapPath("~/lib/Blog");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extention = Path.GetExtension(fileFrontImage.PostedFile.FileName);
            fileFrontImage.SaveAs(SavePath + "\\" + code + Extention);
            insert[8] = code + Extention;
        }
        else if (txtVideo.Text != "")
        {
            insert[8] = txtVideo.Text;
        }
        bool Update = BlogManager.UpdateBlog(insert, blogId);
        Response.Redirect(Request.RawUrl);
    }

    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = BlogManager.SearchBlogByName(txtSearch.Text);
        //gridViewBlog.DataSourceID = "SqlDataSource1";
        gridViewBlog.DataSource = dt;
        gridViewBlog.DataBind();
    }
}