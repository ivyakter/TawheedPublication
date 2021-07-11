using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Writer : System.Web.UI.Page
{
    private DAL bookManager = new DAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DataTable tt = (DataTable)Session["shoppingcart"];

            if (Request.QueryString.ToString().Contains("Writer"))
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                GetLeftSideInfo();
                GetBooks();
            }
            else
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                loadAllData();
            }

        }

    }
    private void loadAllData()
    {
        DataTable dt = bookManager.GetAuthor();
        rptAllWriter.DataSource = dt;
        rptAllWriter.DataBind();

        DataTable dt2 = bookManager.GetPopularAuthor();
        rptPopularWriter.DataSource = dt2;
        rptPopularWriter.DataBind();        
    }

    //pagination
    public int PageNumber
    {
        get
        {
            if (ViewState["PageNumber"] != null)
            {
                return Convert.ToInt32(ViewState["PageNumber"]);
            }
            else
            {
                return 0;
            }
        }
        set { ViewState["PageNumber"] = value; }
    }
    private void GetBooks()
    {
        string id = Request.QueryString["Writer"].ToString();
        DataTable writer = bookManager.GetWriterbyCode(id);
        rptWriter.DataSource = writer;
        rptWriter.DataBind();

        
        var dt = bookManager.getWritersAllBooks(id);
        if (dt.Rows.Count > 0)
        {
            //Create the PagedDataSource that will be used in paging
            PagedDataSource pgitems = new PagedDataSource();
            pgitems.DataSource = dt.DefaultView;
            pgitems.AllowPaging = true;

            //Control page size from here 
            pgitems.PageSize = 12;
            pgitems.CurrentPageIndex = PageNumber;
            if (pgitems.PageCount > 1)
            {
                rptPaging.Visible = true;
                ArrayList pages = new ArrayList();
                for (int i = 0; i <= pgitems.PageCount - 1; i++)
                {
                    pages.Add((i + 1).ToString());
                }
                rptPaging.DataSource = pages;
                rptPaging.DataBind();
            }
            else
            {
                rptPaging.Visible = false;
            }
            //Finally, set the datasource of the repeater

            repeaterBooks.DataSource = pgitems;
            repeaterBooks.DataBind();
            repeaterBooks.Visible = true;
            lblMessage.Visible = false;
        }
        else
        {
            lblMessage.Visible = true;
        }
    }

    //pagination
    protected void rptPaging_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
    {
        PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
        GetBooks();
    }

    protected void btnaddtocart_Click1(object sender, EventArgs e)
    {
        LinkButton btbag = sender as LinkButton;
        RepeaterItem repeaterval = btbag.NamingContainer as RepeaterItem;

        string pid = ((HiddenField)repeaterval.FindControl("hfPId")).Value;
        string pname = ((HiddenField)repeaterval.FindControl("hfname")).Value;
        string price = ((HiddenField)repeaterval.FindControl("hfprice")).Value;
        //string size = ((RadioButtonList)repeaterval.FindControl("rblSize")).SelectedItem.Text;
        string Barcode = ((HiddenField)repeaterval.FindControl("hfproductid")).Value;
        string Imagename = ((HiddenField)repeaterval.FindControl("hfimagename")).Value;
        string Imageextension = ((HiddenField)repeaterval.FindControl("hfimageExtesion")).Value;
        string hfvatamount = ((HiddenField)repeaterval.FindControl("hfvatamount")).Value;
        Session["Imagename"] = Imagename;
        Session["pname"] = pname;
        Session["price"] = price;
        Session["Barcode"] = hfvatamount;
        int quantity = 1;
        double sum = 0;

        DataTable dt = (DataTable)Session["shoppingcart"];

        if (Session["shoppingcart"] == null)
        {
            //create the datatable
            DataTable createdt = new DataTable();
            createdt.Columns.Add("pid", typeof(string));


            createdt.Columns.Add("pname", typeof(string));
            createdt.Columns.Add("quantity", typeof(int));
            createdt.Columns.Add("price", typeof(double));
            //createdt.Columns.Add("size", typeof(string));
            createdt.Columns.Add("Barcode", typeof(string));
            createdt.Columns.Add("Imagename", typeof(string));
            createdt.Columns.Add("Imageextension", typeof(string));
            createdt.Columns.Add("hfvatamount", typeof(double));
            createdt.Columns.Add("total", typeof(double));


            //Store first row
            DataRow row = createdt.NewRow();
            row["pid"] = pid;
            row["pname"] = pname;
            row["quantity"] = quantity;
            row["price"] = price;
            row["Barcode"] = Barcode;
            row["Imagename"] = Imagename;
            row["Imageextension"] = Imageextension;
            row["hfvatamount"] = hfvatamount;
            row["total"] = quantity * double.Parse(price);


            createdt.Rows.Add(row);
            Session["shoppingcart"] = createdt;
            sum = Convert.ToDouble(row["total"]);

            MasterPage ms = new MasterPage();
            Label count = Page.Master.FindControl("lblcount") as Label;
            //Label countsmall = Page.Master.FindControl("lblcountinside") as Label;

            count.Text = "(" + createdt.Rows.Count + ")";
            //countsmall.Text = "(" + createdt.Rows.Count + ")";

        }
        else
        {
            bool exist = false;
            int a = 0;
            DataRow foundProductId = dt.Select("pid ='" + pid + "'").FirstOrDefault();
            if (foundProductId != null)
            {
                a = Convert.ToInt32(foundProductId["quantity"].ToString());
                foundProductId["quantity"] = a + 1;
                foundProductId["total"] = (a + 1) * double.Parse(price);
                exist = true;
            }
            if (exist != true)
            {
                DataRow row = dt.NewRow();
                row["pid"] = pid;
                row["pname"] = pname;
                row["quantity"] = a + quantity;
                row["price"] = price;
                row["Barcode"] = Barcode;
                row["Imagename"] = Imagename;
                row["Imageextension"] = Imageextension;
                row["hfvatamount"] = hfvatamount;
                row["total"] = (a + quantity) * double.Parse(price);
                dt.Rows.Add(row);
            }
            Session["shoppingcart"] = dt;

            foreach (DataRow dr in dt.Rows)
            {
                sum += Convert.ToDouble(dr["total"]);
            }
            MasterPage ms = new MasterPage();
            Label count = Page.Master.FindControl("lblcount") as Label;
            //Label countsmall = Page.Master.FindControl("lblcountinside") as Label;


            count.Text = "(" + dt.Rows.Count + ")";
            //countsmall.Text = "(" + dt.Rows.Count + ")";
        }
    }

    protected void btnQuickView_Click(object sender, EventArgs e)
    {
        int bookId = int.Parse((sender as LinkButton).CommandArgument);

        try
        {
            var booksQuickView = bookManager.GetBookById(Convert.ToInt32(bookId));

            rptPopUp.DataSource = booksQuickView;
            rptPopUp.DataBind();
            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        }
        catch (Exception)
        {

        }
    }

    protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
    {
        string writer = Request.QueryString["Writer"].ToString();
        DataTable dt = null;
        if (ddlSort.SelectedValue == "1")
        {
            dt = bookManager.GetAllBooksMostSale();
        }
        if (ddlSort.SelectedValue == "2")
        {
            dt = bookManager.GetAllBooksNew();
        }
        if (ddlSort.SelectedValue == "3")
        {
            dt = bookManager.GetAllBooksUpcoming();
        }
        else if (ddlSort.SelectedValue == "4")
        {
            dt = bookManager.GetAllBooksPopular();

        }
        else if (ddlSort.SelectedValue == "5")
        {
            dt = bookManager.GetAllBooksLowToHighByWriter(writer);
        }
        else if (ddlSort.SelectedValue == "6")
        {
            dt = bookManager.GetAllBooksHighToLowByWriter(writer);
        }
        if (dt.Rows.Count > 0)
        {
            //Create the PagedDataSource that will be used in paging
            PagedDataSource pgitems = new PagedDataSource();
            pgitems.DataSource = dt.DefaultView;
            pgitems.AllowPaging = true;

            //Control page size from here 
            pgitems.PageSize = 12;
            pgitems.CurrentPageIndex = PageNumber;
            if (pgitems.PageCount > 1)
            {
                rptPaging.Visible = true;
                ArrayList pages = new ArrayList();
                for (int i = 0; i <= pgitems.PageCount - 1; i++)
                {
                    pages.Add((i + 1).ToString());
                }
                rptPaging.DataSource = pages;
                rptPaging.DataBind();
            }
            else
            {
                rptPaging.Visible = false;
            }

            repeaterBooks.DataSource = pgitems;
            repeaterBooks.DataBind();
            repeaterBooks.Visible = true;
            lblMessage.Visible = false;
        }
        else
        {
            lblMessage.Visible = true;
            repeaterBooks.DataSource = null;
            repeaterBooks.DataBind();
        }
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        decimal min = Convert.ToDecimal(txtMin.Text);
        decimal max = Convert.ToDecimal(txtMax.Text);
        repeaterBooks.DataSource = null;
        repeaterBooks.DataBind();
        if (txtMin.Text != null && txtMax.Text != null)
        {
            string id = Request.QueryString["Writer"].ToString();
            DataTable dt = bookManager.GetCategoryAllBooks8(id, min, max);
            if (dt.Rows.Count > 0)
            {
                //Create the PagedDataSource that will be used in paging
                PagedDataSource pgitems = new PagedDataSource();
                pgitems.DataSource = dt.DefaultView;
                pgitems.AllowPaging = true;

                //Control page size from here 
                pgitems.PageSize = 12;
                pgitems.CurrentPageIndex = PageNumber;
                if (pgitems.PageCount > 1)
                {
                    rptPaging.Visible = true;
                    ArrayList pages = new ArrayList();
                    for (int i = 0; i <= pgitems.PageCount - 1; i++)
                    {
                        pages.Add((i + 1).ToString());
                    }
                    rptPaging.DataSource = pages;
                    rptPaging.DataBind();
                }
                else
                {
                    rptPaging.Visible = false;
                }
                repeaterBooks.DataSource = pgitems;
                repeaterBooks.DataBind();
                repeaterBooks.Visible = true;
            }
        }
    }
    protected void btnWishList_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Session["CEmail"] as string))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('You Need To Login First!');", true);
        }
        else
        {
            int bookId = int.Parse((sender as LinkButton).CommandArgument);
            DataTable dt = bookManager.GetBookById1(Convert.ToInt32(bookId));

            string[] insert = new string[10];
            insert[0] = Session["CEmail"].ToString();
            insert[1] = dt.Rows[0]["Code"].ToString();
            insert[2] = dt.Rows[0]["Title"].ToString();
            insert[3] = dt.Rows[0]["Price"].ToString();
            insert[4] = dt.Rows[0]["SpecialPrice"].ToString();
            insert[5] = dt.Rows[0]["FontImage"].ToString();

            DataTable checkWishlist = bookManager.CheckCustomerWishlist(insert);
            if (checkWishlist.Rows.Count == 0)
            {
                bool save = bookManager.InsertCustomerWishlist(insert);
                if (save)
                    ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Add Successfully to your WishList');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Product Already in your Wishlist!');", true);
            }
        }
    }

    protected void repeaterBooks_ItemDataBound1(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HiddenField hfCateId = (HiddenField)e.Item.FindControl("hfCatID");
            Label lvlDiscount = (Label)e.Item.FindControl("lvlDiscount");
            // string a = hfCateId.Value;
            DataTable dt = bookManager.GetBookById(Convert.ToInt32(hfCateId.Value));
            string dis = dt.Rows[0]["SpecialPrice"].ToString();
            if (dis == null || dis == "" || dis == "0") lvlDiscount.Visible = false;
        }
    }

    private void GetLeftSideInfo()
    {
        var categories = bookManager.GetCategory();
        chkBoxCategories.DataTextField = "Name";
        chkBoxCategories.DataValueField = "Id";
        chkBoxCategories.DataSource = categories;
        chkBoxCategories.DataBind();
        chkBoxCategories.Attributes.Add("onclick", "radioCategories(event);");

        var subCategories = bookManager.GetSubCategoryBooks();
        chkBoxSubCategories.DataTextField = "Name";
        chkBoxSubCategories.DataValueField = "Id";
        chkBoxSubCategories.DataSource = subCategories;
        chkBoxSubCategories.DataBind();
        chkBoxSubCategories.Attributes.Add("onclick", "radioSubCategories(event);");

        var authors = bookManager.GetAuthor();
        chkBoxAuthors.DataTextField = "Name";
        chkBoxAuthors.DataValueField = "Id";
        chkBoxAuthors.DataSource = authors;
        chkBoxAuthors.DataBind();
        chkBoxAuthors.Attributes.Add("onclick", "radioauthors(event);");

        var publication = bookManager.GetAllPublicationAsc();
        chkBoxPublication.DataTextField = "Name";
        chkBoxPublication.DataValueField = "Id";
        chkBoxPublication.DataSource = publication;
        chkBoxPublication.DataBind();
        chkBoxPublication.Attributes.Add("onclick", "radioPublication(event);");
    }

    protected void chkBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in chkBoxCategories.Items)
        {
            if (item.Selected)
            {
                var dt = bookManager.GetAllBooksByCategory(item.Value);
                if (dt.Rows.Count > 0)
                {
                    PagedDataSource pgitems = new PagedDataSource();
                    pgitems.DataSource = dt.DefaultView;
                    pgitems.AllowPaging = true;

                    pgitems.PageSize = 12;
                    pgitems.CurrentPageIndex = PageNumber;
                    if (pgitems.PageCount > 1)
                    {
                        rptPaging.Visible = true;
                        ArrayList pages = new ArrayList();
                        for (int i = 0; i <= pgitems.PageCount - 1; i++)
                        {
                            pages.Add((i + 1).ToString());
                        }
                        rptPaging.DataSource = pages;
                        rptPaging.DataBind();
                    }
                    else
                    {
                        rptPaging.Visible = false;
                    }
                    repeaterBooks.DataSource = pgitems;
                    repeaterBooks.DataBind();
                    repeaterBooks.Visible = true;

                    lblMessage.Visible = false;
                }
                else
                {
                    lblMessage.Visible = true;
                    repeaterBooks.DataSource = null;
                    repeaterBooks.DataBind();
                }
            }
        }
    }
    protected void chkBoxAuthors_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in chkBoxAuthors.Items)
        {
            if (item.Selected)
            {
                var dt = bookManager.GetAllBooksByWriter(item.Value);
                if (dt.Rows.Count > 0)
                {
                    PagedDataSource pgitems = new PagedDataSource();
                    pgitems.DataSource = dt.DefaultView;
                    pgitems.AllowPaging = true;

                    pgitems.PageSize = 12;
                    pgitems.CurrentPageIndex = PageNumber;
                    if (pgitems.PageCount > 1)
                    {
                        rptPaging.Visible = true;
                        ArrayList pages = new ArrayList();
                        for (int i = 0; i <= pgitems.PageCount - 1; i++)
                        {
                            pages.Add((i + 1).ToString());
                        }
                        rptPaging.DataSource = pages;
                        rptPaging.DataBind();
                    }
                    else
                    {
                        rptPaging.Visible = false;
                    }
                    repeaterBooks.DataSource = pgitems;
                    repeaterBooks.DataBind();
                    repeaterBooks.Visible = true;

                    lblMessage.Visible = false;
                }
                else
                {
                    lblMessage.Visible = true;
                    repeaterBooks.DataSource = null;
                    repeaterBooks.DataBind();
                }
            }
        }
    }
    protected void chkBoxSubCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in chkBoxSubCategories.Items)
        {
            if (item.Selected)
            {
                var dt = bookManager.GetAllBooksBySubCat(item.Value);
                if (dt.Rows.Count > 0)
                {
                    PagedDataSource pgitems = new PagedDataSource();
                    pgitems.DataSource = dt.DefaultView;
                    pgitems.AllowPaging = true;

                    pgitems.PageSize = 12;
                    pgitems.CurrentPageIndex = PageNumber;
                    if (pgitems.PageCount > 1)
                    {
                        rptPaging.Visible = true;
                        ArrayList pages = new ArrayList();
                        for (int i = 0; i <= pgitems.PageCount - 1; i++)
                        {
                            pages.Add((i + 1).ToString());
                        }
                        rptPaging.DataSource = pages;
                        rptPaging.DataBind();
                    }
                    else
                    {
                        rptPaging.Visible = false;
                    }
                    repeaterBooks.DataSource = pgitems;
                    repeaterBooks.DataBind();
                    repeaterBooks.Visible = true;

                    lblMessage.Visible = false;
                }
                else
                {
                    lblMessage.Visible = true;
                    repeaterBooks.DataSource = null;
                    repeaterBooks.DataBind();
                }
            }
        }
    }
    protected void chkBoxPublication_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in chkBoxPublication.Items)
        {
            if (item.Selected)
            {
                var dt = bookManager.GetPublicationAllBooks(item.Value);
                if (dt.Rows.Count > 0)
                {
                    PagedDataSource pgitems = new PagedDataSource();
                    pgitems.DataSource = dt.DefaultView;
                    pgitems.AllowPaging = true;

                    pgitems.PageSize = 12;
                    pgitems.CurrentPageIndex = PageNumber;
                    if (pgitems.PageCount > 1)
                    {
                        rptPaging.Visible = true;
                        ArrayList pages = new ArrayList();
                        for (int i = 0; i <= pgitems.PageCount - 1; i++)
                        {
                            pages.Add((i + 1).ToString());
                        }
                        rptPaging.DataSource = pages;
                        rptPaging.DataBind();
                    }
                    else
                    {
                        rptPaging.Visible = false;
                    }
                    repeaterBooks.DataSource = pgitems;
                    repeaterBooks.DataBind();
                    repeaterBooks.Visible = true;

                    lblMessage.Visible = false;
                }
                else
                {
                    lblMessage.Visible = true;
                    repeaterBooks.DataSource = null;
                    repeaterBooks.DataBind();
                }
            }
        }
    }
}