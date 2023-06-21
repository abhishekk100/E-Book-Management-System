using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EBookManagementSystem
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
              
               if (Session["role"] != null && Session["role"].ToString().Equals("user"))
                    {
                        LinkButton1.Visible = false;//login link button
                        LinkButton2.Visible = false;//signup link button

                        LinkButton3.Visible = true;// logout link button
                        LinkButton4.Visible = true;//hello user link button

                        LinkButton4.Text = "Hello " + Session["userId"].ToString();


                        LinkButton6.Visible = true;//admin login link button
                        LinkButton7.Visible = false;// Author Management link button
                        LinkButton8.Visible = false;// Publisher Management link button
                        LinkButton9.Visible = false;// book inventory link button
                        LinkButton10.Visible = false;// book issuing link button
                        LinkButton11.Visible = false;// User Management link button   
                    }
                    else if (Session["role"] != null && Session["role"].ToString().Equals("admin"))
                    {
                        LinkButton1.Visible = false;//login link button
                        LinkButton2.Visible = false;//signup link button

                        LinkButton3.Visible = true;// logout link button
                        LinkButton4.Visible = true;//hello user link button

                        LinkButton4.Text = "Hello Admin";// + Session["userId"].ToString();


                        LinkButton6.Visible = false;//admin login link button
                        LinkButton7.Visible = true;// Author Management link button
                        LinkButton8.Visible = true;// Publisher Management link button
                        LinkButton9.Visible = true;// book inventory link button
                        LinkButton10.Visible = true;// book issuing link button
                        LinkButton11.Visible = true;// User Management link button   
                    }
                    else
                    {
                    LinkButton1.Visible = true;//login link button
                    LinkButton2.Visible = true;//signup link button

                    LinkButton3.Visible = false;// logout link button
                    LinkButton4.Visible = false;//hello user link button

                    LinkButton6.Visible = true;//admin login link button
                    LinkButton7.Visible = false;// Author Management link button
                    LinkButton8.Visible = false;// Publisher Management link button
                    LinkButton9.Visible = false;// book inventory link button
                    LinkButton10.Visible = false;// book issuing link button
                    LinkButton11.Visible = false;// User Management link button
                    }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");

            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("AuthorPage.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("PublisherPage.aspx");

        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookInventory.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookIssuingPage.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberManagement.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserSignup.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBooks.aspx");
        }
        //logout link button
        protected void LinkButton3_Click1(object sender, EventArgs e)
        {

            Session["userId"] = "";
            Session["fullName"] = "";
            Session["role"] = "";
            Session["status"] = "";
            LinkButton1.Visible = true;//login link button
            LinkButton2.Visible = true;//signup link button

            LinkButton3.Visible = false;// logout link button
            LinkButton4.Visible = false;//hello user link button

            LinkButton6.Visible = true;//admin login link button
            LinkButton7.Visible = false;// Author Management link button
            LinkButton8.Visible = false;// Publisher Management link button
            LinkButton9.Visible = false;// book inventory link button
            LinkButton10.Visible = false;// book issuing link button
            LinkButton11.Visible = false;// User Management link button

            Response.Redirect("HomePage.aspx");
        }
        //hello user profile page
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }
    }
}