<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="EBookManagementSystem.UserLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

        <div class="container">
            <div class="row">
        <div class="col-md-6 mx-auto">
            <%-- card is class used make box container having curve border  --%>
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>

                                <img src="Images/imgs/generaluser.png" style="width: 150px"/>
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                    <h3>User Login</h3>
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                  <hr />
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">

                              <div class="form-group">
                                  <label>User ID</label>
                                  <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="User ID" runat="server"></asp:TextBox>
                              </div>

                                 <div class="form-group">
                                  <label>Password</label>
                                  <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                              </div>

                                 <div class="form-group">
                                     <asp:Button ID="Button1" runat="server" Text="Login" CssClass="btn btn-primary btn-lg" Width="100%" OnClick="Button1_Click"/>
                              </div>

                                    <div class="form-group">
                                        <a href="UserSingup.aspx">
                                        <input id="Button2" type="button" class="btn btn-info btn-lg" value="Signup" style="width:100%"/>
                                        </a>
                              </div>

                            </div>
                        </div>
                </div>
                </div>

            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/HomePage.aspx"><< Back To Home</asp:LinkButton>
            <br /><br />
        </div>
            </div>
        </div>


</asp:Content>
