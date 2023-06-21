using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace EBookManagementSystem
{
    public partial class PublisherPage : System.Web.UI.Page
    {
        string StrConn = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
           
            //it binds new data whenever you add a new data to database
            GridView1.DataBind();
        }
        //Go Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            getPublisherById();
        }

        private void getPublisherById()
        {
            try
            {

                SqlConnection conn = new SqlConnection(StrConn);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * from publisher_master_tbl where publisher_id = '" + TextBox3.Text.Trim() + "';", conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Publisher ID')</script>");

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
            if (IsPublisherExist())
            {
                Response.Write("<script>alert('Publisher Already Exist of User ID: " + TextBox3.Text.Trim() + "'); </script>");

            }
            else
            {
                AddNewPublisher();

            }
        }
        //Update Button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (IsPublisherExist())
            {
                try
                {
                    SqlConnection sqlCon = new SqlConnection(StrConn);

                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name=@publisher_name WHERE publisher_id= '" + TextBox3.Text.Trim() + "';", sqlCon);

                    cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());

                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    Response.Write("<script>alert('Publisher Updated Successfully'); </script>");
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
                Response.Write("<script>alert('Publisher Does Not Exist'); </script>");

            }

        }

        private void ClearForm()
        {
            TextBox3.Text = "";
            TextBox2.Text = "";
        }

        //Delete Button
        protected void Button4_Click(object sender, EventArgs e)
        {

            if (IsPublisherExist())
            {
                try
                {
                    SqlConnection sqlCon = new SqlConnection(StrConn);

                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM publisher_master_tbl WHERE publisher_id='" + TextBox3.Text.Trim() + "';", sqlCon);
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    Response.Write("<script>alert('Publisher Deleted Successfully'); </script>");
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
                Response.Write("<script>alert('Publisher Does Not Exist'); </script>");

            }
        }
        private void AddNewPublisher()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(StrConn);

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl (publisher_id, publisher_name) VALUES (@publisher_id, @publisher_name)", sqlCon);
                cmd.Parameters.AddWithValue("@publisher_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Write("<script>alert('Publisher Added Successfully'); </script>");
                ClearForm();
                //it binds new data whenever you add a new data to database
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");

            }
        }

        private bool IsPublisherExist()
        {
            try
            {

                SqlConnection conn = new SqlConnection(StrConn);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * from publisher_master_tbl where publisher_id = '" + TextBox3.Text.Trim() + "';", conn);

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