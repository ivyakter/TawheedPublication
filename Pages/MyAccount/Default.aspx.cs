using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_MyAccount_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void FindCoordinates(object sender, EventArgs e)
    {
        ////https://maps.googleapis.com/maps/api/js?libraries=places&sensor=false&key=APIKey
        ////https://maps.googleapis.com/maps/api/js?libraries=places&key=AIzaSyDjR14OREWodXlFSAi-S78TwQG5XhGILdg
        //string url = "http://maps.google.com/maps/api/geocode/js?libraries=places&key=AIzaSyDjR14OREWodXlFSAi-S78TwQG5XhGILdg&xml?address=" + txtLocation.Text + "&sensor=false";
        //WebRequest request = WebRequest.Create(url);
        //using (WebResponse response = (HttpWebResponse)request.GetResponse())
        //{
        //    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
        //    {
        //        DataSet dsResult = new DataSet();
        //        dsResult.ReadXml(reader);
        //        DataTable dtCoordinates = new DataTable();
        //        dtCoordinates.Columns.AddRange(new DataColumn[4] { new DataColumn("Id", typeof(int)),
        //                new DataColumn("Address", typeof(string)),
        //                new DataColumn("Latitude",typeof(string)),
        //                new DataColumn("Longitude",typeof(string)) });
        //        foreach (DataRow row in dsResult.Tables["result"].Rows)
        //        {
        //            string geometry_id = dsResult.Tables["geometry"].Select("result_id = " + row["result_id"].ToString())[0]["geometry_id"].ToString();
        //            DataRow location = dsResult.Tables["location"].Select("geometry_id = " + geometry_id)[0];
        //            dtCoordinates.Rows.Add(row["result_id"], row["formatted_address"], location["lat"], location["lng"]);
        //        }
        //        GridView1.DataSource = dtCoordinates;
        //        GridView1.DataBind();
        //    }
        //}
    }
}