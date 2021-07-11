using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_blog_details : System.Web.UI.Page
{
    DAL blogDetails = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Id"] != "")
        {
            LoadPage();
        }
    }

    private void LoadPage()
    {
        string id = Request.QueryString["Id"];
        DataTable dt = blogDetails.GetBlogById(id);
        rptBlogDetails.DataSource = dt;
        rptBlogDetails.DataBind();
        DataTable dt1 = blogDetails.GetThreeBlog();
        DataTable dt3 = blogDetails.GetTenBlog();
        rptBlogRelatedPost.DataSource = dt1;
        rptBlogRelatedPost.DataBind();
        rptRecentPost.DataSource = dt3;
        rptRecentPost.DataBind();

        DataTable dt2 = new DAL().GetBlogerComment(id);
        if (dt2.Rows.Count > 0)
        {
            rptrMainComment.DataSource = dt2;
            rptrMainComment.DataBind();
        }
    }

    protected void btncomment_Click(object sender, EventArgs e)
    {
        if (txtreplyname.Text != "" & txtreplyemail.Text != "")
        {
            string[] insert = new string[30];
            insert[0] = txtreplyname.Text;
            insert[1] = txtreplyemail.Text;
            insert[2] = txtreplycomment.Value;
            insert[3] = Request.QueryString["Id"];
            string mn = "Bolger";
            bool InsertComment = blogDetails.InsertReplyComment(insert, mn);
            if (InsertComment)
            {
                txtreplyname.Text = "";
                txtreplyemail.Text = "";
                txtreplycomment.Value = "";
                LoadPage();
            }
        }
        else
        {
            string strconfirmd = "<script>if(window.confirm('You Need ToLoginFirst')){window.location.href='ProductDetails.aspx'}</script>";
            ScriptManager.RegisterStartupScript(this, GetType(), "Confirm", strconfirmd, false);
        }
    }
    protected void btnDeleteCommand_Click(object sender, EventArgs e)
    {
        int bookId = int.Parse((sender as LinkButton).CommandArgument);

        bool delete = blogDetails.deleteCommand(bookId);
        if (delete)
        {
            LoadPage();
            ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Comment Deleted!');", true);
        }
    }
    protected void rptrMainComment_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (!string.IsNullOrEmpty(Session["AEmail"] as string))
            {
                LinkButton btnDeleteCommand = (LinkButton)e.Item.FindControl("btnDeleteCommand");
                btnDeleteCommand.Visible = true;
            }
        }
    }

    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        string blog = txtSearch.Text;
        DataTable dt = blogDetails.GetSearchBlog(blog);
        rptRecentPost.DataSource = dt;
        rptRecentPost.DataBind();
    }
    protected void rptBlogDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater VideosRepeater = (Repeater)e.Item.FindControl("VideosRepeater");
            Label lvlCode = (Label)e.Item.FindControl("lvlCode");
            Label lvlId = (Label)e.Item.FindControl("lvlId");
            Image blogImg = e.Item.FindControl("blogImg") as Image;
            //Image blogImg = (Image)e.Item.FindControl("blogImg");
            if (lvlCode.Text == "Video")
            {
                DataTable dt = blogDetails.GetBlogById(Convert.ToInt32(lvlId.Text));
                VideosRepeater.DataSource = dt;
                VideosRepeater.DataBind();
                blogImg.Visible = false;
            }
        }
    }
    protected void rptBlogRelatedPost_DataBinding(object sender, EventArgs e)
    {

    }
    protected void rptBlogRelatedPost_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater VideosRepeater = (Repeater)e.Item.FindControl("VideosRepeater");
            Label lvlCode = (Label)e.Item.FindControl("lvlCode");
            Label lvlId = (Label)e.Item.FindControl("lvlId");
            Image blogImg = e.Item.FindControl("blogImg") as Image;
            //Image blogImg = (Image)e.Item.FindControl("blogImg");
            if (lvlCode.Text == "Video")
            {
                DataTable dt = blogDetails.GetBlogById(Convert.ToInt32(lvlId.Text));
                VideosRepeater.DataSource = dt;
                VideosRepeater.DataBind();
                blogImg.Visible = false;
            }
        }
    }
}