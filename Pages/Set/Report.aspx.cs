using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Pages_Set_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadData();
    }

    private void LoadData()
    {
        gridViewRepot.DataSourceID = "SqlDataSource1";
        gridViewRepot.DataBind();
    }

}