using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MasterPage_Default : System.Web.UI.MasterPage
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           //Session.RemoveAll();
            if (Session["shoppingcart"] != null)
            {
                GetMenuList2();
            }
            LoadMenuBooks();
        }
    }
    private void countMe()
    {
        DataSet tmpDs = new DataSet();
        tmpDs.ReadXml(Server.MapPath("~/counter.xml"));
        int hits = Int32.Parse(tmpDs.Tables[0].Rows[0]["hits"].ToString());
        hits += 1;
        tmpDs.Tables[0].Rows[0]["hits"] = hits.ToString();
        tmpDs.WriteXml(Server.MapPath("~/counter.xml"));
    }

    private void LoadMenuBooks()
    {
        DataTable dt = mydal.GetBooks();
        DataTable topSubCategory = mydal.GetTop5SubCategory();
        
        DataTable dtSubject = mydal.GetCategory();
        repeaterAllCategory.DataSource = dtSubject;
        repeaterAllCategory.DataBind();

        DataTable dtwriter = mydal.GetWriters();
        rptWriter.DataSource = dtwriter;
        rptWriter.DataBind();
        rptWriter2.DataSource = dtwriter;
        rptWriter2.DataBind();
        rptWriter3.DataSource = dtwriter;
        rptWriter3.DataBind();

        DataTable getPublication = mydal.GetPublication();
        rptPublication.DataSource = getPublication;
        rptPublication.DataBind();
        rptPublication1.DataSource = getPublication;
        rptPublication1.DataBind();
        rptPublication2.DataSource = getPublication;
        rptPublication2.DataBind();

        DataTable dtbook = mydal.getSubCategoryBookByCategoryId(1);
        rptBooks.DataSource = dtbook;
        rptBooks.DataBind();
        rptBook2.DataSource = dtbook;
        rptBook2.DataBind();
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        BookSearch();
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        BookSearch();
    }

    public void BookSearch()
    {
        //string name = txtSearch.Text;
        // DataTable dt = mydal.GetBookId(txtSearch.Text);
        //string id = dt.Rows[0]["Id"].ToString();
        //var url = String.Format("~/Pages/ProductDetails.aspx?PID={0}", id);
        //Response.Redirect(url);
        
    }

    protected void GetMenuList()
    {
        DataTable dt = (DataTable)Session["shoppingcart"];
        int total = 0;
        //if (dt.Rows.Count == 0) return;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            total = total + Convert.ToInt32(dt.Rows[i]["price"]);
        }
        rptrsuperdeals1.DataSource = dt;
        rptrsuperdeals1.DataBind();
        Label2.Text = total + ".00";
        //Label3.Text = total + ".00";
    }
    protected void GetMenuList2()
    {
        //Session.RemoveAll();

        DataTable dt = (DataTable)Session["shoppingcart"];
        int total = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            total = total + Convert.ToInt32(dt.Rows[i]["price"]);
        }
        rptrsuperdeals1.DataSource = dt;
        rptrsuperdeals1.DataBind();
        Label2.Text = total + ".00";
        lblcount.Text = dt.Rows.Count.ToString();
    }

    protected void repeaterAllCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblCatId = (Label)e.Item.FindControl("lblCatId");
            Repeater repeaterBookCategory1 = (Repeater)e.Item.FindControl("repeaterBookCategory1");
            DataTable dt = mydal.getSubCategoryBookByCategoryId(Convert.ToInt32(lblCatId.Text));
            if (dt.Rows.Count > 0)
            {
                repeaterBookCategory1.DataSource = dt;
                repeaterBookCategory1.DataBind();
            }
        }
    }

}
