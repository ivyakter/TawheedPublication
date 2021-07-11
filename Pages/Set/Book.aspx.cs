using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Pages_Set_Book : System.Web.UI.Page
{
    private DAL entities = new DAL();

    private DAL bookManager = new DAL();

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
            BindCategories();
            BindAuthors();
            GetAllBookRecord();
            BindPublication();
        }
    }

    private void BindCategories()
    {
        DataTable query = bookManager.GetCategory();
        ddlMain.DataTextField = "Name";
        ddlMain.DataValueField = "Id";
        ddlMain.DataSource = query;
        ddlMain.DataBind();
        //var query = entities.tblCategories.ToList();

        //List<tblCategory> query = new List<tblCategory>();

        //ddlCategory.DataSource = bookManager.GetCategory();
        //DataTable query = bookManager.getCategoryBook();
        
    }

    private void BindPublication()
    {
        DataTable query = bookManager.GetPublication();
        ddlPublication.DataTextField = "Name";
        ddlPublication.DataValueField = "Id";
        ddlPublication.DataSource = query;
        ddlPublication.DataBind();
    }
    protected void gridViewBook_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GetAllBookRecord();
        gridViewBook.PageIndex = e.NewPageIndex;
        gridViewBook.DataBind();
    }

    protected void ddlMain_TextChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(ddlMain.SelectedValue);
        DataTable query = bookManager.getSubCategoryBookByCategoryId(id);
        ddlCategory.DataTextField = "Name";
        ddlCategory.DataValueField = "Id";
        ddlCategory.DataSource = query;
        ddlCategory.DataBind();
    }
    private void BindAuthors()
    {
        //var query = entities.tblAuthors.ToList();
        var query = bookManager.GetAuthor();

        //List<tblAuthor> query = new List<tblAuthor>();
        //ddlAuthor.DataSource = bookManager.GetAuthor();
        ddlAuthor.DataTextField = "Name";
        ddlAuthor.DataValueField = "Id";
        ddlAuthor.DataSource = query;
        ddlAuthor.DataBind();
    }

    protected void btnAddBook_Click(object sender, EventArgs e)
    {
        panelBookTable.Visible = false;
        panelAddBook.Visible = true;
        btnSubmit.Visible = true;
        btnUpdate.Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    private void AddBook()
    {
        //if (ddlMain.SelectedValue == "0")
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "ale", "alert('Select Category');", true);

        //    ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Select Category');", true);
        //    return;
        //}

        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
        string date = now.ToString("yyyy-MM-dd hh:mm:ss tt");

        string[] insert = new string[25];
        DataTable CategoryID = bookManager.GetBookNo();
        string id = 0 + CategoryID.Rows[0][0].ToString();

        insert[0] = txtBookTitle.Text;
        insert[1] = txtISBN.Text;
        insert[2] = txtNumberOfPages.Text;
        insert[3] = ddlPublication.SelectedItem.Text;
        insert[4] = txtPublishedDate.Text;
        insert[5] = txtEditionNumber.Text;
        insert[6] = txtPrice.Text;
        insert[7] = txtSpecialPrice.Text;
        if (txtSpecialPrice.Text == "") insert[7] = "0";
        insert[8] = txtDescription.Text;
        insert[9] = ddlMostSale.SelectedItem.Text; //MostSale
        insert[10] = ddlNew.SelectedItem.Text; //New
        insert[11] = ddlUpcoming.SelectedItem.Text; //Upcoming
        insert[12] = ""; 
        insert[13] = ""; 
        insert[20] = ddlPopular.SelectedItem.Text;
        insert[21] = ddlMain.SelectedValue;
        insert[22] = txtOldPrice.Text;
        if (fileFrontImage.HasFile)
        {
            string SavePath = Server.MapPath("~/BookImage/") + id;
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extention = Path.GetExtension(fileFrontImage.PostedFile.FileName);
            fileFrontImage.SaveAs(SavePath + "\\" + id + "Font" + Extention);
            insert[12] = Extention;
        }
        if (fileBackImage.HasFile)
        {
            string SavePath = Server.MapPath("~/BookImage/") + id;
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extention = Path.GetExtension(fileBackImage.PostedFile.FileName);
            fileBackImage.SaveAs(SavePath + "\\" + id + "Back" + Extention);
            insert[13] = Extention;
        }
        if (filePdf.HasFile)
        {
            string Extention = Path.GetExtension(filePdf.PostedFile.FileName);
            if (Extention == ".pdf")
            {
                string SavePath = Server.MapPath("~/BookImage/") + id;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                filePdf.SaveAs(SavePath + "\\" + id + Extention);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error",
                    "alert('File must be in pdf formate. please try again');", true);
                return;
            }
        }
        insert[14] = "Active"; //Status
        insert[15] = "Admin"; //CreatedBy
        insert[16] = date; //CreatedDateTime
        insert[17] = "Admin"; //LastUpdatedBy
        insert[18] = date; //LastUpdatedDateTime
        insert[19] = id; //code

        bool Save = bookManager.InsertBook(insert);
        //entities.tblBooks.Add(book);
        //entities.SaveChanges();

        string[] categoryArray = new string[ddlCategory.Items.Count];

        int index1 = 0;

        foreach (ListItem listCategory in ddlCategory.Items)
        {
            if (listCategory.Selected)
            {
                DataTable dt = bookManager.GetBookNo1();
                string bookId = 0 + dt.Rows[0][0].ToString();
                categoryArray[index1] = listCategory.Value;
                index1 = index1 + 1;
                string CategoryId = listCategory.Value;
                string CategoryName = listCategory.Text;
                int BookId = Convert.ToInt32(bookId);
                bool bookCategory = bookManager.InsertBookCategory(CategoryId, CategoryName, BookId);
                //entities.tblBookCategories.Add(bookCategory);
                //entities.SaveChanges();
            }
        }

        string[] authorArray = new string[ddlAuthor.Items.Count];

        int index2 = 0;

        foreach (ListItem listAuthor in ddlAuthor.Items)
        {
            if (listAuthor.Selected)
            {
                DataTable dt = bookManager.GetBookNo1();
                string bookId = 0 + dt.Rows[0][0].ToString();
                authorArray[index2] = listAuthor.Value;
                index2 = index2 + 1;
                string AuthorId = listAuthor.Value;
                string AuthorName = listAuthor.Text;
                int BookId = Convert.ToInt32(bookId);

                bool bookCategory = bookManager.InsertBookWriter(AuthorId, AuthorName, BookId);
                //entities.tblBookAuthors.Add(bookAuthor);
                //entities.SaveChanges();
            }
        }

        //bookViewCount.BookId = book.Id;
        //bookViewCount.ViewCount = 0;

        //entities.tblBookViewCounts.Add(bookViewCount);
        //entities.SaveChanges();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        AddBook();
        Response.Redirect(Request.RawUrl);
    }

    private void GetAllBookRecord()
    {
        DataTable dt = bookManager.GetallBooks();
        //gridViewBook.DataSourceID = "SqlDataSource1";
        gridViewBook.DataSource = dt;
        gridViewBook.DataBind();
    }

    private void GetBookById(int bookId)
    {
        var result = bookManager.GetBookById(bookId);
        if (result.Rows.Count > 0)
        {
            //var book = result.First();
            string code = result.Rows[0]["Code"].ToString();
            txtBookTitle.Text = result.Rows[0]["Title"].ToString();
            txtISBN.Text = result.Rows[0]["ISBN"].ToString();
            txtNumberOfPages.Text = result.Rows[0]["NumberOfPages"].ToString();
            ddlPublication.SelectedItem.Text = result.Rows[0]["Publisher"].ToString();
            txtPublishedDate.Text = result.Rows[0]["PublishedDate"].ToString();
            txtEditionNumber.Text = result.Rows[0]["EditionNumber"].ToString();
            txtPrice.Text = result.Rows[0]["Price"].ToString();
            txtOldPrice.Text= result.Rows[0]["OldPrice"].ToString();
            txtSpecialPrice.Text = result.Rows[0]["SpecialPrice"].ToString();
            txtDescription.Text = result.Rows[0]["Description"].ToString();
            ddlMain.SelectedItem.Text = result.Rows[0]["Category"].ToString();
            ddlMain.SelectedValue= result.Rows[0]["CId"].ToString();
            ddlMain_TextChanged(null, null);
            string FontImage = result.Rows[0]["FontImage"].ToString();


            //string[] filePathFrontImage = Directory.GetFiles(Server.MapPath("~/BookImage/"+code+"/"));
            //List<ListItem> frontImagefiles = new List<ListItem>();
            //foreach (string filePath in filePathFrontImage)
            //{
            //    string fileName = code + "Font" + FontImage; 
            //    frontImagefiles.Add(new ListItem(fileName, "~/BookImage/" + code+ "/"+ fileName));
            //}
            gridViewGetFrontImage.DataSource = result;
            gridViewGetFrontImage.DataBind();

            //string[] filePathBackImage = Directory.GetFiles(Server.MapPath("~/Content/BookBackImage/"));
            //List<ListItem> backImagefiles = new List<ListItem>();
            //foreach (string filePath in filePathBackImage)
            //{
            //    string fileName = code+ "Back" + FontImage;
            //    backImagefiles.Add(new ListItem(fileName, "~/BookImage/" + code + "/" + fileName));
            //}
            gridViewGetBackImage.DataSource = result;
            gridViewGetBackImage.DataBind();

            ddlMostSale.SelectedItem.Text = result.Rows[0]["MostSale"].ToString();
            ddlNew.SelectedItem.Text = result.Rows[0]["New"].ToString();
            ddlUpcoming.SelectedItem.Text = result.Rows[0]["Upcoming"].ToString();
        }
    }

    protected void gridViewGetPdf_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DownloadPdf")
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Content/BookPdf/") + e.CommandArgument);
            Response.End();
        }
    }

    private void GetBookCategoryById(int bookId)
    {
        var result = bookManager.GetBookCategoryById(bookId);
        if (result.Rows.Count > 0)
        {
            for (int i = 0; i < result.Rows.Count; i++)
            {
                ddlCategory.Value += result.Rows[i]["CategoryId"].ToString();
            }
        }
    }

    private void GetBookAuthorById(int bookId)
    {
        var result = bookManager.GetBookAuthorById(bookId);
        if (result.Rows.Count > 0)
        {
            for (int i = 0; i < result.Rows.Count; i++)
            {
                ddlAuthor.Value += result.Rows[i]["AuthorId"].ToString();
                //ddlAuthor.SelectedValue = bookAuthor.AuthorId.ToString();
                //ddlAuthor.DataBind();
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int bookId = Convert.ToInt32(lblhiddenFieldForId.Text);
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
        string date = now.ToString("yyyy-MM-dd hh:mm:ss tt");

        string[] insert = new string[25];
        var result = bookManager.GetBookById(bookId);
        string id = result.Rows[0]["Code"].ToString();
        insert[0] = txtBookTitle.Text;
        insert[1] = txtISBN.Text;
        insert[2] = txtNumberOfPages.Text;
        insert[3] = ddlPublication.SelectedItem.Text;
        insert[4] = txtPublishedDate.Text;
        insert[5] = txtEditionNumber.Text;
        insert[6] = txtPrice.Text;
        insert[7] = txtSpecialPrice.Text;
        insert[8] = txtDescription.Text;
        insert[9] = ddlMostSale.SelectedItem.Text; //MostSale
        insert[10] = ddlNew.SelectedItem.Text; //New
        insert[11] = ddlUpcoming.SelectedItem.Text; //Upcoming
        insert[12]= result.Rows[0]["FontImage"].ToString();
        insert[13]= result.Rows[0]["BackImage"].ToString();
        insert[21] = ddlMain.SelectedValue;
        insert[22] = txtOldPrice.Text;
        if (fileFrontImage.HasFile)
        {
            string SavePath = Server.MapPath("~/BookImage/") + id;
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extention = Path.GetExtension(fileFrontImage.PostedFile.FileName);
            fileFrontImage.SaveAs(SavePath + "\\" + id + "Font" + Extention);
            insert[12] = Extention;
        }
        if (fileBackImage.HasFile)
        {
            string SavePath = Server.MapPath("~/BookImage/") + id;
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extention = Path.GetExtension(fileBackImage.PostedFile.FileName);
            fileBackImage.SaveAs(SavePath + "\\" + id + "Back" + Extention);
            insert[13] = Extention;
        }
        if (filePdf.HasFile)
        {
            string Extention = Path.GetExtension(filePdf.PostedFile.FileName);
            if (Extention == ".pdf")
            {
                string SavePath = Server.MapPath("~/BookImage/") + id;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                filePdf.SaveAs(SavePath + "\\" +  id + Extention);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error",
                    "alert('File must be in pdf formate. please try again');", true);
                return;
            }
        }
        //insert[14] = "Active"; //Status
        //insert[15] = "Admin"; //CreatedBy
        //insert[16] = date; //CreatedDateTime
        insert[17] = "Admin"; //LastUpdatedBy
        insert[18] = date; //LastUpdatedDateTime
        //insert[19] = id; //code

        bool Save = bookManager.UpdateBook(insert, bookId);

        //tblBookCategory bookCategory = new tblBookCategory();
        //tblBookAuthor bookAuthor = new tblBookAuthor();

        //int bookId = Convert.ToInt32(lblhiddenFieldForId.Text);

        //var books = entities.tblBooks.Where(d => d.Id == bookId).FirstOrDefault();

        //books.Title = txtBookTitle.Text;
        //books.ISBN = txtISBN.Text;
        //books.NumberOfPages = Convert.ToInt32(txtNumberOfPages.Text);
        //books.Publisher = txtPublisher.Text;
        //books.PublishedDate = DateTime.ParseExact(txtPublishedDate.Text, "MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture);
        //books.EditionNumber = Convert.ToInt32(txtEditionNumber.Text);
        //books.Price = Convert.ToDecimal(txtPrice.Text);
        //books.SpecialPrice = Convert.ToDecimal(txtSpecialPrice.Text);
        //books.Description = txtDescription.Text;
        //if (fileFrontImage.HasFile)
        //{
        //    string fileNameFrontImage = fileFrontImage.FileName.Replace(",", "");
        //    books.FrontImage = txtBookTitle.Text + "_" + fileNameFrontImage;
        //    fileFrontImage.SaveAs(Server.MapPath("../../Content/BookFrontImage/" + books.FrontImage));
        //}
        //if (fileBackImage.HasFile)
        //{
        //    string fileNameBackImage = fileBackImage.FileName.Replace(",", "");
        //    books.BackImage = txtBookTitle.Text + "_" + fileNameBackImage;
        //    fileBackImage.SaveAs(Server.MapPath("../../Content/BookBackImage/" + books.BackImage));
        //}
        //if (filePdf.HasFile)
        //{
        //    string fileNamePdf = filePdf.FileName.Replace(",", "");
        //    books.Pdf = txtBookTitle.Text + "_" + fileNamePdf;
        //    filePdf.SaveAs(Server.MapPath("../../Content/BookPdf/" + books.Pdf));
        //}
        //books.MostSale = ddlMostSale.SelectedItem.Text;
        //books.New = ddlNew.SelectedItem.Text;
        //books.Upcoming = ddlUpcoming.SelectedItem.Text;
        //books.LastUpdatedBy = "Admin";
        //books.LastUpdatedDateTime = Convert.ToDateTime(date);

        //foreach (var bookCategories in entities.tblBookCategories.Where(x => x.BookId == books.Id).ToList())
        //{
        //    entities.tblBookCategories.Remove(bookCategories);
        //    entities.SaveChanges();
        //}

        
        DataTable dtM = bookManager.GetBookById(bookId);
        if (dtM.Rows.Count > 0)
        {
            bool delete1 = bookManager.DeleteBookCategory(bookId);
            bool delete2 = bookManager.DeleteBookAuther(bookId);

            string[] categoryArray = new string[ddlCategory.Items.Count];

            int index1 = 0;

            foreach (ListItem listCategory in ddlCategory.Items)
            {
                if (listCategory.Selected)
                {
                    categoryArray[index1] = listCategory.Value;
                    index1 = index1 + 1;
                    string CategoryId = listCategory.Value;
                    string CategoryName = listCategory.Text;
                    bool bookCategory = bookManager.InsertBookCategory(CategoryId, CategoryName, bookId);
                    //entities.tblBookCategories.Add(bookCategory);
                    //entities.SaveChanges();
                }
            }

            string[] authorArray = new string[ddlAuthor.Items.Count];

            int index2 = 0;

            foreach (ListItem listAuthor in ddlAuthor.Items)
            {
                if (listAuthor.Selected)
                {
                    authorArray[index2] = listAuthor.Value;
                    index2 = index2 + 1;
                    string AuthorId = listAuthor.Value;
                    string AuthorName = listAuthor.Text;
                    bool bookCategory = bookManager.InsertBookWriter(AuthorId, AuthorName, bookId);
                    //entities.tblBookAuthors.Add(bookAuthor);
                    //entities.SaveChanges();
                }
            }
        }
        GetAllBookRecord();
        Response.Redirect(Request.RawUrl);
    }

    private void GetBookByIdForDetailView(int bookId)
    {
        var result = bookManager.GetBookById(bookId);
        if (result.Rows.Count > 0)
        {
            //var book = result.First();
            string FontImage = result.Rows[0]["FontImage"].ToString();
            string code = result.Rows[0]["Code"].ToString();
            lblBookIdView.Text = result.Rows[0]["Id"].ToString();
            lblISBNView.Text = result.Rows[0]["ISBN"].ToString();
            lblNumberOfPagesView.Text = result.Rows[0]["NumberOfPages"].ToString();
            lblPublishedDateView.Text = result.Rows[0]["PublishedDate"].ToString();
            lblEditionNumberView.Text = result.Rows[0]["EditionNumber"].ToString();
            lblPriceView.Text = result.Rows[0]["Price"].ToString();
            lblSpecialPriceView.Text = result.Rows[0]["SpecialPrice"].ToString();
            lblDescriptionView.Text = result.Rows[0]["Description"].ToString();
            lblStatusView.Text = result.Rows[0]["Status"].ToString();
            lblMostSaleView.Text = result.Rows[0]["MostSale"].ToString();
            lblBookTitleView.Text = result.Rows[0]["Title"].ToString();
            lblDescriptionView.Text = result.Rows[0]["Description"].ToString();
            lblBookCategory.Text= result.Rows[0]["Category"].ToString();
            lblOldprice.Text= result.Rows[0]["OldPrice"].ToString();
            //string[] filePathFrontImage = Directory.GetFiles(Server.MapPath("~/BookImage/" + code + "/"));
            //List<ListItem> frontImagefiles = new List<ListItem>();
            //foreach (string filePath in filePathFrontImage)
            //{
            //    string fileName = Path.GetFileName(filePath);
            //    frontImagefiles.Add(new ListItem(fileName, "~/BookImage/" + code + "/" + fileName));
            //}
            gridViewGetFrontImage.DataSource = result;
            gridViewGetFrontImage.DataBind();

            //string[] filePathBackImage = Directory.GetFiles(Server.MapPath("~/Content/BookBackImage/"));
            //List<ListItem> backImagefiles = new List<ListItem>();
            //foreach (string filePath in filePathBackImage)
            //{
            //    string fileName = code + "Back" + FontImage;
            //    backImagefiles.Add(new ListItem(fileName, "~/BookImage/" + code + "/" + fileName));
            //}
            gridViewGetBackImage.DataSource = result;
            gridViewGetBackImage.DataBind();

            lblCreatedByView.Text = result.Rows[0]["CreatedBy"].ToString();
            lblCreateDateTimeView.Text = result.Rows[0]["CreatedDateTime"].ToString();
            lblLastUpdatedByView.Text = result.Rows[0]["LastUpdatedBy"].ToString();
            lblLastUpdatedOnView.Text = result.Rows[0]["LastUpdatedDateTime"].ToString();
        }
    }

    private void GetBookCategoryByIdForDetailView(int bookId)
    {
        var result = bookManager.GetBookCategoryById(bookId);
        if (result.Rows.Count > 0)
        {
            for (int i = 0; i < result.Rows.Count; i++)
            {
                lblBookCategoriesView.Text += result.Rows[i]["CategoryName"].ToString() + "<br />";
            }
        }
    }

    private void GetBookAuthorByIdForDetailView(int bookId)
    {
        var result = bookManager.GetBookAuthorById(bookId);
        if (result.Rows.Count > 0)
        {
            for (int i = 0; i < result.Rows.Count; i++)
            {
                lblBookAuthorsView.Text += result.Rows[i]["AuthorName"].ToString() + "<br />";
            }
        }
    }

    private void GetBookViewCountByIdForDetailView(int bookId)
    {
        //var result = bookManager.GetBookViewCountById(bookId);
        //if (result.Count() > 0)
        //{
        //    var bookViewCount = result.First();
        //    lblBookViewCount.Text = bookViewCount.ViewCount.ToString();
        //}
    }

    protected void gridViewPdfDownload_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DownloadPdf")
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Content/BookPdf/") + e.CommandArgument);
            Response.End();
        }
    }

    protected void gridViewBook_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditBook" && e.CommandName != "RemoveBook"
            && e.CommandName != "DetailBook" && e.CommandName != "ActivateDeactivate")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewBook.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int bookId = Convert.ToInt32(lblhiddenFieldForId.Text);

            GetBookById(bookId);

            GetBookCategoryById(bookId);
            GetBookAuthorById(bookId);

            panelBookTable.Visible = false;
            panelAddBook.Visible = true;
            btnSubmit.Visible = false;
            btnUpdate.Visible = true;
            panelFrontImageEditView.Visible = true;
            panelBackImageEditView.Visible = true;
            gridViewGetPdf.Visible = true;
        }
        else if (e.CommandName == "DetailBook" && e.CommandName != "RemoveBook"
            && e.CommandName != "EditBook" && e.CommandName != "ActivateDeactivate")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewBook.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int bookId = Convert.ToInt32(lblhiddenFieldForId.Text);

            GetBookByIdForDetailView(bookId);
            GetBookCategoryByIdForDetailView(bookId);
            GetBookAuthorByIdForDetailView(bookId);
            GetBookViewCountByIdForDetailView(bookId);

            panelDetail.Visible = true;
            panelBookTable.Visible = false;
            panelAddBook.Visible = false;
            btnSubmit.Visible = false;
            btnUpdate.Visible = false;
        }
        else if (e.CommandName == "RemoveBook" && e.CommandName != "EditBook"
            && e.CommandName != "DetailBook" && e.CommandName != "ActivateDeactivate")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewBook.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int bookId = Convert.ToInt32(lblhiddenFieldForId.Text);
            DataTable dt = bookManager.GetBookById(bookId);
            if (dt.Rows.Count != 0)
            {
                string id = dt.Rows[0]["Code"].ToString();
                string path = Server.MapPath("~/BookImage/") + id;
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }                
                bool delete = bookManager.DeleteBookById(bookId);
                bool delete1 = bookManager.DeleteBookCategory(bookId);
                bool delete2 = bookManager.DeleteBookAuther(bookId);

                
                
                //foreach (var bookCategories in entities.tblBookCategories.Where(x => x.BookId == bookId).ToList())
                //{
                //    entities.tblBookCategories.Remove(bookCategories);
                //    entities.SaveChanges();
                //}
                //foreach (var bookAuthors in entities.tblBookAuthors.Where(x => x.BookId == bookId).ToList())
                //{
                //    entities.tblBookAuthors.Remove(bookAuthors);
                //    entities.SaveChanges();
                //}
                //foreach (var bookViewCount in entities.tblBookViewCounts.Where(x => x.BookId == bookId).ToList())
                //{
                //    entities.tblBookViewCounts.Remove(bookViewCount);
                //    entities.SaveChanges();
                //}
            }
            GetAllBookRecord();
        }
        else if (e.CommandName == "ActivateDeactivate" && e.CommandName != "RemoveBook"
            && e.CommandName != "EditBook" && e.CommandName != "DetailBook")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblId = (Label)gridViewBook.Rows[index].FindControl("lblId");
            lblhiddenFieldForId.Text = lblId.Text;
            int bookId = Convert.ToInt32(lblhiddenFieldForId.Text);

            DataTable dt = bookManager.GetBookById(bookId);
            if (dt.Rows.Count != 0)
            {
                var data = bookManager.GetBookById(bookId);
                var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
                var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
                string date = now.ToString("yyyy-MM-dd hh:mm:ss tt");

                if (data.Rows[0]["Status"].ToString() == "Active")
                {
                    string Status = "Inactive";
                    string LastUpdatedBy = "Admin";
                    string LastUpdatedDateTime = date;
                    bool update = bookManager.UpdateBookStatus(Status, LastUpdatedBy, LastUpdatedDateTime, bookId);
                    GetAllBookRecord();
                }
                else if (data.Rows[0]["Status"].ToString() == "Inactive")
                {
                    string Status = "Active";
                    string LastUpdatedBy = "Admin";
                    string LastUpdatedDateTime = date;
                    bool update = bookManager.UpdateBookStatus(Status, LastUpdatedBy, LastUpdatedDateTime, bookId);
                    GetAllBookRecord();
                }
            }
        }
    }

    protected void gridViewBook_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Normal)))
            {
                string statusValue = DataBinder.Eval(e.Row.DataItem, "Status").ToString();

                LinkButton btnStatus = (LinkButton)e.Row.FindControl("btnStatus");

                if (statusValue == "Active")
                {
                    btnStatus.CssClass = "badge badge-success";
                    btnStatus.ForeColor = System.Drawing.Color.White;
                }
                else if (statusValue == "Inactive")
                {
                    btnStatus.CssClass = "badge badge-danger";
                    btnStatus.ForeColor = System.Drawing.Color.White;
                }
            }
        }
    }

    protected void btnGoBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }





    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = bookManager.SearchBooksByName(txtSearch.Text);
        // gridViewBook.DataSourceID = "SqlDataSource1";
        gridViewBook.DataSource = dt;
        gridViewBook.DataBind();
    }
}