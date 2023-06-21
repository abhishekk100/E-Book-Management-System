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

    public partial class UserLogin : System.Web.UI.Page
    {

    string strCon = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Response.Write("<script>alert('login btn Click ')</script>");

            try { 
            
            SqlConnection con = new SqlConnection(strCon);

                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from user_master_tbl where user_id = '"+TextBox1.Text.Trim()+"' and password = '"+TextBox2.Text.Trim()+"';", con);
                //connected way of database coding means database is still open even after the code is being executed

                //use to execute query and read data 
                SqlDataReader dr = cmd.ExecuteReader();


                //login logic
               //to check that query return ant data
                if (dr.HasRows)                       
                {
                    while (dr.Read())
                    {
      //for testing Response.Write("<script>alert('"+dr.GetValue(8).ToString()+" ')</script>");

 //create session variables, connection is still open so we can get values from table to our session variables

 //Session variables are access throughout the website or project and it dies when website is close 

                        Session["userId"] = dr.GetValue(8).ToString();
                        Session["fullName"] = dr.GetValue(0).ToString();
                        Session["role"] = "user";
                        Session["status"] = dr.GetValue(10).ToString();

                    }
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Credentials')</script>");
                }


            }
            catch(Exception ex) {
               Response.Write("<script>alert('"+ex.Message+"')</script>");
            }

        }
    }
}