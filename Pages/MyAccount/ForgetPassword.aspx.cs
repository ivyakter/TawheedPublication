using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_MyAccount_ForgetPassword : System.Web.UI.Page
{
    DAL mydal = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }




    protected void btnsave_Click(object sender, EventArgs e)
    {
        string email = txtemail.Text;
        DataTable check = mydal.CheckPasswordbymail(email);
        if (check.Rows.Count > 0)
        {
            string name = check.Rows[0]["FirstName"].ToString();
            string Password = check.Rows[0]["Password"].ToString();
            using (MailMessage mm = new MailMessage("torekul002@gmail.com", txtemail.Text))
            {
                //mm.Subject = "Account Password";
                //string body = "Hello " + name + ",";
                //body += "<br /><br />Your Password Is ";
                //body += "<br /><br /><h1>"+Password+"</h1>";
                //body += "<br /><br />Thanks";
                //mm.Body = body;
                //mm.IsBodyHtml = true;
                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.gmail.com";
                //smtp.EnableSsl = true;
                //NetworkCredential NetworkCred = new NetworkCredential("torekul002@gmail.com", "Tk@#123ht");
                //smtp.UseDefaultCredentials = true;
                //smtp.Credentials = NetworkCred;
                //smtp.Port = 587;
                //smtp.Send(mm);
                mm.Subject = "Account Password";
                string body = "Hello " + name + ",";
                body += "<br /><br />Your Password Is ";
                body += "<br /><br /><h1>" + Password + "</h1>";
                body += "<br /><br />Thanks";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = "torekul002@gmail.com";
                NetworkCred.Password = "Tk@#123ht";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);

                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('We Sent A Password To Your Email');", true);

            }
        }
        else
        {
            lblerror.Visible = true;
            lblerror.Text = "Sorry ! This Email Is Not Valid";

        }

    }
}