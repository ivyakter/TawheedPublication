using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_quick_view : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["PID"] != null)
            {
                //loadSingleImagebyPID();
                //loadthreeImagebyPID();
                loadProductInfobyPID();
            }

        }
    }

    public void loadSingleImagebyPID()
    {
        string PID = Request.QueryString["PID"];

        DataTable dt = mydal.GetProductByPIDsingleimage(PID);
        if (dt.Rows.Count > 0)
        {
            repeaterBooksQuickView.DataSource = dt;
            repeaterBooksQuickView.DataBind();
            repeaterBooksQuickView.Visible = true;

           
        }
    }

    //public void loadthreeImagebyPID()
    //{
    //    string PID = Request.QueryString["PID"];

    //    DataTable dt = mydal.GetProductByPIDthreeimage(PID);
    //    if (dt.Rows.Count > 0)
    //    {
    //        rptrthreeimage.DataSource = dt;
    //        rptrthreeimage.DataBind();
    //        rptrthreeimage.Visible = true;

    //        //rptrsidebar.DataSource = dt;
    //        //rptrsidebar.DataBind();
    //        //rptrsidebar.Visible = true;
    //    }
    //}



    public void loadProductInfobyPID()
    {
        string PID = Request.QueryString["PID"];

        DataTable dt = mydal.GetBookInfoByID(PID);
        if (dt.Rows.Count > 0)
        {
            repeaterBooksQuickView.DataSource = dt;
            repeaterBooksQuickView.DataBind();
            repeaterBooksQuickView.Visible = true;            
        }
    }

    protected void rptrproductinfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        string PID = Request.QueryString["PID"];
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rptrBrandimage = (Repeater)e.Item.FindControl("rptrBrandimage");
            //HiddenField hfCateId = (HiddenField)e.Item.FindControl("hfCateId");
            DataTable dt = new DAL().GetBrandimage(PID);
            if (dt.Rows.Count > 0)
            {
                rptrBrandimage.DataSource = dt;
                rptrBrandimage.DataBind();
            }

        }
    }

    protected void repeaterBooksQuickView_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        foreach (RepeaterItem item in repeaterBooksQuickView.Items)
        {
            TextBox txtQuantity = (TextBox)item.FindControl("txtQuantity");

            if (e.CommandName == "AddToCart")
            {
                //string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });

                //lblHiddenFieldForId.Text = commandArgs[0];
                //lblhiddenFieldForImage.Text = commandArgs[1];
                //lblhiddenFieldForBookTitle.Text = commandArgs[2];
                //lblhiddenFieldForPrice.Text = commandArgs[3];

                //int bookId = Convert.ToInt32(lblHiddenFieldForId.Text);

                //int quantity = Convert.ToInt32(txtQuantity.Text);

                //decimal bookPrice = Convert.ToDecimal(lblhiddenFieldForPrice.Text);

                //decimal totalPrice = quantity * bookPrice;

                //var list = (List<CartViewModel>)Session["cartList"];

                //cartViewModel.Id = Guid.NewGuid().ToString("N");
                //cartViewModel.BookId = bookId;
                //cartViewModel.BookTitle = lblhiddenFieldForBookTitle.Text;
                //cartViewModel.Image = lblhiddenFieldForImage.Text;
                //cartViewModel.Price = bookPrice;
                //cartViewModel.Quantity = quantity;
                //cartViewModel.Total = totalPrice;

                //cartList.Add(cartViewModel);
                //Session["cartList"] = cartList;
            }
        }
    }
}