using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_MyAccount_Registration : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnsaveconti_Click(object sender, EventArgs e)
    {
        DataTable checkEmail = mydal.checkEmail(txtEmail.Text);
        if (txtfirstname.Text==""|| txtlastname.Text==""|| txtEmail.Text==""||txtPassword.Text==""||txtConfirmPassword.Text=="") return;
        if (checkEmail.Rows.Count > 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('This Email Has Been Taken');", true);
        }
        else
        {
            if (chkagree.Checked)
            {
                string[] insert = new string[15];
                insert[0] = txtfirstname.Text;
                insert[2] = txtlastname.Text;
                insert[3] = txtCountry.Text;
                insert[6] = txtmobile.Text;
                insert[7] = txtEmail.Text;
                insert[8] = txtPassword.Text;
                insert[9] = txtaddress.Text;

                bool Insert = mydal.InsertRegistrationInfo(insert);
                if (Insert == true)
                {
                    Session["Email"]=txtEmail.Text;
                    Session["Password"]= txtPassword.Text;
                    Session["FirstName"] = txtfirstname.Text;

                    //ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Submit Successfylly</br>Your User Name And Password Is Sent to Youe Email');", true);

                    //SentEmail();
                    string strconfirm = "<script>if(window.confirm('Submit Successfylly!! Your User Name And Password Is Sent to Your Email')){window.location.href='MyAccount.aspx'}</script>";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Confirm", strconfirm, false);
                    //var url = String.Format("MyAccount.aspx");
                    //Response.Redirect(url);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Something Went Wrong');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Yoy Need to check the Checkbox');", true);
            }            
        }
    }

    protected void SentEmail()
    {
        using (MailMessage mm = new MailMessage("torekul002@gmail.com", txtEmail.Text))
        {
            mm.Subject = "Account Password";
            string body = "Hello " + txtfirstname.Text + ",";
            body += "<br /><br />Your User Name Will Be Your Email ID ";
            body += "<br /><br /><h1>" + txtEmail.Text + "</h1>";
            body += "<br /><br />Your Password Is ";
            body += "<br /><br /><h1>" + txtPassword.Text + "</h1>";
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

           // ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('We Sent A Password To Your Email');", true);

        }
    }





    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registration.aspx");
    }
}