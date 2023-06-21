using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EBookManagementSystem
{
    public partial class BookIssuingPage : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Go Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            GetBookAndUserName();
        }
        //Issue button
        protected void Button2_Click(object sender, EventArgs e)
        {
       
                if (CheckBookExist() && CheckUserExist())
                {
                    if(CheckUserHasBook())
                    {
                        Response.Write("<script>alert('User Already Issued Book'); </script>");
                    return;
                    }
                    else
                    {

                        IssueBookToUser();
                    }
                }
                else
                {
                    Response.Write("<script>alert('Book ID OR User ID is Wrong'); </script>");

                }

           
        }
        //Return button 
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (CheckBookExist() && CheckUserExist())
            {
                if (CheckUserHasBook())
                {
                    UserReturnsBook();
                }
                else
                {

                    Response.Write("<script>alert('Entry does not Exist'); </script>");
                    return;

                }
            }
            else
            {
                Response.Write("<script>alert('Book ID OR User ID is Wrong'); </script>");

            }
          
        }

         void UserReturnsBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("Delete from book_issue_tbl WHERE book_id='" + TextBox3.Text.Trim() + "' AND user_id='" + TextBox2.Text.Trim() + "'", con);
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {

                    cmd = new SqlCommand("update book_master_tbl set current_stock = current_stock+1 WHERE book_id='" + TextBox3.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                 
                    Response.Write("<script>alert('Book Returned Successfully');</script>");
                    GridView1.DataBind();

                    con.Close();

                }
                else
                {
                    Response.Write("<script>alert('Error - Invalid details');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        //user defined
        void GetBookAndUserName()
        {
            try
            {//create connection 
                SqlConnection con = new SqlConnection(strCon);

                if(con.State == ConnectionState.Closed)
                    con.Open();
                //create sql command for book

                SqlCommand cmd = new SqlCommand("SELECT book_name FROM book_master_tbl WHERE book_id='"+TextBox3.Text.Trim()+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);    
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count > 0 )
                {
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Book ID is Wrong'); </script>");

                }
                //create sql command for user
                    cmd = new SqlCommand("SELECT full_name FROM user_master_tbl WHERE user_id = '"+TextBox2.Text.Trim()+"'",con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    TextBox1.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('User ID is Wrong'); </script>");

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void IssueBookToUser()
        {
            try
            {//create connection 
                SqlConnection con = new SqlConnection(strCon);

                if (con.State == ConnectionState.Closed)
                    con.Open();
                //create sql command for book

                SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl (user_id,user_name,book_id,book_name,issue_date,due_date) VALUES (@user_id,@user_name,@book_id,@book_name,@issue_date,@due_date)", con);

                cmd.Parameters.AddWithValue("@user_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@user_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());
         
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock = current_stock - 1 WHERE book_id = '"+TextBox3.Text.Trim()+"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind(); 

                    Response.Write("<script>alert('Book Issued Successfully'); </script>");

              
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

      bool  CheckUserHasBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);

                if (con.State == ConnectionState.Closed)
                    con.Open();
                //create sql command for book

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tbl WHERE book_id = '"+TextBox3.Text.Trim()+"' And user_id='"+TextBox2.Text.Trim()+"';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count >= 1;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }

        }
        bool CheckBookExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);

                if (con.State == ConnectionState.Closed)
                    con.Open();
                //create sql command for book

      SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id = '" + TextBox3.Text.Trim() + "' AND current_stock > 0;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt); 
                return dt.Rows.Count >= 1;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }
        }
        bool CheckUserExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);

                if (con.State == ConnectionState.Closed)
                    con.Open();
                //create sql command for book

                SqlCommand cmd = new SqlCommand("SELECT * FROM user_master_tbl WHERE user_id = '"+TextBox2.Text.Trim()+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count >= 1;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Check your condition here with taking value from due_date column
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        //if condition is true row becomes red
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}