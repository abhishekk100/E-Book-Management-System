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
    public partial class UserProfile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["userId"].ToString() == "" || Session["userId"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                   Response.Redirect("UserLogin.aspx");
                }
                else
                {
                    getUserBookData();

                    if (!Page.IsPostBack)
                    {
                        getUserPersonalDetails();
                    }

                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
               Response.Redirect("UserLogin.aspx");
            }
        }


        //update button
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (Session["userId"].ToString() == "" || Session["userId"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
          Response.Redirect("UserLogin.aspx");
            }
            else
            {
          updateUserPersonalDetails();

            }
        }

        private void updateUserPersonalDetails()
        {
           
                string password = "";
                if (TextBox10.Text.Trim() == "")
                {
                    password = TextBox9.Text.Trim();
                }
                else
                {
                    password = TextBox10.Text.Trim();
                }
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }


                    SqlCommand cmd = new SqlCommand("update user_master_tbl set full_name=@full_name, dob=@dob, contact_no=@contact_no, email=@email, state=@state, city=@city, pincode=@pincode, full_address=@full_address, password=@password, account_status=@account_status WHERE user_id='" + Session["userId"].ToString().Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@full_name", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@contact_no", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@account_status", "pending");

                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result > 0)
                    {

                        Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                        getUserPersonalDetails();
                        getUserBookData();
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid entry');</script>");
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            

        }

        // user defined function

        private void getUserPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from user_master_tbl where user_id='" + Session["userId"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                TextBox2.Text = dt.Rows[0]["dob"].ToString();
                TextBox1.Text = dt.Rows[0]["contact_no"].ToString();
                TextBox4.Text = dt.Rows[0]["email"].ToString();
               DropDownList1.SelectedValue = dt.Rows[0]["state"].ToString().Trim();
                TextBox7.Text = dt.Rows[0]["pincode"].ToString();
                TextBox6.Text = dt.Rows[0]["city"].ToString();
                TextBox5.Text = dt.Rows[0]["full_address"].ToString();
                TextBox8.Text = dt.Rows[0]["user_id"].ToString();
                TextBox9.Text = dt.Rows[0]["password"].ToString();
                //TextBox10.Text = dt.Rows[0]["password"].ToString();


                if (dt.Rows[0]["account_status"].ToString().Trim().Equals("active"))
                {
                    Label1.Attributes.Add("Style", "background-color: #198754");
                    Label1.Attributes.Add("class", "badge badge-pill");


                }
                else if (dt.Rows[0]["account_status"].ToString().Trim().Equals("pending"))
                {
                    Label1.Attributes.Add("Style", "background-color: #ffc107");
                    Label1.Attributes.Add("class", "badge badge-pill");

                }
                else if (dt.Rows[0]["account_status"].ToString().Trim().Equals("deactive"))
                {
                    Label1.Attributes.Add("Style", "background-color: #dc3545");
                    Label1.Attributes.Add("class", "badge badge-pill");

                }
                else
                {
                    Label1.Attributes.Add("Style", "background-color: #0d6efd");
                    Label1.Attributes.Add("class", "badge badge-pill");

                }
                Label1.Text = dt.Rows[0]["account_status"].ToString().Trim();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
        void getUserBookData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from book_issue_tbl where user_id='" + Session["userId"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        //row event to highlights rows when user crossed  due date 
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