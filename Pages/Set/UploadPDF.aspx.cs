using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Pages_Set_UploadPDF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (fileFrontImage.HasFile)
        {
            string SavePath = Server.MapPath("~/lib/PDF");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extention = Path.GetExtension(fileFrontImage.PostedFile.FileName);
            if (Extention == ".pdf")
            {
                fileFrontImage.SaveAs(SavePath + "\\" + "TawheedPublication" + Extention);                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Only PDF file Upload.');", true);
                return;
            }
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('File Upload Complete.');", true);        
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}