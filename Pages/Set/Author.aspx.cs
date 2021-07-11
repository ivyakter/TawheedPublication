using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class Pages_Set_Author : System.Web.UI.Page
{
    private DAL authorManager = new DAL();

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
            GetAllAuthorRecord();
        }
    }

    protected void btnAddAuthor_Click(object sender, EventArgs e)
    {
        panelAuthorTable.Visible = false;
        panelAddAuthor.Visible = true;
        btnSubmit.Visible = true;
        btnUpdate.Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    private void AddAuthor()
    {
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
        string date = now.ToString("yyyy-MM-dd hh:mm:ss tt");
        DataTable CategoryID = authorManager.GetWriterNo();

        string[] insert = new string[20];

        insert[0] = txtAuthorName.Text;
        insert[1] = txtDescription.Text;
        insert[2] = ddlGender.SelectedItem.Text;
        insert[3] = txtDateOfBirth.Text;
        insert[4] = txtAddress.Text;
        insert[5] = txtEmail.Text;
        insert[6] = ddlPopular.SelectedItem.Text;
        insert[7] = "Active";
        insert[8] = "Admin";
        insert[9] = date;
        insert[10] = "Admin";
        insert[11] = date;
        insert[12] = "W" + CategoryID.Rows[0][0].ToString();
        insert[13] = "";
        if (fileFrontImage.HasFile)
        {
            string SavePath = Server.MapPath("~/BookImage/Writer/") ;
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extention = Path.GetExtension(fileFrontImage.PostedFile.FileName);
            fileFrontImage.SaveAs(SavePath + "\\" + insert[12] + Extention);
            insert[13] = insert[12] + Extention;
        }

        bool Save = authorManager.InsertWriter(insert);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataTable dt = authorManager.CheckAuthe(txtAuthorName.Text, txtEmail.Text, txtAddress.Text);

        if (dt.Rows.Count!=0)
        {
            Page.ClientScript.RegisterStartupScript
                (GetType(), "msgbox", "alert('" + "Record already exists!" + "');", true);
        }
        else
        {
            AddAuthor();
            Response.Redirect(Request.RawUrl);
        }

    }

    private void GetAllAuthorRecord()
    {
        DataTable dt = authorManager.GetAllAuthor();
        //gridViewAuthor.DataSourceID = "SqlDataSource1";
        gridViewAuthor.DataSource = dt;
        gridViewAuthor.DataBind();
    }

    private void GetAuthorById(int authorId)
    {
        var result = authorManager.GetAuthorById(authorId);
        if (result.Rows.Count > 0)
        {
            //var author = result.First();
            lvlWriterCode.Text = result.Rows[0]["Code"].ToString();
            txtAuthorName.Text = result.Rows[0]["Name"].ToString();
            txtDescription.Text = result.Rows[0]["Description"].ToString();
            txtAddress.Text = result.Rows[0]["Address"].ToString();
            //txtDateOfBirth.Text = Convert.ToDateTime(result.Rows[0]["DateOfBirth"].ToString()).ToShortDateString();
            txtDateOfBirth.Text = result.Rows[0]["DateOfBirth"].ToString();
            txtEmail.Text = result.Rows[0]["Email"].ToString();
            ddlPopular.SelectedItem.Text = result.Rows[0]["Phone"].ToString();
            ddlGender.SelectedItem.Text = result.Rows[0]["Gender"].ToString();
            lvlImage.Text = result.Rows[0]["Extension"].ToString();

            panelFrontImageEditView.Visible = true;
            gridViewGetFrontImage.DataSource = result;
            gridViewGetFrontImage.DataBind();
        }
        else
        {
            txtAuthorName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtDateOfBirth.Text = string.Empty;
            txtEmail.Text = string.Empty;
            ddlGender.SelectedItem.Text = string.Empty;
        }
    }

    private void GetAuthorByIdForDetailView(int authorId)
    {
        var result = authorManager.GetAuthorById(authorId);
        if (result.Rows.Count > 0)
        {
            //var author = result.First();
            lblAuthorIdView.Text = result.Rows[0]["Id"].ToString();
            lblAuthorNameView.Text = result.Rows[0]["Name"].ToString();
            lblDescriptionView.Text = result.Rows[0]["Description"].ToString();
            //lblDateOfBirthView.Text = Convert.ToDateTime(result.Rows[0]["DateOfBirth"].ToString()).ToShortDateString();
            lblDateOfBirthView.Text = result.Rows[0]["DateOfBirth"].ToString();
            lblGenderView.Text = result.Rows[0]["Gender"].ToString();
            lblAddressView.Text = result.Rows[0]["Address"].ToString();
            lblEmailView.Text = result.Rows[0]["Email"].ToString();
            lblPhoneView.Text = result.Rows[0]["Phone"].ToString();
            lblStatusView.Text = result.Rows[0]["Status"].ToString();
            lblCreatedByView.Text = result.Rows[0]["CreatedBy"].ToString();
            lblCreateDateTimeView.Text = result.Rows[0]["CreatedDateTime"].ToString();
            lblLastUpdatedByView.Text = result.Rows[0]["LastUpdatedBy"].ToString();
            lblLastUpdatedOnView.Text = result.Rows[0]["Name"].ToString();

            gridViewImage.DataSource = result;
            gridViewImage.DataBind();
        }
    }

    protected void btnGoBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    protected void gridViewAuthor_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditAuthor" && e.CommandName != "RemoveAuthor"
            && e.CommandName != "DetailAuthor" && e.CommandName != "ActivateDeactivate")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewAuthor.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int AuthorId = Convert.ToInt32(lblhiddenFieldForId.Text);

            GetAuthorById(AuthorId);

            panelAuthorTable.Visible = false;
            panelAddAuthor.Visible = true;
            btnSubmit.Visible = false;
            btnUpdate.Visible = true;
        }
        else if (e.CommandName == "DetailAuthor" && e.CommandName != "RemoveAuthor"
            && e.CommandName != "EditAuthor" && e.CommandName != "ActivateDeactivate")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewAuthor.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int AuthorId = Convert.ToInt32(lblhiddenFieldForId.Text);

            GetAuthorByIdForDetailView(AuthorId);

            panelDetail.Visible = true;
            panelAuthorTable.Visible = false;
            panelAddAuthor.Visible = false;
            btnSubmit.Visible = false;
            btnUpdate.Visible = false;
        }
        else if (e.CommandName == "RemoveAuthor" && e.CommandName != "EditAuthor"
            && e.CommandName != "DetailAuthor" && e.CommandName != "ActivateDeactivate")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewAuthor.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int AuthorId = Convert.ToInt32(lblhiddenFieldForId.Text);

            var result = authorManager.GetAuthorById(AuthorId);
            if (result.Rows.Count > 0)
            {
                string filename = result.Rows[0]["Extension"].ToString();
                var filePath = Server.MapPath("~/BookImage/Writer/" + filename);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            authorManager.DeleteAuthor(AuthorId);
            GetAllAuthorRecord();
        }
        else if (e.CommandName == "ActivateDeactivate" && e.CommandName != "RemoveAuthor"
            && e.CommandName != "EditAuthor" && e.CommandName != "DetailAuthor")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewAuthor.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int AuthorId = Convert.ToInt32(lblhiddenFieldForId.Text);

            DataTable dt = authorManager.CheckAutheStatus(AuthorId);

            if (dt.Rows.Count != 0)
            {
                var data = authorManager.CheckAutheStatus(AuthorId);
                var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
                var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
                string date = now.ToString("yyyy-MM-dd hh:mm:ss tt");

                if (data.Rows[0]["Status"].ToString() == "Active")
                {
                    string[] check = new string[5];
                    check[0]=   "Inactive";
                    check[1] =  "Admin";
                    check[2] = date;
                    bool update = authorManager.UpdateAutheStatus(check, AuthorId);
                    GetAllAuthorRecord();
                }
                else if (data.Rows[0]["Status"].ToString() == "Inactive")
                {
                    string[] check = new string[5];
                    check[0] = "Active";
                    check[1] = "Admin";
                    check[2] = date;
                    bool update = authorManager.UpdateAutheStatus(check, AuthorId);
                    GetAllAuthorRecord();
                }
            }
        }
    }

    protected void gridViewAuthor_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void gridViewAuthor_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GetAllAuthorRecord();
        gridViewAuthor.PageIndex = e.NewPageIndex;
        gridViewAuthor.DataBind();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int AuthorId = Convert.ToInt32(lblhiddenFieldForId.Text);
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
        string date = now.ToString("yyyy-MM-dd hh:mm:ss tt");

        string[] insert = new string[20];

        insert[0] = txtAuthorName.Text;
        insert[1] = txtDescription.Text;
        insert[2] = ddlGender.SelectedItem.Text;
        insert[3] = txtDateOfBirth.Text;
        insert[4] = txtAddress.Text;
        insert[5] = txtEmail.Text;
        insert[6] = ddlPopular.SelectedItem.Text;
        insert[10] = "Admin";
        insert[11] = date;
        insert[12] = lvlImage.Text;

        if (fileFrontImage.HasFile)
        {
            string SavePath = Server.MapPath("~/BookImage/Writer/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extention = Path.GetExtension(fileFrontImage.PostedFile.FileName);
            fileFrontImage.SaveAs(SavePath + "\\" + lvlWriterCode.Text + Extention);
            insert[12] = lvlWriterCode.Text + Extention;
        }

        bool Save = authorManager.UpdateAuthor(insert, AuthorId);
        Response.Redirect(Request.RawUrl);           
    }

    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = authorManager.SearchAuthorByName(txtSearch.Text);
        //gridViewAuthor.DataSourceID = "SqlDataSource1";
        gridViewAuthor.DataSource = dt;
        gridViewAuthor.DataBind();
    }
}