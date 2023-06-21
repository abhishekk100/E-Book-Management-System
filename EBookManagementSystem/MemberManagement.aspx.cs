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
    public partial class MemberManagement : System.Web.UI.Page
    {
        string StrCon = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            GridView1.DataBind();

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");

            }
        }

        //go button
        protected void LinkButton5_Click(object sender, EventArgs e)
        {

            getUserById();
        }

        //user defined method
        private void getUserById()
        {
            try
            {

                SqlConnection conn = new SqlConnection(StrCon);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM user_master_tbl WHERE user_id = '"+TextBox3.Text.Trim()+"'", conn);

                SqlDataReader rdr = cmd.ExecuteReader();

                if(rdr.HasRows)
                {
                    while(rdr.Read())
                    {

                        TextBox2.Text = rdr.GetValue(0).ToString();//Name
                        TextBox8.Text = rdr.GetValue(10).ToString();//Account Status
                        TextBox1.Text = rdr.GetValue(1).ToString();//DOB
                        TextBox4.Text = rdr.GetValue(2).ToString();//contact
                        TextBox7.Text = rdr.GetValue(3).ToString();//Email
                        TextBox5.Text = rdr.GetValue(4).ToString();//State
                        TextBox6.Text = rdr.GetValue(5).ToString();//City
                        TextBox9.Text = rdr.GetValue(6).ToString();//pincode
                        TextBox10.Text = rdr.GetValue(7).ToString();//full address
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid ID')</script>");
                }

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        //de-active button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            UpdateUserStatusById("deactive");
        }
        //active button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            UpdateUserStatusById("active");
        }
        //pending
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            UpdateUserStatusById("pending");
        }

        void UpdateUserStatusById(string status)
        {

            try
            {
                SqlConnection con = new SqlConnection(StrCon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open(); 
                }
                SqlCommand cmd = new SqlCommand("UPDATE user_master_tbl SET account_status= '"+status+ "' WHERE user_id = '"+TextBox3.Text.Trim()+"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Account Status Updated Successfully')</script>");
                GridView1.DataBind();

            }
            catch (Exception ex) {

                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }
        }
        //Delete button
        protected void Button2_Click(object sender, EventArgs e)
        {
            DeleteUserById();
        }

        private void DeleteUserById()
        {
            if(string.IsNullOrEmpty(TextBox3.Text.Trim()))
            {
                Response.Write("<script>alert('User ID Can not be Empty'); </script>");

            }
            else if (!CheckUserExistInDatabase())
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

                    SqlCommand cmd = new SqlCommand("DELETE FROM user_master_tbl WHERE user_id='" + TextBox3.Text.Trim() + "';", sqlCon);
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    Response.Write("<script>alert('User Deleted Successfully'); </script>");
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

        private void ClearForm()
        {
            TextBox2.Text = "";//Name
            TextBox8.Text = "";//Account Status
            TextBox1.Text = "";//DOB
            TextBox4.Text = "";//contact
            TextBox7.Text = "";//Email
            TextBox5.Text = "";//State
            TextBox6.Text = "";//City
            TextBox9.Text = "";//pincode
            TextBox10.Text = "";
        }
        bool CheckUserExistInDatabase()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(StrCon);

                if (sqlCon.State == ConnectionState.Closed)
                { sqlCon.Open(); }

                SqlCommand cmd = new SqlCommand("Select * from user_master_tbl where user_id='" + TextBox3.Text.Trim() + "';", sqlCon);
                //below way is disconnected way of database code means after the code is executed the database automatically close.
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();// temporary database table
                da.Fill(dt);

                return dt.Rows.Count >= 1;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
                return false;

            }
        }
    }
}