using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_ProductDetails : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        loadSingleImagebyPID();
        CountBookView();
        LoadCommentTextInfo();
    }
    private void LoadCommentTextInfo()
    {
        if (!string.IsNullOrEmpty(Session["CEmail"] as string))
        {
            txtreplyname.Text = Session["CEmail"].ToString();
            txtreplyemail.Text = Session["FirstName"].ToString();
        }
    }
    private void CountBookView()
    {
        string PID = Request.QueryString["PID"];
        bool updateCount = mydal.UpdateBookView(PID);
    }

    public void loadSingleImagebyPID()
    {
        string PID = Request.QueryString["PID"];

        DataTable dt = mydal.GetBookimage(PID);
        if (dt.Rows.Count > 0)
        {
            rptrsingleimage.DataSource = dt;
            rptrsingleimage.DataBind();
            rptrsingleimage.Visible = true;
        }

        DataTable dt1 = new DAL().GetMenuComment(PID);
        if (dt1.Rows.Count > 0)
        {
            rptrMainComment.DataSource = dt1;
            rptrMainComment.DataBind();
        }

        DataTable relatedBook = mydal.RelatedBookID(PID);
        if (relatedBook.Rows.Count > 0)
        {
            string subject = relatedBook.Rows[0]["CategoryId"].ToString();

            DataTable dt2 = mydal.GetRelatedBooks(subject);
            if (dt2.Rows.Count > 0)
            {
                rptrrelatedproduct.DataSource = dt2;
                rptrrelatedproduct.DataBind();
                rptrrelatedproduct.Visible = true;
            }
        }


        DataTable dt3 = mydal.RelatedWriterBookID(PID);
        if (dt3.Rows.Count > 0)
        {
            string writer = dt3.Rows[0]["authorId"].ToString();
            DataTable dt2 = mydal.GetRelatedWriterBooks(writer);
            if (dt2.Rows.Count > 0)
            {
                rptSameWriter.DataSource = dt;
                rptSameWriter.DataBind();
            }
        }

        string publication = dt.Rows[0]["Publisher"].ToString();
        DataTable dt4 = mydal.RelatedBookPublication(publication);
        if (dt4.Rows.Count > 0)
        {
            rptRetaledPublication.DataSource = dt4;
            rptRetaledPublication.DataBind();
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

    protected void rptrsingleimage_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string PID = Request.QueryString["PID"];
            Label lvlWriter = (Label)e.Item.FindControl("lvlWriter");
            Label lvlSubCategory = (Label)e.Item.FindControl("lvlSubCategory");
            DataTable dt3 = mydal.RelatedWriterBookID(PID);
            if (dt3.Rows.Count > 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    lvlWriter.Text += dt3.Rows[i]["AuthorName"].ToString() + "<br/>";
                }
            }

            DataTable dt2 = mydal.GetRelatedSubCategory(PID);
            if (dt2.Rows.Count > 0)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    lvlSubCategory.Text += dt2.Rows[i]["CategoryName"].ToString() + ", ";
                }
            }


            //Repeater rptrMainComment = (Repeater)e.Item.FindControl("rptrMainComment");
            //string PID = Request.QueryString["PID"];
            //DataTable dt = new DAL().GetMenuComment(PID);
            //if (dt.Rows.Count > 0)
            //{
            //    rptrMainComment.DataSource = dt;
            //    rptrMainComment.DataBind();
            //}
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
            insert[3] = Request.QueryString["PID"];
            string mn = "User";
            bool InsertComment = mydal.InsertReplyComment(insert, mn);
            if (InsertComment)
            {
                txtreplyname.Text = "";
                txtreplyemail.Text = "";
                txtreplycomment.Value = "";
                loadSingleImagebyPID();
            }
        }
        else
        {
            string strconfirmd = "<script>if(window.confirm('You Need ToLoginFirst')){window.location.href='ProductDetails.aspx'}</script>";
            ScriptManager.RegisterStartupScript(this, GetType(), "Confirm", strconfirmd, false);
        }
    }

    protected void rptrMainComment_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (!string.IsNullOrEmpty(Session["CEmail"] as string))
            {
                txtreplyname.Text = Session["CEmail"].ToString();
                txtreplyemail.Text = Session["FirstName"].ToString();
            }
        }
    }

    protected void rptrrelatedproduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HiddenField hfCateId = (HiddenField)e.Item.FindControl("hfCatID");
            Label lvlDiscount = (Label)e.Item.FindControl("lvlDiscount");
            // string a = hfCateId.Value;
            DataTable dt = mydal.GetBookById(Convert.ToInt32(hfCateId.Value));
            string dis = dt.Rows[0]["SpecialPrice"].ToString();
            if (dis == null || dis == "" || dis == "0") lvlDiscount.Visible = false;
        }
    }

    protected void rptSameWriter_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HiddenField hfCateId = (HiddenField)e.Item.FindControl("hfCatID");
            Label lvlDiscount = (Label)e.Item.FindControl("lvlDiscount");
            // string a = hfCateId.Value;
            DataTable dt = mydal.GetBookById(Convert.ToInt32(hfCateId.Value));
            string dis = dt.Rows[0]["SpecialPrice"].ToString();
            if (dis == null || dis == "" || dis == "0") lvlDiscount.Visible = false;
        }
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
}

