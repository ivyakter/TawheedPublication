using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Pages_Blog : System.Web.UI.Page
{
    DAL blogs = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadAllBlogs();
        }
    }

    private void LoadAllBlogs()
    {
        DataTable dt = blogs.GetAllBlog();
        rptBlogs.DataSource = dt;
        rptBlogs.DataBind();

        DataTable dt3 = blogs.GetTenBlog();
        rptRecentPost.DataSource = dt3;
        rptRecentPost.DataBind();
    }

    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        string blog = txtSearch.Text;
        DataTable dt = blogs.GetSearchBlog(blog);
        rptRecentPost.DataSource = dt;
        rptRecentPost.DataBind();
    }
    protected void rptBlogs_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
                DataTable dt = blogs.GetBlogById(Convert.ToInt32( lvlId.Text));
                VideosRepeater.DataSource = dt;
                VideosRepeater.DataBind();
                blogImg.Visible = false;
            }
        }
    }
    protected void btn_All_Click(object sender, EventArgs e)
    {
        DataTable dt = blogs.GetAllBlog();
        rptBlogs.DataSource = dt;
        rptBlogs.DataBind();
    }
    protected void btn_popular_Click(object sender, EventArgs e)
    {
        DataTable dt = blogs.GetBlogByCategory("Popular");
        rptBlogs.DataSource = dt;
        rptBlogs.DataBind();
    }
    protected void btn_Leatest_Click(object sender, EventArgs e)
    {
        DataTable dt = blogs.GetBlogByCategory("Leatest");
        rptBlogs.DataSource = dt;
        rptBlogs.DataBind();
    }
    protected void btn_Video_Click(object sender, EventArgs e)
    {
        DataTable dt = blogs.GetBlogByCategory("Video");
        rptBlogs.DataSource = dt;
        rptBlogs.DataBind();
    }
}