using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UCHitCount : System.Web.UI.UserControl
{
    DAL counterManager = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        AddCount();
        lblVisitorOnline.Text = Application["OnlineUsers"].ToString();
        object[] o = new object[2];
        o = GetCount();
        lblTodayVisitor.Text = o[0].ToString();
        lblTotalVisitor.Text = o[1].ToString();
        if (!IsPostBack)
        {
            Application["hit"] = Convert.ToInt32(Application["hit"].ToString()) + 1;
        }
        lblTotalPageHit.Text = Application["hit"].ToString();
        
    }
    public object[] GetCount()
    {
        object[] o = new object[2];
        DateTime today = DateTime.Now.Date;
        DataTable dt = counterManager.GetCounter(today);
        DataTable dt1 = counterManager.GetCounter();
        // get Today Hits
        o[0] = dt.Rows.Count;

        // get all hits

        o[1] = dt1.Rows.Count;

        return o;
    }
    public void AddCount()
    {
        string ipAddress = Request.UserHostAddress;
        DateTime today = DateTime.Now.Date;
        DataTable dt = counterManager.GetCounter(ipAddress, today);
        if (dt.Rows.Count == 0)
        {
            bool save = counterManager.SaveHitCounter(ipAddress, today);
        }        
    }    
}