using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_MyAccount_MyAccount : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(Session["CEmail"] as string)) Response.Redirect("LogIn.aspx");
            lblEmail.Text = Session["CEmail"].ToString();
            lblSurname.Text = Session["FirstName"].ToString();
            lblPassword.Text = Session["Password"].ToString();

            loadInfo();
        }
    }

    private void loadInfo()
    {
        string[] loginfo = new string[15];
        loginfo[0] = Session["CEmail"].ToString();
        loginfo[1] = Session["Password"].ToString();

        DataTable dt = mydal.selectinfocustomer(loginfo);

        int id = Convert.ToInt32(dt.Rows[0]["Id"]);
        lblName.Text = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["SurName"].ToString();
        lblSurname.Text = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["SurName"].ToString();
        lblSurname1.Text = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["SurName"].ToString();
        lblCountry.Text = dt.Rows[0]["Country"].ToString();
        lblAddress.Text = dt.Rows[0]["Address"].ToString();
        lblEmail1.Text = dt.Rows[0]["Email"].ToString();
        lblPhone.Text = dt.Rows[0]["Phone"].ToString();
        lblDate.Text = dt.Rows[0]["CreateDate"].ToString();

        txtName.Text = dt.Rows[0]["FirstName"].ToString();
        txtCountry.Text = dt.Rows[0]["Country"].ToString();
        txtAddress.Text = dt.Rows[0]["Address"].ToString();
        txtEmail.Text = dt.Rows[0]["Email"].ToString();
        txtPhone.Text = dt.Rows[0]["Phone"].ToString();
        txtPassword.Text = dt.Rows[0]["Password"].ToString();
        txtJoinDate.Text = dt.Rows[0]["CreateDate"].ToString();

        DataTable dtB = mydal.GetBlogByEmail(lblEmail1.Text);
        rptBlogDetails.DataSource = dtB;
        rptBlogDetails.DataBind();
        DataTable dtO = mydal.GetOrderDetailsByEmail(lblEmail1.Text);
        rptOrders.DataSource = dtO;
        rptOrders.DataBind();
        DataTable dtW = mydal.GetWishlist(lblEmail1.Text);
        rptWishlist.DataSource = dtW;
        rptWishlist.DataBind();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
        string date = now.ToString("yyyy-MM-dd hh:mm:ss tt");
        string Email = lblEmail.Text;
        string Password = lblPassword.Text;
        //DataTable info = mydal.getCustomerInfo(Email, Password);
        DataTable maxId = mydal.GetLastBlogId();
        string code = "B" + maxId.Rows[0]["Id"].ToString();
        string[] insert = new string[10];
        insert[0] = txtBlogTitle.Text;
        insert[1] = txtDescription.Text;
        insert[2] = lblSurname.Text;
        insert[3] = Email;
        insert[4] = date;
        insert[5] = "Admin";
        insert[6] = date;
        insert[7] = "Inactive";
        insert[8] = "";
        insert[9] = code;
        if (fileFrontImage.HasFile)
        {
            string SavePath = Server.MapPath("~/lib/Blog");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extention = Path.GetExtension(fileFrontImage.PostedFile.FileName);
            fileFrontImage.SaveAs(SavePath + "\\" + code + Extention);
            insert[8] = code + Extention;
        }
        bool save = mydal.InsertBlog(insert);
        if (save)
        {
            txtBlogTitle.Text = "";
            txtDescription.Text = "";
            ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Blog Submitted!');", true);
        }
    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("../../Default.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string[] insert = new string[7];
        insert[0] = txtName.Text;
        insert[1] = txtCountry.Text;
        insert[2] = txtAddress.Text;
        insert[3] = txtEmail.Text;
        insert[4] = txtPhone.Text;
        insert[5] = txtPassword.Text;

        bool updateInfo = mydal.UpdateUserinfromuserInfo(insert);
        ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Information Save!');", true);
        loadInfo();
    }

    protected void rptWishlist_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        foreach (RepeaterItem item in rptWishlist.Items)
        {
            switch (e.CommandName)
            {
                case "delete":
                    HiddenField hfCode = (HiddenField)e.Item.FindControl("hfproductid");
                    bool dt = mydal.DeleteBookFromWishlist(hfCode.Value);
                    
                    //rptPopUp.DataSource = dt;
                    //rptPopUp.DataBind();
                    break;
            }
        }
        loadInfo();
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
}
