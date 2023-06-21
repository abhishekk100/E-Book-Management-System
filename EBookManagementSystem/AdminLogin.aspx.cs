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
    public partial class AdminLogin : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //login button
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(strCon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from admin_login_tbl where username = '" + TextBox1.Text.Trim() + "' and password = '" + TextBox2.Text.Trim() + "';", con);
                //connected way of database coding means database is still open even after the code is being executed
                SqlDataReader dr = cmd.ExecuteReader();

                //login logic is that the if any data return from query then user is present else not
                if (dr.HasRows)
                {
                    
                    while (dr.Read())
                    {
                        //Response.Write("<script>alert('" + dr.GetValue(0).ToString() + " ')</script>");

                        Session["userId"] = dr.GetValue(0).ToString();
                        Session["fullName"] = dr.GetValue(2).ToString();
                        Session["role"] = "admin";

                     //   Session["status"] = dr.GetValue(10).ToString();
                    }
                    Response.Redirect("HomePage.aspx");

                }
                else
                {
                    Response.Write("<script>alert('Invalid Credentials')</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");


            }

        }
    }
}