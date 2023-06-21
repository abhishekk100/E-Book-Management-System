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
    public partial class UserSignup : System.Web.UI.Page
    {
        //step 1 configuration of connectionString declare inside the Web.config file
        //step 2 create SqlConnection
        string strCon = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        //Signup button click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            //  Response.Write("<script>alert('Testing app'); </script>");// For testing purpose only pop-up

            if (CheckUserExistInDatabase())
            {
                Response.Write("<script>alert('User Already Exist of User ID: "+TextBox8.Text.Trim()+"'); </script>");

            }
            else
            {

                NewUserSignup();
            }

        }

        private void NewUserSignup()
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO user_master_tbl (full_name,dob,contact_no,email,state,city,pincode,full_address,user_id,password,account_status) values (@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@user_id,@password,@account_status)", con);

                cmd.Parameters.AddWithValue("@full_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@user_id", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Signup Successful'); </script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
        }

        bool CheckUserExistInDatabase()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(strCon);

                if (sqlCon.State == ConnectionState.Closed)
                { sqlCon.Open(); }

                SqlCommand cmd = new SqlCommand("Select * from user_master_tbl where user_id='" + TextBox8.Text.Trim() + "';", sqlCon);
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