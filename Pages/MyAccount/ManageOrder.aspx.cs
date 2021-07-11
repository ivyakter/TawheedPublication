using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Set_ManageOrder : System.Web.UI.Page
{
    //private tawheedpublicationsbdEntities entities = new tawheedpublicationsbdEntities();

    private DAL orderManager = new DAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["roleId"] == null)
        //{
        //    Response.Redirect("~/ViewsAndControllers/Home/Login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        //}
        //else if (Session["roleId"].ToString() == "1")
        //{
        //    if (string.IsNullOrEmpty(Convert.ToString(Session["userId"])))
        //    {
        //        Response.Redirect("~/ViewsAndControllers/Home/Login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        //    }
        //}
        //else if (Session["roleId"].ToString() == "2")
        //{
        //    Server.Transfer("~/ViewsAndControllers/Shared/AccessDenied.aspx");
        //}

        if (!IsPostBack)
        {
            GetAllOrdersRecord();
        }
    }

    private void GetAllOrdersRecord()
    {
        gridViewOrders.DataSourceID = "SqlDataSource1";
        gridViewOrders.DataBind();
    }

    private void GetBookDetailsFromOrder(string invoiceNumber)
    {
        
        var order = orderManager.GetOrderByInvoice2(invoiceNumber);
        var customerInfo = orderManager.GetOrderByInvoice(invoiceNumber);
        if (customerInfo.Rows.Count > 0)
        {
            //var order = result.First();

            lblOrderFromNameView.Text = "Admin";
            lblOrderFromPhoneView.Text = "";
            lblOrderFromAddressView.Text = "";
            lblOrderFromEmailView.Text = "";
            lblOrderFromInvoiceDateView.Text = Convert.ToDateTime(DateTime.Now).Date.ToString(); 

            lblInvoiceNumberView.Text = customerInfo.Rows[0]["InvoiceNumber"].ToString(); 
            lblCustomerNameView.Text = customerInfo.Rows[0]["CustomerName"].ToString(); 
            lblMobileView.Text =customerInfo.Rows[0]["Mobile"].ToString();
            lblAddressView.Text = customerInfo.Rows[0]["Address"].ToString();
            lblEmailView.Text = customerInfo.Rows[0]["Email"].ToString();
            lblStatusView.Text = customerInfo.Rows[0]["Status"].ToString();
            lblInvoiceDateView.Text = customerInfo.Rows[0]["InvoiceDateTime"].ToString();
            lblDueDateView.Text = "";
            lblDeliveryChargeView.Text = "100";
            lblTotalPaymentAmountView.Text = customerInfo.Rows[0]["TotalPaymentAmount"].ToString();

            foreach (GridViewRow row in gridViewBookDetails.Rows)
            {
                Label lblBookPrice = ((Label)row.FindControl("lblPrice"));
                Label lblQuantity = ((Label)row.FindControl("lblQuantity"));
                Label lblSubTotal = ((Label)row.FindControl("lblSubTotal"));
                //if (lblBookPrice != null && lblQuantity != null)
                //{
                //    lblSubTotal.Text = (int.Parse(lblQuantity.Text) * decimal.Parse(lblBookPrice.Text)).ToString();
                //}
            }
        }
    }

    protected void gridViewOrders_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DetailOrder" && e.CommandName != "PaidUnpaid"
                && e.CommandName != "CancelOrder")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblInvoiceNumber = (Label)gridViewOrders.Rows[index].FindControl("lblInvoiceNumber");
            lblhiddenFieldForId.Text = lblInvoiceNumber.Text;
            string InvoiceNumber = lblhiddenFieldForId.Text;

            GetBookDetailsFromOrder(InvoiceNumber);

            panelDetail.Visible = true;
            panelOrdersTable.Visible = false;
            panelCustomerList.Visible = false;
        }
        else if (e.CommandName == "CancelOrder" && e.CommandName != "DetailOrder"
                && e.CommandName != "PaidUnpaid")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblInvoiceNumber = (Label)gridViewOrders.Rows[index].FindControl("lblInvoiceNumber");
            lblhiddenFieldForId.Text = lblInvoiceNumber.Text;
            string InvoiceNumber = lblhiddenFieldForId.Text;

            var result = orderManager.GetOrderByInvoice(InvoiceNumber);
            if (result.Rows.Count > 0)
            {
                if (result.Rows[0]["Status"].ToString() == "Unpaid")
                {
                    string orderStatus = "Cancelled";
                    bool updateOrderStatus = orderManager.UpdateOrderStatus(orderStatus, InvoiceNumber);
                    GetAllOrdersRecord();
                }
                else if (result.Rows[0]["Status"].ToString() == "Paid")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "This order cannot be cancelled because it was paid." + "');", true);
                }
            }
        }
        else if (e.CommandName == "PaidUnpaid" && e.CommandName != "DetailOrder"
                && e.CommandName != "CancelOrder")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblInvoiceNumber = (Label)gridViewOrders.Rows[index].FindControl("lblInvoiceNumber");
            lblhiddenFieldForId.Text = lblInvoiceNumber.Text;
            string InvoiceNumber = lblhiddenFieldForId.Text;

            var result = orderManager.GetOrderByInvoice(InvoiceNumber);
            if (result.Rows.Count > 0)
            {
                if (result.Rows[0]["Status"].ToString() == "Unpaid")
                {
                    string orderStatus = "Paid";
                    bool updateOrderStatus = orderManager.UpdateOrderStatus(orderStatus, InvoiceNumber);
                    GetAllOrdersRecord();
                }
                else if (result.Rows[0]["Status"].ToString() == "Paid")
                {
                    string orderStatus = "Unpaid";
                    bool updateOrderStatus = orderManager.UpdateOrderStatus(orderStatus, InvoiceNumber);
                    GetAllOrdersRecord();
                }
            }
        }
    }

    protected void gridViewOrders_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Normal)))
            {
                string statusValue = DataBinder.Eval(e.Row.DataItem, "Status").ToString();

                LinkButton btnStatus = (LinkButton)e.Row.FindControl("btnStatus");
                LinkButton btnCancel = (LinkButton)e.Row.FindControl("btnCancel");

                if (statusValue == "Paid")
                {
                    btnStatus.CssClass = "badge badge-success";
                    btnStatus.ForeColor = System.Drawing.Color.White;
                }
                else if (statusValue == "Unpaid")
                {
                    btnStatus.CssClass = "badge badge-warning";
                    btnStatus.ForeColor = System.Drawing.Color.White;
                }
                else if (statusValue == "Cancelled")
                {
                    btnStatus.CssClass = "badge badge-danger";
                    btnStatus.ForeColor = System.Drawing.Color.White;
                    btnStatus.Enabled = false;
                    btnStatus.OnClientClick = null;
                    btnCancel.Enabled = false;
                    btnCancel.OnClientClick = null;
                }
            }
        }
    }

    protected void btnGoBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    protected void btnInvoice_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Invoice.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //StringWriter sw = new StringWriter();
        //HtmlTextWriter hw = new HtmlTextWriter(sw);
        //panelDetail.RenderControl(hw);
        //StringReader sr = new StringReader(sw.ToString());
        //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //using (MemoryStream memoryStream = new MemoryStream())
        //{
        //    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
        //    pdfDoc.Open();
        //    htmlparser.Parse(sr);
        //    pdfDoc.Close();
        //    byte[] bytes = memoryStream.ToArray();
        //    memoryStream.Close();

        //    MailMessage mm = new MailMessage("munemmaruf@gmail.com", "munemmaruf@gmail.com");
        //    mm.Subject = "Your Invoice";
        //    mm.Body = "Tawheed Publications- Invoice";
        //    mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "Invoice.pdf"));
        //    mm.IsBodyHtml = true;
        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "smtp.gmail.com";
        //    smtp.Port = 587;
        //    smtp.EnableSsl = true;
        //    NetworkCredential credentials = new NetworkCredential("munemmaruf@gmail.com", "*Primered9990");
        //    smtp.UseDefaultCredentials = true;
        //    smtp.Credentials = credentials;
        //    smtp.Send(mm);
        //}
        //Response.Write(pdfDoc);
        //Response.End();

    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void btnListCustomer_Click(object sender, EventArgs e)
    {
        panelOrdersTable.Visible = false;
        panelCustomerList.Visible = true;
        DataTable dt = orderManager.GetCustomerInfo();
        gridViewCustomerList.DataSource = dt;
        gridViewCustomerList.DataBind();
        //btnSubmit.Visible = true;
        //btnUpdate.Visible = false;
    }
    protected void sellectAll(object sender, EventArgs e)
    {
        CheckBox ChkBoxHeader = (CheckBox)gridViewCustomerList.HeaderRow.FindControl("chkb1");
        foreach (GridViewRow row in gridViewCustomerList.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkb2");
            if (ChkBoxHeader.Checked == true)
            {
                ChkBoxRows.Checked = true;
            }
            else
            {
                ChkBoxRows.Checked = false;
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        panelCustomerList.Visible = true;
        panelAddEmailOrSms.Visible = false;
        //panelOrdersTable.Visible = false;
        //Response.Redirect(Request.RawUrl);
    }    

    protected void btnSms_Click(object sender, EventArgs e)
    {
        panelOrdersTable.Visible = false;
        panelCustomerList.Visible = false;
        panelAddEmailOrSms.Visible = true;
        txtSubject.Visible = false;

        int a = 0;
        foreach (GridViewRow row in gridViewCustomerList.Rows)
        {
            CheckBox chkb2 = ((CheckBox)row.FindControl("chkb2"));
            if (chkb2.Checked) a = a + 1;
        }
        lblCount.Text = "Total Customer Select: " + a.ToString();
    }

    protected void btnEmail_Click(object sender, EventArgs e)
    {
        panelOrdersTable.Visible = false;
        panelCustomerList.Visible = false;
        panelAddEmailOrSms.Visible = true;
        txtSubject.Visible = true;

        int a = 0;
        foreach (GridViewRow row in gridViewCustomerList.Rows)
        {
            CheckBox chkb2 = ((CheckBox)row.FindControl("chkb2"));
            if (chkb2.Checked) a = a + 1;
        }
        lblCount.Text = "Total Customer Select: " + a.ToString();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtSubject.Visible == true)
        {
            //Email Seding Code
            foreach (GridViewRow row in gridViewCustomerList.Rows)
            {
                CheckBox chkb2 = ((CheckBox)row.FindControl("chkb2"));
                Label lblEmail = ((Label)row.FindControl("lblEmail"));
                if (chkb2.Checked)
                {
                    using (MailMessage mm = new MailMessage("torekul002@gmail.com", lblEmail.Text))
                    {
                        mm.Subject = txtSubject.Text;
                        string body = "Hello Dear,";
                        body = "<br /><br />" + txtMessage.Text;
                        mm.Body = body;
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential("torekul002@gmail.com", "Tk@#123ht");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                        
                    }
                }
            }
            // ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('We Sent A Password To Your Email');", true);
        }
        else
        {
            //Sms code
        }
    }

    protected void txtSearchCustomer_TextChanged(object sender, EventArgs e)
    {
        string customer = txtSearchCustomer.Text;
        DataTable dt = orderManager.SearchCustomerInfo(customer);
        gridViewCustomerList.DataSource = dt;
        gridViewCustomerList.DataBind();

        if (txtSearchCustomer.Text == "")
            btnListCustomer_Click(null, null);
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        gridViewOrders.DataSourceID = "SqlDataSource1";
        gridViewOrders.DataBind();
    }
}