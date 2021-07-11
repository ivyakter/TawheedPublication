using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSubcategory();
            loadTopSoldBooks();
            //loadProductInfobyPID();

            //if (Request.QueryString["Date1"] == "0")
            //{
            //    DataTable tt = (DataTable)Session["shoppingcart"];
            //}
            //else
            //{
            //    Session["shoppingcart"] = Request.QueryString["product"];
            //    Session["shoppingcart"] = Request.QueryString["SelectedProducts"];
            //}
            DataTable tt = (DataTable)Session["shoppingcart"];
            //lblloigin.Text = Request.QueryString["Loggenin"];

            Session["Loginfo"] = Request.QueryString["Loggenin"];

            Session["Passwords"] = Request.QueryString["Passwords"];

            Session["Date"] = Request.QueryString["Date"];

            Session["ShoppingType"] = Request.QueryString["ShoppingType"];

            Session["Timeslot"] = Request.QueryString["Timeslot"];
        }
    }

    public void LoadSubcategory()
    {
        SubcatDrinkandbreverage();
        string Position = "1";
        DataTable bt1 = mydal.GetShopNow1(Position);
        rptShopNow1.DataSource = bt1;
        rptShopNow1.DataBind();

        string Position2 = "2";
        DataTable bt2 = mydal.GetShopNow1(Position2);
        rptShopNow2.DataSource = bt2;
        rptShopNow2.DataBind();

        string Position3 = "3";
        DataTable bt3 = mydal.GetShopNow1(Position3);
        rptShopNow3.DataSource = bt3;
        rptShopNow3.DataBind();

        string Position4 = "4";
        DataTable bt4 = mydal.GetShopNow1(Position4);
        rptShopNow4.DataSource = bt4;
        rptShopNow4.DataBind();

        string Position5 = "5";
        DataTable bt5 = mydal.GetShopNow1(Position5);
        rptShopNow5.DataSource = bt5;
        rptShopNow5.DataBind();
    }



    protected void rptrMain_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rptrSubCate = (Repeater)e.Item.FindControl("rptrSubCate");
            HiddenField hfCateId = (HiddenField)e.Item.FindControl("hfCateId");
            DataTable dt = new DAL().GetMenuData(hfCateId.Value);
            if (dt.Rows.Count > 0)
            {
                rptrSubCate.DataSource = dt;
                rptrSubCate.DataBind();
            }

        }
    }
    private void SubcatDrinkandbreverage()
    {
        DataTable dt = mydal.GetSubCategoryMenu();
        if (dt.Rows.Count > 0)
        {
            rptSubjectName.DataSource = dt;
            rptSubjectName.DataBind();
        }
    }


    protected void rptBooks_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HiddenField hfCateId = (HiddenField)e.Item.FindControl("hfCatID");
            Label lvlDiscount = (Label)e.Item.FindControl("lvlDiscount");
            DataTable dt = mydal.GetBookById(Convert.ToInt32(hfCateId.Value));
            string dis = dt.Rows[0]["SpecialPrice"].ToString();
            if (dis == null || dis == "" || dis == "0") lvlDiscount.Visible = false;
        }
    }

    protected void rptSubjectName_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rptBooks = (Repeater)e.Item.FindControl("rptBooks");
            Repeater rptHiddenFile1 = (Repeater)e.Item.FindControl("rptHiddenFile1");
            HiddenField hfCateId = (HiddenField)e.Item.FindControl("hfCateId");
            DataTable dt = mydal.GetBookBySubCategory(hfCateId.Value);
            if (dt.Rows.Count > 0)
            {
                rptBooks.DataSource = dt;
                rptBooks.DataBind();
                rptBooks.Visible = true;
                rptHiddenFile1.DataSource = dt;
                rptHiddenFile1.DataBind();
            }
        }
    }

    protected void rptCateName_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rptrSubCateFoodcupboard = (Repeater)e.Item.FindControl("rptrSubCateFoodcupboard");
            HiddenField hfCateId = (HiddenField)e.Item.FindControl("hfCateId");
            DataTable dt = mydal.GetSubcatMuneId(hfCateId.Value);
            if (dt.Rows.Count > 0)
            {
                rptrSubCateFoodcupboard.DataSource = dt;
                rptrSubCateFoodcupboard.DataBind();
            }
        }

    }
    public void loadTopSoldBooks()
    {
        DataTable dt = mydal.GetBooks();
        if (dt.Rows.Count > 0)
        {
            rptTopSoldBooks.DataSource = dt;
            foreach (RepeaterItem ri in rptTopSoldBooks.Items)
            {
                string Deliveryoldprice = dt.Rows[0]["PPrice"].ToString();
                if (Deliveryoldprice == "")
                {
                    Label Deliveryoldpricer = (Label)ri.FindControl("Deliveryoldprice");
                    Deliveryoldpricer.Visible = false;
                }
            }
            rptTopSoldBooks.DataBind();
            rptTopSoldBooks.Visible = true;
        }

        DataTable dt2 = mydal.GetUpcomingBooks();
        rptUpcomingProduct.DataSource = dt2;
        rptUpcomingProduct.DataBind();
        DataTable dt3 = mydal.GetNewBooks();
        rptNewProduct.DataSource = dt3;
        rptNewProduct.DataBind();
        DataTable dt4 = mydal.GetPopularBooks();
        rptPopularBook.DataSource = dt4;
        rptPopularBook.DataBind();
        DataTable dt5 = mydal.GetFourBlog();
        rptBlogRelatedPost.DataSource = dt5;
        rptBlogRelatedPost.DataBind();
    }

    protected void btnQuickView_Click(object sender, EventArgs e)
    {
        int bookId = int.Parse((sender as LinkButton).CommandArgument);

        try
        {
            //DataTable dt = mydal.GetBookById(Convert.ToInt32(hfCateId.Value));
            var booksQuickView = mydal.GetBookById(Convert.ToInt32(bookId));

            rptPopUp.DataSource = booksQuickView;
            rptPopUp.DataBind();
            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        }
        catch (Exception)
        {

            //repeaterBooksQuickView.DataSource = booksQuickView;
            //repeaterBooksQuickView.DataBind();
        }
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

    protected void btnWishList_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Session["CEmail"] as string))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('You Need To Login First!');", true);
        }
        else
        {
            int bookId = int.Parse((sender as LinkButton).CommandArgument);
            DataTable dt = mydal.GetBookById1(Convert.ToInt32(bookId));

            string[] insert = new string[10];
            insert[0] = Session["CEmail"].ToString();
            insert[1] = dt.Rows[0]["Code"].ToString();
            insert[2] = dt.Rows[0]["Title"].ToString();
            insert[3] = dt.Rows[0]["Price"].ToString();
            insert[4] = dt.Rows[0]["SpecialPrice"].ToString();
            insert[5] = dt.Rows[0]["FontImage"].ToString();

            DataTable checkWishlist = mydal.CheckCustomerWishlist(insert);
            if (checkWishlist.Rows.Count == 0)
            {
                bool save = mydal.InsertCustomerWishlist(insert);
                if (save)
                    ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Add Successfully to your WishList');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Product Already in your Wishlist!');", true);
            }
        }
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
                DataTable dt = mydal.GetBlogById(Convert.ToInt32(lvlId.Text));
                VideosRepeater.DataSource = dt;
                VideosRepeater.DataBind();
                blogImg.Visible = false;
            }
        }
    }
}