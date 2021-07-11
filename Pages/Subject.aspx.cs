using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Writer : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadBookandWriter();
        }
    }

    private void LoadBookandWriter()
    {
        string Subject = Request.QueryString["Subject"].ToString();

        DataTable getproductbysubcat = mydal.getSubjectAllBooks(Subject);
        if (getproductbysubcat.Rows.Count > 0)
        {
            rptrWriterBooks.DataSource = getproductbysubcat;
            rptrWriterBooks.DataBind();
        }
        else
        {
            lblemptydate.Text = "No Books Found";

        }
        //DataTable getwrirer = mydal.GetWriters(Writer);
        //if (getwrirer.Rows.Count > 0)
        //{
        //    rptWriter.DataSource = getwrirer;
        //    rptWriter.DataBind();
        //}
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
            Label countsmall = Page.Master.FindControl("lblcountinside") as Label;

            count.Text = "(" + createdt.Rows.Count + ")";
            countsmall.Text = "(" + createdt.Rows.Count + ")";

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
            Label countsmall = Page.Master.FindControl("lblcountinside") as Label;


            count.Text = "(" + dt.Rows.Count + ")";
            countsmall.Text = "(" + dt.Rows.Count + ")";
        }
    }


    protected void rptrWriterBooks_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
}