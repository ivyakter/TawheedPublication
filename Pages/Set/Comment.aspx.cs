using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Pages_Set_Comment : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadData();
    }

    private void LoadData()
    {
        DataTable dt1 = mydal.GetBooksComments();
        gridViewBookComment.DataSource = dt1;
        gridViewBookComment.DataBind();

        DataTable dt2 = mydal.GetBlogComments();
        gridViewBlogComment.DataSource = dt2;
        gridViewBlogComment.DataBind();
    }

    protected void gridViewBookComment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int bookId = Convert.ToInt32(e.CommandArgument.ToString());
            bool delete = mydal.deleteCommand(bookId);
            if (delete)
            {
                 Response.Redirect(Request.RawUrl);
            }
        }
    }
    protected void gridViewBlogComment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int bookId = Convert.ToInt32(e.CommandArgument.ToString());
            bool delete = mydal.deleteCommand(bookId);
            if (delete)
            {
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}