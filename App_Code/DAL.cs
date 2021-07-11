using System;
using System.Activities.Expressions;
using System.Data;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.UI;
using System.Data.Common;
using System.Data.SqlClient;
using DataSet = System.Data.DataSet;

public class DAL
{


    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBcon"].ConnectionString);
    SqlCommand sqlcmd = null;

  

    public void con()
    {
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
        cn.Open();
    }

 

    //bool returnbool = false;


    public SqlConnection Connection
    {
        get
        {
            return cn;
        }
    }



    public bool SizeDeletebyid(string id)
    {
        try
        {
            con();
            string Save = "Delete from ProductSize where ID=@ID";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", id);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool TitleSetDeletebyid(string id)
    {
        try
        {
            con();
            string Save = "Delete from TitleSet where ID=@ID";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", id);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable GetShopNow1(string position)
    {
        con();
        string id = @"Select * from SliderDetails Where Position='"+position+"'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataSet GetDataSet(string sql)
    {
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);

        DataSet ds = new DataSet();
        adp.Fill(ds);
        Connection.Close();

        return ds;
    }
    public DataTable GetCounter()
    {
        con();
        string id = @"select * from tblViewCounts";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetCounter(DateTime date)
    {
        con();
        string id = @"select * from tblViewCounts where CreateDate='" + date + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetCounter(string ipAddress, DateTime date)
    {
        con();
        string id = @"select * from tblViewCounts where IPAddress='" + ipAddress + "' and CreateDate='"+date+"'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public bool SaveHitCounter(string ipAddress, DateTime date)
    {
        con();
        string insertreginfo = "Insert into tblViewCounts (IPAddress,CreateDate)Values (@IPAddress,@CreateDate)";
        sqlcmd = new SqlCommand(insertreginfo, cn);
        sqlcmd.Parameters.AddWithValue("@IPAddress", ipAddress);
        sqlcmd.Parameters.AddWithValue("@CreateDate", date);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public bool deletefromCatdImage(string CatID)
    {
        con();
        string insertreginfo = "Delete from CategoryImages where CatID='" + CatID + "' ";
        sqlcmd = new SqlCommand(insertreginfo, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public DataTable getSizebyid(long rowid)
    {
        con();
        string id = @"select * from ProductSize where ID='" + rowid + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetBookId(string title)
    {
        con();
        string id = @"select * from Books where Title='" + title + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getWriterbyid(long rowid)
    {
        con();
        string id = @"select  * from Writer where Id='" + rowid + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetWriterbyCode(string code)
    {
        con();
        string id = @"select * from Writer where Code='" + code + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetAuthorById(int authorId)
    {
        con();
        string id = @"select  * from Writer where Id='" + authorId + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;

        //var authors = (from c in entities.tblAuthors select c).Where(c => c.Id == authorId).ToList<tblAuthor>();
        //return authors;
    }
    public DataTable GetAuthor()
    {
        con();
        string id = @"select  * from Writer Where Status='Active' ORDER BY Id DESC";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetPopularAuthor()
    {
        con();
        string id = @"select  * from Writer Where Status='Active' and Phone='Yes' ORDER BY Id DESC";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetAllAuthor()
    {
        con();
        string id = @"select  * from Writer ORDER BY Id DESC";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable SearchAuthorByName(string name)
    {
        string a = "%";
        con();
        string id = @"select  * from Writer where Name like '" + name + a + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    //Admin SubCategory Page
    public bool InsertSubCategoryBook(string[] insert)
    {
        con();
        string Save = "Insert into Subject (Name,Description,Status,CreatedBy,CreatedDateTime,LastUpdatedBy,LastUpdatedDateTime,Code,CategoryId) values (@Name,@Description,@Status,@CreatedBy,@CreatedDateTime,@LastUpdatedBy,@LastUpdatedDateTime,@Code,@CategoryId)";
        sqlcmd = new SqlCommand(Save, cn);
        sqlcmd.Parameters.AddWithValue("@Name", insert[0]);
        sqlcmd.Parameters.AddWithValue("@Description", insert[1]);
        sqlcmd.Parameters.AddWithValue("@Status", insert[2]);
        sqlcmd.Parameters.AddWithValue("@CreatedBy", insert[3]);
        sqlcmd.Parameters.AddWithValue("@CreatedDateTime", insert[4]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedBy", insert[5]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedDateTime", insert[6]);
        sqlcmd.Parameters.AddWithValue("@Code", insert[7]);
        sqlcmd.Parameters.AddWithValue("@CategoryId", insert[8]);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public bool UpdateSubCategory(string[] insert, int id)
    {
        con();
        string Save = "Update Subject set Name=@Name,Description=@Description,LastUpdatedBy=@LastUpdatedBy,LastUpdatedDateTime=@LastUpdatedDateTime,CategoryId=@CategoryId where id='" + id+"'";
        sqlcmd = new SqlCommand(Save, cn);
        sqlcmd.Parameters.AddWithValue("@Name", insert[0]);
        sqlcmd.Parameters.AddWithValue("@Description", insert[1]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedBy", insert[2]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedDateTime", insert[3]);
        sqlcmd.Parameters.AddWithValue("@CategoryId", insert[8]);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public bool UpdateSubCategoryStatus(string[] insert, int id)
    {
        con();
        string Save = "Update Subject set Status=@Status,LastUpdatedBy=@LastUpdatedBy,LastUpdatedDateTime=@LastUpdatedDateTime where id='" + id+"'";
        sqlcmd = new SqlCommand(Save, cn);
        sqlcmd.Parameters.AddWithValue("@Status", insert[0]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedBy", insert[1]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedDateTime", insert[2]);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public bool DeleteSubCategory(int id)
    {
        con();
        string Save = "Delete From Subject where id='" + id + "'";
        sqlcmd = new SqlCommand(Save, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public DataTable getSubCategoryBook(int bid)
    {
        con();
        string id = @"select  Subject.*, tblCategories.Name as Category  from Subject join tblCategories ON tblCategories.Id=Subject.CategoryId where Subject.Id='" + bid+"'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getSubCategoryBookByCategoryId(int bid)
    {
        con();
        string id = @"select  Subject.*, tblCategories.Name as Category  from Subject join tblCategories ON tblCategories.Id=Subject.CategoryId where Subject.CategoryId='" + bid + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetAllSubCategory()
    {
        con();
        string id = @"Select * from Subject ORDER BY Id DESC";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetSubCategory()
    {
        con();
        string sql = @"Select * from Subject where Status='Active' ORDER BY Id DESC";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;

    }
    public DataTable GetTop5SubCategory()
    {
        con();
        string sql = @"Select Top 4* from Subject where Status='Active' ORDER BY Id DESC";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;

    }
    public DataTable SearchSubCategoryBookByName(string name)
    {
        string a = "%";
        con();
        string id = @"select  * from Subject where Name like '" + name + a + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    //Admin Category Page
    public bool InsertCategoryBook(string[] insert)
    {
        con();
        string Save = "Insert into tblCategories (Name,Description,Status,CreatedBy,CreatedDateTime,LastUpdatedBy,LastUpdatedDateTime,Code) values (@Name,@Description,@Status,@CreatedBy,@CreatedDateTime,@LastUpdatedBy,@LastUpdatedDateTime,@Code)";
        sqlcmd = new SqlCommand(Save, cn);
        sqlcmd.Parameters.AddWithValue("@Name", insert[0]);
        sqlcmd.Parameters.AddWithValue("@Description", insert[1]);
        sqlcmd.Parameters.AddWithValue("@Status", insert[2]);
        sqlcmd.Parameters.AddWithValue("@CreatedBy", insert[3]);
        sqlcmd.Parameters.AddWithValue("@CreatedDateTime", insert[4]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedBy", insert[5]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedDateTime", insert[6]);
        sqlcmd.Parameters.AddWithValue("@Code", insert[7]);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public bool UpdateCategory(string[] insert, int id)
    {
        con();
        string Save = "Update tblCategories set Name=@Name,Description=@Description,LastUpdatedBy=@LastUpdatedBy,LastUpdatedDateTime=@LastUpdatedDateTime where id='" + id + "'";
        sqlcmd = new SqlCommand(Save, cn);
        sqlcmd.Parameters.AddWithValue("@Name", insert[0]);
        sqlcmd.Parameters.AddWithValue("@Description", insert[1]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedBy", insert[2]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedDateTime", insert[3]);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public bool UpdateCategoryStatus(string[] insert, int id)
    {
        con();
        string Save = "Update tblCategories set Status=@Status,LastUpdatedBy=@LastUpdatedBy,LastUpdatedDateTime=@LastUpdatedDateTime where id='" + id + "'";
        sqlcmd = new SqlCommand(Save, cn);
        sqlcmd.Parameters.AddWithValue("@Status", insert[0]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedBy", insert[1]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedDateTime", insert[2]);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public bool DeleteCategory(int id)
    {
        con();
        string Save = "Delete From tblCategories where id='" + id + "'";
        sqlcmd = new SqlCommand(Save, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public DataTable getCategoryBook(int bid)
    {
        con();
        string id = @"select  * from tblCategories where Id='" + bid + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getCategoryBookByName(string name)
    {
        string a = "%";
        con();
        string id = @"select  * from tblCategories where Name like '" + name +a +"'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetCategory()
    {
        con();
        string sql = @"Select * from tblCategories where Status='Active' ORDER BY Id Asc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetAllCategory()
    {
        con();
        string sql = @"Select * from tblCategories ORDER BY Id DESC";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;

    }

    

     //Admin Publication Page
    public bool InsertPublicationBook(string[] insert)
    {
        con();
        string Save = "Insert into tblPublication (Name,Description,Status,CreatedBy,CreatedDateTime,LastUpdatedBy,LastUpdatedDateTime,Code) values (@Name,@Description,@Status,@CreatedBy,@CreatedDateTime,@LastUpdatedBy,@LastUpdatedDateTime,@Code)";
        sqlcmd = new SqlCommand(Save, cn);
        sqlcmd.Parameters.AddWithValue("@Name", insert[0]);
        sqlcmd.Parameters.AddWithValue("@Description", insert[1]);
        sqlcmd.Parameters.AddWithValue("@Status", insert[2]);
        sqlcmd.Parameters.AddWithValue("@CreatedBy", insert[3]);
        sqlcmd.Parameters.AddWithValue("@CreatedDateTime", insert[4]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedBy", insert[5]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedDateTime", insert[6]);
        sqlcmd.Parameters.AddWithValue("@Code", insert[7]);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public bool UpdatePublication(string[] insert, int id)
    {
        con();
        string Save = "Update tblPublication set Name=@Name,LastUpdatedBy=@LastUpdatedBy,LastUpdatedDateTime=@LastUpdatedDateTime where id='" + id + "'";
        sqlcmd = new SqlCommand(Save, cn);
        sqlcmd.Parameters.AddWithValue("@Name", insert[0]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedBy", insert[2]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedDateTime", insert[3]);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public bool UpdatePublicationStatus(string[] insert, int id)
    {
        con();
        string Save = "Update tblPublication set Status=@Status,LastUpdatedBy=@LastUpdatedBy,LastUpdatedDateTime=@LastUpdatedDateTime where id='" + id + "'";
        sqlcmd = new SqlCommand(Save, cn);
        sqlcmd.Parameters.AddWithValue("@Status", insert[0]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedBy", insert[1]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedDateTime", insert[2]);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public bool DeletePublication(int id)
    {
        con();
        string Save = "Delete From tblPublication where id='" + id + "'";
        sqlcmd = new SqlCommand(Save, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public DataTable getPublicationBook(int bid)
    {
        con();
        string id = @"select  * from tblPublication where Id='" + bid + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getPublicationBookByName(string name)
    {
        string a = "%";
        con();
        string id = @"select  * from tblPublication where Name like '" + name + a + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetPublication()
    {
        con();
        string sql = @"Select * from tblPublication where Status='Active' ORDER BY Id Asc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetAllPublication()
    {
        con();
        string sql = @"Select * from tblPublication ORDER BY Id DESC";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetAllPublicationAsc()
    {
        con();
        string sql = @"Select * from tblPublication ORDER BY Id ASC";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getPublicationAllBooks(string subject)
    {

        con();
        string sql = @"Select * from Books join tblCategories On Books.CategoryId=tblCategories.Id where Books.Publisher='" + subject + "' and Books.Status='Active'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetPublicationAllBooks(string id)
    {
        con();
        string sql = "Select Books.* from tblPublication join Books on Books.Publisher=tblPublication.Name Where tblPublication.Id='" + id + "' and Books.Status='Active' ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetPublicationAllBookByPriceRange(string id, decimal min, decimal max)
    {
        con();
        string sql = "Select Books.* from tblPublication join Books on Books.Publisher=tblPublication.Name Where tblPublication.Id='" + id + "' and Books.Status='Active' and Books.Price between " + min + " and " + max + " Order By Books.Price Asc ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    //Admin Manage Page
    public bool InsertAdmin(string[] insert)
    {
        con();
        string Save = "Insert into tblAdmin (Name,Email,Password,MobileNo,Type,CreatedDate,Status) values (@Name,@Email,@Password,@MobileNo,@Type,@CreatedDate,@Status)";
        sqlcmd = new SqlCommand(Save, cn);
        sqlcmd.Parameters.AddWithValue("@Name", insert[0]);
        sqlcmd.Parameters.AddWithValue("@Email", insert[1]);
        sqlcmd.Parameters.AddWithValue("@Password", insert[2]);
        sqlcmd.Parameters.AddWithValue("@MobileNo", insert[3]);
        sqlcmd.Parameters.AddWithValue("@Type", insert[4]);
        sqlcmd.Parameters.AddWithValue("@CreatedDate", insert[5]);
        sqlcmd.Parameters.AddWithValue("@Status", insert[6]);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public bool UpdateAdmin(string[] insert, int id)
    {
        con();
        string Save = "Update tblAdmin set Name=@Name,Email=@Email,Password=@Password,MobileNo=@MobileNo,Type=@Type,CreatedDate=@CreatedDate where id='" + id + "'";
        sqlcmd = new SqlCommand(Save, cn);
        sqlcmd.Parameters.AddWithValue("@Name", insert[0]);
        sqlcmd.Parameters.AddWithValue("@Email", insert[1]);
        sqlcmd.Parameters.AddWithValue("@Password", insert[2]);
        sqlcmd.Parameters.AddWithValue("@MobileNo", insert[3]);
        sqlcmd.Parameters.AddWithValue("@Type", insert[4]);
        sqlcmd.Parameters.AddWithValue("@CreatedDate", insert[5]);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public bool UpdateAdminStatus(string[] insert, int id)
    {
        con();
        string Save = "Update tblAdmin set Status=@Status,CreatedDate=@CreatedDate where id='" + id + "'";
        sqlcmd = new SqlCommand(Save, cn);
        sqlcmd.Parameters.AddWithValue("@Status", insert[0]);
        sqlcmd.Parameters.AddWithValue("@CreatedDate", insert[1]);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public bool DeleteAdmin(int id)
    {
        con();
        string Save = "Delete From tblAdmin where id='" + id + "'";
        sqlcmd = new SqlCommand(Save, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public DataTable GetAdminById(int bid)
    {
        con();
        string id = @"select  * from tblAdmin where Id='" + bid + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetAdmin(string name, string email, string phone)
    {
        con();
        string sql = @"Select * from tblAdmin where Name='"+name+"' and Email='"+email+ "' and MobileNo='"+phone+"'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;

    }


    public DataTable getSubCategoryBook()
    {
        con();
        string id = @"select  * from Subject ORDER BY Id DESC";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetBookCategoryById(int bookId)
    {
        con();
        string id = @"select  * from tblBookCategories  where BookId='" + bookId + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;

        //var bookCategory = (from bc in entities.tblBookCategories select bc).Where(bc => bc.BookId == bookId).ToList();
        //return bookCategory;
    }

    public DataTable getBookBySubCategoryId(int bid)
    {
        con();
        string id = @"Select Top 5* from Books join tblBookCategories ON Books.Id=tblBookCategories.BookId Where tblBookCategories.CategoryId='" + bid + "' And Books.Status='Active' Order by Books.Id desc";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetSliderById(int sliderId)
    {
        con();
        string id = @"select  * from tblSliders  where Id='" + sliderId + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
        //var sliders = (from s in entities.tblSliders select s).Where(s => s.Id == sliderId).ToList();
        //return sliders;
    }
    public bool DeleteSlider(int sliderId)
    {
        con();
        string insertreginfo = "Delete from tblSliders where Id='" + sliderId + "' ";
        sqlcmd = new SqlCommand(insertreginfo, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
        //var slider = (from s in entities.tblSliders
        //              where s.Id == sliderId
        //              select s).First();
        //entities.tblSliders.Remove(slider);
        //entities.SaveChanges();
    }
    public DataTable GetPolicyById(int policyId)
    {
        con();
        string id = @"select  * from tblPolicy   where Id='" + policyId + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
        //var policies = (from p in entities.tblPolicies select p).Where(p => p.Id == policyId).ToList<tblPolicy>();
        //return policies;
    }
    public bool DeletePolicy(int policyId)
    {
        con();
        string insertreginfo = "Delete from tblPolicy where Id='" + policyId + "' ";
        sqlcmd = new SqlCommand(insertreginfo, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
        //var policy = (from p in entities.tblPolicies
        //              where p.Id == policyId
        //              select p).First();
        //entities.tblPolicies.Remove(policy);
        //entities.SaveChanges();
    }
    public bool UpdatePolicyStatus(string Status, string LastUpdatedBy, string LastUpdatedDateTime, int policyId)
    {
        con();
        string insertreginfo = "Update tblPolicy set Status=@Status, LastUpdatedBy=@LastUpdatedBy, LastUpdatedDateTime=@LastUpdatedDateTime where Id='" + policyId + "' ";
        sqlcmd = new SqlCommand(insertreginfo, cn);
        sqlcmd.Parameters.AddWithValue("@Status", Status);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedBy", LastUpdatedBy);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedDateTime", LastUpdatedDateTime);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public DataTable GetSubcatMuneId()
    {
        con();
        string id = @"Select ParentId  from Menu where MenuLevel=0";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetSubcatMuneId(string id2)
    {
        con();
        string id = @"Select ParentId  from Menu where MenuLevel=0";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetOrderByInvoice(string invoiceNumber)
    {
        con();
        string id = @"select  * from tblOrder  where InvoiceNumber='" + invoiceNumber + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
        //var order = (from o in entities.tblOrders select o).
        //                    Where(o => o.InvoiceNumber == invoiceNumber).ToList();
        //return order;
    }

    public DataTable GetOrderByDate()
    {
        con();
        string id = @"select  Top 5* from tblOrder Order By Id Desc";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetOrderByInvoice2(string invoiceNumber)
    {
        con();
        string id = @"select  * from tblOrder2  where InvoiceNumber='" + invoiceNumber + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
        //var order = (from o in entities.tblOrders select o).
        //                    Where(o => o.InvoiceNumber == invoiceNumber).ToList();
        //return order;
    }
    public bool UpdateOrderStatus(string status, string voucherOn)
    {
        try
        {
            con();
            string update = "Update tblOrder set Status=@Status where InvoiceNumber='" + voucherOn + "'";
            sqlcmd = new SqlCommand(update, cn);
            sqlcmd.Parameters.AddWithValue("@Status", status);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable GetPaidtblOrder(string status)
    {
        con();
        string id = @"select  * from tblOrder where Status='" + status + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetBookAuthorById(int bookId)
    {
        con();
        string id = @"select  * from tblBookAuthors where BookId='"+bookId+"'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;

        //var bookAuthor = entities.tblBookAuthors.Where(ba => ba.BookId == bookId).ToList();
        //return bookAuthor;
    }
    public bool DeleteAuthor(int authorId)
    {
        con();
        string insertreginfo = "Delete from Writer where Id='" + authorId + "' ";
        sqlcmd = new SqlCommand(insertreginfo, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }

    public DataTable getCategorybyid(long rowid)
    {
        con();
        string id = @"select  * from CategoryImages inner join Menu on Menu.Id=CategoryImages.CatID where CatIMGID='" + rowid + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getBookByPID(long rowid)
    {
        con();
        string id = @"  Select * from Books Where Id='"+rowid+"' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getBookByPID(string rowid)
    {
        con();
        string id = @"  Select * from Books Where Id='" + rowid + "' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }



    public DataTable getTitlebyid(long rowid)
    {
        con();
        string id = @"select * from TitleSet where ID='" + rowid + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetDataTable(string sql)
    {
        DataSet ds = GetDataSet(sql);

        if (ds.Tables.Count > 0)
            return ds.Tables[0];
        return null;
    }

    public bool UpdateUserinfromuserInfo(string[] Insert)
    {
        try
        {
            con();

            string update = "Update CustomerRegistration set FirstName=@FirstName,Country=@Country,Address=@Address,Phone=@Phone,Password=@Password where Email=@Email";
            sqlcmd = new SqlCommand(update, cn);
            sqlcmd.Parameters.AddWithValue("@FirstName", Insert[0]);
            sqlcmd.Parameters.AddWithValue("@Country", Insert[1]);
            sqlcmd.Parameters.AddWithValue("@Address", Insert[2]);
            sqlcmd.Parameters.AddWithValue("@Phone", Insert[4]);
            sqlcmd.Parameters.AddWithValue("@Password", Insert[5]);
            sqlcmd.Parameters.AddWithValue("@Email", Insert[3]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool UpdateSizeList(long id, string sizename)
    {
        try
        {
            con();
            string update = "Update ProductSize set SizeName='" + sizename + "'  where ID='" + id + "'";
            sqlcmd = new SqlCommand(update, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool UpdateTitle(long id, string title)
    {
        try
        {
            con();
            string update = "Update TitleSet set Title='" + title + "'  where ID='" + id + "'";
            sqlcmd = new SqlCommand(update, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool InsertRegistrationInfo(string[] insert)
    {
        try
        {
            con();
            string update = "Insert Into CustomerRegistration (FirstName,SurName,Country,Phone,Email,Password,Address,CreateDate) values (@FirstName,@SurName,@Country,@Phone,@Email,@Password,@Address,@Date)";
            sqlcmd = new SqlCommand(update, cn);
            sqlcmd.Parameters.AddWithValue("@FirstName", insert[0]);           
            sqlcmd.Parameters.AddWithValue("@SurName", insert[2]);
            sqlcmd.Parameters.AddWithValue("@Country", insert[3]);
            sqlcmd.Parameters.AddWithValue("@Phone", insert[6]);
            sqlcmd.Parameters.AddWithValue("@Email", insert[7]);
            sqlcmd.Parameters.AddWithValue("@Password", insert[8]);
            sqlcmd.Parameters.AddWithValue("@Address", insert[9]);
            sqlcmd.Parameters.AddWithValue("@Date", DateTime.Now);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public bool UpdateRegistrationInfo(string[] insert)
    {
        try
        {
            con();
            string update = "Update CustomerRegistration set FirstName=@FirstName,SurName=@SurName,Country=@Country,Distance=@Distance,Phone=@Phone,Landline=@Landline,Email=@Email,Password=@Password,PostCode=@PostCode,Address=@Address,HouseNo=@HouseNo where ID=@Id";
            sqlcmd = new SqlCommand(update, cn);
            sqlcmd.Parameters.AddWithValue("@Id", insert[0]);
            sqlcmd.Parameters.AddWithValue("@FirstName", insert[1]);
            sqlcmd.Parameters.AddWithValue("@SurName", insert[2]);
            sqlcmd.Parameters.AddWithValue("@Country", insert[4]);
            sqlcmd.Parameters.AddWithValue("@Distance", insert[5]);
            sqlcmd.Parameters.AddWithValue("@Phone", insert[9]);
            sqlcmd.Parameters.AddWithValue("@Landline", insert[10]);
            sqlcmd.Parameters.AddWithValue("@Email", insert[3]);
            sqlcmd.Parameters.AddWithValue("@Password", insert[11]);
            sqlcmd.Parameters.AddWithValue("@PostCode", insert[6]);
            sqlcmd.Parameters.AddWithValue("@Address", insert[8]);
            sqlcmd.Parameters.AddWithValue("@HouseNo", insert[7]);
            
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public bool DeleteRegistrationInfo(string[] insert)
    {
        try
        {
            con();
            string delete = "Delete from CustomerRegistrationUpdate where CustomerId=@Id";
            sqlcmd = new SqlCommand(delete, cn);
            sqlcmd.Parameters.AddWithValue("@Id", insert[0]);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool InsertCustomerWishlist(string[] insert)
    {
        try
        {
            con();
            string update = "Insert Into tblWishlist (Email, Code,Title,Price,SpecialPrice,FontImage) values (@Email,@Code,@Title,@Price,@SpecialPrice,@FontImage)";
            sqlcmd = new SqlCommand(update, cn);
            sqlcmd.Parameters.AddWithValue("@Email", insert[0]);
            sqlcmd.Parameters.AddWithValue("@Code", insert[1]);
            sqlcmd.Parameters.AddWithValue("@Title", insert[2]);
            sqlcmd.Parameters.AddWithValue("@Price", insert[3]);
            sqlcmd.Parameters.AddWithValue("@SpecialPrice", insert[4]);
            sqlcmd.Parameters.AddWithValue("@FontImage", insert[5]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable CheckCustomerWishlist(string[] insert)
    {
        try
        {
            con();
            string sql = @"Select * From tblWishlist Where Email='"+ insert[0] + "'  and Code='" + insert[1] + "' and  Price='" + insert[3] + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable GetWishlist(string email)
    {
        try
        {
            con();
            string sql = @"Select * From books join tblWishlist  On Books.Code=tblWishlist.Code Where tblWishlist.Email='" + email + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool InsertRegistrationInfo1(string[] insert)
    {
        try
        {
            con();
            string update = "Insert Into CustomerRegistrationUpdate (CustomerId, FirstName,SurName,Country,Distance,PostCode,HouseNo,Address,Phone,Email,Password) values (@CustomerId,@FirstName,@SurName,@Country,@Distance,@PostCode,@HouseNo,@Address,@Phone,@Email,@Password)";
            sqlcmd = new SqlCommand(update, cn);
            sqlcmd.Parameters.AddWithValue("@CustomerId", insert[0]);
            sqlcmd.Parameters.AddWithValue("@FirstName", insert[3]);
            sqlcmd.Parameters.AddWithValue("@SurName", insert[4]);
            sqlcmd.Parameters.AddWithValue("@Country", insert[5]);
            sqlcmd.Parameters.AddWithValue("@Distance", insert[6]);
            sqlcmd.Parameters.AddWithValue("@PostCode", insert[7]);
            sqlcmd.Parameters.AddWithValue("@HouseNo", insert[8]);
            sqlcmd.Parameters.AddWithValue("@Address", insert[9]);
            sqlcmd.Parameters.AddWithValue("@Phone", insert[10]);
            sqlcmd.Parameters.AddWithValue("@Email", insert[1]);
            sqlcmd.Parameters.AddWithValue("@Password", insert[2]);
                      

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public bool SaveOrder(string orderid, string pid, string pname, string quantity, string price, string lbltotal, string customerid, string date, string Barcode,string DeliveryDate, string ShoppingType, string TimeSlot,string SpecialRequist,string Vat)
    {
        try
        {
            con();
            string Save = "INSERT INTO TblOrder(orderid,Customerid,Pid,Pname,Quantity,Total,Price,Status,Date,Barcode,DeliveyDate,ShoppingType,TimeSlot,SpeialRequist,Vat)values(@orderid,@Customerid,@Pid,@Pname,@Quantity,@Total,@Price,@Status,@Date,@Barcode,@DeliveyDate,@ShoppingType,@TimeSlot,@SpeialRequist,@Vat)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@orderid", orderid);
            sqlcmd.Parameters.AddWithValue("@Customerid", customerid);
            sqlcmd.Parameters.AddWithValue("@Pid", pid);
            sqlcmd.Parameters.AddWithValue("@Pname", pname);
            sqlcmd.Parameters.AddWithValue("@Quantity", quantity);
            sqlcmd.Parameters.AddWithValue("@Total", lbltotal);
            sqlcmd.Parameters.AddWithValue("@Price", price);
            sqlcmd.Parameters.AddWithValue("@Status", "On Hold");
            sqlcmd.Parameters.AddWithValue("@Date", date);
            sqlcmd.Parameters.AddWithValue("@Barcode", Barcode);
            sqlcmd.Parameters.AddWithValue("@DeliveyDate", DeliveryDate);
            sqlcmd.Parameters.AddWithValue("@ShoppingType", ShoppingType);
            sqlcmd.Parameters.AddWithValue("@TimeSlot", TimeSlot);
            sqlcmd.Parameters.AddWithValue("@SpeialRequist", SpecialRequist);
            sqlcmd.Parameters.AddWithValue("@Vat", Vat);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }



    public DataTable GetOrderid()
    {
        con();
        string sql = @"select ISNULL(Max(id),0) as id from TblOrder";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetHotNewArrival()
    {
        con();
        //string sql = @"Select * from tblProducts B  cross apply(select top 1 * from tblProductImages C where C.PID = B.PID and B.PCategoryID='2' order by C.PID desc ) C";
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID  ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C where Section='0' And B.ShowOnFirstPage!='Not need to show in first Page' order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetHotBestSeller()
    {
        con();
        //string sql = @"Select * from tblProducts B  cross apply(select top 1 * from tblProductImages C where C.PID = B.PID and B.PCategoryID='2' order by C.PID desc ) C";
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID  ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C where Section='2' order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetHotDealsProduct()
    {
        con();
        //string sql = @"Select * from tblProducts B  cross apply(select top 1 * from tblProductImages C where C.PID = B.PID and B.PCategoryID='2' order by C.PID desc ) C";
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID  ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C where Section='3' order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public bool InsertSizes(string[] insert)
    {
        try
        {
            con();
            string update = "Insert Into ProductSize (SizeID,SizeName) values (@SizeID,@SizeName)";
            sqlcmd = new SqlCommand(update, cn);
            sqlcmd.Parameters.AddWithValue("@SizeID", insert[1]);
            sqlcmd.Parameters.AddWithValue("@SizeName", insert[2]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool InsertTitle(string[] insert)
    {
        try
        {
            con();
            string update = "Insert Into TitleSet (Title) values (@Title)";
            sqlcmd = new SqlCommand(update, cn);

            sqlcmd.Parameters.AddWithValue("@Title", insert[2]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable getCustomerInfo(string email)
    {
        con();
        string sql = @"Select * from CustomerRegistration where Email='"+email+"'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetCustomerInfoById(string id)
    {
        con();
        string sql = @"Select * from CustomerRegistration where Id='" + id + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getCustomerInfo(string email, string pw)
    {
        con();
        string sql = @"Select * from CustomerRegistration where Email='" + email + "' and password='"+pw+"'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public bool UpdateCategoryname(string[] insert)
    {
        try
        {
            con();
            string update = "Update Menu set MenuText='" + insert[1] + "' where Id='" + insert[0] + "'";

            sqlcmd = new SqlCommand(update, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool updateCategoryphoto(string pID, string pname, string extention, string lblPIMGID)
    {

        try
        {
            con();
            string Save = "update CategoryImages set Name = '" + pname.ToString().Trim() + "',Extention='" + extention + "' where CatIMGID='" + lblPIMGID + "'";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }

    }

    public DataTable GetLastBlogId()
    {
        con();
        string id = @"select ISNULL(Max(Id),0) as Id from tblBlog";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetAllBlog()
    {
        con();
        string id = @"select * from tblBlog Where Status='Active' Order By Id desc";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetBlogByCategory(string cat)
    {
        con();
        string id = @"select * from tblBlog Where Status='Active' and Code='"+cat+"' Order By Id desc";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetBlog()
    {
        con();
        string id = @"select * from tblBlog Order By Id desc";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable SearchBlogByName(string name)
    {
        string a = "%";
        con();
        string id = @"select * from tblBlog where Title like '"+name+a+"'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetBlogById(string blogId)
    {
        con();
        string id = @"select * from tblBlog Where Id='"+blogId+"'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetBlogByEmail(string name)
    {
        con();
        string id = @"select * from tblBlog Where Email='" + name + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetThreeBlog()
    {
        con();
        string id = @"select top 3 * from tblBlog Where Status='Active' Order By Id desc";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetTenBlog()
    {
        con();
        string id = @"select top 10 * from tblBlog Where Status='Active' Order By Id desc";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetSearchBlog(string title)
    {
        string a = "%";
        con();
        string id = @"select * from tblBlog Where Status='Active' and Title like '"+title+a+"' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetFourBlog()
    {
        con();
        string id = @"select * from tblBlog Where Status='Active' Order By Id desc";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetBlogById(int blogId)
    {
        con();
        string id = @"select  * from tblBlog   where Id='" + blogId + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
        //var policies = (from p in entities.tblPolicies select p).Where(p => p.Id == policyId).ToList<tblPolicy>();
        //return policies;
    }
    public bool DeleteBlog(int blogId)
    {
        con();
        string insertreginfo = "Delete from tblBlog where Id='" + blogId + "' ";
        sqlcmd = new SqlCommand(insertreginfo, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public bool UpdateBlogStatus(string Status, string LastUpdatedBy, string LastUpdatedDateTime, int blogId)
    {
        con();
        string insertreginfo = "Update tblBlog set Status=@Status, UpdatedBy=@LastUpdatedBy, UpdatedDate=@LastUpdatedDateTime where Id='" + blogId + "' ";
        sqlcmd = new SqlCommand(insertreginfo, cn);
        sqlcmd.Parameters.AddWithValue("@Status", Status);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedBy", LastUpdatedBy);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedDateTime", LastUpdatedDateTime);
        sqlcmd.ExecuteNonQuery();
        return true;
    }

    public bool UpdateBlog(string[] insert, int id)
    {
        try
        {
            con();
            string Save = "Update tblBlog set Title=@Title,Description=@Description,UpdatedBy=@UpdatedBy,UpdatedDate=@UpdatedDate,img=@img,Code=@Code Where Id='"+id+"'";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Title", insert[0]);
            sqlcmd.Parameters.AddWithValue("@Description", insert[1]);
            sqlcmd.Parameters.AddWithValue("@UpdatedBy", insert[5]);
            sqlcmd.Parameters.AddWithValue("@UpdatedDate", insert[6]);
            sqlcmd.Parameters.AddWithValue("@img", insert[8]);
            sqlcmd.Parameters.AddWithValue("@Code", insert[9]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable CheckSameProduct(string productCode)
    {
        con();
        string id = @"select ProductCode from tblProducts where ProductCode='" + productCode + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    //public bool checkloginfo(string[] loginfo)
    //{
    //    try
    //    {
    //        con();
    //        string update = "Insert Into CustomerRegistration (Email,Password) values (@Email,@Password)";
    //        sqlcmd = new SqlCommand(update, cn);
    //        sqlcmd.Parameters.AddWithValue("@Email", loginfo[0]);
    //        sqlcmd.Parameters.AddWithValue("@Password", loginfo[1]);


    //        sqlcmd.ExecuteNonQuery();
    //        return true;
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //}

    public DataTable selectinfocustomer(string[] loginfo)
    {
        con();
        string id = @"select * from CustomerRegistration   where Email='" + loginfo[0] + "' and Password='" + loginfo[1] + "'  ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable selectinfoAdmin(string[] loginfo)
    {
        con();
        string id = @"select * from tblAdmin   where Email='" + loginfo[0] + "' and Password='" + loginfo[1] + "'  ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    
    public DataTable GetNameAndEmail(string Email)
    {
        con();
        string id = @"select * from CustomerRegistration   where Email='" + Email + "'   ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetAreaNo()
    {
        con();
        string id = @"Select ISNULL(Max(ID),0)+1 from AreaWithDays";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }



    public DataTable GetAreaName()
    {
        con();
        string id = @"Select *  from AreaName";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool InsertBlog(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO tblBlog(Title,Description,CreatedBy,Email,CreatedDate,UpdatedBy,UpdatedDate,Status,img,Code)values(@Title,@Description,@CreatedBy,@Email,@CreatedDate,@UpdatedBy,@UpdatedDate,@Status,@img,@Code)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Title", insert[0]);
            sqlcmd.Parameters.AddWithValue("@Description", insert[1]);
            sqlcmd.Parameters.AddWithValue("@CreatedBy", insert[2]);
            sqlcmd.Parameters.AddWithValue("@Email", insert[3]);
            sqlcmd.Parameters.AddWithValue("@CreatedDate", insert[4]);
            sqlcmd.Parameters.AddWithValue("@UpdatedBy", insert[5]);
            sqlcmd.Parameters.AddWithValue("@UpdatedDate", insert[6]);
            sqlcmd.Parameters.AddWithValue("@Status", insert[7]);
            sqlcmd.Parameters.AddWithValue("@img", insert[8]);
            sqlcmd.Parameters.AddWithValue("@Code", insert[9]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool insertProductCategory(string PID, string category)
    {
        try
        {
            con();
            string Save = "INSERT INTO ProductCategory(PID,CategoryID)values(@PID,@CategoryID)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@PID", PID);
            sqlcmd.Parameters.AddWithValue("@CategoryID", category);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool UpdateProductCategory(string PID, string category)
    {
        try
        {
            con();
            string Save = "UPDATE ProductCategory set CategoryID=@CategoryID where PID=@PID";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@PID", PID);
            sqlcmd.Parameters.AddWithValue("@CategoryID", category);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable getVoucherNo()
    {
        con();
        string sql = @"Select MAX(Id)+1 from tblOrder";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public bool insertProductSubCategory(string PID, string Subcategory)
    {
        try
        {
            con();
            string Save = "INSERT INTO ProductSubCategory(PID,SubCategoryID)values(@PID,@SubCategoryID)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@PID", PID);
            sqlcmd.Parameters.AddWithValue("@SubCategoryID", Subcategory);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool UpdateProductSubCategory(string PID, string Subcategory)
    {
        try
        {
            con();
            string Save = "UPDATE ProductSubCategory set SubCategoryID=@SubCategoryID where PID=@PID";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@PID", PID);
            sqlcmd.Parameters.AddWithValue("@SubCategoryID", Subcategory);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool InsertPayment(string voucherNo, string colId, string email, string paymentOption, string paymentMedium, string transaction, string emailskrill, string mobileBikash, string phoneDBBL, string total)
    {
        try
        {
            con();
            string Save = "Insert Into Payment (VoucherNo, ColId, Email, PaymentOption, PaymentMedium, [Transaction], EmailSkrill, MobileBikash, PhoneDBBL, TotalAmount) Values ('" + voucherNo + "' ,'" + colId + "','" + email + "','" + paymentOption + "','" + paymentMedium + "','" + transaction + "','" + emailskrill + "','" + mobileBikash + "','" + phoneDBBL + "', '"+total+"')";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool insertProductBrand(string PID, string Brand)
    {
        try
        {
            con();
            string Save = "INSERT INTO ProductBrand(PID,BrandID)values(@PID,@BrandID)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@PID", PID);
            sqlcmd.Parameters.AddWithValue("@BrandID", Brand);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    

    public bool UpdateProductBrand(string PID, string Brand)
    {
        try
        {
            con();
            string Save = "Update ProductBrand set BrandID=@BrandID where ID=@ID";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", PID);
            sqlcmd.Parameters.AddWithValue("@BrandID", Brand);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool InsertOrder(string[] insert)
    {
        try
        {
            con();
            string Save = "Insert Into tblOrder (InvoiceNumber, CustomerName, Email, Mobile, Address, PaymentOption, TotalPaymentAmount, Status, InvoiceDateTime) Values (@InvoiceNumber,@CustomerName,@Email,@Mobile,@Address,@PaymentOption,@TotalPaymentAmount,@Status,@OrderDate)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@InvoiceNumber", insert[0]);
            sqlcmd.Parameters.AddWithValue("@CustomerName", insert[1]);
            sqlcmd.Parameters.AddWithValue("@Email", insert[2]);
            sqlcmd.Parameters.AddWithValue("@Mobile", insert[3]);
            sqlcmd.Parameters.AddWithValue("@Address", insert[4]);
            sqlcmd.Parameters.AddWithValue("@PaymentOption", insert[5]);
            sqlcmd.Parameters.AddWithValue("@TotalPaymentAmount", insert[6]);
            sqlcmd.Parameters.AddWithValue("@Status", insert[7]);
            sqlcmd.Parameters.AddWithValue("@OrderDate", insert[8]);


            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool InsertOrder2(string[] insert)
    {
        try
        {
            con();
            string Save = "Insert Into tblOrder2 (InvoiceNumber, ProductId, PName, Price, Quantity, TotalAmount, Discount, BarCode, OrderDate) Values (@InvoiceNumber,@ProductId,@PName,@Price,@Quantity,@TotalAmount,@Discount,@BarCode,@OrderDate)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@InvoiceNumber", insert[0]);
            sqlcmd.Parameters.AddWithValue("@ProductId", insert[1]);
            sqlcmd.Parameters.AddWithValue("@PName", insert[2]);
            sqlcmd.Parameters.AddWithValue("@Price", insert[3]);
            sqlcmd.Parameters.AddWithValue("@Quantity", insert[4]);
            sqlcmd.Parameters.AddWithValue("@TotalAmount", insert[5]);
            sqlcmd.Parameters.AddWithValue("@Discount", insert[6]);
            sqlcmd.Parameters.AddWithValue("@BarCode", insert[8]);
            sqlcmd.Parameters.AddWithValue("@OrderDate", insert[7]);


            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }        
    }

    public DataTable GetMenuData()
    {
        con();
        string id = @"Select *  from Menu where MenuLevel=0";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetMenuData(string Category)
    {
        con();
        string id = @"Select *  from Menu where ParentId='" + Category + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool InsertAreawithday(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO AreaWithDays(AreaName,DaysForArea)values(@AreaName,@DaysForArea)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@AreaName", insert[2]);
            sqlcmd.Parameters.AddWithValue("@DaysForArea", insert[3]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool UpdateAreaWithDays(string AreaID, string AreaName, string Dayname)
    {
        try
        {
            con();
            string update = "Update AreaWithDays set AreaName='" + AreaName + "',DaysForArea='" + Dayname + "' where ID='" + AreaID + "'";

            sqlcmd = new SqlCommand(update, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable getAreabyid(long ID)
    {
        con();
        string id = @"select * from AreaWithDays where ID='" + ID + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getAreawithdayList()
    {
        string id = "select * from AreaWithDays";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool AreawithdayDeletebyid(string ID)
    {
        try
        {
            con();
            string Delete = "Delete from AreaWithDays where ID=@ID";
            sqlcmd = new SqlCommand(Delete, cn);
            sqlcmd.Parameters.AddWithValue("@id", ID);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable SlectPerson(string Email, string Password)
    {
        string id = "select * from CustomerRegistration where Email='" + Email + "'and Password='" + Password + "' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable SlectPerson1(string Email)
    {
        string id = "select * from CustomerRegistration where Email='" + Email + "' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable selectdatebypostcode(string post)
    {
        string id = "select DaysForArea from AreaWithDays where AreaWithDays.AreaName <=50 ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable selectdatebypostcode100(string post)
    {
        string id = "select DaysForArea from AreaWithDays where AreaWithDays.AreaName <= 100 and AreaWithDays.AreaName >= 51 ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable selectdatebypostcode150(string post)
    {
        string id = "select DaysForArea from AreaWithDays where AreaWithDays.AreaName >= 101 and AreaWithDays.AreaName <= 250 ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable selectCollectionDate()
    {
        string id = "select DayName from CollectionDays ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetWriterNo()
    {
        con();
        string id = @"Select ISNULL(Max(Id),0)+1 from Writer";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetBookNo()
    {
        con();
        string id = @"Select ISNULL(Max(Id),0)+1 from Books";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetBookNo1()
    {
        con();
        string id = @"Select ISNULL(Max(Id),0) from Books";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetSubjectNo()
    {
        con();
        string id = @"Select ISNULL(Max(Id),0)+1 from Subject";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetCategoryNo()
    {
        con();
        string id = @"Select ISNULL(Max(Id),0)+1 from Menu";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool InsertWriter(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO Writer(Name,Description,Gender,DateOfBirth,Address,Email,Phone,Status,CreatedBy,CreatedDateTime,LastUpdatedBy,LastUpdatedDateTime,Code,Extension)values(@Name,@Description,@Gender,@DateOfBirth,@Address,@Email,@Phone,@Status,@CreatedBy,@CreatedDateTime,@LastUpdatedBy,@LastUpdatedDateTime,@Code,@Extension)";
            sqlcmd = new SqlCommand(Save, cn);            
            sqlcmd.Parameters.AddWithValue("@Name", insert[0]);
            sqlcmd.Parameters.AddWithValue("@Description", insert[1]);
            sqlcmd.Parameters.AddWithValue("@Gender", insert[2]);
            sqlcmd.Parameters.AddWithValue("@DateOfBirth", insert[3]);
            sqlcmd.Parameters.AddWithValue("@Address", insert[4]);
            sqlcmd.Parameters.AddWithValue("@Email", insert[5]);
            sqlcmd.Parameters.AddWithValue("@Phone", insert[6]);
            sqlcmd.Parameters.AddWithValue("@Status", insert[7]);
            sqlcmd.Parameters.AddWithValue("@CreatedBy", insert[8]);
            sqlcmd.Parameters.AddWithValue("@CreatedDateTime", insert[9]);
            sqlcmd.Parameters.AddWithValue("@LastUpdatedBy", insert[10]);
            sqlcmd.Parameters.AddWithValue("@LastUpdatedDateTime", insert[11]);
            sqlcmd.Parameters.AddWithValue("@Code", insert[12]);
            sqlcmd.Parameters.AddWithValue("@Extension", insert[13]);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool UpdateAuthor(string[] insert, int id)
    {
        try
        {
            con();
            string Save = "Update Writer set Name=@Name,Description=@Description,Gender=@Gender,DateOfBirth=@DateOfBirth,Address=@Address,Email=@Email,Phone=@Phone,Extension=@Extension,LastUpdatedBy=@LastUpdatedBy,LastUpdatedDateTime=@LastUpdatedDateTime Where Id='" + id + "'";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Name", insert[0]);
            sqlcmd.Parameters.AddWithValue("@Description", insert[1]);
            sqlcmd.Parameters.AddWithValue("@Gender", insert[2]);
            sqlcmd.Parameters.AddWithValue("@DateOfBirth", insert[3]);
            sqlcmd.Parameters.AddWithValue("@Address", insert[4]);
            sqlcmd.Parameters.AddWithValue("@Email", insert[5]);
            sqlcmd.Parameters.AddWithValue("@Phone", insert[6]);
            sqlcmd.Parameters.AddWithValue("@LastUpdatedBy", insert[10]);
            sqlcmd.Parameters.AddWithValue("@LastUpdatedDateTime", insert[11]);
            sqlcmd.Parameters.AddWithValue("@Extension", insert[12]);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable CheckAuthe(string name, string email, string address)
    {
        string id = "select * from Writer  Where Name='"+name+ "' and Email='"+email+ "' and Address='"+address+"'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable CheckAutheStatus(int wid)
    {
        string id = "select * from Writer  Where id='" + wid + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public bool UpdateAutheStatus(string[] insert, Int64 id)
    {
        try
        {
            con();
            string Save = "Update Writer set Status=@Status, LastUpdatedBy=@LastUpdatedBy ,LastUpdatedDateTime=@LastUpdatedDateTime Where Id='" + id + "'";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Status", insert[0]);
            sqlcmd.Parameters.AddWithValue("@LastUpdatedBy", insert[1]);
            sqlcmd.Parameters.AddWithValue("@LastUpdatedDateTime", insert[2]);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool UpdateWriter(string[] insert, Int64 id)
    {
        try
        {
            con();
            string Save = "Update Writer set Code=@Code, Name=@Name ,Description=@Description,Extension=@Extension Where Id='"+id+"'";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Code", insert[0]);
            sqlcmd.Parameters.AddWithValue("@Name", insert[1]);
            sqlcmd.Parameters.AddWithValue("@Description", insert[2]);
            sqlcmd.Parameters.AddWithValue("@Extension", insert[3]);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool InsertCategory(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO Menu(MenuText,MenuLevel,ParentId)values(@MenuText,@MenuLevel,@ParentId)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@MenuText", insert[1]);
            sqlcmd.Parameters.AddWithValue("@MenuLevel", '0');
            sqlcmd.Parameters.AddWithValue("@ParentId", insert[0]);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    //public bool UpdateCategoryname(string CategoryId, string CategoryName)
    //{
    //    try
    //    {
    //        con();
    //        string update = "Update Menu set MenuText='" + CategoryName + "' where Id='" + CategoryId + "'";

    //        sqlcmd = new SqlCommand(update, cn);
    //        sqlcmd.ExecuteNonQuery();
    //        return true;
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //}

    public DataTable getSubject()
    {
        string id = "select * from Subject";
        // string id = "select Id,MenuText,MenuLevel,ParentId,(select MenuText from Menu where Id='2' ) as new  from Menu where MenuLevel !='0'";

        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getWriter()
    {
        string id = "select * from Writer order by Id asc";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getCategory()
    {
        string id = "select * from Menu inner join CategoryImages on Menu.Id = CategoryImages.CatID where MenuLevel ='0' order by CategoryImages.CatID asc";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool CategoryDeletebyid(string ID)
    {
        try
        {
            con();
            string Delete = "Delete from Subject where Id=@Id";
            sqlcmd = new SqlCommand(Delete, cn);
            sqlcmd.Parameters.AddWithValue("@Id", ID);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool WriterDeletebyid(string ID)
    {
        try
        {
            con();
            string Delete = "Delete from Writer where Id=@ID";
            sqlcmd = new SqlCommand(Delete, cn);
            sqlcmd.Parameters.AddWithValue("@id", ID);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable getCategoryid(long ID)
    {
        con();
        string id = @"select * from Menu where Id='" + ID + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable LoadCategoryname()
    {
        string id = "select * from Menu where MenuLevel='0'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getSubCategoryid(long ID)
    {
        con();
        string id = @"select * from Subject where Id='" + ID + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getSubCategoryByCategort(string ID)
    {
        con();
        string id = @"select * from Menu where ParentId='" + ID + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getSubCategoryByonly()
    {
        con();
        string id = @"select * from Menu";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool InsertSubject(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO Subject(Code,Name,Description)values(@Code,@Name,@Description)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Code", insert[0]);
            sqlcmd.Parameters.AddWithValue("@Name", insert[1]);
            sqlcmd.Parameters.AddWithValue("@Description", insert[2]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable CheckSubject(string name)
    {
        try
        {
            con();
            string Save = "Select *from Subject where Name='"+name+"'";
            sqlcmd = new SqlCommand(Save, cn);
            
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(Save, cn);
            adapter.Fill(dt);
            return dt;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable GetFrozenBestSeller()
    {
        con();
        // string sql = @"Select * from tblProducts B  cross apply(select top 1 * from tblProductImages C where C.PID = B.PID and B.PCategoryID='9' order by C.PID desc ) C";
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='9' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetPackaginganddisposalBestSeller()
    {
        con();
        // string sql = @"Select * from tblProducts B  cross apply(select top 1 * from tblProductImages C where C.PID = B.PID and B.PCategoryID='9' order by C.PID desc ) C";
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='11' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public bool UpdateSubject(string code, string name, Int64 ID)
    {
        try
        {
            con();
            string update = "Update Subject set Code='" + code + "',Name='" + name + "'  where Id='" + ID + "'";

            sqlcmd = new SqlCommand(update, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable GetVoucher()
    {
        DataTable _dt = new DataTable();
        try
        {
            con();
            string sql = "select ISNULL(Max(PID),0)+1 from tblProducts";
            sqlcmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(_dt);
        }
        catch (Exception)
        {
            throw;
        }
        return _dt;
    }

    public DataTable GetallSize()
    {
        DataTable _dt = new DataTable();
        try
        {
            con();
            string sql = "select * from ProductSize";
            sqlcmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(_dt);
        }
        catch (Exception)
        {
            throw;
        }
        return _dt;
    }

    public DataTable GetallWriter()
    {
        DataTable _dt = new DataTable();
        try
        {
            con();
            string sql = "select * from Writer";
            sqlcmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(_dt);
        }
        catch (Exception)
        {
            throw;
        }
        return _dt;
    }

    public DataTable GetProductName()
    {
        DataTable _dt = new DataTable();
        try
        {
            con();
            string sql = "select * from tblProducts";
            sqlcmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(_dt);
        }
        catch (Exception)
        {
            throw;
        }
        return _dt;
    }

    public DataTable GetallSubject()
    {
        DataTable _dt = new DataTable();
        try
        {
            con();
            string sql = "select * from Subject";
            sqlcmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(_dt);
        }
        catch (Exception)
        {
            throw;
        }
        return _dt;
    }

    public bool InsertBook(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO Books(Title,ISBN,NumberOfPages,Publisher,PublishedDate,Price,SpecialPrice,EditionNumber,Description,FontImage,BackImage,MostSale,Upcoming,New,Code,Status,CreatedBy,CreatedDateTime,LastUpdatedBy,LastUpdatedDateTime,Popular,CategoryId,OldPrice,Count)values(@Title,@ISBN,@PageNumber,@Publisher,@PublishedDate,@Price,@SpecialPrice,@EditionNumber,@Description,@FontImage,@BackImage,@MostSale,@Upcoming,@New,@Code,@Status,@CreatedBy,@CreatedDateTime,@LastUpdatedBy,@LastUpdatedDateTime,@Popular,@CategoryId,@OldPrice,'0')";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Title", insert[0]);
            sqlcmd.Parameters.AddWithValue("@ISBN", insert[1]);
            sqlcmd.Parameters.AddWithValue("@PageNumber", insert[2]);
            sqlcmd.Parameters.AddWithValue("@Publisher", insert[3]);
            sqlcmd.Parameters.AddWithValue("@PublishedDate", insert[4]);
            sqlcmd.Parameters.AddWithValue("@Price", insert[6]);
            sqlcmd.Parameters.AddWithValue("@SpecialPrice", insert[7]);
            sqlcmd.Parameters.AddWithValue("@EditionNumber", insert[5]);
            sqlcmd.Parameters.AddWithValue("@Description", insert[8]);
            sqlcmd.Parameters.AddWithValue("@FontImage", insert[12]);
            sqlcmd.Parameters.AddWithValue("@BackImage", insert[13]);
            sqlcmd.Parameters.AddWithValue("@MostSale", insert[9]);
            sqlcmd.Parameters.AddWithValue("@Upcoming", insert[11]);
            sqlcmd.Parameters.AddWithValue("@New", insert[10]);
            sqlcmd.Parameters.AddWithValue("@Code", insert[19]);
            sqlcmd.Parameters.AddWithValue("@Status", insert[14]);
            sqlcmd.Parameters.AddWithValue("@CreatedBy", insert[15]);
            sqlcmd.Parameters.AddWithValue("@CreatedDateTime", insert[16]);
            sqlcmd.Parameters.AddWithValue("@LastUpdatedBy", insert[17]);
            sqlcmd.Parameters.AddWithValue("@LastUpdatedDateTime", insert[18]);
            sqlcmd.Parameters.AddWithValue("@Popular", insert[20]);
            sqlcmd.Parameters.AddWithValue("@CategoryId", insert[21]);
            sqlcmd.Parameters.AddWithValue("@OldPrice", insert[22]);
            
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception )
        {
            throw;
        }
    }

    public bool UpdateBook(string[] insert, int id)
    {
        try
        {
            con();
            string Save = "Update Books set    Title=@Title,ISBN=@ISBN,NumberOfPages=@PageNumber,Publisher=@Publisher,PublishedDate=@PublishedDate,Price=@Price,SpecialPrice=@SpecialPrice,EditionNumber=@EditionNumber,Description=@Description,FontImage=@FontImage,BackImage=@BackImage,MostSale=@MostSale,Upcoming=@Upcoming,New=@New,LastUpdatedBy=@LastUpdatedBy,LastUpdatedDateTime=@LastUpdatedDateTime,CategoryId=@CategoryId,OldPrice=@OldPrice Where Id='" + id+"'";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Title", insert[0]);
            sqlcmd.Parameters.AddWithValue("@ISBN", insert[1]);
            sqlcmd.Parameters.AddWithValue("@PageNumber", insert[2]);
            sqlcmd.Parameters.AddWithValue("@Publisher", insert[3]);
            sqlcmd.Parameters.AddWithValue("@PublishedDate", insert[4]);
            sqlcmd.Parameters.AddWithValue("@Price", insert[6]);
            sqlcmd.Parameters.AddWithValue("@SpecialPrice", insert[7]);
            sqlcmd.Parameters.AddWithValue("@EditionNumber", insert[5]);
            sqlcmd.Parameters.AddWithValue("@Description", insert[8]);
            sqlcmd.Parameters.AddWithValue("@FontImage", insert[12]);
            sqlcmd.Parameters.AddWithValue("@BackImage", insert[13]);
            sqlcmd.Parameters.AddWithValue("@MostSale", insert[9]);
            sqlcmd.Parameters.AddWithValue("@Upcoming", insert[11]);
            sqlcmd.Parameters.AddWithValue("@New", insert[10]);
            sqlcmd.Parameters.AddWithValue("@LastUpdatedBy", insert[17]);
            sqlcmd.Parameters.AddWithValue("@LastUpdatedDateTime", insert[18]);
            sqlcmd.Parameters.AddWithValue("@CategoryId", insert[21]);
            sqlcmd.Parameters.AddWithValue("@OldPrice", insert[22]);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception )
        {
            throw;
        }
    }


    public bool UpdateBookView(string id)
    {
        try
        {
            con();
            string Save = "Update Books set Count=Count+1  Where Id='" + id + "'";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool InsertBookCategory(string CategoryId, string CategoryName, int BookId)
    {
        try
        {
            con();
            string Save = "INSERT INTO tblBookCategories(CategoryId,CategoryName,BookId)values(@CategoryId,@CategoryName,@BookId)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@CategoryId", CategoryId);
            sqlcmd.Parameters.AddWithValue("@CategoryName", CategoryName);
            sqlcmd.Parameters.AddWithValue("@BookId", BookId);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception )
        {
            throw;
        }
    }
    public bool InsertBookWriter(string AuthorId, string AuthorName, int BookId)
    {
        try
        {
            con();
            string Save = "INSERT INTO tblBookAuthors(AuthorId,AuthorName,BookId)values(@AuthorId,@AuthorName,@BookId)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@AuthorId", AuthorId);
            sqlcmd.Parameters.AddWithValue("@AuthorName", AuthorName);
            sqlcmd.Parameters.AddWithValue("@BookId", BookId);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception )
        {
            throw;
        }
    }

    public bool UpdateBook(string[] insert, long rowid)
    {
        try
        {
            con();
            string Save = @"Update Books set Title=@Title,Subject=@Subject,Writer=@Writer,ISBN=@ISBN,PageNumber=@PageNumber,Publisher=@Publisher,PublishedDate=@PublishedDate,Price=@Price,SpecialPrice=@SpecialPrice,EditionNumber=@EditionNumber,Description=@Description,FontImage=@FontImage,MostSale=@MostSale,Upcoming=@Upcoming,New=@New,Code=@Code,Status=@Status Where Id='"+rowid+"'";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Title", insert[0]);
            sqlcmd.Parameters.AddWithValue("@Subject", insert[1]);
            sqlcmd.Parameters.AddWithValue("@Writer", insert[2]);
            sqlcmd.Parameters.AddWithValue("@ISBN", insert[3]);
            sqlcmd.Parameters.AddWithValue("@PageNumber", insert[4]);
            sqlcmd.Parameters.AddWithValue("@Publisher", insert[5]);
            sqlcmd.Parameters.AddWithValue("@PublishedDate", insert[6]);
            sqlcmd.Parameters.AddWithValue("@Price", insert[7]);
            sqlcmd.Parameters.AddWithValue("@SpecialPrice", insert[8]);
            sqlcmd.Parameters.AddWithValue("@EditionNumber", insert[9]);
            sqlcmd.Parameters.AddWithValue("@Description", insert[10]);
            sqlcmd.Parameters.AddWithValue("@FontImage", insert[11]);
            //sqlcmd.Parameters.AddWithValue("@BackImage", insert[12]);
            sqlcmd.Parameters.AddWithValue("@MostSale", insert[13]);
            sqlcmd.Parameters.AddWithValue("@Upcoming", insert[14]);
            sqlcmd.Parameters.AddWithValue("@New", insert[15]);
            sqlcmd.Parameters.AddWithValue("@Code", insert[16]);
            sqlcmd.Parameters.AddWithValue("@Status", insert[17]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception )
        {
            throw;
        }
    }

    public DataTable SelectMaxBID()
    {
        con();
        string id = @"select ISNULL(Max(Id),0) as Id from Books";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }



    public bool insertProductsizequantity(string PID, string SizeID, int Quantity)
    {
        try
        {
            con();
            string Save = "INSERT INTO tblProductSizeQuantity(PID,SizeID,Quantity)values(@PID,@SizeID,@Quantity)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@PID", PID);
            sqlcmd.Parameters.AddWithValue("@SizeID", SizeID);
            sqlcmd.Parameters.AddWithValue("@Quantity", Quantity);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool UpdateProductsizequantity(string PID, string SizeID, int Quantity)
    {
        try
        {
            con();
            string Save = "UPDATE  tblProductSizeQuantity set SizeID=@SizeID , Quantity=@Quantity where PID=@PID";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@PID", PID);
            sqlcmd.Parameters.AddWithValue("@SizeID", SizeID);
            sqlcmd.Parameters.AddWithValue("@Quantity", Quantity);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable GetSubcatFoodandcipboard()
    {
        con();
        string id = @"Select *  from Menu where ParentId=2";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetCategoryList()
    {
        con();
        string id = @"Select *  from Menu where MenuLevel=0";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetCategoryList(string pId)
    {
        con();
        string id = @"Select *  from Menu where MenuLevel!=0 and ParentId='" + pId+"'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetSubjectMenu()
    {
        con();
        string id = @"Select * from Subject Where Status='Active' Order by Id asc";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetCategoryMenu()
    {
        con();
        string id = @"Select * from tblCategories Where Status='Active' Order by Id asc";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetSubCategoryMenu()
    {
        con();
        string id = @"select Subject.Id, Subject.Name from Subject join tblBookCategories on Subject.Id=tblBookCategories.CategoryId Group By Subject.Id, Subject.Name";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetSubcatFrozenfood()
    {
        con();
        string id = @"Select *  from Menu where ParentId=9";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetSubcatPackaginganddisposal()
    {
        con();
        string id = @"Select *  from Menu where ParentId=11";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetSubcatCookingoilandfat()
    {
        con();
        string id = @"Select *  from Menu where ParentId=10";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetSubcatPackaginganddisposable()
    {
        con();
        string id = @"Select *  from Menu where ParentId=11";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetSubcatHygieneandcleaning()
    {
        con();
        string id = @"Select *  from Menu where ParentId=12";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable FooterSubcatFrozenfood()
    {
        con();
        string id = @"Select top 5 *  from Menu where ParentId=9";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetSubcatPackingDisposal()
    {
        con();
        string id = @"Select *  from Menu where ParentId=11";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetFrozenDeals()
    {
        con();
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='9' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetSuperDeals()
    {
        con();
        string sql = @"Select top 5 * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and B.Occation!='' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetAllSuperDeals()
    {
        con();
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and B.Occation!='' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetAllPopulars()
    {
        con();
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and B.Occation='Popular' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetPackaginganddisposalDeals()
    {
        con();
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='11' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetFoodAndCupbordBestsellers()
    {
        con();
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='2' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetFoodAndCupbordDeal()
    {
        con();
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='2' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetFreshBestSellers()
    {
        con();
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='3' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetFreshDeal()
    {
        con();
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='3' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetDrinkAndBraverageBestsellers()
    {
        con();
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='4' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetDrinkAndBraverageDeals()
    {
        con();
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='4' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetDairyandCheeseDeals()
    {
        con();
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='8' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetDairyandCheeseBestSellers()
    {
        con();
        //string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='8' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }



    public DataTable GetFoodcupboardNewArrival()
    {
        con();
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='2' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetBookById(int id)
    {
        con();
        string sql = @"Select Books.*,tblCategories.Name as Category, tblCategories.Id as CId from Books join tblCategories ON Books.CategoryId=tblCategories.Id Where Books.Id='" + id + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public bool DeleteBookFromWishlist(string code)
    {
        con();
        string sql = @"Delete from tblWishlist Where Code='" + code + "'";
        sqlcmd = new SqlCommand(sql, cn);
        sqlcmd.ExecuteNonQuery();        
        return true;
    }

    public DataTable GetBookById1(int id)
    {
        con();
        string sql = @"Select * from Books Where Id='" + id + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public bool UpdateBookStatus(string Status, string LastUpdatedBy, string LastUpdatedDateTime,  int id)
    {
        con();
        string sql = @"Update  Books set Status=@Status, LastUpdatedBy=@LastUpdatedBy, LastUpdatedDateTime=@LastUpdatedDateTime Where Id='" + id + "'";
        sqlcmd = new SqlCommand(sql, cn);
        sqlcmd.Parameters.AddWithValue("@Status", Status);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedBy", LastUpdatedBy);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedDateTime", LastUpdatedDateTime);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public bool DeleteBookById(int id)
    {
        con();
        string sql = @"Delete from Books Where Id='" + id + "'";
        sqlcmd = new SqlCommand(sql, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public bool DeleteBookCategory(int id)
    {
        con();
        string sql = @"Delete from tblBookCategories Where BookId='" + id + "'";
        sqlcmd = new SqlCommand(sql, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public bool DeleteBookAuther(int id)
    {
        con();
        string sql = @"Delete from tblBookAuthors Where Id='" + id + "'";
        sqlcmd = new SqlCommand(sql, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public DataTable GetBookBySubject(string sub)
    {
        con();
        string sql = @"Select * from Books join tblBookCategories ON Books.Id=tblBookCategories.BookId Where tblBookCategories.CategoryId='" + sub+ "' And Books.Status='Active' Order by Books.Id desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetBookByCategory(string sub)
    {
        con();
        string sql = @"Select * from Books join tblCategories ON Books.CategoryId=tblCategories.Id Where tblCategories.id='"+sub+"' And Books.Status='Active' Order by Books.Id desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetBookBySubCategory(string sub)
    {
        con();
        string sql = @"Select * from Books join tblBookCategories on Books.Id=tblBookCategories.BookId join Subject on Subject.Id=tblBookCategories.CategoryId Where Subject.Id='"+sub+"' And Books.Status='Active' Order by Books.Id desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public bool InsertPolicy(string[] insert)
    {
        con();
        string sql = @"Insert Into tblPolicy(DeliveryCharge,ShippingCharge,Vat,Status,CreatedBy,CreatedDateTime,LastUpdatedBy,LastUpdatedDateTime) Values (@DeliveryCharge,@ShippingCharge,@Vat,@Status,@CreatedBy,@CreatedDateTime,@LastUpdatedBy,@LastUpdatedDateTime)";
        sqlcmd = new SqlCommand(sql, cn);
        sqlcmd.Parameters.AddWithValue("@DeliveryCharge", insert[0]);
        sqlcmd.Parameters.AddWithValue("@ShippingCharge", insert[1]);
        sqlcmd.Parameters.AddWithValue("@Vat", insert[2]);
        sqlcmd.Parameters.AddWithValue("@Status", insert[3]);
        sqlcmd.Parameters.AddWithValue("@CreatedBy", insert[4]);
        sqlcmd.Parameters.AddWithValue("@CreatedDateTime", insert[5]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedBy", insert[6]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedDateTime", insert[7]);
        sqlcmd.ExecuteNonQuery();
        return true;
    }

    public bool UpdatePolicy(string[] insert, int policyId)
    {
        con();
        string sql = @"Update tblPolicy set DeliveryCharge=@DeliveryCharge,ShippingCharge=@ShippingCharge,Vat=@Vat,LastUpdatedBy=@LastUpdatedBy,LastUpdatedDateTime=@LastUpdatedDateTime Where Id='"+policyId+"'";
        sqlcmd = new SqlCommand(sql, cn);
        sqlcmd.Parameters.AddWithValue("@DeliveryCharge", insert[0]);
        sqlcmd.Parameters.AddWithValue("@ShippingCharge", insert[1]);
        sqlcmd.Parameters.AddWithValue("@Vat", insert[2]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedBy", insert[6]);
        sqlcmd.Parameters.AddWithValue("@LastUpdatedDateTime", insert[7]);
        sqlcmd.ExecuteNonQuery();
        return true;
    }

    public DataTable GetProductByCategoryname(string CatID)
    {
        con();
        //string sql = @"Select * from tblProducts B  cross apply(select top 1 * from tblProductImages C where C.PID = B.PID and B.PCategoryID='"+ CatID + "' order by C.PID desc ) C";
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='" + CatID + "' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetProductByCategorynameandSubcategory(string CatID, string Subcat)
    {
        con();
        //string sql = @"Select * from tblProducts B  cross apply(select top 1 * from tblProductImages C where C.PID = B.PID and B.PCategoryID='"+ CatID + "' order by C.PID desc ) C";
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='" + CatID + "' ) F cross apply(select top 1 * from ProductSubCategory G where G.PID=B.PID and G.SubCategoryID='" + Subcat + "' ) G  cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable foodcupboardbannerimage()
    {
        con();
        string sql = @"Select * from Menu B  cross apply(select top 1 * from CategoryImages C where C.CatID = B.Id and B.Id='2' order by C.CatIMGID asc ) C ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable foodcupboardthumbimage()
    {
        con();
        string sql = @"Select * from Menu B  cross apply(select top 2 * from CategoryImages C where C.CatID = B.Id and B.Id='2' order by C.CatIMGID desc ) C";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetFreshNewArrival()
    {
        con();
        //string sql = @"Select * from tblProducts B  cross apply(select top 1 * from tblProductImages C where C.PID = B.PID and B.PCategoryID='3' order by C.PID desc ) C";
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='3' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable Freshbannerimage()
    {
        con();
        string sql = @"Select * from Menu B  cross apply(select top 1 * from CategoryImages C where C.CatID = B.Id and B.Id='3' order by C.CatIMGID asc ) C";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable freshthumbimage()
    {
        con();
        string sql = @"Select * from Menu B  cross apply(select top 2 * from CategoryImages C where C.CatID = B.Id and B.Id='3' order by C.CatIMGID desc ) C";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetDrinkandBraverazeNewArrival()
    {
        con();
        // string sql = @"Select * from tblProducts B  cross apply(select top 1 * from tblProductImages C where C.PID = B.PID and B.PCategoryID='4' order by C.PID desc ) C";
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='4' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable DrinkandBreveragebannerimage()
    {
        con();
        string sql = @"Select * from Menu B  cross apply(select top 1 * from CategoryImages C where C.CatID = B.Id and B.Id='4' order by C.CatIMGID asc ) C";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable Drinkthumbimage()
    {
        con();
        string sql = @"Select * from Menu B  cross apply(select top 2 * from CategoryImages C where C.CatID = B.Id and B.Id='4' order by C.CatIMGID desc ) C";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetDairyandCheeseNewArrival()
    {
        con();
        //string sql = @"Select * from tblProducts B  cross apply(select top 1 * from tblProductImages C where C.PID = B.PID and B.PCategoryID='8' order by C.PID desc ) C";
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='8' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    
    

    public DataTable GetFrozenNewArrival()
    {
        con();
        // string sql = @"Select * from tblProducts B  cross apply(select top 1 * from tblProductImages C where C.PID = B.PID and B.PCategoryID='9' order by C.PID desc ) C";
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='9' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetPackaginganddisposalNewArrival()
    {
        con();
        // string sql = @"Select * from tblProducts B  cross apply(select top 1 * from tblProductImages C where C.PID = B.PID and B.PCategoryID='9' order by C.PID desc ) C";
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='11' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable Frozenbannerimage()
    {
        con();
        string sql = @"Select * from Menu B  cross apply(select top 1 * from CategoryImages C where C.CatID = B.Id and B.Id='9' order by C.CatIMGID asc ) C ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable Frozenthumbimage()
    {
        con();
        string sql = @"Select * from Menu B  cross apply(select top 2 * from CategoryImages C where C.CatID = B.Id and B.Id='9' order by C.CatIMGID desc ) C";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetProductByPIDsingleimage(string PID)
    {
        con();
        string sql = @"select top 1 * from tblProductImages where tblProductImages.PID ='" + PID + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetBookimage(string Id)
    {
        con();
        string sql = @"select * from Books where Id ='" + Id + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }


    public DataTable GetProductByPIDthreeimage(string PID)
    {
        con();
        string sql = @"select  * from tblProductImages where tblProductImages.PID ='" + PID + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetBrandimage(string PID)
    {
        con();
        string sql = @"select  * from tblBrandImages inner join ProductBrand on ProductBrand.BrandID=tblBrandImages.BID where ProductBrand.PID ='" + PID + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetBookInfoByID(string PID)
    {
        con();
        string sql = @"select  * from Books where Id ='" + PID + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    //public DataTable Getsubcatidbyname(string SubcatText)
    //{
    //    con();
    //    string sql = @"select  * from Menu where MenuText ='" + SubcatText + "'";
    //    SqlDataAdapter da = new SqlDataAdapter(sql, cn);
    //    DataTable dt = new DataTable();
    //    da.Fill(dt);
    //    return dt;
    //}

    public DataTable getWritersAllBooks(string code)
    {

        con();
        string sql = @"Select * from Books join tblBookAuthors On Books.Id=tblBookAuthors.BookId join Writer On Writer.Id=tblBookAuthors.AuthorId where Writer.Code='" + code + "' and Writer.Status='Active'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getSubjectAllBooks(string subject)
    {

        con();
        string sql = @"Select * from Books join tblBookCategories On Books.Id=tblBookCategories.BookId join Subject On Subject.Id=tblBookCategories.CategoryId where tblBookCategories.CategoryName='" + subject + "' and Subject.Status='Active'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getCategoryAllBooks(string subject)
    {

        con();
        string sql = @"Select * from Books join tblCategories On Books.CategoryId=tblCategories.Id where tblCategories.Name='"+subject+"' and Books.Status='Active'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetBooksBySubcategory(string subC)
    {

        con();
        string sql = @"select * from Books join tblBookCategories on Books.Id=tblBookCategories.BookId Where tblBookCategories.CategoryName='" + subC + "' and Books.Status='Active'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable getPopularBooks()
    {

        con();
        string sql = @"Select * from Books where Popular='Yes' and Status='Active'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getPopularAllBooks3()
    {
        con();
        string sql = @"Select * from Books join tblCategories On Books.CategoryId=tblCategories.Id where Books.Popular='Yes' and Books.Status='Active' Order By Books.Id Desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetPopularAllBooks4()
    {

        con();
        string sql = @"Select * from Books join tblCategories On Books.CategoryId=tblCategories.Id where Books.Popular='Yes' and Books.Status='Active' Order By Books.Price Desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetPopularAllBooks5()
    {
        con();
        string sql = @"Select * from Books join tblCategories On Books.CategoryId=tblCategories.Id where Books.Popular='Yes' and Books.Status='Active' Order By Books.Price asc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetpopularAllBooks6()
    {
        con();
        string sql = @"Select * from Books join tblCategories On Books.CategoryId=tblCategories.Id where Books.Popular='Yes' and Books.Status='Active' Order By Books.Title desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetPopularAllBooks7(decimal max, decimal min)
    {
        con();
        string sql = @"Select * from Books join tblCategories On Books.CategoryId=tblCategories.Id where Books.Popular='Yes' and Books.Status='Active' and Books.Price between " + min + " and " + max + " Order By Books.Price Asc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getSubjectAllBooks3(string subject)
    {
        con();
        string sql = @"Select * from Books join tblCategories On Books.CategoryId=tblCategories.Id where tblCategories.Name='" + subject + "' and Books.Status='Active' Order By Books.Id Desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getPublicationAllBooks3(string subject)
    {
        con();
        string sql = @"Select * from Books where Publisher='" + subject + "' and Status='Active' Order By Books.Id Desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getSubCateAllBooks3(string subject)
    {
        con();
        string sql = @"Select * from Books join tblBookCategories On Books.Id=tblBookCategories.BookId join Subject On Subject.Id=tblBookCategories.CategoryId where tblBookCategories.CategoryName='" + subject + "' and Subject.Status='Active' Order By Books.Id Desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getSubjectAllBooks4(string subject)
    {

        con();
        string sql = @"Select * from Books join tblCategories On Books.CategoryId=tblCategories.Id where tblCategories.Name='" + subject + "' and Books.Status='Active' Order By Books.Price Desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getWriterAllBooks4(string writer)
    {
        con();
        string sql = @"Select * from Books join tblBookAuthors On Books.Id=tblBookAuthors.BookId join Writer On Writer.Id=tblBookAuthors.AuthorId where tblBookAuthors.AuthorName='" + writer + "' and Writer.Status='Active' Order By Books.Price Desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetAllBooks4()
    {
        con();
        string sql = @"Select * from Books Where Status='Active' Order By Price Desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetPublicationAllBooks4(string subject)
    {
        con();
        string sql = @"Select * from Books where Publisher='" + subject + "' and Status='Active' Order By Books.Price Desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetSubCatAllBooks4(string subject)
    {
        con();
        string sql = @"Select * from Books join tblBookCategories On Books.Id=tblBookCategories.BookId join Subject On Subject.Id=tblBookCategories.CategoryId where tblBookCategories.CategoryName='" + subject + "' and Subject.Status='Active' Order By Books.Price Desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getSubjectAllBooks5(string subject)
    {
        con();
        string sql = @"Select * from Books join tblCategories On Books.CategoryId=tblCategories.Id where tblCategories.Name='" + subject + "' and Books.Status='Active' Order By Books.Price asc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getWriterAllBooks5(string writer)
    {
        con();
        string sql = @"Select * from Books join tblBookAuthors On Books.Id=tblBookAuthors.BookId join Writer On Writer.Id=tblBookAuthors.AuthorId where tblBookAuthors.AuthorName='" + writer + "' and Writer.Status='Active' Order By Books.Price asc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getAllBooks5()
    {
        con();
        string sql = @"Select * from Books Where Status='Active' Order By Price asc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetPublicationAllBooks5(string subject)
    {
        con();
        string sql = @"Select * from Books where Publisher='" + subject + "' and Status='Active' Order By Books.Price asc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetSubCatAllBooks5(string subject)
    {
        con();
        string sql = @"Select * from Books join tblBookCategories On Books.Id=tblBookCategories.BookId join Subject On Subject.Id=tblBookCategories.CategoryId where tblBookCategories.CategoryName='" + subject + "' and Subject.Status='Active' Order By Books.Price asc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getSubjectAllBooks6(string subject)
    {
        con();
        string sql = @"Select * from Books join tblCategories On Books.CategoryId=tblCategories.Id where tblCategories.Name='" + subject + "' and Books.Status='Active' Order By Books.Title desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getWriterAllBooks6(string writer)
    {
        con();
        string sql = @"Select * from Books join tblBookAuthors On Books.Id=tblBookAuthors.BookId join Writer On Writer.Id=tblBookAuthors.AuthorId where tblBookAuthors.AuthorName='" + writer + "' and Writer.Status='Active' Order By Books.Title desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getAllBooks6()
    {
        con();
        string sql = @"Select * from Books Where Status='Active' Order By Title desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getPublicationAllBooks6(string subject)
    {
        con();
        string sql = @"Select * from Books where Publisher='" + subject + "' and Status='Active' Order By Books.Title desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetSubCatAllBooks6(string subject)
    {
        con();
        string sql = @"Select * from Books join tblCategories On Books.CategoryId=tblCategories.Id where tblCategories.Name='" + subject + "' and Books.Status='Active' Order By Books.Title desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetCategoryAllBooks7(string subject, decimal max, decimal min)
    {
        con();
        string sql = @"Select * from Books join tblCategories On Books.CategoryId=tblCategories.Id where tblCategories.Name='" + subject + "' and Books.Status='Active' and Books.Price between " + min + " and " + max + " Order By Books.Price Asc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetCategoryAllBooks8(string writer, decimal min, decimal max)
    {
        con();
        string sql = @"Select * from Books join tblBookAuthors On Books.Id=tblBookAuthors.BookId join Writer On Writer.Id=tblBookAuthors.AuthorId where Writer.Code='" + writer + "' and Writer.Status='Active' and Books.Status='Active' and Books.Price between " + min + " and " + max + " Order By Books.Price Asc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetAllBooks8(decimal max, decimal min)
    {
        con();
        string sql = @"Select * from Books Where Status='Active' and Price between " + min + " and " + max + " Order By Price Asc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetSubcategoryAllBooks7(string subject, decimal max, decimal min)
    {
        con();
        string sql = @"Select * from Books join tblBookCategories On Books.Id=tblBookCategories.BookId join Subject On Subject.Id=tblBookCategories.CategoryId where Subject.Name='" + subject + "' and Subject.Status='Active' and Books.Price between " + min + " and " + max + " Order By Books.Price Asc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetPublicherAllBooks7(string subject, decimal max, decimal min)
    {
        con();
        string sql = @"Select * from Books join tblCategories On Books.CategoryId=tblCategories.Id where Books.Publisher='" + subject + "' and Books.Status='Active' and Books.Price between " + min + " and " + max + " Order By Books.Price Asc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable getAllBooks(int bookId)
    {
        con();
        string sql = @"Select * from Books where Id='" + bookId + "' and Status='Active'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetallBooks()
    {
        con();
        string sql = @"Select * from Books order by Id desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetallActiveBooks()
    {
        con();
        string sql = @"Select * from Books Where Status='Active' order by Id desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable SearchBooksByName(string name)
    {
        string a = "%";
        con();
        string sql = @"Select * from Books Where Title like '"+name+a+"'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public bool insertBrand(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO BrandName(BrandName)values(@BrandName)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@BrandName", insert[0]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable SelectBrandMaxID()
    {
        con();
        string id = @"select ISNULL(Max(ID),0) as BID from BrandName";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getBrandid(long ID)
    {
        con();
        string id = @"select * from BrandName where ID='" + ID + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetBrandNo()
    {
        con();
        string id = @"Select ISNULL(Max(ID),0)+1 from BrandName";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetSizeNo()
    {
        con();
        string id = @"Select ISNULL(Max(ID),0)+1 from ProductSize";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetTitle()
    {
        con();
        string id = @"Select ISNULL(Max(ID),0)+1 from TitleSet";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool UpdateBrandname(string BrandId, string BrandName)
    {
        try
        {
            con();
            string update = "Update BrandName set BrandName='" + BrandName + "' where ID='" + BrandId + "'";

            sqlcmd = new SqlCommand(update, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable getBrand()
    {
        string id = "select * from BrandName inner join tblBrandImages on tblBrandImages.BID=BrandName.ID";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool BrandDeletebyid(string ID)
    {
        try
        {
            con();
            string Delete = "Delete from BrandName where ID=@ID";
            sqlcmd = new SqlCommand(Delete, cn);
            sqlcmd.Parameters.AddWithValue("@ID", ID);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool EditBrand(string[] insert)
    {
        try
        {
            con();
            string Save = "Update BrandName set BrandName=@BrandName where ID=@ID ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", insert[0]);
            sqlcmd.Parameters.AddWithValue("@BrandName", insert[1]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool updatephoto(string BID, string Pname, string Extention, string lblPIMGID)
    {
        try
        {
            con();
            string Save = "update tblBrandImages set BID='" + BID + "', Name = '" + Pname.ToString().Trim() + "',Extention='" + Extention + "' where BIMGID='" + lblPIMGID + "'";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable GetSubcatMenu(string pId)
    {
        con();
        string id = @"Select * from Menu where ParentId='" + pId + "' Order by Id asc";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public bool DeleteBrand(string ProductID)
    {
        con();
        string insertreginfo = "Delete from BrandName where ID='" + ProductID + "' ";
        sqlcmd = new SqlCommand(insertreginfo, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }

    public bool deletefromBrandImage(string ProductID)
    {
        con();
        string insertreginfo = "Delete from tblBrandImages where BID='" + ProductID + "' ";
        sqlcmd = new SqlCommand(insertreginfo, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }

    public DataTable GetWriter()
    {
        con();
        string sql = @"Select * from Books order by Id DESC  ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetWriters()
    {
        con();
        string sql = @"Select * from Writer Where Status='Active'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetWriters(string code)
    {
        con();
        string sql = @"Select * from Writer where Code='" + code + "' And Status='Active'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetSubject()
    {
        con();
        string sql = @"Select * from Subject";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetSubCategoryBooks()
    {
        con();
        string sql = @"Select * from Subject Order by CategoryId asc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetBooks()
    {
        con();
        string sql = @"Select * from Books Where MostSale='Yes' Order by Id DESC";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetUpcomingBooks()
    {
        con();
        string sql = @"Select * from Books Where Upcoming='Yes' Order by Id DESC";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetNewBooks()
    {
        con();
        string sql = @"Select * from Books Where New='Yes' Order by Id DESC";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetPopularBooks()
    {
        con();
        string sql = @"Select Top 5* from Books Where Popular='Yes' Order by Id DESC";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public bool EditProduct(string[] insert)
    {
        try
        {
            con();
            string Save = "Update tblProducts set PName=@PName ,PPrice=@PPrice,PSelPrice=@PSelPrice,Unit=@Unit,CollectionPrice=@CollectionPrice,Occation=@Occation,OccationDesc=@OccationDesc,OccationRemain=@OccationRemain where PID=@PID ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@PID", insert[0]);
            sqlcmd.Parameters.AddWithValue("@PName", insert[1]);
            sqlcmd.Parameters.AddWithValue("@PPrice", insert[2]);
            sqlcmd.Parameters.AddWithValue("@PSelPrice", insert[3]);
            //sqlcmd.Parameters.AddWithValue("@PDescription", insert[4]);
            //sqlcmd.Parameters.AddWithValue("@PProductDetails", insert[5]);
            sqlcmd.Parameters.AddWithValue("@Unit", insert[8]);
            sqlcmd.Parameters.AddWithValue("@CollectionPrice", insert[9]);

            sqlcmd.Parameters.AddWithValue("@Occation", insert[10]);
            sqlcmd.Parameters.AddWithValue("@OccationDesc", insert[11]);
            sqlcmd.Parameters.AddWithValue("@OccationRemain", insert[12]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool DeleteBook(string id)
    {
        con();
        string insertreginfo = "Delete from Books where Id='" + id + "' ";
        sqlcmd = new SqlCommand(insertreginfo, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }
    public DataTable SelectBook(string id)
    {
        con();
        string sql = "Select * from Books where Id='" + id + "' ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public bool UpdateBookStatus(string id, string status)
    {
        con();
        string sql = "Update tblOrder2 set Status='" + status+"' where Id='" + id + "' ";
        sqlcmd = new SqlCommand(sql, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }

    public bool deletefromPrdImage(string ProductID)
    {
        con();
        string insertreginfo = "Delete from tblProductImages where PID='" + ProductID + "' ";
        sqlcmd = new SqlCommand(insertreginfo, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }

    public DataTable SearchBookbyname(string name)
    {
        con();
        string sql = @"Select * from Books where Title='" + name + "' ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable checkOccation()
    {
        con();
        string sql = @"Select top 1  * from tblProducts inner join ProductCategory on ProductCategory.PID =tblProducts.PID inner join   Menu on Menu.Id=ProductCategory.CategoryID where tblProducts.Occation!=''  ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetImageNo()
    {
        con();
        string id = @"Select ISNULL(Max(ID),0)+1 from SliderImage";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool insertsliderimage(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO SliderImage(ImageName,ImageDescTop,ImageDescbottom)values(@ImageName,@ImageDescTop,@ImageDescbottom)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ImageName", insert[0]);
            sqlcmd.Parameters.AddWithValue("@ImageDescTop", insert[1]);
            sqlcmd.Parameters.AddWithValue("@ImageDescbottom", insert[2]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable SelectSliderimageMaxID()
    {
        con();
        string id = @"select ISNULL(Max(ID),0) as ID from SliderImage";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool UpdateImage(string Extention, string ID, string txtimagename)
    {
        try
        {
            con();
            string Save = "Update SliderImage set ImageName=@ImageName ,Extention=@Extention where ID=@ID ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", ID);
            sqlcmd.Parameters.AddWithValue("@ImageName", txtimagename.Trim() + "01");
            sqlcmd.Parameters.AddWithValue("@Extention", Extention);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }



    public DataTable getproductbysubcat()
    {
        con();
        string sql = @"Select * from tblProducts B  cross apply(select top 1 * from tblProductImages C where C.PID = B.PID and B.Occation !='' order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable selectinforAdmin(string[] loginfo)
    {
        con();
        string id = @"select * from AdminRegistration   where Name='" + loginfo[0] + "' and Password='" + loginfo[1] + "'  ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetallAdminUser()
    {
        DataTable _dt = new DataTable();
        try
        {
            con();
            string sql = "select * from AdminRegistration";
            sqlcmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(_dt);
        }
        catch (Exception)
        {
            throw;
        }
        return _dt;
    }

    public bool InsertAdminUser(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO AdminRegistration(Name,Password)values(@Name,@Password)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Name", insert[0]);
            sqlcmd.Parameters.AddWithValue("@Password", insert[1]);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool DeleteAdminUser(string ID)
    {
        con();
        string insertreginfo = "Delete from AdminRegistration where ID='" + ID + "' ";
        sqlcmd = new SqlCommand(insertreginfo, cn);
        sqlcmd.ExecuteNonQuery();
        return true;
    }

    public bool EditAdminUser(string[] insert)
    {
        try
        {
            con();
            string Save = "Update AdminRegistration set Name=@Name ,Password=@Password where ID=@ID ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ID", insert[0]);
            sqlcmd.Parameters.AddWithValue("@Name", insert[1]);
            sqlcmd.Parameters.AddWithValue("@Password", insert[2]);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool InsertSliderDetails(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO SliderDetails(Title,Description,Position,Subcategory)values(@Title,@Description,@Position,@Subcategory)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Title", insert[1]);
            sqlcmd.Parameters.AddWithValue("@Description", insert[2]);
            sqlcmd.Parameters.AddWithValue("@Position", insert[0]);
            sqlcmd.Parameters.AddWithValue("@Subcategory", insert[3]);


            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool updateSliderDetails(string[] insert)
    {
        try
        {
            con();
            string Save = "Update SliderDetails set Title=@Title ,Description=@Description, Subcategory=@Subcategory where Position=@Position ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Title", insert[1]);
            sqlcmd.Parameters.AddWithValue("@Description", insert[2]);
            sqlcmd.Parameters.AddWithValue("@Position", insert[0]);
            sqlcmd.Parameters.AddWithValue("@Subcategory", insert[3]);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable GetCustomerInfo()
    {
        con();
        string id = @"select * from CustomerRegistration Order By Id DESC";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable SearchCustomerInfo(string info)
    {
        con();
        string id = @"select * from CustomerRegistration Where FirstName='"+info+ "' or Email='"+info+ "' or Phone='"+info+"'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetCustomerInfoForUpdate()
    {
        con();
        string id = @"select * from CustomerRegistrationUpdate";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetCustomerOrder()
    {
        con();
        string id = @"select * from tblOrder2 Where Status is null Order By Date DESC";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable DeleteCustomerOrder(string id2)
    {
        con();
        string id = @"Delete from tblOrder2 where Id='"+id2+"'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getSizeList()
    {
        con();
        string id = @"select * from ProductSize";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable checkposition(string[] insert)
    {
        con();
        string id = @"select * from SliderDetails where Position='" + insert[0] + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public void DeleteCustomerInfo(string ID)
    {
        try
        {
            con();
            string Delete = "Delete from CustomerRegistration where ID=@ID ";
            sqlcmd = new SqlCommand(Delete, cn);
            sqlcmd.Parameters.AddWithValue("@ID", ID);
            sqlcmd.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable getTitleSetList()
    {
        con();
        string id = @"select * from TitleSet";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getFirstSliderdetails()
    {
        con();
        string id = @"select * from SliderDetails where Position='1'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable getSecondSliderdetails()
    {
        con();
        string id = @"select * from SliderDetails where Position='2'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getThirdSliderdetails()
    {
        con();
        string id = @"select * from SliderDetails where Position='3'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getFourthSliderdetails()
    {
        con();
        string id = @"select * from SliderDetails where Position='4'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getFifthSliderdetails()
    {
        con();
        string id = @"select * from SliderDetails where Position='5'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetRelatedProduct(string CatID)
    {
        con();
        string sql = @"Select * from tblProducts B cross apply(select top 1 * from ProductCategory F where F.PID=B.PID and F.CategoryID='" + CatID + "' ) F cross apply(select top 1 * from tblProductImages C where C.PID = B.PID  order by C.PID desc ) C order by B.PID desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetRelatedBooks(string subject)
    {
        con();
        string sql = @"Select * from Books Where CategoryId='" + subject + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetRelatedSubCategory(string bId)
    {
        con();
        string sql = @"Select * from tblBookCategories Where BookId='" + bId + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetOnSaleBooks1()
    {
        con();
        string sql = @"Select top 3* from Books Where SpecialPrice!=0 Order by Id desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetOnSaleBooks2()
    {
        con();
        string sql = @"Select top 3* from Books Where SpecialPrice!=0 Order by Id asc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetMostSaleBooks1()
    {
        con();
        string sql = @"Select top 3* from Books Where MostSale='Yes' Order by Id desc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetMostSaleBooks2()
    {
        con();
        string sql = @"Select top 3* from Books Where MostSale='Yes' Order by Id asc";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable CategoryID(string pID)
    {
        con();
        string sql = @"Select * from ProductCategory inner join ProductSubCategory on ProductSubCategory.PID=ProductCategory.PID where ProductCategory.PID='" + pID + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable RelatedBookID(string pID)
    {
        con();
        string sql = @"Select * from Books where Id='" + pID + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable RelatedBookPublication(string pub)
    {
        con();
        string sql = @"Select * from Books where Publisher='" + pub + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable RelatedWriterBookID(string pID)
    {
        con();
        string sql = @"Select * from tblBookAuthors  where BookId='" + pID + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetRelatedWriterBooks(string wId)
    {
        con();
        string sql = @"select * from Books join tblBookAuthors on Books.Id=tblBookAuthors.BookId Where tblBookAuthors.authorId='" + wId + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public bool InsertComment(string[] insert)
    {
        try
        {
            con();
            string Save = "INSERT INTO Comments(Name,Email,Website,Comments,PId,LevelNo,Date)values(@name,@email,@website,@comments,@pId,@levelNo,@date)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@name", insert[0]);
            sqlcmd.Parameters.AddWithValue("@email", insert[1]);
            sqlcmd.Parameters.AddWithValue("@website", insert[2]);
            sqlcmd.Parameters.AddWithValue("@comments", insert[3]);
            sqlcmd.Parameters.AddWithValue("@pId", insert[4]);
            sqlcmd.Parameters.AddWithValue("@levelNo", "User");
            sqlcmd.Parameters.AddWithValue("@date", DateTime.Now);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool InsertReplyComment(string[] insert, string MainCommentID)
    {
        try
        {
            con();
            string Save = "INSERT INTO Comments(Name,Email,Comments,PId,LevelNo,Date)values(@Name,@Email,@Comments,@PId,@LevelNo,@Date)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Name", insert[0]);
            sqlcmd.Parameters.AddWithValue("@Email", insert[1]);
            sqlcmd.Parameters.AddWithValue("@Comments", insert[2]);
            sqlcmd.Parameters.AddWithValue("@PId", insert[3]);
            sqlcmd.Parameters.AddWithValue("@LevelNo", MainCommentID);
            sqlcmd.Parameters.AddWithValue("@Date", DateTime.Now);


            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool deleteCommand(int id)
    {
        try
        {
            con();
            string Save = "Delete from Comments Where Id='"+id+"'";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable GetMenuComment(string bId)
    {
        con();
        string id = @"Select top 7 *  from Comments where PId='" + bId+"'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetBlogerComment(string bId)
    {
        con();
        string id = @"Select top 7 *  from Comments where PId='" + bId + "' AND LevelNo='Bolger' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetReplyComment(string Maincommentid)
    {
        con();
        string id = @"Select *  from UserComments where LevelNo='" + Maincommentid + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool UpdateTblproducts(string[] insert,string PID)
    {
        try
        {
            con();
            string Save = "Update tblProducts set ProductCode=@ProductCode ,PName=@PName,OccationRemain=@OccationRemain,PPrice=@PPrice,PSelPrice=@PSelPrice,Vat=@Vat,Discount=@Discount,Quantity=@Quantity,Unit=@Unit,Section=@Section, PProductDetails=@PProductDetails where PID=@PID ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@ProductCode", insert[15]);
            sqlcmd.Parameters.AddWithValue("@PName", insert[1]);
            sqlcmd.Parameters.AddWithValue("@OccationRemain", insert[20]);
            sqlcmd.Parameters.AddWithValue("@PPrice", insert[6]);
            sqlcmd.Parameters.AddWithValue("@PSelPrice", insert[7]);
            sqlcmd.Parameters.AddWithValue("@Vat", insert[16]);
            sqlcmd.Parameters.AddWithValue("@Discount", insert[17]);
            sqlcmd.Parameters.AddWithValue("@Quantity", insert[5]);
            sqlcmd.Parameters.AddWithValue("@PProductDetails", insert[12]);
            sqlcmd.Parameters.AddWithValue("@Unit", insert[8]);
            sqlcmd.Parameters.AddWithValue("@Section", insert[25]);
            sqlcmd.Parameters.AddWithValue("@PID", PID);

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable GetImageformImagetable(string Category)
    {
        con();
        string id = @"Select *  from tblProductImages where PID='" + Category + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetBrandsRowID(string PID, string BrandID)
    {
        con();
        string id = @"Select *  from ProductBrand where PID='" + PID + "' and BrandID='"+ BrandID + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }


    public bool EditCustomer(string[] insert)
    {
        try
        {
            con();
            string Save = "Update CustomerRegistration set Distance=@Distance,Phone=@Phone,Email=@Email,Password=@Password where ID=@ID ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Distance", insert[0]);
            sqlcmd.Parameters.AddWithValue("@Phone", insert[3]);      
            sqlcmd.Parameters.AddWithValue("@Email", insert[1]);
            sqlcmd.Parameters.AddWithValue("@Password", insert[2]);
            sqlcmd.Parameters.AddWithValue("@ID", insert[4]);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable CheckDistance(string email, string password)
    {
        con();
        string id = @"Select *  from CustomerRegistration where Email='" + email + "' and Password='" + password + "'";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetCollectionTimeSlot()
    {
        con();
        string id = @"Select *  from CollectionTime";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getCustomersOrder(string Email)
    {
        con();
        string id = @"select * from TblOrder where Customerid='"+Email+"' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable getAllCustomersOrder()
    {
        con();
        string id = @"select * from TblOrder inner join CustomerRegistration on TblOrder.Customerid=CustomerRegistration.Email ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable LoadOrderByOrderID(string orderNo)
    {
        con();
        string id = @"select * from TblOrder inner join CustomerRegistration on TblOrder.Customerid=CustomerRegistration.Email where orderid='"+orderNo+"' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable checkEmail(string email)
    {
        con();
        string id = @"select * from CustomerRegistration where Email='" + email + "' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetOrderDetails(string orderID)
    {
        con();
        //string id = @"select * from TblOrder where orderid='" + orderID + "' ";
        string id = @"select orderid as OrderID,Pname as Product,Quantity,Price,Vat,Total from TblOrder where orderid='" + orderID + "' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetOrderDetailsByEmail(string email)
    {
        con();
        //string id = @"select * from TblOrder where orderid='" + orderID + "' ";
        string id = @"select * from TblOrder where Email='" + email + "' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public bool UpdateAction(string Action, string orderNo)
    {
        try
        {
            con();
            string Save = "Update TblOrder set Status=@Status where orderid=@orderid ";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Status", Action);
            sqlcmd.Parameters.AddWithValue("@orderid", orderNo);
         
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable Alltotal(string orderNo)
    {
        con();
        //string id = @"select * from TblOrder where orderid='" + orderID + "' ";
        string id = @"  select sum(Total) as Alltotal,FirstName,PostCode from TblOrder inner join CustomerRegistration on CustomerRegistration.Email=TblOrder.Customerid where orderid='" + orderNo + "' group by FirstName ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetProductVattwenty(string orderNo)
    {
        con();
        //string id = @"select * from TblOrder where orderid='" + orderID + "' ";
        string id = @"select Vat as VatRate, SUM(Total) as Net,Vat*SUM(Total)/100 as Vat from TblOrder where Vat=20 and orderid='" + orderNo+"' group by  Vat  ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }
    public DataTable GetProductVatzero(string orderNo)
    {
        con();
        //string id = @"select * from TblOrder where orderid='" + orderID + "' ";
        string id = @"select Vat as VatRate, SUM(Total) as Net,Vat*SUM(Total)/100 as Vat from TblOrder where Vat=0 and orderid='" + orderNo + "' group by  Vat  ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    //   public DataTable GetProductVat(string orderNo)
    //   {
    //       con();
    //       //string id = @"select * from TblOrder where orderid='" + orderID + "' ";
    //       string id = @"select Vat, 
    //  (select SUM(Total) from TblOrder where Vat=20 and orderid='OSN206')as withtwentypercentvat,
    //  (select SUM(Total) from TblOrder where Vat=0 and orderid='OSN206')as withzeropercentvat,
    //  ((select SUM(Total) from TblOrder where Vat=20 and orderid='OSN206')*Vat/100) as productvat
    //from  TblOrder where orderid='"+orderNo+"' group by  Vat";
    //       DataTable dta = new DataTable();
    //       SqlDataAdapter da = new SqlDataAdapter(id, cn);
    //       da.Fill(dta);
    //       return dta;
    //   }


    public DataTable CheckPasswordbymail(string email)
    {
        con();
        //string id = @"select * from TblOrder where orderid='" + orderID + "' ";
        string id = @"select * from CustomerRegistration where Email='"+email+"' ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable CheckHeaderBanner()
    {
        con();
        //string id = @"select * from TblOrder where orderid='" + orderID + "' ";
        string id = @"select Allow from HeaderBannerCheck ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public bool insertBannerShowhide(string selectedValue)
    {
        try
        {
            con();
            string Save = "UPDATE HeaderBannerCheck set Allow=@Allow where ID=@ID";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Allow", selectedValue);
            sqlcmd.Parameters.AddWithValue("@ID",'1');

            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool InsertSubcriptionEmail(string email,string Date)
    {
        try
        {
            con();
            string Save = "Insert into EmailSubcription (Email,SubmissionDate)values(@Email,@SubmissionDate)";
            sqlcmd = new SqlCommand(Save, cn);
            sqlcmd.Parameters.AddWithValue("@Email", email);
            sqlcmd.Parameters.AddWithValue("@SubmissionDate", Date);
            sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable LoadSubcriptionEmail()
    {

        con();
        //string id = @"select * from TblOrder where orderid='" + orderID + "' ";
        string id = @"select * from EmailSubcription ";
        DataTable dta = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(id, cn);
        da.Fill(dta);
        return dta;
    }

    public DataTable GetAllBooksByCategory(string cat)
    {
        con();
        string sql = "Select * from Books join tblCategories on Books.CategoryId=tblCategories.Id Where CategoryId='"+cat+"'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetAllBooksByWriter(string wat)
    {
        con();
        string sql = "Select * from Books join tblBookAuthors on Books.Id=tblBookAuthors.BookId Where AuthorId='" + wat + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetAllBooksBySubCat(string sCat)
    {
        con();
        string sql = "Select * from Books join tblBookCategories on Books.Id=tblBookCategories.BookId Where tblBookCategories.CategoryId='" + sCat + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetAllBooksMostSale()
    {
        con();
        string sql = "Select * from Books Where MostSale='yes' ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetAllBooksNew()
    {
        con();
        string sql = "Select * from Books Where New='yes' ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetAllBooksUpcoming()
    {
        con();
        string sql = "Select * from Books Where Upcoming='yes' ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetAllBooksPopular()
    {
        con();
        string sql = "Select * from Books Where Popular='yes' ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetAllBooksLowToHigh(string id)
    {
        con();
        string sql = "Select Books.* from tblPublication join Books on Books.Publisher=tblPublication.Name Where tblPublication.Id='" + id + "' and Books.Status='Active' order by Books.price Asc ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetAllBooksHighToLow(string id)
    {
        con();
        string sql = "Select Books.* from tblPublication join Books on Books.Publisher=tblPublication.Name Where tblPublication.Id='" + id + "' and Books.Status='Active' order by Books.price desc ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetAllBooksLowToHighByWriter(string id)
    {
        con();
        string sql = @"Select * from Books join tblBookAuthors On Books.Id=tblBookAuthors.BookId join Writer On Writer.Id=tblBookAuthors.AuthorId where Writer.Code='" + id + "' and Writer.Status='Active' order by Books.price Asc ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetAllBooksHighToLowByWriter(string id)
    {
        con();
        string sql = @"Select * from Books join tblBookAuthors On Books.Id=tblBookAuthors.BookId join Writer On Writer.Id=tblBookAuthors.AuthorId where Writer.Code='" + id + "' and Writer.Status='Active' order by Books.price Desc ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable GetAllPolicy()
    {
        con();
        string sql = "SELECT * FROM [tblPolicy] ORDER BY [DeliveryCharge] ASC ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetBooksComments()
    {
        con();
        string sql = "Select Comments.Id, Title, Name, Comments, Comments.Date from Comments join Books ON Comments.PId=Books.Id Where LevelNo='User' order By Comments.Date Desc ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetBlogComments()
    {
        con();
        string sql = "Select * from Comments Where LevelNo='Bolger' order By Comments.Date Desc ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
}