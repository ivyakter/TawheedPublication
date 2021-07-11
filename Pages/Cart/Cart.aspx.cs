
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Text;
//using System.Net;
//using System.Net.Mail;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.html.simpleparser;
//using System.IO;
using System.Drawing;

public partial class Pages_Cart_Cart : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrid();
        }

    }

    //private void SendPDFEmail(DataTable dt)
    //{
        
    //    using (StringWriter sw = new StringWriter())
    //    {
    //        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
    //        {
    //            Paragraph paragraph = new Paragraph("<b>Terms and conditions can be found on: brrwholesale.com </b> </br>Registered in England and Wales No. 08366495, VAT Registration Number GB 168 2010 28</br>Registered Address Unit 15, Canning Road, Abbey Trading Point, London, E15 3NW, United Kingdom.");

    //            string imageURL = Server.MapPath(".") + "/icone.png";

    //            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(imageURL);
    //            logo.SpacingBefore = 100f;


    //            //string companyName = "BRR Whole Sale";
    //            string orderNo = dt.Rows[0]["orderid"].ToString();

    //            double totalamount = 0;
    //            string username = "";
    //            string PostCode = "";
    //            string Email = "";
    //            DataTable alltotal = mydal.Alltotal(orderNo);
    //            if (alltotal.Rows.Count > 0)
    //            {
    //                totalamount = double.Parse(alltotal.Rows[0]["Alltotal"].ToString());
    //                username = alltotal.Rows[0]["FirstName"].ToString();
    //                PostCode = alltotal.Rows[0]["PostCode"].ToString();
    //                Email = alltotal.Rows[0]["Email"].ToString();
    //            }


    //            StringBuilder sb = new StringBuilder();
    //            sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
    //            sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><h2>Order Sheet</h2></td></tr>");
    //            sb.Append("</table>");



    //            sb.Append("<table width='100%' style='font - size:5px;'>");
    //            //sb.Append("<tr><td colspan = '2'></td></tr>");

    //            sb.Append("<tr><td><b>BRR Wholesale Ltd</b>");

    //            sb.Append("<p>Unit-15</p>");
    //            sb.Append("<p>Canning Road, Abbey Trading Point</p>");
    //            sb.Append("<p>London");
    //            sb.Append("<p>E15 3NW </p>");
    //            sb.Append("</td>");
    //            // sb.Append("<br />");

    //            sb.Append("<td align='right'>Website www.brrwholesale.com ");
    //            sb.Append("<p>Telephone 01992252141 </p> ");
    //            sb.Append("<p>Email info@brrwholesale.com </p> </td></tr>");

    //            sb.Append("</table>");





    //            sb.Append("<table align='left'>");
    //            sb.Append("<tr><td><b>Date: </b>");
    //            //sb.Append(logo);
    //            sb.Append(DateTime.Now);
    //            sb.Append(" </td></tr>");


    //            sb.Append("<tr><td><b>Order No:</b>");
    //            sb.Append(orderNo);
    //            sb.Append(" </td></tr>");



    //            sb.Append("<tr><td><b>User Name:</b>");
    //            sb.Append(username);
    //            sb.Append(" </td></tr>");
    //            sb.Append("<tr><td><b>User Name:</b>");
    //            sb.Append(PostCode);
    //            sb.Append(" </td></tr>");


    //            sb.Append("</table>");




    //            sb.Append("<br />");
    //            sb.Append("<table border = '1'>");
    //            sb.Append("<tr>");
    //            foreach (DataColumn column in dt.Columns)
    //            {
    //                sb.Append("<th style = 'background-color: #DCDCDC;color:#000000'>");
    //                sb.Append(column.ColumnName);
    //                sb.Append("</th>");
    //            }
    //            sb.Append("</tr>");
    //            foreach (DataRow row in dt.Rows)
    //            {
    //                sb.Append("<tr>");
    //                foreach (DataColumn column in dt.Columns)
    //                {
    //                    sb.Append("<td>");
    //                    sb.Append(row[column]);
    //                    sb.Append("</td>");
    //                }
    //                sb.Append("</tr>");
    //            }
                

    //            sb.Append("</table>");




    //            sb.Append("<br />");


    //            DataTable GetProductVattwenty = mydal.GetProductVattwenty(orderNo);
    //            DataTable GetProductVatzero = mydal.GetProductVatzero(orderNo);
    //            //if (GetProductVat.Rows.Count > 0)
    //            //{
    //            sb.Append("<table width='40%' border = '1' cellspacing='0'>");
    //            sb.Append("<tr  align='left' style='background-color: #	e0ffff'><th><p>VAT Rate</p></th>");
    //            sb.Append("<th><p>Net</p></th>");
    //            sb.Append("<th><p>VAT</p></th>");
    //            sb.Append("</tr>");
    //            sb.Append("<tr><td align='left' style='background-color: #18B5F0'><p>20.00%</p></td>");

    //            sb.Append("<td>");
    //            sb.Append(GetProductVattwenty.Rows[0]["Net"].ToString());
    //            sb.Append("</td>");
    //            sb.Append("<td>");
    //            sb.Append("£" + "&nbsp;&nbsp;" + double.Parse(GetProductVattwenty.Rows[0]["Vat"].ToString()));
    //            sb.Append("</td>");
    //            sb.Append("</tr>");
    //            sb.Append("<tr><td align='left' style='background-color: #18B5F0'><p>0.00%</p></td>");
    //            sb.Append("<td>");
    //            sb.Append(GetProductVatzero.Rows[0]["Net"].ToString());
    //            sb.Append("</td>");
    //            sb.Append("<td>");
    //            sb.Append(double.Parse(GetProductVatzero.Rows[0]["Vat"].ToString()));
    //            sb.Append("</td>");

    //            sb.Append("</tr>");
    //            sb.Append("</table>");


    //            //}
    //            ///////////Total Show///////////



    //            sb.Append("<table width='40%' align='right' border = '1' cellspacing='0'>");
    //            sb.Append("<tr>");
    //            sb.Append("<th align='right'><p>Net Amount </p></th>");

    //            sb.Append("<th align='center' style='background-color: #18B5F0' >");
    //            sb.Append("£" + "&nbsp;&nbsp;" + totalamount);
    //            sb.Append("</th></tr>");
    //            sb.Append("<tr>");
    //            sb.Append("<th align='right'><p>Vat </p></th>");
    //            sb.Append("<th  align='center'>");
    //            sb.Append("£" + "&nbsp;&nbsp;" + double.Parse(GetProductVattwenty.Rows[0]["Vat"].ToString()));
    //            sb.Append("</th>");
    //            sb.Append("</tr>");

    //            sb.Append("<tr>");
    //            sb.Append("<th align='right'><p>Total </p></th>");
    //            sb.Append("<th  align='center'>");
    //            sb.Append("£" + "&nbsp;&nbsp;" + double.Parse(GetProductVattwenty.Rows[0]["Vat"].ToString()) + totalamount);
    //            sb.Append("</th>");
    //            sb.Append("</tr>");
    //            sb.Append("</table>");

    //            StringReader sr = new StringReader(sb.ToString());

    //            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
    //            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //            using (MemoryStream memoryStream = new MemoryStream())
    //            {
    //                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);


    //                pdfDoc.Open();
    //                //writer.PageEvent = new PDFFooter();

    //                pdfDoc.Add(logo);
    //                htmlparser.Parse(sr);
    //                //pdfDoc.Add(paragraph);




    //                pdfDoc.Close();
    //                byte[] bytes = memoryStream.ToArray();
    //                memoryStream.Close();

    //                MailMessage mm = new MailMessage("torekul002@gmail.com", Email);
    //                mm.Subject = "iTextSharp PDF";
    //                mm.Body = "iTextSharp PDF Attachment";
    //                mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "iTextSharpPDF.pdf"));
    //                mm.IsBodyHtml = true;
    //                SmtpClient smtp = new SmtpClient();
    //                smtp.Host = "smtp.gmail.com";
    //                smtp.EnableSsl = true;
    //                NetworkCredential NetworkCred = new NetworkCredential();
    //                NetworkCred.UserName = "torekul002@gmail.com";
    //                NetworkCred.Password = "Tk@#123ht";
    //                smtp.UseDefaultCredentials = true;
    //                smtp.Credentials = NetworkCred;
    //                smtp.Port = 587;
    //                smtp.Send(mm);
    //            }
    //        }
    //    }
    //    //}


    //}

    //public class PDFFooter : PdfPageEventHelper
    //{
    //    // write on top of document

    //    //public override void OnOpenDocument(PdfWriter writer, Document document)
    //    //{
    //    //    base.OnOpenDocument(writer, document);
    //    //    PdfPTable tabFot = new PdfPTable(new float[] { 1F });
    //    //    tabFot.SpacingAfter = 10F;
    //    //    PdfPCell cell;
    //    //    tabFot.TotalWidth = 300F;
    //    //    cell = new PdfPCell(new Phrase("Header"));
    //    //    tabFot.AddCell(cell);
    //    //    tabFot.WriteSelectedRows(0, -1, 150, document.Top, writer.DirectContent);
    //    //}

    //    // write on start of each page

    //    //public override void OnStartPage(PdfWriter writer, Document document)
    //    //{
    //    //    base.OnStartPage(writer, document);
    //    //}

    //    // write on end of each page
    //    public override void OnEndPage(PdfWriter writer, Document document)
    //    {
    //        base.OnEndPage(writer, document);
    //        PdfPTable tabFot = new PdfPTable(new float[] { 1F });
    //        PdfPCell cell;
    //        tabFot.TotalWidth = 300F;
    //        cell = new PdfPCell(new Phrase("Footer"));
    //        tabFot.AddCell(cell);
    //        tabFot.WriteSelectedRows(0, -1, 150, document.Bottom, writer.DirectContent);

    //        base.OnCloseDocument(writer, document);
    //    }

    //    //write on close of document
    //    //public override void OnCloseDocument(PdfWriter writer, Document document)
    //    //{
    //    //    base.OnCloseDocument(writer, document);
    //    //}
    //}




    /// <summary>
    /// //////////////////
    /// </summary>

    protected void LoadGrid()
    {
        DataTable dt = (DataTable)Session["shoppingcart"];
        if (dt != null)
        {
            Label lbl_TitlePage = Page.Master.FindControl("lblcount") as Label;
            lbl_TitlePage.Text = dt.Rows.Count.ToString();
            // for main user 
            //lblmainusername.Text = Session["mainitemserrler"].ToString();

        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
        GridView1.Visible = true;

    }


    double total = 0;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            total += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "total"));
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblamount = (Label)e.Row.FindControl("lbltt");
            lblamount.Text = total.ToString();
            //Label lbl_TitlePage = Page.Master.FindControl("lbltotal") as Label;
            //lbl_TitlePage.Text = lblamount.Text;
        }
    }


    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        GridView1.EditIndex = -1;
        LoadGrid();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = (DataTable)Session["shoppingcart"];
        if (dt.Rows.Count > 0)
        {
            dt.Rows[e.RowIndex].Delete();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Label count = Page.Master.FindControl("lblcount") as Label;
            count.Text = dt.Rows.Count.ToString();
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument.ToString());
        GridViewRow gvRow = GridView1.Rows[index];
        Label txtq = (Label)gvRow.FindControl("LblQ");
        Label price = (Label)gvRow.FindControl("lblprice");
        Label txtto = (Label)gvRow.FindControl("lbltotal");
        Label footertotal = (Label)GridView1.FooterRow.FindControl("lbltt");

        Button bt = (Button)gvRow.FindControl("btdcre");

        if (e.CommandName == "decrement")
        {
            int q = Convert.ToInt32(txtq.Text) - 1;
            txtq.Text = q.ToString();
            if (q > 0)
            {
                txtto.Text = (Convert.ToDouble(txtto.Text) - Convert.ToDouble(price.Text)).ToString();
                footertotal.Text = (Convert.ToDouble(footertotal.Text) - Convert.ToDouble(price.Text)).ToString();

                //txtDollarto.Text = (Convert.ToDouble(txtDollarto.Text) - Convert.ToDouble(Dollarprice.Text)).ToString();
                //footerDollartotal.Text = (Convert.ToDouble(footerDollartotal.Text) - Convert.ToDouble(Dollarprice.Text)).ToString();

                //Label t = Page.Master.FindControl("lbltotal") as Label;
                //t.Text = footertotal.Text;
                Label lbl = Page.Master.FindControl("lblcount") as Label;
                lbl.Text = (Convert.ToInt32(lbl.Text) - 1).ToString();

            }
            else
            {
                bt.Visible = false;
                txtq.Text = "1";
            }
        }
        if (e.CommandName == "increment")
        {

            int q = Convert.ToInt32(txtq.Text) + 1;
            txtq.Text = q.ToString();
            txtto.Text = (q * Convert.ToDouble(price.Text)).ToString();
            footertotal.Text = (Convert.ToDouble(footertotal.Text) + Convert.ToDouble(price.Text)).ToString();

            //txtDollarto.Text = (q * Convert.ToDouble(Dollarprice.Text)).ToString();
            //footerDollartotal.Text = (Convert.ToDouble(footerDollartotal.Text) + Convert.ToDouble(Dollarprice.Text)).ToString();

            //Label t = Page.Master.FindControl("lbltotal") as Label;
            //t.Text = footertotal.Text;
            Label lbl = Page.Master.FindControl("lblcount") as Label;
            lbl.Text = (Convert.ToInt32(lbl.Text) + 1).ToString();
            bt.Visible = true;

        }
    }


    protected void btncheckout_Click(object sender, EventArgs e)
    {

        Label total = (Label)GridView1.FooterRow.FindControl("lbltt");

        if (double.Parse(total.Text) >= 150)
        {
            pan1.Visible = true;
            pnl2.Visible = false;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Order Amount Has to be $150 Or More');", true);
        }

        if (double.Parse(total.Text) >= 200)
        {
            pan1.Visible = true;
            pnl2.Visible = false;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Order Amount Has to be $200 Or More');", true);
        }

        if (double.Parse(total.Text) >= 250)
        {
            pan1.Visible = true;
            pnl2.Visible = false;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Order Amount Has to be $250 Or More');", true);
        }

    }

    protected void txtEmail_TextChanged(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        DataTable dt = mydal.getCustomerInfo(email);
        if (dt.Rows.Count > 0)
        {
            txtFullName.Text = dt.Rows[0]["FirstName"].ToString();
            txtPhone.Text = dt.Rows[0]["Phone"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            txtrefid.Text = "00";
        }
        else
        {
            txtFullName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtrefid.Text = "";
        }
    }

    private DateTime GetDate(string DayName)
    {
        DateTime start = DateTime.Now.AddHours(5).AddDays(1);
        DateTime end = DateTime.Now.AddDays(7);
        DateTime matchDate = start;

        for (DateTime counter = start; counter < end; counter = counter.AddDays(1))
        {
            if (counter.DayOfWeek.ToString() == DayName)
            {
                matchDate = counter;
            }
        }

        return matchDate;
    }

    
    protected void btncontinue_Click(object sender, EventArgs e)
    {
        DataTable date = (DataTable)Session["shoppingcart"];
        if (Session["shoppingcart"] != null)
        {
            var url = String.Format("../../Default.aspx");
            // var url = String.Format("../../Default.aspx?Loggenin={0} ", Session["Email"].ToString());
            Response.Redirect(url);
        }
    }


    protected void btncard_Click(object sender, EventArgs e)
    {
    }

    protected void btncod_Click(object sender, EventArgs e)
    {
        if (Session["shoppingcart"] == null) return;
        
        if(txtFullName.Text=="" || txtEmail.Text=="" || txtPhone.Text == "" || txtAddress.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('All Field Are Required!!');", true);
            return;
        }        
        DataTable dt = mydal.getVoucherNo();
        string voucherNo = "VC/" + DateTime.Now.Year + "/" + dt.Rows[0][0].ToString();
        string date = Convert.ToDateTime(DateTime.Now).Date.ToString();
        string PaymentOption = "Cash On Delivery";
        if (ddlPaymentMethod.SelectedItem.Text != "Select")
            PaymentOption = "Payment On Mobile";
        string gTotal = "";

        foreach (GridViewRow row in GridView1.Rows)
        {
            Label pid = (Label)row.FindControl("lblid");
            Label Barcode = (Label)row.FindControl("lblBarcode");
            Label pname = (Label)row.FindControl("lblpname");
            Label quantity = (Label)row.FindControl("LblQ");
            Label price = (Label)row.FindControl("lblprice");
            Label total = (Label)row.FindControl("lbltotal");
            Label discount = (Label)row.FindControl("lblhfvatamount");
            Label grandTotal = (Label)GridView1.FooterRow.FindControl("lbltt");            
            
            string[] inserts = new string[10];
            inserts[0] = voucherNo;
            inserts[1] = pid.Text;
            inserts[2] = pname.Text;
            inserts[3] = price.Text;
            inserts[4] = quantity.Text;
            inserts[5] = total.Text;
            inserts[6] = discount.Text;
            inserts[7] = date;
            inserts[8] = Barcode.Text;

            bool Save1 = mydal.InsertOrder2(inserts);
            gTotal = grandTotal.Text;
        }
        string[] insert = new string[10];
        insert[0] = voucherNo;
        insert[1] = txtFullName.Text;
        insert[2] = txtEmail.Text;
        insert[3] = txtPhone.Text;
        insert[4] = txtAddress.Text;
        insert[5] = PaymentOption;
        insert[6] = gTotal;
        insert[7] = "Unpaid";
        insert[8] = date;
        bool Save = mydal.InsertOrder(insert);

        if (ddlPaymentMethod.SelectedItem.Text == "Select")
        {
            string skilltransaction = "";
            string emailskrill = "";
            string paymentMedium = ddlPaymentMethod.SelectedItem.Text;
            string MobileBikash = "";
            string phoneDBBL = "";
            bool insert2 = mydal.InsertPayment(voucherNo, voucherNo, txtEmail.Text, PaymentOption, paymentMedium, skilltransaction, emailskrill, MobileBikash, phoneDBBL, gTotal);
        }
        if (ddlPaymentMethod.SelectedItem.Text == "Skrill")
        {
            string skilltransaction = txtSkillTransaction.Text;
            string emailskrill = txtEmailSkrill.Text;
            string paymentMedium = ddlPaymentMethod.SelectedItem.Text;
            string MobileBikash = "";
            string phoneDBBL = "";
            bool insert3 = mydal.InsertPayment(voucherNo, voucherNo, txtEmail.Text, PaymentOption, paymentMedium, skilltransaction, emailskrill, MobileBikash, phoneDBBL, gTotal);
        }
        if (ddlPaymentMethod.SelectedItem.Text == "Bikash")
        {
            string Bikashtransaction = txtBikashTranstacitonNumebr.Text;
            string MobileBikash = txtMobileBikash.Text;
            string paymentMedium = ddlPaymentMethod.SelectedItem.Text;
            string emailskrill = "";
            string phoneDBBL = "";
            bool insert4 = mydal.InsertPayment(voucherNo, voucherNo, txtEmail.Text, PaymentOption, paymentMedium, Bikashtransaction, emailskrill, MobileBikash, phoneDBBL, gTotal);
        }
        if (ddlPaymentMethod.SelectedItem.Text == "Datch Bangla Mobile Bangking")
        {
            string dutchbanglatransacrtion = txtDutchBanglaTransaction.Text;
            string phoneDBBL = txtPhoneNumDutch.Text;
            string paymentMedium = ddlPaymentMethod.SelectedItem.Text;
            string emailskrill = "";
            string MobileBikash = "";
            bool insert5 = mydal.InsertPayment(voucherNo, voucherNo, txtEmail.Text, PaymentOption, paymentMedium, dutchbanglatransacrtion, emailskrill, MobileBikash, phoneDBBL, gTotal);
        }
        Session.Remove("shoppingcart"); //.Clear("shoppingcart");
        string strconfirmd = "<script>if(window.confirm('Send Order Successfull')){window.location.href='../../Default.aspx'}</script>";
        ScriptManager.RegisterStartupScript(this, GetType(), "Confirm", strconfirmd, false);
    }

    protected void ddlPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (ddlPaymentMethod.SelectedItem.Text)
        {
            case "Skrill":
                MultiView1.ActiveViewIndex = 0;
                break;
            case "Bikash":
                MultiView1.ActiveViewIndex = 1;
                break;
            case "Datch Bangla Mobile Bangking":
                MultiView1.ActiveViewIndex = 2;
                break;
            default:
                MultiView1.ActiveViewIndex = 0;
                break;
        }
    }

    protected void btndbbl_Click(object sender, EventArgs e)
    {
    }

    protected void btnrocket_Click(object sender, EventArgs e)
    {
    }

    protected void bkashtransaction_Click(object sender, EventArgs e)
    {
    }

}