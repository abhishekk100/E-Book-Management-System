using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

namespace EBookManagementSystem
{
    public partial class BookInventory : System.Web.UI.Page
    {
         string StrCon = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    GetAllAuthorPublisher();

                }
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");

            }
        }
        //Go button 
        protected void Button1_Click(object sender, EventArgs e)
        {
            GetBookDetailsById();
        }

        //user defined
        private void GetBookDetailsById()
        {
            try
            {

                SqlConnection conn = new SqlConnection(StrCon);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("Select * from book_master_tbl where book_id = '" + TextBox3.Text.Trim() + "';", conn);

                //disconnected architecture 
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count >= 1)
                {

                    TextBox2.Text = dt.Rows[0]["book_name"].ToString();
                    TextBox1.Text = dt.Rows[0]["publish_date"].ToString();
                    TextBox10.Text = dt.Rows[0]["edition"].ToString();
                    TextBox5.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    TextBox7.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox8.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox4.Text = dt.Rows[0]["book_description"].ToString();

                    TextBox9.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim()));
                    DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();

                    //first clear all selection from genre ListBox
                    ListBox1.ClearSelection();
                    //and then run loop for multiple selection of genres true
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i])
                            {
                                ListBox1.Items[j].Selected = true;
                            }
                          
                        }
                    }

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());

                    global_issued_books = global_actual_stock - global_current_stock;

                    global_filepath = dt.Rows[0]["book_img_link"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID')</script>");

                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }

        //Add Button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (IsBookExist())
            {
                Response.Write("<script>alert('Book Already Exist, Try some other ID')</script>");

            }
            else
            {
                AddBook();
            }
        }
        //Update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            UpdateBookDetailsById();
        }

        private void UpdateBookDetailsById()
        {
         
            if(IsBookExist())
            {
                try
                {
                    int actual_stock = Convert.ToInt32(TextBox7.Text.Trim());
                    int current_stock = Convert.ToInt32(TextBox8.Text.Trim());

                    if (global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_issued_books)
                        {
                            Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books');</script>");
                            return;


                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            TextBox8.Text = "" + current_stock;
                        }
                    }

                    //for selecting multiple genre in single column
                    string genre = "";

                    //GetSelectedIndices() methods takes only the values which been selected from listbox
                    foreach (int i in ListBox1.GetSelectedIndices())
                        genre += ListBox1.Items[i] + ",";

                    //to remove last ","
                    genre = genre.Remove(genre.Length - 1);

                    string filepath = "~/book_inventory/bookimg.png";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {

                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                        filepath = "~/book_inventory/" + filename;
                    }

                    SqlConnection con = new SqlConnection(StrCon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl set book_name=@book_name, genre=@genre, author_name=@author_name, publisher_name=@publisher_name, publish_date=@publish_date, language=@language, edition=@edition, book_cost=@book_cost, no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link where book_id='" + TextBox3.Text.Trim() + "'", con);


                    cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genre);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());//bcoz initially actual st and current st are same
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Book Updated Successfully')</script>");

                }
                catch (Exception ex)
                {

                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID');</script>");

            }




        }

        //Delete button
        protected void Button4_Click(object sender, EventArgs e)
        {
            DeleteBookById();
        }


        //user defined methods
        void DeleteBookById()
        {

            if (string.IsNullOrEmpty(TextBox3.Text.Trim()))
            {
                Response.Write("<script>alert('User ID Can not be Empty'); </script>");

            }
            else if (!IsBookExist())
            {
                Response.Write("<script>alert('Invalid User ID'); </script>");
            }
            else
            {
                try
                {
                    SqlConnection sqlCon = new SqlConnection(StrCon);

                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM book_master_tbl WHERE book_id='" + TextBox3.Text.Trim() + "';", sqlCon);
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    Response.Write("<script>alert('Book Deleted Successfully'); </script>");
                    ClearForm();
                    //it binds new data whenever you add a new data to database
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
            }
        }

        void GetAllAuthorPublisher()
        {
            try
            {

                SqlConnection conn = new SqlConnection(StrCon);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("Select author_name from author_master_tbl;", conn);

                //disconnected architecture 
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // for Author List
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "author_name"; //to Check it should show only one column
                DropDownList3.DataBind();

                //For Publisher List
                cmd = new SqlCommand("Select publisher_name from publisher_master_tbl;", conn);
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);

                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void AddBook()
        {

            try
            {
                //for selecting multiple genre in single column
                string genre = "";

                //GetSelectedIndices() methods takes only the values which been selected from listbox
                foreach (int i in ListBox1.GetSelectedIndices())
                    genre += ListBox1.Items[i] + ",";

                //to remove last ","
                genre = genre.Remove(genre.Length - 1);

                //for saving img link

                string filepath = "~/book_inventory/bookimg.png";

                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);

                    FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                    filepath = "~/book_inventory/" + filename;
             
                SqlConnection conn = new SqlConnection(StrCon);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl (book_id,book_name,genre,author_name,publisher_name,publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) VALUES(@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", conn);

                cmd.Parameters.AddWithValue("@book_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genre);
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox7.Text.Trim());//bcoz initially actual st and current st are same

                cmd.Parameters.AddWithValue("@book_img_link", filepath);

                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('Book Is Successfully Added')</script>");
              //  ClearForm();
                GridView1.DataBind();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }


        }

        private void ClearForm()
        {
            TextBox3.Text = "";
            TextBox2.Text = "";
            TextBox1.Text = "";
            TextBox10.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox4.Text = "";
            TextBox7.Text = "";
            TextBox7.Text = "";
        }

        private bool IsBookExist()
        {
            try
            {
                SqlConnection conn = new SqlConnection(StrCon);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * from book_master_tbl where book_id = '" + TextBox3.Text.Trim() + "'OR book_name = '" + TextBox2.Text.Trim() + "';", conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt.Rows.Count >= 1;

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }

        }

    }
}