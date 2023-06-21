using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


namespace EBookManagementSystem
{
    public partial class AuthorPage : System.Web.UI.Page
    {

        string StrConn = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            //it binds new data whenever you add a new data to database
            GridView1.DataBind();
        }
        //Add Button
        protected void Button2_Click(object sender, EventArgs e)
        {

            if (IsAuthorExist())
            {
                Response.Write("<script>alert('Author Already Exist of User ID: " + TextBox3.Text.Trim() + "'); </script>");

            }
            else
            {
                AddNewAuthor();

            }
        }
        //Update Button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if(IsAuthorExist())
            {
                try
                {
                    SqlConnection sqlCon = new SqlConnection(StrConn);

                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name=@author_name WHERE author_id= '" + TextBox3.Text.Trim() + "';", sqlCon);

                    cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    Response.Write("<script>alert('Author Updated Successfully'); </script>");      
                    ClearForm();
                    //it binds new data whenever you add a new data to database
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Author Does Not Exist'); </script>");

            }

        }
        //Delete Button
        protected void Button4_Click(object sender, EventArgs e)
        {
         
           if(IsAuthorExist())
            {
                try
                {
                    SqlConnection sqlCon = new SqlConnection(StrConn);

                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM author_master_tbl WHERE author_id='" + TextBox3.Text.Trim() + "';", sqlCon);
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    Response.Write("<script>alert('Author Deleted Successfully'); </script>");
                    ClearForm();
                    //it binds new data whenever you add a new data to database
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
            }
           else
            {
                Response.Write("<script>alert('Author Does Not Exist'); </script>");

            }

        }

        //Go Button

        protected void Button1_Click(object sender, EventArgs e)
        {
            getAuthorById();
        }

        void getAuthorById()
        {
            try
            {

                SqlConnection conn = new SqlConnection(StrConn);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * from author_master_tbl where author_id = '" + TextBox3.Text.Trim() + "';", conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

              if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
              else
                {
                    Response.Write("<script>alert('Invalid Author ID')</script>");

                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
               
            }

        }
    

        private void AddNewAuthor()
        {
            try 
            {
                SqlConnection sqlCon = new SqlConnection(StrConn);

                if(sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl (author_id, author_name) VALUES (@author_id, @author_name)", sqlCon);
                cmd.Parameters.AddWithValue("@author_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Write("<script>alert('Author Added Successfully'); </script>");
                ClearForm();

                //it binds new data whenever you add a new data to database
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
        }

        private bool IsAuthorExist()
        {
            try
            {

                SqlConnection conn = new SqlConnection(StrConn);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * from author_master_tbl where author_id = '"+TextBox3.Text.Trim()+"';", conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable(); 
                adapter.Fill(dt);

                return dt.Rows.Count >= 1;

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
                return false;
            }
          
        }

       
    }
}